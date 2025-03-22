

use master


create database SQLpractice_assignment3;

use SQLpractice_assignment3;

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


--questions from SET-2 for assignment 3

--1. Retrieve a list of MANAGERS.

select * from dept;
select * from emp;

select distinct e1.ename as ManagerList 
from emp e1
join emp e2 on e1.empno = e2.mgr_id;

--2. Find out the names and salaries of all employees earning more than 1000 per month. 

select * from dept;
select * from emp;

select ename 'Name',sal 'Salary' 
from emp
where sal>1000
order by sal desc;

--3. Display the names and salaries of all employees except JAMES. 

select  ename 'Names', sal 'Salary'
from emp 
where ename <> 'james';

--4. Find out the details of employees whose names begin with ‘S’. 

select * from emp
where ename like 'S%';

-- 5. Find out the names of all employees that have ‘A’ anywhere in their name. 

select * from emp 
where ename like '%[a]%';

-- 6. Find out the names of all employees that have ‘L’ as their third character in their name. 

select * from emp 
where ename like '__L%';

-- 7. Compute daily salary of JONES. 

select sal 'Monthly Salary',(sal/30) 'Daily Salary' from emp
where ename = 'jones';

-- 8. Calculate the total monthly salary of all employees. 

select sum(sal) 'Total Monthly Salary of All Employees' from emp;

-- 9. Print the average annual salary . 

select Avg(sal*12) 'Average Annual Salary' from emp;

-- 10. Select the name, job, salary, department number of all employees except SALESMAN from department number 30. 

select *from emp
select ename, job, sal, deptno from emp
where not(deptno = 30 and job = 'salesman');


