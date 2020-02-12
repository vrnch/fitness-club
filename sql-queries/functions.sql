create or replace function create_employee
(
	_passport_number_and_series varchar,
	_first_name varchar,
	_last_name varchar, 
	_patronymic varchar,
	_phone_number varchar,
	_email varchar,
	_position_name varchar,
	_date_of_issue date,
	_expiration_date date
)
returns void 
as $$
declare 
	new_employee_id int;
begin 
	insert into "employee" ("passport_number_and_series", "first_name", "last_name", "patronymic", "phone_number", "email")
	values (_passport_number_and_series, _first_name, _last_name, _patronymic, _phone_number, _email);

	new_employee_id = (select max("employee_id") from "employee");

	insert into "contract" ("employee_id", "position_id", "date_of_issue", "expiration_date")
	values (new_employee_id, 
		(select "position_id" from "position" where "position_name" = _position_name), 
		_date_of_issue, _expiration_date);
end $$ 
	language plpgSQL;

create or replace function create_service
(
	_employee_id int,
	_service_name varchar
)
returns void 
as $$
begin
	insert into "service"("employee_id", "service_name") values(_employee_id, _service_name);
end $$ 
	language plpgSQL;

create or replace function fire_employee
(
    _employee_id int
)
returns void
as $$
begin
    update "contract" 
    set "expiration_date" = current_date
    where "employee_id" = _employee_id;
end $$ 
	language plpgSQL;	

create or replace function create_client
(
	_first_name varchar,
	_last_name varchar,
	_patronymic varchar,
	_phone_number varchar,
	_email varchar
)
returns void
as $$
begin
	insert into "client" ("first_name", "last_name", "patronymic", "phone_number", "email")
	values (_first_name, _last_name, _patronymic, _phone_number, _email);
end $$ 
	language plpgSQL;

create or replace function renew_subscription
(
	_subscription_id int,
	_expiration_date date
)
returns void
as $$
begin 
	update "subscription"
	set "expiration_date" = _expiration_date
	where "subscription_id" = _subscription_id;
end $$ 
	language plpgSQL;	

create or replace function create_schedule
(
	_service_id int,
    _client_id int,
    _room_type varchar,
    _day varchar,
    _start_time time,
    _end_time time
)
returns void
as $$
begin 	
		insert into "schedule" ("service_id", "client_id", "room_id", "day", "start_time", "end_time")
		values (_service_id, _client_id, (select "room_id" from "room" where "type" = _room_type), _day, _start_time, _end_time);	
end $$ 
	language plpgSQL;

create or replace function subscribe_client
(
	_client_id int,
	_subscription_type varchar,
	_date_of_issue date,
	_expiration_date date
)
returns void
as $$
begin 
	insert into "subscription"("client_id","subscription_type_id","date_of_issue","expiration_date")
	values(_client_id, (select "subscription_type_id" 
						from "subscription_type" 
						where "type"=_subscription_type),_date_of_issue,_expiration_date);
end $$ 
	language plpgSQL;

create or replace function delete_schedule
(
	_schedule_id int
)
returns void
as $$
begin 
	delete from "schedule" 
	where "schedule_id" = _schedule_id;
end $$ 
	language plpgSQL;

create or replace view "client_info"
as
	select
		 c.client_id,
		 concat(c."first_name", ' ', c."patronymic", ' ', c."last_name") as "name",
		 c.phone_number,
		 c.email,
		 s.subscription_id,
		 st.type,
		 st.price,
		 s.date_of_issue,
		 s.expiration_date
	from 
		"client" c
	left join
		"subscription" s using("client_id")
	left join 
		"subscription_type" st using("subscription_type_id");

create or replace view "employee_info"
as 
	select 
		e."employee_id",
		concat(e."first_name", ' ', e."patronymic", ' ', e."last_name") as "name",
		e."phone_number",
		e."passport_number_and_series",
		e."email",
		p."position_name",
		s."service_name",
		c."date_of_issue",
		c."expiration_date"
	from 
		"employee" e
	join 
		"contract" c using("employee_id")
	left join 
		"service" s using("employee_id")
	join 
		"position" p using("position_id");

create view "schedule_info"
as 
	select 
		sc.schedule_id,
		sr.service_name,
		sr.employee_id,
		sc.client_id,
		r.type as "room_type",
		sc.day,
		sc.start_time,
		sc.end_time
	from 
		"schedule" sc
	join 
		"client" c using("client_id")
	join 
		"service" sr using("service_id") 
	join 
		"room" r using("room_id");

