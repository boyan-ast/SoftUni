-- 1

-- CREATE DATABASE Bitbucket
-- GO

-- USE Bitbucket

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	Password VARCHAR(30) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL,
	PRIMARY KEY(RepositoryId, ContributorId)
)

CREATE TABLE Issues
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(255) NOT NULL,
	IssueStatus CHAR(6) NOT NULL,
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	AssigneeId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
	Id INT PRIMARY KEY IDENTITY,
	Message VARCHAR(255) NOT NULL,
	IssueId INT REFERENCES Issues(Id),
	RepositoryId INT REFERENCES Repositories(Id) NOT NULL,
	ContributorId INT REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
	Id INT PRIMARY KEY IDENTITY,
	Name VARCHAR(100) NOT NULL,
	Size DECIMAL(18,2) NOT NULL,
	ParentId INT REFERENCES Files(Id),
	CommitId INT REFERENCES Commits(Id) NOT NULL
)

-- 2

INSERT INTO Files (Name, Size, ParentId, CommitId) VALUES
('Trade.idk', 2598.0, 1, 1),
('menu.net', 9238.31, 2, 2),
('Administrate.soshy', 1246.93, 3, 3),
('Controller.php', 7353.15, 4, 4),
('Find.java', 9957.86, 5, 5),
('Controller.json', 14034.87, 3, 6),
('Operate.xix', 7662.92, 7, 7)


INSERT INTO Issues (Title, IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file', 'open', 1,	4),
('Typo fix in Judge.html', 'open', 4, 3),
('Implement documentation for UsersService.cs', 'closed', 8, 2),
('Unreachable code in Index.cs', 'open', 9, 8)

-- 3

UPDATE Issues SET IssueStatus = 'closed' WHERE AssigneeId = 6

-- 4

DELETE FROM RepositoriesContributors
WHERE RepositoryId = 3

DELETE FROM Issues
WHERE RepositoryId = 3

-- 5

SELECT Id,
	Message,
	RepositoryId,
	ContributorId
FROM Commits
ORDER BY Id, Message, RepositoryId, ContributorId

-- 6

SELECT Id,
	Name,
	Size
FROM Files
WHERE Size > 1000 AND Name LIKE '%html%'
ORDER BY Size DESC, Id, Name

-- 7

SELECT i.Id,
	CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues i
JOIN Users u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC, i.AssigneeId ASC

-- 8

SELECT Id, 
	Name,
	CONVERT(VARCHAR, Size) + 'KB' AS Size
FROM Files
WHERE Id NOT IN 
(
	SELECT DISTINCT ParentId
	FROM Files
	WHERE ParentId IS NOT NULL
)
ORDER BY Id, Name, Size DESC

-- 8 second way

SELECT f2.Id,
	f2.Name,
	CONVERT(VARCHAR, f2.Size) + 'KB' AS Size
FROM Files f
RIGHT JOIN Files f2 ON f.ParentId = f2.Id
WHERE f.Id IS NULL
ORDER BY f2.Id, f2.Name, f2.Size DESC


-- 9

select top(5)
	r.Id,
	r.Name,
	count(*) as Commits
from Repositories r
join Commits c on c.RepositoryId = r.Id
left join RepositoriesContributors rc on rc.RepositoryId = r.Id
group by r.Id, r.Name
order by Commits desc, r.Id, r.Name

-- 10

select u.Username,
	AVG(f.Size) as Size
from Users u
join Commits c on c.ContributorId = u.Id
join Files f on f.CommitId = c.Id
group by u.Username
order by Size desc, u.Username

-- 11

create function udf_AllUserCommits(@username VARCHAR(30))
returns int
begin
	declare @count int = 
		(
		select count(*)
		from Commits
		where ContributorId = 
			(
				select id from Users where Username = @username
			)
		)

	return @count
end

-- 12

create proc usp_SearchForFiles(@fileExtension varchar(100))
as
	select Id,
		Name,
		CONCAT(Size, 'KB') as Size
	from Files
	where name like concat('%', @fileExtension)
	order by Id, Name, Size desc
















































