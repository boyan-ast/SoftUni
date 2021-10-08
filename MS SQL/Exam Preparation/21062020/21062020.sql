-- 1

CREATE TABLE Cities
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
	CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	EmployeeCount INT NOT NULL,
	BaseRate DECIMAL(10,2)
)

CREATE TABLE Rooms
(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(10, 2) NOT NULL,
	[Type] NVARCHAR(20) NOT NULL,
	Beds INT NOT NULL,
	HotelId INT REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
	Id INT PRIMARY KEY IDENTITY,
	RoomId INT REFERENCES Rooms(Id) NOT NULL,
	BookDate DATE NOT NULL,
	ArrivalDate DATE NOT NULL,
	ReturnDate DATE NOT NULL,
	CancelDate DATE,
	CONSTRAINT Chk_BookDate CHECK(BookDate < ArrivalDate),
	CONSTRAINT Chk_ArrivalDate CHECK(ArrivalDate < ReturnDate)
)

CREATE TABLE Accounts
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(50) NOT NULL,
	MiddleName NVARCHAR(20),
	LastName NVARCHAR(50) NOT NULL,
	CityId INT REFERENCES Cities(Id) NOT NULL,
	BirthDate DATE NOT NULL,
	Email VARCHAR(100) NOT NULL UNIQUE
)

CREATE TABLE AccountsTrips
(
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	TripId INT REFERENCES Trips(Id) NOT NULL,
	Luggage INT NOT NULL
		CHECK (Luggage >= 0),
	PRIMARY KEY(AccountId, TripId)
)

-- 2

INSERT INTO Accounts VALUES
('John', 'Smith', 'Smith', 34, '1975-07-21', 'j_smith@gmail.com'),
('Gosho', NULL, 'Petrov', 11, '1978-05-16', 'g_petrov@gmail.com'),
('Ivan', 'Petrovich', 'Pavlov', 59, '1849-09-26', 'i_pavlov@softuni.bg'),
('Friedrich', 'Wilhelm', 'Nietzsche', 2, '1844-10-15', 'f_nietzsche@softuni.bg');


INSERT INTO Trips VALUES
(101, '2015-04-12', '2015-04-14', '2015-04-20', '2015-02-02'),
(102, '2015-07-07', '2015-07-15', '2015-07-22', '2015-04-29'),
(103, '2013-07-17', '2013-07-23', '2013-07-24', NULL),
(104, '2012-03-17', '2012-03-31', '2012-04-01', '2012-01-10'),
(109, '2017-08-07', '2017-08-28', '2017-08-29', NULL);

-- 3

UPDATE Rooms
SET Price = Price * 1.14
WHERE HotelId IN (5, 7, 9)

-- 4

DELETE FROM AccountsTrips WHERE AccountId = 47;

-- 5

SELECT a.FirstName,
	a.LastName,
	FORMAT(a.BirthDate, 'MM-dd-yyyy') AS BirthDate,
	c.Name AS Hometown,
	a.Email
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
WHERE a.Email LIKE 'e%'
ORDER BY c.[Name]

-- 6

select c.Name,
	count(*) as Hotels
from Hotels h
join Cities c ON h.CityId = c.Id
group by c.Name
order by count(*) desc, c.Name

-- 7

SELECT k.AccountId,
	k.FullName,
	MAX(k.TripLength) AS LongestTrip,
	MIN(k.TripLength) AS ShortestTrip
FROM
(
	SELECT a.Id AS AccountId,
		CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
		t.ArrivalDate,
		t.ReturnDate,
		DATEDIFF(day, t.ArrivalDate, t.ReturnDate) AS TripLength
	FROM Trips t
	JOIN AccountsTrips ac ON t.Id = ac.TripId
	JOIN Accounts a ON ac.AccountId = a.Id
	WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
) AS k
GROUP BY k.AccountId, k.FullName
ORDER BY MAX(k.TripLength) DESC, MIN(k.TripLength)

-- 8

SELECT TOP(10)
	c.Id,
	c.[Name],
	c.CountryCode AS Country,
	COUNT(a.Id) AS Accounts
