-- 1

SELECT FirstName, LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'
	
-- 2

SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 3

SELECT FirstName
FROM Employees
WHERE DepartmentID IN (3, 10) AND 
	DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
	
-- 4

SELECT 
	FirstName,
	LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 5

SELECT Name
FROM Towns
WHERE LEN(Name) = 5 OR LEN(Name) = 6
ORDER BY Name

-- 6

SELECT *
FROM Towns
WHERE SUBSTRING(Name, 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY Name

-- 7

SELECT *
FROM Towns
WHERE SUBSTRING(Name, 1, 1) LIKE '[^RBD]'
ORDER BY Name

-- 8

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName,
	LastName
FROM Employees
WHERE YEAR(HireDate) > 2000

-- 9

SELECT FirstName,
	LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10

SELECT EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER
	(
		PARTITION BY Salary
		ORDER BY EmployeeID
	) AS Rank
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11

SELECT * 
FROM
	(SELECT EmployeeID,
		FirstName,
		LastName,
		Salary,
		DENSE_RANK() OVER
		(
			PARTITION BY Salary
			ORDER BY EmployeeID
		) AS Rank
	FROM Employees
	WHERE Salary BETWEEN 10000 AND 50000) 
	AS MyTable
WHERE Rank = 2
ORDER BY Salary DESC

-- 12

SELECT CountryName AS [Country Name],
	IsoCode AS [ISO Code]
FROM Countries
WHERE 
	LEN(CountryName) - LEN(REPLACE(UPPER(CountryName), 'A', '')) >= 3
ORDER BY IsoCode

-- 13

SELECT p.PeakName,
	r.RiverName,
	LOWER(p.PeakName) + LOWER(SUBSTRING(r.RiverName, 2, LEN(r.RiverName))) AS Mix
FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName,1) = LEFT(r.RiverName,1)
ORDER BY Mix

-- 14

SELECT TOP(50) 
	[Name],
	FORMAT([Start], 'yyyy-MM-dd', 'en-US') AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], Name

-- 15

SELECT Username,
	SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email)) AS [Email Provider]
FROM Users
WHERE Email IS NOT NULL
ORDER BY [Email Provider], Username

-- 16

SELECT Username,
	IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY Username

-- 17

SELECT Name AS Game,
	CASE
		WHEN DATEPART(hour, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(hour, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(hour, [Start]) BETWEEN 18 AND 23 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration >= 4 AND Duration <= 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY Name, [Duration], [Part of the Day]

-- 18

SELECT ProductName,
	OrderDate,
	DATEADD(day, 3, OrderDate) AS [Pay Due],
	DATEADD(month, 1, OrderDate) AS [Deliver Due]
FROM Orders
