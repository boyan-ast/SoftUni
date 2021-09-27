-- 1

SELECT TOP(5)
	e.EmployeeID,
	e.JobTitle,
	e.AddressID AS AddressId,
	a.AddressText
FROM Employees e
JOIN Addresses a ON a.AddressID = e.AddressID
ORDER BY AddressId

-- 2

SELECT TOP(50) 
	e.FirstName,
	e.LastName,
	t.Name AS Town,
	a.AddressText
FROM Employees e
LEFT JOIN Addresses a ON a.AddressID = e.AddressID
LEFT JOIN Towns t ON t.TownID = a.TownID
ORDER BY e.FirstName ASC, LastName ASC

-- 3

SELECT e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.Name AS DepartmentName
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE d.Name = 'Sales'
ORDER BY e.EmployeeID

-- 4

SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.Name AS DepartmentName
FROM Employees e
JOIN Departments d ON d.DepartmentID = e.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5

SELECT TOP(3)
	EmployeeID,
	FirstName
FROM
	(
	SELECT e.EmployeeID,
		e.FirstName,
		ep.ProjectID
	FROM Employees e
	LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
	) AS MyTable
WHERE ProjectID IS NULL
ORDER BY EmployeeID

-- 6

SELECT e.FirstName,
	e.LastName,
	e.HireDate,
	d.Name AS DeptName
FROM Employees e
LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01'
	AND d.Name IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- 7

SELECT TOP(5)
	e.EmployeeID,
	FirstName,
	p.Name AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY EmployeeID

-- 8

SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN YEAR(p.StartDate) >= 2005 THEN NULL
		ELSE p.Name
	END AS ProjectName
FROM Employees e
JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects p ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24
ORDER BY e.EmployeeID

-- 9

SELECT e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName
FROM Employees e
JOIN Employees m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3, 7)
ORDER BY e.EmployeeID

-- 10

SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
	CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
	d.Name AS DepartmentName
FROM Employees e
LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11

SELECT TOP(1)
	AVG(Salary) AS MinAverageSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary