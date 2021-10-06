-- 1

CREATE TABLE Planets
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PlanetId INT REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	LightSpeedRate INT DEFAULT(0)
)

CREATE TABLE Colonists
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	Ucn VARCHAR(10) NOT NULL UNIQUE,
	BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
	Id INT PRIMARY KEY IDENTITY,
	JourneyStart DATETIME NOT NULL,
	JourneyEnd DATETIME NOT NULL,
	Purpose VARCHAR(11) CHECK (Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
	DestinationSpaceportId INT REFERENCES Spaceports(Id) NOT NULL,
	SpaceshipId INT REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
	Id INT PRIMARY KEY IDENTITY,
	CardNumber CHAR(10) NOT NULL UNIQUE,
	JobDuringJourney VARCHAR(8) CHECK (JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper', 'Cleaner', 'Cook')),
	ColonistId INT REFERENCES Colonists(Id) NOT NULL,
	JourneyId INT REFERENCES Journeys(Id) NOT NULL
)

-- 2

INSERT INTO Planets
VALUES
	('Mars'),
	('Earth'),
	('Jupiter'),
	('Saturn')

INSERT INTO Spaceships
VALUES 
	('Golf', 'VW', 3),
	('WakaWaka', 'Wakanda', 4),
	('Falcon9', 'SpaceX', 1),
	('Bed', 'Vidolov', 6)
	
-- 3

UPDATE Spaceships
SET LightSpeedRate = LightSpeedRate + 1
WHERE Id BETWEEN 8 AND 12

-- 4

DELETE FROM TravelCards
WHERE JourneyId IN (1, 2, 3)

DELETE FROM Journeys
WHERE Id IN (1, 2, 3)

-- 5

SELECT Id,
	FORMAT(JourneyStart, 'dd/MM/yyyy') AS JourneyStart,
	FORMAT(JourneyEnd, 'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

-- 6

SELECT c.Id AS id,
	CONCAT(c.FirstName, ' ', c.LastName) AS full_name
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.Id
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

-- 7

SELECT COUNT(*) AS [count]
FROM Colonists c
JOIN TravelCards tc ON tc.ColonistId = c.Id
JOIN Journeys j ON tc.JourneyId = j.Id
WHERE j.Purpose = 'Technical'

-- 8

SELECT s.[Name],
	s.Manufacturer
FROM Spaceships s
JOIN Journeys j ON j.SpaceshipId = s.Id
JOIN TravelCards tc ON tc.JourneyId = j.Id
JOIN Colonists c ON c.Id = tc.ColonistId
WHERE DATEDIFF(year, c.BirthDate, '2019-01-01') < 30 
	AND tc.JobDuringJourney = 'Pilot'
ORDER BY s.[Name]

-- 9

SELECT p.[Name] AS PlanetName,
	COUNT(j.Id) AS JourneysCount
FROM Planets p
JOIN Spaceports s ON s.PlanetId = p.Id
JOIN Journeys j ON j.DestinationSpaceportId = s.Id
GROUP BY p.[Name]
ORDER BY COUNT(j.Id) DESC, p.[Name]

-- 10

SELECT *
FROM
(
	SELECT tc.JobDuringJourney,
		CONCAT(c.FirstName, ' ', c.LastName) AS FullName,
		DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate) AS JobRank
	FROM Colonists c
	JOIN TravelCards tc ON tc.ColonistId = c.Id
) AS k
WHERE k.JobRank = 2

-- 11

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN 
	(
		SELECT COUNT(*)
		FROM Colonists c
		JOIN TravelCards tc ON tc.ColonistId = c.Id
		JOIN Journeys j ON tc.JourneyId = j.Id
		JOIN Spaceports s ON j.DestinationSpaceportId = s.Id
		JOIN Planets p ON s.PlanetId = p.Id
		WHERE p.[Name] = @PlanetName
	)
END

-- 12

CREATE PROC usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
	DECLARE @JourneyExists BIT;
	SET @JourneyExists = (SELECT COUNT(*) FROM Journeys WHERE Id = @JourneyId);

	IF (@JourneyExists = 0)
		THROW 50001, 'The journey does not exist!', 1;

	DECLARE @CurrentPurpose VARCHAR(11);
	SET @CurrentPurpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId);

	IF (@CurrentPurpose = @NewPurpose)
		THROW 50002, 'You cannot change the purpose!', 2

	UPDATE Journeys SET Purpose = @NewPurpose WHERE Id = @JourneyId;