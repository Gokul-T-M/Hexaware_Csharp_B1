use master;

create database Hexaware;

use hexaware;

create table clients(
client_id numeric(4) primary key,
cname varchar(40) not null,
address varchar(30),
Email varchar(30) unique,
phone numeric(10),
business varchar(20) not null
);

create table departments(
deptno numeric(2) primary key,
dname varchar(15) not null,
loc varchar(20)
);

create table employees(
Empno numeric(4) primary key,
ename varchar(20) not null,
job varchar(15),
salary numeric(7) check (salary>0),
deptno numeric(2),
foreign key (deptno) references departments(deptno)
);

create table projects(
project_id numeric(3) primary key,
descr varchar(30) not null,
start_date date,
planned_end_date date,
actual_end_date date,
budget numeric(10) check (budget>0),
client_id numeric(4),
foreign key (client_id) references clients(client_id),
constraint chk_dates check(actual_end_date>planned_end_date)
);

create table empProjectTasks(
project_id numeric(3),
empno numeric(4),
start_date date,
end_date date,
task varchar(25) not null,
status varchar(15) not null,
primary key (project_id, empno),
foreign key (project_id)  references projects(project_id),
foreign key (empno) references employees(empno)
);

INSERT INTO clients VALUES (1001, 'ACME Utilities', 'Noida', 'contact@acmeutil.com', 9567880032, 'Manufacturing'),
(1002, 'Trackon Consultants', 'Mumbai', 'consult@trackon.com', 8734210090, 'Consultant'),
(1003, 'MoneySaver Distributors', 'Kolkata', 'save@moneysaver.com', 7799886655, 'Reseller'),
(1004, 'Lawful Corp', 'Chennai', 'justice@lawful.com', 9210342219, 'Professional');

select * from clients;

INSERT INTO Employees VALUES (7001, 'Sandeep', 'Analyst', 25000, 10),
(7002, 'Rajesh', 'Designer', 30000, 10),
(7003, 'Madhav', 'Developer', 40000, 20),
(7004, 'Manoj', 'Developer', 40000, 20),
(7005, 'Abhay', 'Designer', 35000, 10),
(7006, 'Uma', 'Tester', 30000, 30),
(7007, 'Gita', 'Tech. Writer', 30000, 40),
(7008, 'Priya', 'Tester', 35000, 30),
(7009, 'Nutan', 'Developer', 45000, 20),
(7010, 'Smita', 'Analyst', 20000, 10),
(7011, 'Anand', 'Project Mgr', 65000, 10);

select * from employees;

INSERT INTO Departments VALUES (10, 'Design', 'Pune'),
(20, 'Development', 'Pune'),
(30, 'Testing', 'Mumbai'),
(40, 'Document', 'Mumbai');

select * from departments;


INSERT INTO Projects VALUES (401, 'Inventory', '01-Apr-11','01-Oct-11', '31-Oct-11', 150000, 1001),
(402, 'Accounting', '01-Aug-11', '01-Jan-12', NULL, 500000, 1002),
(403, 'Payroll', '01-Oct-11', '31-Dec-11', NULL, 75000, 1003),
(404, 'Contact Mgmt', '01-Nov-11', '31-Dec-11', NULL, 50000, 1004);

select * from projects;

INSERT INTO empProjectTasks VALUES
(401,7001,'01-Apr-11','20-Apr-11','System Analysis','completed'),
(401,7002,'21-Apr-11','30-May-11','System Design','completed'),
(401,7003,'01-Jun-11','15-Jul-11','Coding','completed'),
(401,7004,'18-Jul-11','01-Sep-11','Coding','completed'),
(401,7006,'03-Sep-11','15-Sep-11','Testing','completed'),
(401,7009,'18-Sep-11','05-Oct-11','code change','completed'),
(401,7007,'06-Oct-11','22-Oct-11','documentation','completed'),
(401,7011,'22-Oct-11','31-Oct-11','sign off','completed'),
(402,7010,'01-Aug-11','20-Aug-11','System Analysis','completed'),
(402,7002,'22-Aug-11','30-Sep-11','System Design','completed'),
(402,7004,'01-Oct-11',null,'coding','in progress');

select * from empProjectTasks;