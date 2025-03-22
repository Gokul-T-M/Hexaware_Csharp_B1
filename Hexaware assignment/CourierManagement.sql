use master

use dbCourierManagement;

drop table tblPayment;

drop table tblCourier;

drop table tblUser;

drop table tblCourierServices;

drop table tblEmployee;

drop table tblLocation;

create table tblUser(
UserID int primary key,
UserName varchar(255),
UserEmail varchar(255) unique,
UserPassword varchar (255),
UserContact varchar(20),
UserAddress text
);

create table tblCourierServices(
ServiceID int primary key,
ServiceName varchar(100),
ServiceCost decimal(8,2)
);

create table tblEmployee(
EmployeeID int primary key,
EmployeeName varchar(255),
EmployeeEmail varchar(255) unique,
EmployeeContact varchar(20),
EmployeeRole varchar(50), 
EmployeeSalary decimal(10,2)
);

create table tblLocation(
LocationId int primary key,
LocationName varchar(100),
LocationAddress text
);

create table tblCourier(
CourierID int primary key,
SenderName varchar(25),
SenderAddress text,
ReceiverName varchar(25),
ReceiverAddress text,
CourierWeight decimal(5,2),
CourierStatus varchar(50),
TrackingNumber varchar(20),
DeliveryDate date,
UserID INT,  
EmployeeID INT,  
ServiceID INT,  
LocationID INT,
constraint fk_courier_user foreign key (UserID) references tblUser(UserID),
constraint fk_courier_employee foreign key (EmployeeID) references tblEmployee(EmployeeID),
constraint fk_courier_CourierService foreign key (ServiceID) references tblCourierServices(ServiceID),
constraint fk_courier_location foreign key (LocationID) references tblLocation(LocationID)
);


create table tblPayment(
PaymentID int primary key,
CourierID int,
locationID int,
EmployeeID int,
Amount decimal(10,2),
PaymentDate date,
constraint fk_payment_courier foreign key (CourierID) references tblCourier(CourierID),
constraint fk_payment_location foreign key (LocationID) references tblLocation(LocationID),
constraint fk_payment_employee foreign key (EmployeeID) references tblEmployee(EmployeeID)
);


INSERT INTO tblUser VALUES
(1, 'Arun Kumar', 'arun.kumar@example.com', 'pass123', '9876543210', 'Chennai, Tamil Nadu'),
(2, 'Priya Sharma', 'priya.sharma@example.com', 'secure456', '9898989898', 'Coimbatore, Tamil Nadu'),
(3, 'Dinesh Kumar', 'dinesh.k@example.com', 'password789', '9876512345', 'Madurai, Tamil Nadu'),
(4, 'Sowmya R', 'sowmya.r@example.com', 'pass999', '9867543210', 'Trichy, Tamil Nadu'),
(5, 'Vignesh B', 'vignesh.b@example.com', 'secure555', '9944556677', 'Salem, Tamil Nadu'),
(6, 'Vikash', 'vikash2003@example.com','ToughPass35','9546595473','Madurai, Tamil Nadu'),
(7, 'Prashanth','Prashanth03@example.com','PrashPass35','9876595472', 'Trichy, Tamil Nadu'),
(8, 'Priya', 'Priya43@example.com','Priya678','9876595473','Salem, Tamil Nadu'),
(9, 'kaviya', 'kavi03@example.com','kaviya321','9812345473','Coimbatore, Tamil Nadu');

select * from tblUser;

INSERT INTO tblCourierServices VALUES
(1, 'Standard Delivery', 100.00),
(2, 'Express Delivery', 200.00),
(3, 'Same Day Delivery', 350.00),
(4, 'Overnight Delivery', 500.00),
(5, 'Insurance Coverage', 100.00),
(6, 'Fragile Item Handling', 75.00);

select * from tblCourierServices;

INSERT INTO tblEmployee VALUES
(1, 'Vikram R', 'vikram.r@example.com', '9876541230', 'Delivery Agent', 25000.00),
(2, 'Meena L', 'meena.l@example.com', '9845123456', 'Manager', 50000.00),
(3, 'Karthik S', 'karthik.s@example.com', '9785612345', 'Delivery Agent', 27000.00),
(4, 'Lavanya M', 'lavanya.m@example.com', '9823456789', 'Supervisor', 60000.00),
(5, 'Senthil K', 'senthil.k@example.com', '9798765432', 'Delivery Agent', 26000.00),
(6, 'John', 'JohnCena@example.com', '9798765431', 'Supervisor', 55000.00),
(7, 'Johnson', 'Johnson@example.com', '9798765430', 'Manager', 52000.00);

select * from tblEmployee;

