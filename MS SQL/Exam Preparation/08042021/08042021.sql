-- 1

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username NVARCHAR(30) NOT NULL UNIQUE,
	[Password] NVARCHAR(50) NOT NULL,
	[Name] NVARCHAR(50),
	Birthdate DATETIME,
	Age INT,
		CHECK (Age >= 14 AND Age <= 110),
	Email NVARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(25),
	LastName NVARCHAR(25),
	Birthdate DATETIME,
	Age INT,
		CHECK (Age BETWEEN 18 AND 110),
	DepartmentId INT REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	DepartmentId INT REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] NVARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT REFERENCES Categories(Id) NOT NULL,
	StatusId INT REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] NVARCHAR(200) NOT NULL,
	UserId INT REFERENCES Users(Id) NOT NULL,
	EmployeeId INT REFERENCES Employees(Id)
)

-- 2

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5);

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES
(1, 1, '2017-04-13', null, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', null, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1);

-- 3

UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- 4

DELETE FROM Reports
WHERE StatusId = 4

-- 5

SELECT [Description],
	FORMAT(OpenDate, 'dd-MM-yyyy') AS OpenDate 
FROM Reports r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate, [Description]

-- 6

SELECT r.[Description],
	c.[Name]
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
WHERE CategoryId IS NOT NULL
ORDER BY r.[Description], c.[Name]

-- 7

SELECT TOP(5) 
	c.[Name],
	COUNT(r.Id) AS ReportsNumber
FROM Reports r
JOIN Categories c ON r.CategoryId = c.Id
GROUP BY c.[Name]
ORDER BY COUNT(r.Id) DESC, c.[Name]

-- 8

select u.Username,
	c.[Name] as CategoryName
from Reports r
join Users u on r.UserId = u.Id
join Categories c on r.CategoryId = c.Id
where DAY(u.Birthdate) = DAY(r.OpenDate) AND MONTH(u.Birthdate) = MONTH(r.OpenDate)
order by u.Username, c.Name

-- 9

SELECT k.FullName,
	COUNT(DISTINCT k.Id) AS UsersCount
FROM
(
	SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
		u.Id
	FROM Employees e
	LEFT JOIN Reports r ON r.EmployeeId = e.Id
	LEFT JOIN Users u ON r.UserId = u.Id
) AS k
GROUP BY k.FullName
ORDER BY COUNT(k.Id) DESC, k.FullName

-- 10

SELECT 
	CASE
		WHEN (e.FirstName IS NULL AND e.LastName IS NULL) THEN 'None'
		ELSE CONCAT(e.FirstName, ' ', e.LastName)
	END AS Employee,
	ISNULL(d.[Name], 'None') AS Department,
	ISNULL(c.[Name], 'None') AS Category,
	ISNULL(r.[Description], 'None') AS [Description],
	CASE
		WHEN r.OpenDate IS NULL THEN 'None'
		ELSE FORMAT(r.OpenDate, 'dd.MM.yyyy')
	END AS OpenDate,
	ISNULL(s.[Label], 'None') AS [Status],
	ISNULL(u.[Name], 'None') AS [User]
FROM Reports r
LEFT JOIN Employees e ON r.EmployeeId = e.Id
LEFT JOIN Departments d ON e.DepartmentId = d.Id
LEFT JOIN Categories c ON r.CategoryId = c.Id
LEFT JOIN Status s ON r.StatusId = s.Id
LEFT JOIN Users u ON r.UserId = u.Id
ORDER BY e.FirstName DESC,
	e.LastName DESC,
	Department ASC,
	Category ASC,
	[Description] ASC,
	r.OpenDate ASC,
	[Status] ASC,
	[User] ASC

-- 11

CREATE OR ALTER FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF((@StartDate IS NULL) OR (@EndDate IS NULL))
		RETURN 0

	RETURN DATEDIFF(HOUR, @StartDate, @EndDate)
END

-- 12

CREATE OR ALTER PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
	DECLARE @ReportCategoryDepartmentId INT =
		(
			SELECT k.CategoryDepartmentId
			FROM
			(	
				SELECT r.[Id] AS ReportId,
					c.[DepartmentId] AS CategoryDepartmentId
				FROM Reports r
				JOIN Categories c ON r.CategoryId = c.Id
			) AS k
			WHERE k.ReportId = @ReportId
		)

	DECLARE @EmployeeDepartmentId INT = 
		(
			SELECT DepartmentId
			FROM Employees
			WHERE Id = @EmployeeId
		)

	IF (@ReportCategoryDepartmentId <> @EmployeeDepartmentId)
		THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
	SET EmployeeId = @EmployeeId
	WHERE Id = @ReportId