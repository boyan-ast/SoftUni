-- 1

--CREATE DATABASE WMS
--GO

--USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId) NOT NULL,
	Status VARCHAR(11) DEFAULT 'Pending',
		CHECK (Status IN ('Pending', 'In Progress', 'Finished')),
	ClientId INT REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) NOT NULL UNIQUE
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) NOT NULL UNIQUE,
	Description VARCHAR(255),
	Price DECIMAL(6,2) NOT NULL,
		CHECK (Price > 0),
	VendorId INT REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT NOT NULL DEFAULT 0,
		CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT REFERENCES Orders(OrderId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1,
		CHECK(Quantity > 0),
	PRIMARY KEY(OrderId, PartId)
)


CREATE TABLE PartsNeeded
(
	JobId INT REFERENCES Jobs(JobId) NOT NULL,
	PartId INT REFERENCES Parts(PartId) NOT NULL,
	Quantity INT NOT NULL DEFAULT 1,
		CHECK(Quantity > 0),
	PRIMARY KEY(JobId, PartId)
)

-- 2

INSERT INTO Clients (FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal',	117.86,	2),
('W10780048', 'Suspension Rod',	42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

-- 3

UPDATE Jobs 
SET Status = 'In Progress', MechanicId = 3
WHERE Status = 'Pending'

-- 4

DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

-- 5

select concat(m.FirstName, ' ', m.LastName) as Mechanic,
	j.Status,
	j.IssueDate
from Mechanics m
join Jobs j on j.MechanicId = m.MechanicId
order by m.MechanicId, j.IssueDate, j.JobId

-- 6

select concat(c.FirstName, ' ', c.LastName) as Client,
	datediff(day, j.IssueDate, '2017-04-24') as [Days going],
	j.Status
from Clients c
join Jobs j on c.ClientId = j.ClientId
where j.Status <> 'Finished'
order by [Days going] desc, c.ClientId

-- 7

select k.Mechanic,
	AVG(k.JobDays) as [Average Days]
from
(	
	select m.MechanicId,
		concat(m.FirstName, ' ', m.LastName) as Mechanic,
		datediff(day, j.IssueDate, j.FinishDate) as JobDays
	from Mechanics m
	join Jobs j on m.MechanicId = j.MechanicId
	where FinishDate is not null
) as k
group by k.Mechanic, k.MechanicId
order by k.MechanicId

-- 8

select concat(m.FirstName, ' ', m.LastName) as Available
from Mechanics m
where MechanicId not in
	(
		select distinct MechanicId
		from Jobs 
		where Status <> 'Finished' and MechanicId is not null
	)
order by m.MechanicId

-- 9

select k.JobId,
	sum(k.PartPrice) as Total
from
(
	select j.JobId,
		isnull(p.Price * op.Quantity, 0) as PartPrice
	from Jobs j
	left join Orders o on j.JobId = o.JobId
	left join OrderParts op on o.OrderId = op.OrderId
	left join Parts p on op.PartId = p.PartId
	where FinishDate is not null
) as k
group by k.JobId
order by Total desc, k.JobId

-- 10

select *
from
(
	select p.PartId,
		p.Description,
		pn.Quantity AS Required,
		p.StockQty AS [In Stock],
		isnull(op.Quantity, 0) as Ordered
	from Jobs j
	left join PartsNeeded pn on j.JobId = pn.JobId
	left join Parts p on pn.PartId = p.PartId
	left join Orders o on o.JobId = j.JobId
	left join OrderParts op on o.OrderId = op.OrderId
	where j.Status <> 'Finished' and (o.Delivered = 0 or o.Delivered is null)
) as k
where k.Required > k.[In Stock] + k.Ordered
order by k.PartId


-- 12

CREATE FUNCTION udf_GetCost (@JobId INT)
RETURNS DECIMAL(18, 2)
BEGIN
	DECLARE @Result DECIMAL(18, 2) = 
		(
				SELECT ISNULL(SUM(p.Price * op. Quantity), 0)
				FROM Jobs j
				LEFT JOIN Orders o ON j.JobId = o.JobId
				LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
				LEFT JOIN Parts p ON op.PartId = p.PartId
				WHERE j.JobId = @JobId
		)

	RETURN @Result;
END