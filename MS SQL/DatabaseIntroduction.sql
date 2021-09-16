CREATE DATABASE [Minions];

CREATE TABLE Minions (
	Id int NOT NULL,
	Name varchar(50) NOT NULL,
	Age int,
	PRIMARY KEY (Id)
);

CREATE TABLE Towns (
	Id int NOT NULL,
	Name varchar(20) NOT NULL,
	PRIMARY KEY (Id)
);

ALTER TABLE Minions
ADD TownId int;

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id);

-----------------------------

-- Problem 4

INSERT INTO Towns ([Id], [Name]) VALUES (1, 'Sofia');
INSERT INTO Towns ([Id], [Name]) VALUES (2, 'Plovdiv');
INSERT INTO Towns ([Id], [Name]) VALUES (3, 'Varna');

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES (1, 'Kevin', 22, (SELECT Id FROM Towns WHERE Name = 'Sofia'));

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES (2, 'Bob', 15, (SELECT Id FROM Towns WHERE Name = 'Varna'));

INSERT INTO Minions (Id, Name, Age, TownId)
VALUES (3, 'Steward', null, (SELECT Id FROM Towns WHERE Name = 'Plovdiv'));

-----------------------------

TRUNCATE TABLE Minions;

DROP TABLE Minions;
DROP TABLE Towns;

-- Problem 7

CREATE TABLE People (
	Id int IDENTITY(1,1) NOT NULL,
	Name Nvarchar(200) NOT NULL,
	Picture varbinary(2048),
	Height numeric(18, 2),
	Weight numeric(18, 2),
	Gender char(1) NOT NULL,
	Birthdate datetime2 NOT NULL,
	Biography ntext NOT NULL,
	PRIMARY KEY (Id)
);

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Joao Silva', 0x5468697320697320612074657374, 1.834, 73, 'm',  '1990-01-12', 'Ami dobra e');
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Joazinho',null, 1.62, 62, 'm',  '1989-01-12', 'Stava');
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Pedri', null, 1.79, 70, 'm',  '1999-01-12', 'Nadejda e');
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Ronaldo', null, 1.85, 79, 'm',  '1986-01-12', 'Top');
INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES ('Gonzo', null, 1.84, 81, 'm',  '1976-01-12', 'The best');

-----------------------------

-- Problem 8

CREATE TABLE [Users] (
	[Id] BIGINT IDENTITY(1, 1) PRIMARY KEY NOT NULL,
	[Username] VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARBINARY(MAX),
	CHECK (DATALENGTH([ProfilePicture]) <= 900000),
	[LastLoginTime] DATETIME2,
	[IsDeleted] BIT NOT NULL
)

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('User1', '123', null, null, 0);

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('User2', '123', null, null, 0);

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('User3', '123', null, null, 0);

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('User4', '123', null, null, 0);

INSERT INTO [Users] ([Username], [Password], [ProfilePicture], [LastLoginTime], [IsDeleted])
VALUES ('User5', '123', null, null, 0);

-----------------------------

ALTER TABLE [Users] 
DROP CONSTRAINT [PK__Users__3214EC070C721D6A]

ALTER TABLE [Users] 
ADD CONSTRAINT [PK_Users]
PRIMARY KEY ([Id], [Username])

ALTER TABLE [Users]
ADD CONSTRAINT [CHK_PasswordLength] CHECK (DATALENGTH([Password]) > 4)

ALTER TABLE [Users]
ADD CONSTRAINT df_LastLoginTime
DEFAULT CURRENT_TIMESTAMP FOR[LastLoginTime]

ALTER TABLE [Users] 
DROP CONSTRAINT PK_Users

ALTER TABLE [Users] 
ADD CONSTRAINT [PK_Users]
PRIMARY KEY ([Id])

ALTER TABLE [Users]
ADD CONSTRAINT [CHK_Username] 
CHECK (DATALENGTH([Username]) > 2)

-----------------------------

-- Problem 13


