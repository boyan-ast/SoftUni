-- 1

CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
	SELECT FirstName,
		LastName
	FROM Employees
	WHERE Salary > 35000
	
-- 2

CREATE PROC usp_GetEmployeesSalaryAboveNumber (@MinSalary DECIMAL(18, 4))
AS
	SELECT FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @MinSalary
	
-- 3

CREATE PROC usp_GetTownsStartingWith (@StringStart NVARCHAR(MAX))
AS
	DECLARE @StartLen INT = LEN(@StringStart);

	SELECT [Name] AS Town
	FROM Towns
	WHERE LOWER(LEFT([Name], @StartLen)) = LOWER(@StringStart)
	
-- 4

CREATE PROC usp_GetEmployeesFromTown (@TownName VARCHAR(50))
AS
	SELECT e.FirstName AS [First Name],
		e.LastName AS [Last Name]
	FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	JOIN Towns t ON t.TownID= a.TownID
	WHERE t.[Name] = @TownName

-- 5

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18, 4))
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(10);
	IF (@Salary < 30000)
		SET @SalaryLevel = 'Low';
	ELSE IF (@Salary <= 50000)
		SET @SalaryLevel = 'Average';
	ELSE
		SET @SalaryLevel = 'High';
	RETURN @SalaryLevel;
END

-- 6

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@SalaryLevel VARCHAR(10))
AS
	SELECT FirstName AS [First Name],
		LastName AS [Last Name]
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel

-- 7

CREATE FUNCTION ufn_IsWordComprised (@SetOfLetters NVARCHAR(50), @Word NVARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @Count INT = 1;

	WHILE (@Count <= LEN(@Word))
	BEGIN
		DECLARE @Letter NVARCHAR(1) = SUBSTRING(@Word, @Count, 1);
		IF (CHARINDEX(@Letter, @SetOfLetters) = 0)
		BEGIN
			RETURN 0
		END

		SET @Count = @Count + 1;
	END

	RETURN 1;
END

-- 8

CREATE PROC usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
	DECLARE @DeletedEmployeeIDs TABLE
	(
		Id INT
	)

	INSERT INTO @DeletedEmployeeIDs
	SELECT e.EmployeeID
	FROM Employees e
	WHERE e.DepartmentID = @departmentId

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT NULL

	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN (SELECT Id FROM @DeletedEmployeeIDs)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT Id FROM @DeletedEmployeeIDs)

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (SELECT Id FROM @DeletedEmployeeIDs)

	DELETE
	FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE
	FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
	
-- 9

CREATE PROC usp_GetHoldersFullName
AS
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
	
-- 10

CREATE PROC usp_GetHoldersWithBalanceHigherThan (@MinSum MONEY)
AS
		SELECT FirstName AS [First Name],
			LastName AS [Last Name]
		FROM AccountHolders ah
		JOIN Accounts a ON a.AccountHolderId = ah.Id
		GROUP BY FirstName, LastName
		HAVING SUM(Balance) > @MinSum
		ORDER BY [First Name], [Last Name]


-- 11

CREATE FUNCTION ufn_CalculateFutureValue (@InitialSum DECIMAL(18,4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(18, 4)
BEGIN
	DECLARE @Result DECIMAL(18, 4);

	SET @Result = @InitialSum * POWER((1 + @YearlyInterestRate), @NumberOfYears);

	RETURN @Result;
END

-- 12

CREATE PROC usp_CalculateFutureValueForAccount (@AccountId INT, @InterestRate FLOAT)
AS
	SELECT a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.Balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders ah
	JOIN Accounts a ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
	
-- 13

CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(50))
RETURNS TABLE AS
RETURN
(
	SELECT SUM(Cash) AS SumCash
	FROM
	(
		SELECT g.[Name],
			ug.Cash,
			ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
		FROM UsersGames ug
		JOIN Games g ON g.Id = ug.GameId
		WHERE g.Name = @GameName
	) as k
	WHERE k.RowNumber % 2 = 1
)

SELECT * 
FROM dbo.ufn_CashInUsersGames('Love in a mist')