INSERT INTO tblLocation VALUES
(1, 'Chennai Hub', 'Chennai, Tamil Nadu'),
(2, 'Coimbatore Hub', 'Coimbatore, Tamil Nadu'),
(3, 'Madurai Hub', 'Madurai, Tamil Nadu'),
(4, 'Trichy Hub', 'Trichy, Tamil Nadu'),
(5, 'Salem Hub', 'Salem, Tamil Nadu'),
(6, 'Erode Hub', 'Erode, Tamil Nadu');

select * from tblLocation;

INSERT INTO tblCourier VALUES
(101, 'Arun Kumar', 'Chennai, Tamil Nadu', 'Deepak R', 'Madurai, Tamil Nadu', 2.5, 'In Transit', 'TN12345', '2025-03-25', 1, 1, 2, 4),
(102, 'Priya Sharma', 'Coimbatore, Tamil Nadu', 'Anjali K', 'Chennai, Tamil Nadu', 1.2, 'Delivered', 'TN67890', '2025-03-18', 2, 2, 3, 1),
(103, 'Dinesh Kumar', 'Madurai, Tamil Nadu', 'Ravi T', 'Chennai, Tamil Nadu', 3.1, 'Pending', 'TN11223', '2025-03-27', 3, 3, 1, 3),
(104, 'Sowmya R', 'Trichy, Tamil Nadu', 'Sneha P', 'Coimbatore, Tamil Nadu', 2.0, 'In Transit', 'TN33445', '2025-03-22', 4, 4, 4, 4),
(105, 'Vignesh B', 'Salem, Tamil Nadu', 'Meera S', 'Madurai, Tamil Nadu', 1.5, 'Processing', 'TN55667', '2025-03-21', 5, 5, 5, 5),
(106, 'Karthikeyan', 'Chennai, Tamil Nadu', 'Deepak R', 'Madurai, Tamil Nadu', 3.7, 'In Transit', 'TN12445', '2025-03-25', 1, 1, 2, 4),
(107, 'Newton', 'Trichy, Tamil Nadu', 'Einstein', 'Coimbatore, Tamil Nadu', 0.9, 'In Transit', 'TN33445', '2025-03-22', 4, 4, 4, 2),
(108, 'Vikash', 'Madurai, Tamil Nadu', 'Ragul', 'Chennai, Tamil Nadu', 3.1, 'delivered', 'TN63824', '2025-03-27', 3, 3, 1, 3),
(109, 'Prashanth', 'Trichy, Tamil Nadu', 'Sneha P', 'Coimbatore, Tamil Nadu', 2.0, 'delivered', 'TN65345', '2025-03-20', 4, 4, 4, 3),
(110, 'Priya', 'Salem, Tamil Nadu', 'Shankar', 'Madurai, Tamil Nadu', 1.5,'delivered','TN90809', '2025-03-19', 5, 5, 5, 5),
(111, 'Prashanth', 'Trichy, Tamil Nadu', 'Prem', 'Coimbatore, Tamil Nadu', 2.0, 'delivered', 'TN65345', '2025-03-20', 4, 4, 4, 3);

select *from tblCourier;

INSERT INTO tblPayment VALUES
(1, 101, 1, 200.00, '2025-03-24',5),
(2, 102, 2, 350.00, '2025-03-18',2),
(3, 103, 3, 100.00, '2025-03-26',6),
(4, 104, 4, 500.00, '2025-03-22',4),
(5, 105, 5, 75.00, '2025-03-28',1),
(6, 106, 1, 150.00, '2025-03-20',3),
(7, 107, 4, 500.00, '2025-03-21',1),
(8, 108, 5, 75.00, '2025-03-28',3),
(9, 109, 1, 150.00, '2025-03-20',2),
(10, 110, 4, 500.00, '2025-03-21',2);

select * from tblPayment;

--Task 2: Select,Where 
--Solve the following queries in the Schema that you have created above  

--1. List all customers:  

select * from tblUser;

--2. List all orders for a specific customer:  

select * from tblCourier
where UserID='3';

--3. List all couriers:  

select * from tblCourier;

--4. List all packages for a specific order:  

select * from tblCourier
where CourierID='104';

--5. List all deliveries for a specific courier:  

select * from tblCourier 
where CourierID='101'

--6. List all undelivered packages:  

select * from tblCourier
where CourierStatus <> 'Delivered';

--7. List all packages that are scheduled for delivery today:  

select * from tblCourier
where DeliveryDate = CAST(GETDATE() AS DATE);

--8. List all packages with a specific status:  

select * from tblCourier
where CourierStatus = 'in Transit';

--9. Calculate the total number of packages for each courier.  

select CourierID, count(*) as 'Total Number of Packages' from tblCourier
group by CourierID;

--10. Find the average delivery time for each courier  

select C.courierID,avg(DATEDIFF(DAY,P.PaymentDate,C.DeliveryDate)) as 'Average Delivery Time' from tblCourier C
join tblPayment P on C.CourierID = P.CourierID
group by C.CourierID;

