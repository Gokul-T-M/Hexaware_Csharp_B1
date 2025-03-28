use master;

create database SQLpractice_assignment4;

use SQLpractice_assignment4;


CREATE TABLE DEPT (
    deptno INT PRIMARY KEY,
    dname VARCHAR(50),
    loc VARCHAR(50)
);


CREATE TABLE EMP (
    empno INT PRIMARY KEY,
    ename VARCHAR(50),
    job VARCHAR(50),
    mgr_id INT,
    hiredate DATE,
    sal DECIMAL(10,2),
    comm DECIMAL(10,2),
    deptno INT,
    FOREIGN KEY (deptno) REFERENCES DEPT(deptno)
);

INSERT INTO DEPT (deptno, dname, loc) VALUES
(10, 'ACCOUNTING', 'NEW YORK'),
(20, 'RESEARCH', 'DALLAS'),
(30, 'SALES', 'CHICAGO'),
(40, 'OPERATIONS', 'BOSTON');

select * from dept;

INSERT INTO EMP (empno, ename, job, mgr_id, hiredate, sal, comm, deptno) VALUES
(7369, 'SMITH', 'CLERK', 7902, '1980-12-17', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '1981-02-20', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '1981-02-22', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '1981-04-02', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '1981-09-28', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '1981-05-01', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '1981-06-09', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '1987-04-19', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '1981-11-17', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '1981-09-08', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '1987-05-23', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '1981-12-03', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '1981-12-03', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '1982-01-23', 1300, NULL, 10);

select * from dept;
select * from emp;



--Set III

-- 1. List unique departments of the EMP table.

select distinct deptno from emp;

-- 2. List the name and salary of employees who earn more than 1500 and are in department 10 or 30. 
-- Label the columns Employee and Monthly Salary respectively.

select * from dept;
select * from emp;

select ename 'Empployee', sal 'Monthly salary',deptno from emp
where sal>1500 and deptno in(10,30); 

-- 3. Display the name, job, and salary of all the employees whose job is MANAGER or ANALYST 
-- and their salary is not equal to 1000, 3000, or 5000.

select ename, job, sal from emp
where job in ('Manager','Analyst') and sal not in (1000,3000,5000);

-- 4. Display the name, salary and commission for all employees whose commission  amount is greater than their salary increased by 10%. 

select * from dept;
select * from emp;

select ename, sal, (sal*1.10) as 'increased salary', comm from emp
where comm>(sal*1.10);

-- 5. Display the name of all employees who have two Ls in their name and are in department 30 or their manager is 7782. 

select * from dept;
select * from emp;

select ename 'Employee Name' from emp
where ename like ('%L%L%') and (deptno = 30 or mgr_id = 7782); 

-- 6. Display the names of employees with experience of over 30 years and under 40 yrs.Count the total number of employees. 

select ename 'Employee Name', DATEDIFF(YEAR,hiredate,GETDATE()) 'Experience' from emp
where DATEDIFF(YEAR,hiredate,GETDATE()) between 30 and 40;

select count(*) 'Total Experience' from emp;

-- 7. Retrieve the names of departments in ascending order and their employees in descending order. 

select * from dept;
select * from emp;

select d.dname,e.ename
from dept d 
join emp e on d.deptno=e.deptno
order by d.dname asc,e.ename desc;


-- 8. Find out experience of MILLER. 

select DATEDIFF(YEAR, hiredate, GETDATE()) as Experience from emp 
where ename = 'Miller';

-- 9. Write a query to display all employee information where ename contains 5 or more characters

select * from dept;
select * from emp;

select * from emp
where len(ename)>=5

-- 10. Copy empno, ename of all employees from emp table who work for dept 10 into a new table called emp10

create table emp10(
empID int primary key,
ename varchar(50)
);

insert into emp10
select e.empno,e.ename 
from emp e 
where deptno = 10;

select * from emp10;