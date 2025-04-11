use master

create database dbAssetManagement

use dbAssetManagement


create table tblEmployees (

employee_id int primary key identity(1,1),
employee_name varchar(100) not null,
department varchar(100) not null,
email varchar(100) not null,
employee_password varchar(100) not null

);

create table tblAssets (

asset_id int primary key identity(1,1),
asset_name varchar(100) not null,
asset_type varchar(50) not null,
serial_number varchar(100) not null unique,
purchase_date date not null,
asset_location varchar(100) not null,
asset_status varchar(50) not null,

owner_id int not null,
constraint fk_asset_emploee foreign key (owner_id) references tblEmployees(employee_id)
);

create table tblMaintenanceRecords (

maintenance_id int primary key identity(1,1),
asset_id int not null,
maintenance_date date not null,
maintenance_description varchar(255),
cost decimal(10, 2),
constraint fk_maintenance_asset foreign key (asset_id) references tblAssets(asset_id)

);

create table tblAssetAllocations (

allocation_id int primary key identity(1,1),
asset_id int not null,
employee_id int not null,
allocation_date date not null,
return_date date,
constraint fk_allocation_asset foreign key (asset_id) references tblAssets(asset_id),
constraint fk_allocation_employee foreign key (employee_id) references tblEmployees(employee_id)

);

create table tblReservations (

reservation_id int primary key identity(1,1),
asset_id int not null,
employee_id int not null,
reservation_date date not null,
reservation_start_date date not null,
reservation_end_date date not null,
reservation_status varchar(50) not null,
constraint fk_reservation_asset foreign key (asset_id) references tblAssets(asset_id),
constraint fk_reservation_employee foreign key (employee_id) references tblEmployees(employee_id)

);


insert into tblEmployees values
('Raj Kumar', 'IT', 'raj.kumar@example.com', 'raj123'),
('Priya Sharma', 'HR', 'priya.sharma@example.com', 'priya123'),
('Karthik R', 'Finance', 'karthik.r@example.com', 'kar123'),
('Anjali Mehra', 'Admin', 'anjali.mehra@example.com', 'anjali123'),
('Vikram Das', 'Support', 'vikram.das@example.com', 'vikram123');

select * from tblEmployees

insert into tblAssets values
('Dell Laptop', 'Laptop', 'DL123ABC', '2023-04-01', 'Chennai', 'Available', 1),
('HP Printer', 'Printer', 'HP456DEF', '2022-11-10', 'Delhi', 'In Use', 2),
('MacBook Pro', 'Laptop', 'MB789GHI', '2023-06-15', 'Mumbai', 'Available', 3),
('Cisco Router', 'Networking', 'CR321JKL', '2021-09-20', 'Hyderabad', 'Available', 1),
('Lenovo ThinkPad', 'Laptop', 'LT654MNO', '2023-02-05', 'Bangalore', 'In Use', 4);

select * from tblAssets

insert into tblMaintenanceRecords values
(1, '2024-04-01', 'Battery replaced', 2500.00),
(2, '2024-03-15', 'Ink cartridge replacement', 900.00),
(3, '2024-03-25', 'Screen fix', 4000.00),
(4, '2024-04-03', 'Firmware update', 0.00),
(5, '2024-02-10', 'Hard drive issue', 3000.00),
(1, '2024-04-10', 'RAM upgraded', 1500.00);

select * from tblMaintenanceRecords

insert into tblAssetAllocations values
(1, 2, '2024-04-01', null),
(2, 1, '2024-04-03', null),
(3, 4, '2024-04-05', '2024-04-10'),
(4, 5, '2024-03-01', null),
(5, 3, '2024-03-15', '2024-03-20'),
(4, 2, '2024-04-07', null),
(5, 1, '2024-04-08', null);

select * from tblAssetAllocations

insert into tblReservations values
(1, 3, '2024-04-01', '2024-04-05', '2024-04-10', 'pending'),
(2, 4, '2024-04-02', '2024-04-10', '2024-04-15', 'approved'),
(3, 1, '2024-04-03', '2024-04-07', '2024-04-09', 'pending'),
(4, 5, '2024-04-04', '2024-04-08', '2024-04-12', 'cancelled'),
(5, 2, '2024-04-05', '2024-04-10', '2024-04-14', 'pending'),
(2, 3, '2024-04-02', '2024-04-07', '2024-04-10', 'pending'); 

select * from tblReservations




select * from tblEmployees
select * from tblAssets
select * from tblMaintenanceRecords
select * from tblAssetAllocations
select * from tblReservations

