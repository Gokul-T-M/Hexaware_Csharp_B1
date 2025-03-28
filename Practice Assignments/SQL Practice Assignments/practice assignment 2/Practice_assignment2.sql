

use master


create database practice_assignment2;

use SQLpractice_assignment2;

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

--1. List all employees whose name begins with 'A'. 

select * from emp 
where ename like 'a%';

--2. Select all those employees who don't have a manager. 

select * from emp
where mgr_id is null;

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 

select ename, empno, sal from emp
where sal between 1200 and 1400;

--4. Give all the employees in the RESEARCH department a 10% pay rise.
--   Verify that this has been done by listing all their details before and after the rise.

SELECT *, (e.SAL * 1.10) AS Increased_Salary
FROM EMP e  
JOIN DEPT d ON e.DEPTNO = d.DEPTNO  
WHERE d.DNAME = 'RESEARCH';

--5. Find the number of CLERKS employed. Give it a descriptive heading. 

select count(*) 'Number of Clerks' from emp 
where job = 'clerk';

--6. Find the average salary for each job type and the number of people employed in each job. 

select * from dept;
select * from emp;

select job,count(job) 'Number of employees',avg(sal) 'Average Salary'
from emp
group by job;

--7. List the employees with the lowest and highest salary. 

select * from emp 
where sal =(select min(sal) from emp);

--8. List full details of departments that don't have any employees. 

select * from dept
where deptno not in (select distinct deptno from emp);

--9. Get the names and salaries of all the analysts earning 
--   more than 1200 who are based in department 20. Sort the answer by ascending order of name. 

select * from dept;
select * from emp;

select ename, sal
from emp
where sal>1200
and deptno=20
and job='analyst'
order by ename asc;

--10. For each department, list its name and number together with the total salary paid to employees in that department.

select * from dept;
select * from emp;

select d.dname, d.deptno, sum(e.sal) 'Total salary of employees'
from dept d
join emp e on d.deptno = e.deptno
group by d.dname, d.deptno;


--11. Find out salary of both MILLER and SMITH.

select * from dept;
select * from emp;

select ename, sal 
from emp
where ename in('MILLER','SMITH');

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’. 

select ename 'Employee Names starting with A or M' from emp 
where ename like '[AM]%';

--13. Compute yearly salary of SMITH. 

select ename 'Name',sal 'Monthly Salary',(12*sal) 'Yearly Salary' from emp
where ename = 'smith'

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850. 

select * from dept;
select * from emp;

select ename 'name', sal 'salary' from emp
where sal not between 1500 and 2850;

--15. Find all managers who have more than 2 employees reporting to them

select * from dept;
select * from emp;

select ename from emp
where empno in (select mgr_id 'Manager ID' from emp group by mgr_id having count(mgr_id)>2 );
