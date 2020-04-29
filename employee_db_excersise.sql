-- Running these commands didn't show in Object Explorer
-- CREATE DATABASE employee_db_exercise;
-- GO
-- CREATE SCHEMA Emp;
-- GO

-- manually created database in SQL Management Studio
-- Schema became dbo by default

CREATE TABLE EmpDetails (
	ID int UNIQUE IDENTITY NOT NULL,
	EmployeeID int PRIMARY KEY NOT NULL,
	Salary money NOT NULL,
	Address1 nvarchar(255) NOT NULL,
	Address2 nvarchar(255) ,
	City nvarchar(255) NOT NULL,
	State nvarchar(255) ,
	Country nvarchar(255) NOT NULL
);

CREATE TABLE Department (
	ID int PRIMARY KEY NOT NULL,
	Name nvarchar(255) NOT NULL,
	Location nvarchar(255) NOT NULL
);

CREATE TABLE Employee (
	ID int FOREIGN KEY REFERENCES dbo.EmpDetails (EmployeeID) NOT NULL,
	FirstName nvarchar(255) NOT NULL,
	LastName nvarchar(255) NOT NULL,
	SSN nvarchar(255) NOT NULL,
	DeptID int FOREIGN KEY REFERENCES dbo.Department (ID) NOT NULL
);

-- random address generated from 
-- https://www.randomlists.com/random-addresses

-- Add 3 records to each table
INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES (0, 20000, '7265 Border St.', 'San Jose', 'CA', 'USA');

INSERT INTO EmpDetails (EmployeeID, Salary, Address1, Address2, City, State, Country)
VALUES (123, 70000, '6 Oakwood Road', 'Unit 13', 'Avon Lake', 'OH', 'USA');

INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES (459, 100, '442 South Academy Lane', 'Selden', 'NY', 'USA');


INSERT INTO Department (ID, Name, Location)
VALUES (101, 'Sales', '589 Valley View Court, Hinesville, GA 31313');

INSERT INTO Department (ID, Name, Location)
VALUES (1, 'Human Resources', '109 E. Cypress Lane, Suffolk, VA 23434');

INSERT INTO Department (ID, Name, Location)
VALUES (45, 'Logistics', '518 Buttonwood Avenue, Flowery Branch, GA 30542');


INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 0, 'Bobby', 'Bob', '123-45-6789', 45);

INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 123, 'Jo', 'Jojo', '987-65-4321', 1);

INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 459, 'John', 'Smith', '000-00-0000', 101);


-- Add employee Tina Smith
INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES (321, 40000, '7299 Ketch Harbour Street', 'Berwyn', 'IL', 'USA');

INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 321, 'Tina', 'Smith', '111-11-1111', 101 );

-- Add department Marketing
INSERT INTO Department ( ID, Name, Location )
VALUES ( 42, 'Marketing', '7299 Ketch Harbour Street, Berwyn, IL 60402' );

-- Add employees to Marketing to see data for Marketing queries
INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES (8, 50000, '8165 E. Magnolia St.', 'Ashburn', 'VA', 'USA');

INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 8, 'Mark', 'Zuck', '222-22-2222', 42 );

INSERT INTO EmpDetails (EmployeeID, Salary, Address1, City, State, Country)
VALUES (97, 100001, '9231 Shirley Drive', 'Rapid City', 'SD', 'USA');

INSERT INTO Employee ( ID, FirstName, LastName, SSN, DeptID )
VALUES ( 97, 'Bill', 'Fence', '333-33-3333', 42 );

-- List all employees in Marketing
SELECT * FROM Employee
WHERE DeptID = (
	SELECT ID FROM Department
	WHERE Name = 'Marketing'
);

-- Report total salary of Marketing

-- unfinished
--SELECT SUM(Salary) as 'Total Salary' FROM EmpDetails
--WHERE EmployeeID = (
--	SELECT * FROM Employee
--	WHERE DeptID = (
--		SELECT ID FROM Department
--		WHERE Name = 'Marketing'
--	)
--);

-- Report total employees by department
-- unfinished as well, does it require join

-- Increase salary of Tina Smith to $90,000
UPDATE EmpDetails
SET Salary = 90000
WHERE EmployeeID = (
	SELECT ID FROM Employee
	WHERE FirstName = 'Tina' AND LastName = 'Smith'
);