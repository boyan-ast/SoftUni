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