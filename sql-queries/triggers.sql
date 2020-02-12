create or replace function check_time() returns trigger as $$
begin 
	if exists 
		(select * 
		from "schedule"
		where "service_id" = new.service_id -- Selection of the same service on the same day.
		and "day" = new.day 
		and ("start_time" <= new.end_time -- If time periods overlap
		and "end_time" >= new.start_time))	
	then 
		raise exception 'Overlaps with existing time.';	
	else 
		return new;
	end if;	
end $$ 
	language plpgSQL;

create trigger check_time_trigger before insert on "schedule"
	for each row execute procedure check_time();

create or replace function check_room_capacity() returns trigger as $$
declare 
	new_rec_capacity int; 
	occupancy int;
begin 
	new_rec_capacity = (select "capacity" from "room" where "room_id" = new.room_id);
	occupancy = (select count("schedule_id") 
					from "schedule" 
					where "room_id" = new.room_id 
					and "day" = new.day
					and ("start_time" <= new.end_time -- Simultaneously
							and "end_time" >= new.start_time));

 
	if (occupancy < new_rec_capacity) -- Fits in
	then 
		return new;
	else 
		raise exception 'The room is overcrowded.';		
	end if;		
end $$ 
	language plpgSQL;

create trigger check_room_capacity_trigger before insert on "schedule"
	for each row execute procedure check_room_capacity();

create or replace function check_room_availability() returns trigger as $$
begin 
	if ((select "is_available" from "room" where "room_id" = new.room_id) = false)
	then 
		raise exception 'The room is unavailable.';
	else 
		return new;
	end if;
end $$ 
	language plpgSQL;

create trigger check_room_availability_trigger before insert on "schedule"
	for each row execute procedure check_room_availability();

create or replace function prevent_service_creation() returns trigger as $$
begin 
	if 
		((select "position_name" from "employee_info" where "employee_id" = new.employee_id) = 'admin')
	then 
		raise exception 'Administrators cannot provide a service.';
	end if;
end $$ 
	language plpgSQL;

create trigger prevent_service_creation_trigger before insert on "service"
	for each row execute procedure prevent_service_creation();