-- 1

CREATE TABLE Planes
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	Seats INT NOT NULL,
	[Range] INT NOT NULL
)

CREATE TABLE Flights
(
	Id INT PRIMARY KEY IDENTITY,
	DepartureTime DATETIME,
	ArrivalTime DATETIME,
	Origin VARCHAR(50) NOT NULL,
	Destination VARCHAR(50) NOT NULL,
	PlaneId INT REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Age INT NOT NULL,
	[Address] VARCHAR(30) NOT NULL,
	PassportId CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
	Id INT PRIMARY KEY IDENTITY,
	LuggageTypeId INT REFERENCES LuggageTypes(Id) NOT NULL,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
	Id INT PRIMARY KEY IDENTITY,
	PassengerId INT REFERENCES Passengers(Id) NOT NULL,
	FlightId INT REFERENCES Flights(Id) NOT NULL,
	LuggageId INT REFERENCES Luggages(Id) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL
)

-- 2

INSERT INTO Planes VALUES
('Airbus 336', 112,	5132),
('Airbus 330', 432,	5325),
('Boeing 369', 231,	2355),
('Stelt 297', 254,	2143),
('Boeing 338', 165,	5111),
('Airbus 558', 387,	1342),
('Boeing 128', 345,	5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')

-- 3

UPDATE Tickets
SET Price *= 1.13
WHERE FlightId = 41

-- 4

delete from Tickets
where FlightId = 30

delete from Flights
where Destination = 'Ayn Halagim'

-- 5

select *
from Planes
where Name like '%tr%'
order by Id, Name, Seats, Range

-- 6

select f.Id as FlightId,
	sum(t.Price) as Price
from Flights f
join Tickets t on t.FlightId = f.Id
group by f.Id
order by Price desc, FlightId

-- 7

select concat(p.FirstName, ' ', p.LastName) as [Full Name],
	f.Origin,
	f.Destination
from Passengers p
join Tickets t on t.PassengerId = p.Id
join Flights f on f.Id = t.FlightId
order by [Full Name], f.Origin, f.Destination

-- 8

select p.FirstName as [First Name],
	p.LastName as [Last Name],
	p.Age
from Passengers p
left join Tickets t on t.PassengerId = p.Id
group by p.FirstName, p.LastName, p.Age
having count(t.Id) = 0
order by Age desc, [First Name], [Last Name]

-- 8 second solution

select FirstName as [First Name],
	LastName as [Last Name],
	Age
from Passengers
where Id not in (select PassengerId from Tickets)
order by Age desc, [First Name], [Last Name]

-- 9

select concat(p.FirstName, ' ', p.LastName) as [Full Name],
	pl.Name as [Plane Name],
	concat(f.Origin, ' - ', f.Destination) as [Trip],
	lt.Type as [Luggage Type]
from Passengers p
join Tickets t on t.PassengerId = p.Id
join Flights f on f.Id = t.FlightId
join Planes pl on pl.Id = f.PlaneId
join Luggages l on l.Id = t.LuggageId
join LuggageTypes lt on lt.Id = l.LuggageTypeId
order by [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]

-- 10

select p.Name,
	p.Seats,
	count(t.PassengerId) as [Passengers Count]
from Planes p
left join Flights f on f.PlaneId = p.Id
left join Tickets t on t.FlightId = f.Id
group by p.Name, p.Seats
order by [Passengers Count] desc, p.Name, p.Seats

-- 11

CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
BEGIN
	DECLARE @Result VARCHAR(50);

	IF(@peopleCount <= 0)
		SET @Result = 'Invalid people count!';
	ELSE IF NOT EXISTS(SELECT Id FROM Flights WHERE (Origin = @origin AND Destination = @destination))
		SET @Result = 'Invalid flight!';
	ELSE
	BEGIN
		DECLARE @FlightId INT = (SELECT Id FROM Flights WHERE (Origin = @origin AND Destination = @destination));
		DECLARE @SingleTicketPrice DECIMAL (18,2) = (SELECT Price FROM Tickets WHERE FlightId = @FlightId);

		DECLARE @TotalSum DECIMAL(18,2) = @SingleTicketPrice * @peopleCount;
		SET @Result = CONCAT('Total price ', CONVERT(VARCHAR, @TotalSum));
	END

	RETURN @Result;
END

-- 12

CREATE PROC usp_CancelFlights
AS
	UPDATE Flights
	SET ArrivalTime = NULL, DepartureTime = NULL
	WHERE ArrivalTime > DepartureTime