CREATE DATABASE [Movies]

go
USE [Movies]

CREATE TABLE [Directors] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[DirectorName] VARCHAR(50) NOT NULL,
	[Notes] NTEXT
)


CREATE TABLE [Genres] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[GenreName] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
)

CREATE TABLE [Categories] (
	[Id] INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[CategoryName] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
)

CREATE TABLE [Movies] (
	[Id] INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	[Title] VARCHAR(100) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL, 
	[CopyrightYear] SMALLINT,
	[Lenght] SMALLINT,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] TINYINT,
	[Notes] NTEXT
)

INSERT INTO [Directors] ([DirectorName])
VALUES ('Director1')
INSERT INTO [Directors] ([DirectorName])
VALUES ('Director2')
INSERT INTO [Directors] ([DirectorName])
VALUES ('Director3')
INSERT INTO [Directors] ([DirectorName])
VALUES ('Director4')
INSERT INTO [Directors] ([DirectorName])
VALUES ('Director5')

INSERT INTO [Genres] ([GenreName])
VALUES ('Genre1')
INSERT INTO [Genres] ([GenreName])
VALUES ('Genre2')
INSERT INTO [Genres] ([GenreName])
VALUES ('Genre3')
INSERT INTO [Genres] ([GenreName])
VALUES ('Genre4')
INSERT INTO [Genres] ([GenreName])
VALUES ('Genre5')

INSERT INTO [Categories] ([CategoryName])
VALUES ('Category 1')
INSERT INTO [Categories] ([CategoryName])
VALUES ('Category 2')
INSERT INTO [Categories] ([CategoryName])
VALUES ('Category 3')
INSERT INTO [Categories] ([CategoryName])
VALUES ('Category 4')
INSERT INTO [Categories] ([CategoryName])
VALUES ('Category 5')


INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Lenght], [GenreId], [CategoryId], [Rating])
VALUES (
	'Movie1', 
	(SELECT [Id] FROM [Directors] WHERE [DirectorName] = 'Director2'), 
	1996, 
	100, 
	(SELECT [Id] FROM [Genres] WHERE [GenreName] = 'Genre3'),
	(SELECT [Id] FROM [Categories] WHERE [CategoryName] = 'Category 4'),
	6)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Lenght], [GenreId], [CategoryId], [Rating])
VALUES (
	'Movie2', 
	(SELECT [Id] FROM [Directors] WHERE [DirectorName] = 'Director1'), 
	1997, 
	100, 
	(SELECT [Id] FROM [Genres] WHERE [GenreName] = 'Genre1'),
	(SELECT [Id] FROM [Categories] WHERE [CategoryName] = 'Category 1'),
	6)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Lenght], [GenreId], [CategoryId], [Rating])
VALUES (
	'Movie3', 
	(SELECT [Id] FROM [Directors] WHERE [DirectorName] = 'Director3'), 
	1998, 
	100, 
	(SELECT [Id] FROM [Genres] WHERE [GenreName] = 'Genre3'),
	(SELECT [Id] FROM [Categories] WHERE [CategoryName] = 'Category 5'),
	6)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Lenght], [GenreId], [CategoryId], [Rating])
VALUES (
	'Movie4', 
	(SELECT [Id] FROM [Directors] WHERE [DirectorName] = 'Director1'), 
	1999, 
	100, 
	(SELECT [Id] FROM [Genres] WHERE [GenreName] = 'Genre2'),
	(SELECT [Id] FROM [Categories] WHERE [CategoryName] = 'Category 3'),
	6)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Lenght], [GenreId], [CategoryId], [Rating])
VALUES (
	'Movie5', 
	(SELECT [Id] FROM [Directors] WHERE [DirectorName] = 'Director5'), 
	2000, 
	100, 
	(SELECT [Id] FROM [Genres] WHERE [GenreName] = 'Genre5'),
	(SELECT [Id] FROM [Categories] WHERE [CategoryName] = 'Category 1'),
	7)
	
