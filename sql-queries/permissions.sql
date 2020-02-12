create role administrators; 
grant connect on database fitness_club to administrators;
grant usage on schema public to administrators;
grant all privileges on all tables in schema public to administrators;
grant all privileges on all sequences in schema public to administrators;
revoke all privileges on function "create_schedule", "delete_schedule", "create_client", "subscribe_client", "renew_subscription" from administrators;
revoke select on "room", "service", "schedule_info", "client_info", "subscription_type" from administrators;
revoke all privileges on "client", "subscription", "schedule" from administrators;

create user masha_admin with encrypted password 'admin' in role administrators;

create role trainers; 
grant connect on database fitness_club to trainers;
grant usage on schema public to trainers;
grant all privileges on all tables in schema public to trainers;
grant all privileges on all sequences in schema public to trainers;
revoke all privileges on function "create_employee", "create_service", "fire_employee" from trainers;
revoke all privileges on "employee", "contract", "employee_info", "position" from trainers;
revoke insert, delete, update on "room", "subscription_type", "service" from trainers;

create user masha_trainer with encrypted password 'trainer' in role trainers;
