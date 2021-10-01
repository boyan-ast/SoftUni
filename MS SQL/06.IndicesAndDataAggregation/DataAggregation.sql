-- 1

SELECT COUNT(*)
FROM WizzardDeposits

-- 2

SELECT MAX(wd.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits wd

-- 3

SELECT wd.DepositGroup,
	MAX(wd.MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits wd
GROUP BY wd.DepositGroup

-- 4

SELECT TOP(2) wd.DepositGroup
FROM WizzardDeposits wd
GROUP BY wd.DepositGroup
ORDER BY AVG(wd.MagicWandSize)

-- 5

SELECT wd.DepositGroup,
	SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits wd
GROUP BY wd.DepositGroup

-- 6

SELECT wd.DepositGroup,
	SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup

-- 7

SELECT wd.DepositGroup,
	SUM(wd.DepositAmount) AS TotalSum
FROM WizzardDeposits wd
WHERE wd.MagicWandCreator = 'Ollivander family'
GROUP BY wd.DepositGroup
HAVING SUM(wd.DepositAmount) < 150000
ORDER BY SUM(wd.DepositAmount) DESC

-- 8

SELECT DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator

-- 9

SELECT Ranges.AgeRanges,
	COUNT(*) AS WizardCount
FROM
(
	SELECT
		CASE
			WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END as AgeRanges
	FROM WizzardDeposits
) AS Ranges
GROUP BY Ranges.AgeRanges

-- 10

SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

-- 11

SELECT DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '1985-01-01'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

-- 12

SELECT SUM(d.Difference) AS SumDifference
FROM
(
	SELECT FirstName AS [Host Wizard],
		DepositAmount AS [Host Wizard Deposit],
		LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
		LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
		DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
	FROM WizzardDeposits
) AS d

-- 13

SELECT DepartmentID,
	SUM(Salary) AS TotalSalary
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14

SELECT DepartmentID,
	MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '2000-01-01'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)

-- 15

SELECT * 
INTO #EmployeesTemp
FROM Employees
WHERE Salary > 30000

DELETE FROM #EmployeesTemp
WHERE ManagerID = 42 

UPDATE #EmployeesTemp
SET Salary = Salary + 5000
WHERE DepartmentID = 1

SELECT DepartmentID,
	AVG(Salary) AS AverageSalary
FROM #EmployeesTemp
GROUP BY DepartmentID

-- 16

SELECT DepartmentID,
	MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) < 30000 OR MAX(Salary) > 70000

-- 17

SELECT COUNT(*) AS [Count]
FROM Employees
WHERE ManagerID IS NULL

-- 18

SELECT k.DepartmentID,
	k.Salary
FROM
(
	SELECT DepartmentID,
		Salary,
		DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
	FROM Employees
) AS k
WHERE k.SalaryRank = 3
GROUP BY k.DepartmentID, k.Salary

-- 19

SELECT TOP(10)
	f.FirstName,
	f.LastName,
	f.DepartmentID
FROM
(
	SELECT e.FirstName,
		e.LastName,
		e.DepartmentID,
		(k.AverageSalary - e.Salary) AS Diff
	FROM Employees e
	JOIN 
	(
		SELECT
		DepartmentID,
			AVG(Salary) AS AverageSalary
		FROM Employees
		GROUP BY DepartmentID
	) AS k ON e.DepartmentID = k.DepartmentID
) AS f
WHERE f.Diff < 0
ORDER BY f.DepartmentID