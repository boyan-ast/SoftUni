-- 1

CREATE TABLE Passports
(
	PassportID INT IDENTITY(100, 1) PRIMARY KEY,
	PassportNumber VARCHAR(10) UNIQUE
)

CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(20),
	Salary DECIMAL(7, 2),
	PassportID INT UNIQUE REFERENCES Passports(PassportID)
)

-- 2

CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(30) NOT NULL,
	EstablishedOn VARCHAR(10)
)

CREATE TABLE Models
(
	ModelID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(20) NOT NULL,
	ManufacturerID INT NOT NULL,
	CONSTRAINT FK_Models_Manufacturers
		FOREIGN KEY (ManufacturerID)
		REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Manufacturers
VALUES	
	('BMW', '07/03/1916'),
	('Tesla', '01/01/2003'),
	('Lada', '01/05/1966')

INSERT INTO Models 
VALUES 
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)
	
-- 3

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT REFERENCES Students(StudentID),
	ExamID INT REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students VALUES
	('Mila'), ('Toni'), ('Ron')

INSERT INTO Exams VALUES
	('SpringMVC'), ('Neo4j'), ('Oracle 11g')

INSERT INTO StudentsExams VALUES
	(1, 101), (1, 102), 
	(2, 101), (3, 103),
	(2, 102), (2, 103)
	
-- 4

CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	ManagerID INT REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers VALUES
	('John', NULL),
	('Maya', 106),
	('Silvia', 106),
	('Ted', 105),
	('Mark', 101),
	('Greta', 101)

-- 5

CREATE TABLE Cities
(
	CityID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Customers
(
	CustomerID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Birthday DATE,
	CityID INT REFERENCES Cities(CityID)
)

CREATE TABLE Orders
(
	OrderID INT IDENTITY PRIMARY KEY,
	CustomerID INT REFERENCES Customers(CustomerID)
)

CREATE TABLE ItemTypes
(
	ItemTypeID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE Items
(
	ItemID INT IDENTITY PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	ItemTypeID INT REFERENCES ItemTypes(ItemTypeID)
)

CREATE TABLE OrderItems
(
	OrderID INT REFERENCES Orders(OrderID) NOT NULL,
	ItemID INT REFERENCES Items(ItemID) NOT NULL,
	CONSTRAINT PK_OrderItems
	PRIMARY KEY (OrderID, ItemID)
)

-- 7

CREATE TABLE Subjects
(
	SubjectID INT IDENTITY PRIMARY KEY,
	SubjectName NVARCHAR(50) NOT NULL
)

CREATE TABLE Majors
(
	MajorID INT IDENTITY PRIMARY KEY,
	Name NVARCHAR(50) NOT NULL
)

CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	StudentNumber NVARCHAR(20) NOT NULL,
	StudentName NVARCHAR(50) NOT NULL,
	MajorID INT REFERENCES Majors(MajorID)
)

CREATE TABLE Agenda
(
	StudentID INT REFERENCES Students(StudentID) NOT NULL,
	SubjectID INT REFERENCES Subjects(SubjectID) NOT NULL,
	CONSTRAINT PK_Agenda
	PRIMARY KEY (StudentID, SubjectID)
)

CREATE TABLE Payments
(
	PaymentID INT IDENTITY PRIMARY KEY,
	PaymentDate DATETIME2,
	PaymentAmount DECIMAL,
	StudentID INT REFERENCES Students(StudentID) NOT NULL
)

-- 9

SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks AS p
	JOIN Mountains AS m ON p.MountainId = m.Id
	WHERE m.MountainRange = 'Rila'
	ORDER BY p.Elevation DESC