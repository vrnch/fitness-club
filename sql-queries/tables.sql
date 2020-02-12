create table "employee"
(
    "employee_id" serial,
    "passport_number_and_series" varchar not null,
    "first_name" varchar not null,
    "last_name" varchar not null,
    "patronymic" varchar not null,
    "phone_number" varchar not null,
    "email" varchar,

    primary key("employee_id"),
    unique("passport_number_and_series")
);
create table "position"
(
    "position_id" serial,
    "position_name" varchar not null,
    "salary" int not null check("salary" > 0),

    primary key("position_id"),
    unique("position_name")
);
create table "contract" 
(
    "contract_id" serial,
    "employee_id" int not null,
    "position_id" int not null,
    "date_of_issue" date not null,
    "expiration_date" date not null check("expiration_date" > "date_of_issue"),

    primary key("contract_id"),
    foreign key("employee_id") references "employee" on update cascade on delete cascade,
    foreign key("position_id") references "position" on update cascade
);


create table "client"
(
    "client_id" serial,
    "first_name" varchar not null,
    "last_name" varchar  not null,
    "patronymic" varchar  not null,
    "phone_number" varchar not null,
    "email" varchar,

    primary key("client_id"),
    unique("phone_number")
);
create table "subscription_type"
(
    "subscription_type_id" serial,
    "type" varchar not null,
    "price" int not null check("price" > 0),

    primary key("subscription_type_id"),
    unique("type")
);
create table "subscription"
(
    "subscription_id" serial,
    "client_id" int not null,
    "subscription_type_id" int not null,
    "date_of_issue" date not null,
    "expiration_date" date not null check("expiration_date" > "date_of_issue"),

    primary key("subscription_id"),
    foreign key("client_id") references "client" on update cascade on delete cascade,
    foreign key("subscription_type_id") references "subscription_type" on update cascade
); 

create table "service"
(
    "service_id" serial,
    "employee_id" int not null,
    "service_name" varchar not null,

    primary key("service_id"),
    unique("employee_id", "service_name"),
    foreign key("employee_id") references "employee" on update cascade on delete cascade
);
create table "room" 
(
    "room_id" serial,   
    "type" varchar not null,
    "is_available" bool not null default true,
    "capacity" int not null,

    primary key("room_id"),
    unique("type")
);
create table "schedule"
(
    "schedule_id" serial,
    "service_id" int not null,
    "client_id" int not null,
    "room_id" int not null,
    "day" varchar not null check("day" in('monday', 'tuesday', 'wednesday', 'thursday', 'friday', 'saturday', 'sunday')),
    "start_time" time not null,
    "end_time" time not null check("end_time" > "start_time"),

    primary key("schedule_id"),
    foreign key("service_id") references "service" on update cascade,
    foreign key("client_id") references "client" on delete cascade,
    foreign key("room_id") references "room" on update cascade 
);

insert into "position" ("position_name", "salary") values
('trainer', 500),
('admin', 800);

insert into room ("type", "capacity") values
('swim pool', 20),
('gym1', 50),
('gym2', 40),
('group', 20);
insert into room ("type", "is_available","capacity") values
('swim pool2', false, 30);

insert into subscription_type(type, price) values
('standart', 500),
('lux', 800),
('standart_gym', 300),
('standart_swim_pool', 400),
('lux_gym', 300),
('lux_swim_pool', 600);