--11. List all packages with a specific weight range:  

select * from tblCourier 
where CourierWeight between 2 and 3;

--12. Retrieve employees whose names contain 'John'  

select * from tblEmployee 
where EmployeeName like '%John%';

--13. Retrieve all courier records with payments greater than $50.  

select * from tblCourier C
join tblPayment P on C.CourierID = P.CourierID
where P.Amount > 50;

--Task 3: GroupBy, Aggregate Functions, Having, Order By, where  

--14.Find the total number of couriers handled by each employee.

select EmployeeID, count(CourierID) as 'Total number of Couriers Handled' from tblCourier
group by EmployeeID;

--15. Calculate the total revenue generated by each location  

select LocationID, sum(Amount) as 'Total Revenue' from tblPayment
group by LocationId;


--16. Find the total number of couriers delivered to each location.  

SELECT LocationID, COUNT(CourierID) AS DeliveredCouriers FROM tblCourier 
WHERE CourierStatus = 'Delivered' GROUP BY LocationID;


--17. Find the courier with the highest average delivery time:

select top 1 C.CourierID, avg(DATEDIFF(day, P.PaymentDate, C.DeliveryDate)) as 'Average delivery time' from tblCourier C
join tblPayment P on C.CourierID = P.CourierID
group by C.CourierID
Order by 'Average delivery time' desc

--18. Find Locations with Total Payments Less Than a Certain Amount  

select LocationID, sum(Amount) as 'Total Payments' from tblPayment
group by LocationID 
having sum(Amount)<250;

--19. Calculate Total Payments per Location

select LocationID, sum(Amount) as 'Total Payments' from tblPayment
group by LocationID

--20. Retrieve couriers who have received payments totaling more than $1000 in a specific location 
--(LocationID = X):  

select * from tblCourier C
join (
select CourierID,sum(Amount) as 'Total Payment' from tblPayment
where LocationID = 1
group by CourierID
having sum(Amount)>1000
) P on C.CourierID = P.CourierID;

--21. Retrieve couriers who have received payments totaling more than $1000 after a certain date 
--(PaymentDate > 'YYYY-MM-DD'):  

select * from tblCourier
where CourierID in(
select CourierID from tblPayment
where PaymentDate > '2025-03-19'
group by CourierID
having sum(Amount)>1000
)

--22. Retrieve locations where the total amount received is more than $5000 before a certain date 
--(PaymentDate > 'YYYY-MM-DD') 

select * from tblLocation
where LocationId in(
select LocationID 
from tblPayment
where PaymentDate < '2025-03-20'
group by locationID
having sum(Amount)>5000
);


--Task 4: Inner Join,Full Outer Join, Cross Join, Left Outer Join,Right Outer Join 

--23. Retrieve Payments with Courier Information  

select P.*,C.* from tblCourier C
left join tblPayment P on C.CourierID=P.CourierID

--24. Retrieve Payments with Location Information 

select P.*,L.* from tblLocation L
left join tblPayment P on L.LocationID=P.locationID

--25. Retrieve Payments with Courier and Location Information  

select P.*,C.*,L.* from tblPayment P
inner join tblCourier C on P.CourierID = C.CourierID
inner join tblLocation L on C.locationID = L.LocationID

--26. List all payments with courier details  

select P.*,C.* from tblPayment P
right join tblCourier C on P.CourierID = C.CourierID 

--27. Total payments received for each courier  

select C.CourierID,sum(P.Amount) as 'Total Payments Received' from tblCourier C
left join tblPayment P on C.CourierID = P.CourierID
group by C.CourierID

--28. List payments made on a specific date 

select * from tblPayment
where PaymentDate = '2025-03-20'

--29. Get Courier Information for Each Payment  

select P.*,C.* from tblPayment P
right join tblCourier C on P.CourierID = C.CourierID

--30. Get Payment Details with Location  

select P.*,L.* from tblPayment P
right join tblLocation L on P.locationID = L.LocationId

--31. Calculating Total Payments for Each Courier

select C.CourierID, sum(P.Amount) as 'Total Payments' from tblCourier C
left join tblPayment P on C.CourierID = P.CourierID
group by C.CourierID

--32. List Payments Within a Date Range  

select * from tblPayment
where PaymentDate between '2025-03-18' and '2025-03-25'


--33. Retrieve a list of all users and their corresponding courier records, including cases where there are no matches on either side  

select U.*,C.* from tblUser U
left join tblCourier C on U.UserID = C.UserID

--34. Retrieve a list of all couriers and their corresponding services, including cases where there are no matches on either side  

select C.*,CS.* from tblCourier C
full outer join tblCourierServices CS on C.ServiceID = CS.ServiceID

--35. Retrieve a list of all employees and their corresponding payments, including cases where there are no matches on either side  

