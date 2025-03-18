--Task 1

use master

create database dbCourierManagenment;

use dbCourierManagenment;

create table Users(
UserID INT PRIMARY KEY,
UserName VARCHAR(255),
UserEmail VARCHAR(255) UNIQUE,
UserPassword VARCHAR(255),
UserContactNumber VARCHAR(20),
UserAddress TEXT 
);


create table Courier(
CourierID INT PRIMARY KEY,
SenderName VARCHAR(255),
SenderAddress TEXT,
ReceiverName VARCHAR(255),
ReceiverAddress TEXT,
CourierWeight DECIMAL(5, 2),
CourierStatus VARCHAR(50),
TrackingNumber VARCHAR(20) UNIQUE,
DeliveryDate DATE
);


create table CourierServices(
ServiceID INT PRIMARY KEY,
ServiceName VARCHAR(100),
Cost DECIMAL(8, 2)
); 


create table Employee(
EmployeeID INT PRIMARY KEY,
EmployeeName VARCHAR(255),
EmployeeEmail VARCHAR(255) UNIQUE,
EmployeeContactNumber VARCHAR(20),
EmployeeRole VARCHAR(50),
EmployeeSalary DECIMAL(10, 2)
); 


create table Locn(
LocationID INT PRIMARY KEY,
LocationName VARCHAR(100),
LocAddress TEXT
);


create table Payment(
PaymentID INT PRIMARY KEY,
CourierID INT,
LocationId INT,
Amount DECIMAL(10, 2),
PaymentDate DATE,
FOREIGN KEY (CourierID) REFERENCES Courier(CourierID),
FOREIGN KEY (LocationID) REFERENCES Locn(LocationID)
);


INSERT INTO Users 
VALUES
(1, 'Karthik Rajan', 'karthik.rajan@example.com', 'password123', '9876543210', '123 Anna Salai, Chennai, Tamil Nadu'),
(2, 'Priya Lakshmi', 'priya.lakshmi@example.com', 'password456', '8765432109', '456 Mount Road, Chennai, Tamil Nadu'),
(3, 'Arun Kumar', 'arun.kumar@example.com', 'password789', '7654321098', '789 Gandhipuram, Coimbatore, Tamil Nadu'),
(4, 'Deepa Suresh', 'deepa.suresh@example.com', 'password101', '6543210987', '101 Race Course Road, Madurai, Tamil Nadu'),
(5, 'Senthil Nathan', 'senthil.nathan@example.com', 'password202', '5432109876', '202 Trichy Road, Tiruchirappalli, Tamil Nadu');

select * from Users;


INSERT INTO Courier
VALUES
(1, 'Karthik Rajan', '123 Anna Salai, Chennai, Tamil Nadu', 'Priya Lakshmi', '456 Mount Road, Chennai, Tamil Nadu', 2.5, 'Delivered', 'TRK123456', '2023-10-15'),
(2, 'Arun Kumar', '789 Gandhipuram, Coimbatore, Tamil Nadu', 'Deepa Suresh', '101 Race Course Road, Madurai, Tamil Nadu', 5.0, 'In Transit', 'TRK654321', '2023-10-20'),
(3, 'Senthil Nathan', '202 Trichy Road, Tiruchirappalli, Tamil Nadu', 'Karthik Rajan', '123 Anna Salai, Chennai, Tamil Nadu', 3.2, 'Processing', 'TRK987654', '2023-10-25'),
(4, 'Priya Lakshmi', '456 Mount Road, Chennai, Tamil Nadu', 'Arun Kumar', '789 Gandhipuram, Coimbatore, Tamil Nadu', 4.7, 'Delivered', 'TRK321654', '2023-10-10'),
(5, 'Deepa Suresh', '101 Race Course Road, Madurai, Tamil Nadu', 'Senthil Nathan', '202 Trichy Road, Tiruchirappalli, Tamil Nadu', 6.1, 'In Transit', 'TRK456987', '2023-10-30');


select * from Courier;

INSERT INTO CourierServices
VALUES
(1, 'Standard Delivery', 100.00),
(2, 'Express Delivery', 250.00),
(3, 'Overnight Delivery', 500.00),
(4, 'International Delivery', 1500.00),
(5, 'Same-Day Delivery', 400.00);

select * from CourierServices;


INSERT INTO Employee
VALUES
(1, 'Rajesh Kannan', 'rajesh.kannan@example.com', '9123456780', 'Manager', 50000.00),
(2, 'Sundari Devi', 'sundari.devi@example.com', '8123456790', 'Delivery Executive', 30000.00),
(3, 'Anand Babu', 'anand.babu@example.com', '7123456781', 'Customer Support', 25000.00),
(4, 'Meena Kumari', 'meena.kumari@example.com', '6123456782', 'Warehouse Staff', 20000.00),
(5, 'Vijayakumar', 'vijayakumar@example.com', '5123456783', 'Driver', 22000.00);

select * from Employee;


INSERT INTO Locn
VALUES
(1, 'Chennai Warehouse', '123 Anna Salai, Chennai, Tamil Nadu'),
(2, 'Coimbatore Warehouse', '789 Gandhipuram, Coimbatore, Tamil Nadu'),
(3, 'Madurai Warehouse', '101 Race Course Road, Madurai, Tamil Nadu'),
(4, 'Tiruchirappalli Warehouse', '202 Trichy Road, Tiruchirappalli, Tamil Nadu'),
(5, 'Salem Warehouse', '303 Omalur Main Road, Salem, Tamil Nadu');

select * from Locn;


INSERT INTO Payment 
VALUES
(1, 1, 1, 250.00, '2023-10-15'),
(2, 2, 2, 500.00, '2023-10-20'),
(3, 3, 1, 400.00, '2023-10-25'),
(4, 4, 3, 300.00, '2023-10-10'),
(5, 5, 4, 600.00, '2023-10-30');

select * from Payment;