-----------------------------

-- Problem 14

create DATABASE [CarRental]

USE [CarRental]


CREATE TABLE [Categories] (
	Id INT IDENTITY PRIMARY KEY,
	CategoryName VARCHAR(20) NOT NULL,
	DailyRate DECIMAL NOT NULL,
	WeeklyRate DECIMAL,
	MonthlyRate DECIMAL,
	WeekendRate DECIMAL
);

CREATE TABLE [Cars] (
	Id INT IDENTITY PRIMARY KEY,
	PlateNumber VARCHAR(10) NOT NULL,
	Manufacturer VARCHAR(20),
	Model VARCHAR(20),
	CarYear SMALLINT,
	CategoryId INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	Doors TINYINT,
	Picture VARBINARY(MAX),
	Condition VARCHAR(20) NOT NULL,
	Available BIT NOT NULL
);

CREATE TABLE [Employees] (
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50),
	[Notes] NTEXT
);

CREATE TABLE [Customers] (
	[Id] INT IDENTITY PRIMARY KEY,
	[DriverLicenceNumber] VARCHAR(50) NOT NULL,
	[FullName] VARCHAR(255) NOT NULL,
	[Address] VARCHAR(255),
	[City] VARCHAR(50),
	[ZIPCode] SMALLINT,
	[Notes] NTEXT
);

CREATE TABLE [RentalOrders] (
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers]([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars]([Id]) NOT NULL,
	[TankLevel] SMALLINT NOT NULL,
	[KilometrageStart] SMALLINT,
	[KilometrageEnd] SMALLINT,
	[TotalKilometrage] SMALLINT NOT NULL,
	[StartDate] DATETIME2,
	[EndDate] DATETIME2,
	[TotalDays] SMALLINT NOT NULL,
	[RateApplied] BIT NOT NULL,
	[TaxRate] DECIMAL NOT NULL,
	[OrderStatus] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
);

INSERT INTO [Categories] 
([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES
('SUV', 50, 123.50, 1001, 200.50),
('Sedan', 150, 1123.50, 11001, 1200.50),
('Kombi', 250, 2123.50, 21001, 2200.50)

INSERT INTO [Cars] 
([PlateNumber], [Manufacturer], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Available])
VALUES
('123', 'Ford', 'Focus', 2007, 1, 5, 'Good', 1),
('234', 'Renault', 'Megane', 2004, 2, 5, 'Nice', 1),
('345', 'VW', 'Golf', 2010, 3, 5, 'Good', 1)

INSERT INTO [Employees]
([FirstName], [LastName])
VALUES
('Gosho', 'Goshev'),
('Ribo', 'Shterev'),
('Packo', 'Pacov')

INSERT INTO [Customers]
([DriverLicenceNumber], [FullName], [Address], [City])
VALUES
('100', 'Tester', 'Sv 100', 'Sevlievo'),
('101', 'Tester1', 'Sv 101', 'Sevlievo'),
('102', 'Tester2', 'Sv 102', 'Sevlievo')

INSERT INTO [RentalOrders]
([EmployeeId], [CustomerId], [CarId], [TankLevel], [TotalKilometrage], [TotalDays], [RateApplied], [TaxRate], [OrderStatus])
VALUES
(1, 2, 3, 123, 1000, 5, 1, 123.23, 'In Progress'),
(2, 2, 1, 123, 1000, 5, 1, 123.23, 'In Progress'),
(3, 3, 2, 123, 1000, 5, 1, 123.23, 'In Progress')

-------------------------------

-- Problem 15

USE master

CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees] (
	[Id] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(50),
	[Notes] NTEXT
);

INSERT INTO [Employees]
([FirstName], [LastName]) VALUES
('Test1', 'Testerov1'),
('Test2', 'Testerov2'),
('Test3', 'Testerov3')