select E.*,P.* from tblEmployee E
full outer join tblPayment P on E.EmployeeID = P.EmployeeID

--36. List all users and all courier services, showing all possible combinations.

select U.*,CS.* from tblUser U
cross join tblCourierServices CS

--37. List all employees and all locations, showing all possible combinations:  

select * from tblEmployee cross join tblLocation 

--38. Retrieve a list of couriers and their corresponding sender information (if available)  

select CourierID,SenderName,SenderAddress from tblCourier

--39. Retrieve a list of couriers and their corresponding receiver information (if available):  

select CourierID,ReceiverName,ReceiverAddress from tblCourier

--40. Retrieve a list of couriers along with the courier service details (if available):  

select C.*,CS.* from tblCourier C
left join tblCourierServices CS on C.ServiceID = CS.ServiceID

--41. Retrieve a list of employees and the number of couriers assigned to each employee:  

select E.EmployeeID,E.EmployeeName,count(C.EmployeeID) as 'Number of Couriers Assigned' from tblCourier C
right join tblEmployee E on C.EmployeeID = E.EmployeeID
group by E.EmployeeID,E.EmployeeName;

--42. Retrieve a list of locations and the total payment amount received at each location

select L.LocationId,L.LocationName,sum(P.Amount) as 'Total Payment' from tblPayment P
right join tblLocation L on P.LocationId = L.locationID
group by L.LocationId,L.LocationName


--43. Retrieve all couriers sent by the same sender (based on SenderName).

select C1.* from tblCourier C1
inner join tblCourier C2 on C1.SenderName = C2.SenderName
where C1.CourierID <> C2.CourierID

--44. List all employees who share the same role.

select EmployeeID, EmployeeName, EmployeeRole
from tblEmployee e1
where EXISTS (
    select 'a' from tblEmployee e2
    where e1.EmployeeRole = e2.EmployeeRole 
    and e1.EmployeeID <> e2.EmployeeID
)
order by EmployeeRole asc;

--45. Retrieve all payments made for couriers sent from the same location.  

select * from tblPayment P1
where exists(
	select 1 from tblPayment P2
	where P1.locationID=P2.locationID
	and P1.CourierID <> P2.CourierID
	)
order by P1.locationID 


--46. Retrieve all couriers sent from the same location (based on SenderAddress).  

select * from tblCourier C1
where exists(
	select 1 from tblCourier C2
	where cast(C1.SenderAddress as varchar(max))=cast((C2.SenderAddress) as varchar(max))
	and C1.CourierID <> C2.CourierID
	)
order by cast(C1.SenderAddress as varchar(max))

--47. List employees and the number of couriers they have delivered:  

select E.EmployeeID,E.EmployeeName,Count(C.EmployeeID) as 'No of Couriers Delivered' from tblCourier C
right join tblEmployee E on C.EmployeeID = E.EmployeeID
group by E.EmployeeID,E.EmployeeName

--48. Find couriers that were paid an amount greater than the cost of their respective courier services  

select 
	C.CourierID,
	C.SenderName,
	C.SenderAddress, 
	C.ReceiverName,
	C.ReceiverAddress,
	C.CourierWeight,
	C.CourierStatus,
	C.TrackingNumber,
	C.DeliveryDate,
	P.Amount,
	CS.ServiceCost
from tblCourier C
join tblPayment P on C.CourierID = P.CourierID
join tblCourierServices CS on C.ServiceID= CS.ServiceID
where P.Amount>CS.ServiceCost

--Scope: Inner Queries, Non Equi Joins, Equi joins,Exist,Any,All  

--49. Find couriers that have a weight greater than the average weight of all couriers  

select * from tblCourier
where CourierWeight > ( select avg(CourierWeight) as 'Average Weight' from tblCourier);

--50. Find the names of all employees who have a salary greater than the average salary:

select EmployeeName 
from tblEmployee
where EmployeeSalary > ( select avg(EmployeeSalary) as 'Average Salary' from tblEmployee )

--51. Find the total cost of all courier services where the cost is less than the maximum cost  

select sum(ServiceCost) as 'Total Cost' 
from tblCourierServices
where ServiceCost < (select max(ServiceCost) from tblCourierServices)

--52. Find all couriers that have been paid for 

select * from tblCourier
where CourierID in (select CourierID from tblPayment)

--53. Find the locations where the maximum payment amount was made  

select top 1* from tblLocation L
join(
select LocationID,sum(Amount) as 'Total Payment' from tblPayment
group by LocationID
) P
on L.LocationId=P.locationID
order by 'Total Payment' desc

--54. Find all couriers whose weight is greater than the weight of all couriers sent by a specific sender (e.g., 'SenderName'): 

select * from tblCourier
where CourierWeight > all(
select CourierWeight from tblCourier
where SenderName = 'Prashanth'
)