FROM Cities c
LEFT JOIN Accounts a ON c.Id = a.CityId
GROUP BY c.Id, c.[Name], c.CountryCode
ORDER BY COUNT(a.Id) DESC

-- 9

SELECT a.Id,
	a.Email,
	c.Name AS City,
	COUNT(c.Name) AS Trips
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
JOIN AccountsTrips ac ON ac.AccountId = a.Id
JOIN Trips t ON t.Id = ac.TripId
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON h.Id = r.HotelId
JOIN Cities c2 ON h.CityId = c2.Id
WHERE c.Name = c2.Name
GROUP BY a.Id, a.Email, c.Name
ORDER BY COUNT(c.Name) DESC, a.Id

-- 10

SELECT t.Id,
	CONCAT(a.FirstName, ' ', a.MiddleName, ' ', a.LastName) AS [Full Name],
	c.Name AS [From],
	c2.Name AS [To],
	CASE
		WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE CONCAT(DATEDIFF(day, t.ArrivalDate, t.ReturnDate), ' days')
	END AS Duration
FROM Trips t
JOIN AccountsTrips ac ON t.Id = ac.TripId
JOIN Accounts a ON a.Id = ac.AccountId
JOIN Cities c ON a.CityId = c.Id
JOIN Rooms r ON r.Id = t.RoomId
JOIN Hotels h ON r.HotelId = h.Id
JOIN Cities c2 ON c2.Id = h.CityId
ORDER BY [Full Name], t.Id

-- 11

CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(255)
AS
BEGIN
	DECLARE @RoomTable TABLE(RoomId INT, RoomBeds INT, RoomType VARCHAR(20), TotalPrice DECIMAL(10,2));

	INSERT INTO @RoomTable SELECT * FROM
	(
		SELECT TOP(1)
			r.Id AS RoomId,
			r.Beds AS RoomBeds,
			r.Type AS RoomType,
			((h.BaseRate + r.Price) * @People) AS TotalPrice
		FROM Hotels h
		JOIN Rooms r ON r.HotelId = h.Id
		LEFT JOIN Trips t ON t.RoomId = r.Id
		WHERE ((NOT(@Date BETWEEN t.ArrivalDate AND t.ReturnDate))
			OR t.CancelDate IS NOT NULL)
			AND h.Id = @HotelId
			AND r.Beds >= @People
		ORDER BY TotalPrice DESC
	) AS k

	DECLARE @Output VARCHAR(255);

	IF (SELECT COUNT(*) FROM @RoomTable) > 0
	BEGIN
		SET @Output = CONCAT('Room ', (SELECT TOP(1) RoomId FROM @RoomTable), ': ', 
			(SELECT TOP(1) RoomType FROM @RoomTable), ' (',
			(SELECT TOP(1) RoomBeds FROM @RoomTable), ' beds) - $',
			(SELECT TOP(1) TotalPrice FROM @RoomTable));
	END
	ELSE
	BEGIN
		SET @Output = 'No rooms available';
	END

	RETURN @Output;
END

-- 12

CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @CurrentRoomHotelId INT;

	SET @CurrentRoomHotelId =
	(
		SELECT HotelId 
		FROM Rooms 
		WHERE Id = 
			(SELECT RoomId 
			 FROM Trips 
			 WHERE Id = @TripId)
	);

	DECLARE @TargetRoomHotelId INT;

	SET @TargetRoomHotelId =
	(
		SELECT HotelId
		FROM Rooms
		WHERE Id = @TargetRoomId
	);

	IF (@CurrentRoomHotelId <> @TargetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1
	
	DECLARE @TripAccounts INT;

	SET @TripAccounts =
	(
		SELECT COUNT(*) 
		FROM Trips t
		LEFT JOIN AccountsTrips ac ON ac.TripId = t.Id
		WHERE t.Id = @TripId
	);

	DECLARE @TargetRoomBeds INT;

	SET @TargetRoomBeds =
	(
		SELECT Beds
		FROM Rooms
		WHERE Id = @TargetRoomId
	);

	IF (@TripAccounts > @TargetRoomBeds)
		THROW 50002, 'Not enough beds in target room!', 1


	UPDATE Trips 
	SET RoomId = @TargetRoomId
	WHERE Id = @TripId































