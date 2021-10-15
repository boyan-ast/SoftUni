-- 1

CREATE TABLE Students
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(25),
	LastName NVARCHAR(30) NOT NULL,
	Age INT,
		CHECK (Age > 0),
	Address NVARCHAR(50),
	Phone NCHAR(10)
)

CREATE TABLE Subjects
(
	Id INT PRIMARY KEY IDENTITY,
	Name NVARCHAR(20) NOT NULL,
	Lessons INT NOT NULL,
		CHECK (Lessons > 0)
)

CREATE TABLE StudentsSubjects
(
	Id INT PRIMARY KEY IDENTITY,
	StudentId INT REFERENCES Students(Id) NOT NULL,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL,
	Grade DECIMAL(3,2) NOT NULL,
		CHECK (Grade >= 2 AND Grade <= 6)
)

CREATE TABLE Exams
(
	Id INT PRIMARY KEY IDENTITY,
	Date DATETIME,
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	ExamId INT REFERENCES Exams(Id) NOT NULL,
	Grade DECIMAL(3,2) NOT NULL,
		CHECK (Grade >= 2 AND Grade <= 6),
	PRIMARY KEY(StudentId, ExamId)
)

CREATE TABLE Teachers
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(20) NOT NULL,
	LastName NVARCHAR(20) NOT NULL,
	Address NVARCHAR(20) NOT NULL,
	Phone CHAR(10),
	SubjectId INT REFERENCES Subjects(Id) NOT NULL
)

CREATE TABLE StudentsTeachers
(
	StudentId INT REFERENCES Students(Id) NOT NULL,
	TeacherId INT REFERENCES Teachers(Id) NOT NULL,
	PRIMARY KEY(StudentId, TeacherId)
)

-- 2

INSERT INTO Teachers (FirstName, LastName, Address, Phone, SubjectId) VALUES
('Ruthanne','Bamb','84948 Mesta Junction','3105500146',6),
('Gerrard','Lowin','370 Talisman Plaza','3324874824',2),
('Merrile','Lambdin','81 Dahle Plaza','4373065154',5),
('Bert','Ivie','2 Gateway Circle','4409584510',4)

INSERT INTO Subjects (Name, Lessons) VALUES
('Geometry',12),
('Health',10),
('Drama',7),
('Sports',9)

-- 3

UPDATE StudentsSubjects
SET Grade = 6.00
WHERE SubjectId IN (1, 2) and Grade >= 5.50

-- 4

DELETE FROM StudentsTeachers
WHERE TeacherId IN (SELECT Id FROM Teachers WHERE Phone LIKE '%72%')

DELETE FROM Teachers
WHERE Phone LIKE '%72%'

-- 5

SELECT FirstName,
	LastName,
	Age
FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName, Age

-- 6

SELECT s.FirstName,
	s.LastName,
	COUNT(DISTINCT st.TeacherId) AS TeachersCount 
FROM Students s
LEFT JOIN StudentsTeachers st ON st.StudentId = s.Id
GROUP BY s.FirstName, s.LastName

-- 7

SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
FROM Students
WHERE Id NOT IN (SELECT StudentId FROM StudentsExams)
ORDER BY [Full Name]