CREATE TABLE [Customers] (
	[AccountNumber] INT IDENTITY PRIMARY KEY,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[PhoneNumber] INT NOT NULL,
	[EmergencyName] VARCHAR(50),
	[EmergencyNumber] INT,
	[Notes] NTEXT
);

INSERT INTO [Customers]
([FirstName], [LastName], [PhoneNumber]) VALUES
('Test1', 'Testerov1', 123),
('Test2', 'Testerov2', 234),
('Test3', 'Testerov3', 234)

CREATE TABLE [RoomStatus] (
	[Id] INT IDENTITY PRIMARY KEY,
	[RoomStatus] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
);

INSERT INTO [RoomStatus]
([RoomStatus]) VALUES
('Good'),
('Bad'),
('Excellent')

CREATE TABLE [RoomTypes]  (
	[Id] INT IDENTITY PRIMARY KEY,
	[RoomType] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
);

INSERT INTO [RoomTypes]
([RoomType]) VALUES
('Type1'),
('Type2'),
('Type3')

CREATE TABLE [BedTypes]  (
	[Id] INT IDENTITY PRIMARY KEY,
	[BedType] VARCHAR(20) NOT NULL,
	[Notes] NTEXT
);

INSERT INTO [BedTypes]
([BedType]) VALUES
('Type10'),
('Type20'),
('Type30')


CREATE TABLE [Rooms] (
	[Id] INT IDENTITY PRIMARY KEY,
	[RoomNumber] INT NOT NULL,
	[RoomType] INT FOREIGN KEY REFERENCES [RoomTypes]([Id]) NOT NULL,
	[BedType] INT FOREIGN KEY REFERENCES [BedTypes]([Id]) NOT NULL,
	[Rate] DECIMAL NOT NULL,
	[RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus]([Id]) NOT NULL,
	[Notes] NTEXT
);

INSERT INTO [Rooms]
([RoomNumber], [RoomType], [BedType],[Rate], [RoomStatus]) VALUES
(1, 1, 1, 100, 3),
(2, 2, 3, 200, 2),
(2, 1, 3, 300, 1)

CREATE TABLE [Payments] (
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[PaymentDate] DATETIME2,
	[AccountNumber] INT NOT NULL,
	[FirstDateOccupied] DATETIME2,
	[LastDateOccupied] DATETIME2,
	[TotalDays] SMALLINT NOT NULL,
	[AmountCharged] DECIMAL NOT NULL,
	[TaxRate] DECIMAL,
	[TaxAmount] DECIMAL NOT NULL,
	[PaymentTotal] DECIMAL NOT NULL,
	[Notes] NTEXT
)

INSERT INTO [Payments]
([EmployeeId], [AccountNumber], [TotalDays], [AmountCharged], [TaxAmount], [PaymentTotal]) VALUES
(1, 123, 234, 2423, 20, 1232),
(3, 123, 234, 2423, 20, 1232),
(1, 123, 234, 2423, 20, 1232)

CREATE TABLE [Occupancies] (
	[Id] INT IDENTITY PRIMARY KEY,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id]) NOT NULL,
	[DateOccupied] DATETIME2,
	[AccountNumber] INT NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms]([Id]) NOT NULL,
	[RateApplied] BIT NOT NULL,
	[PhoneCharge] BIT NOT NULL,
	[Notes] NTEXT
)

INSERT INTO [Occupancies]
([EmployeeId], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge]) VALUES
(1, 123, 1, 1, 0),
(2, 123, 3, 0, 0),
(3, 123, 2, 0, 1)

------------------------------------

SELECT [Name] FROM [Towns]
ORDER BY [Name]

SELECT [Name] FROM [Departments]
ORDER BY [Name]

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM [Employees]
ORDER BY [Salary] DESC

UPDATE [Employees]
SET [Salary] = [Salary] * 1.1

SELECT [Salary] FROM [Employees]

UPDATE [Payments]
SET [TaxRate] = [TaxRate] * 0.97

SELECT [TaxRate] FROM [Payments]

TRUNCATE TABLE [Occupancies]