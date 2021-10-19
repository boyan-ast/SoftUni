-- 1

--CREATE DATABASE CigarShop
--GO

--USE CigarShop
--GO

CREATE TABLE Sizes
(
	Id INT PRIMARY KEY IDENTITY,
	Length INT NOT NULL,
		CHECK (Length BETWEEN 10 AND 25),
	RingRange DECIMAL(3,2) NOT NULL,
		CHECK (RingRange BETWEEN 1.5 AND 7.5)
)

CREATE TABLE Tastes
(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands
(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE NOT NULL,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars
(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT REFERENCES Brands(Id) NOT NULL,
	TastId INT REFERENCES Tastes(Id) NOT NULL,
	SizeId INT REFERENCES Sizes(Id) NOT NULL,
	PriceForSingleCigar DECIMAL(18,2) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country NVARCHAR(30) NOT NULL,
	Streat NVARCHAR(100) NOT NULL,
	ZIP VARCHAR(20) NOT NULL
)

CREATE TABLE Clients
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName NVARCHAR(30) NOT NULL,
	LastName NVARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT REFERENCES Addresses(Id) NOT NULL
)

CREATE TABLE ClientsCigars
(
	ClientId INT REFERENCES Clients(Id) NOT NULL,
	CigarId INT REFERENCES Cigars(Id) NOT NULL
	PRIMARY KEY(ClientId, CigarId)
)

-- 2

INSERT INTO Cigars (CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
('COHIBA ROBUSTO',9,1,5,15.50,'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I',9,1,10,410.00,'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE',14,5,11,7.50,'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN',14,4,15,32.00,'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES',2,3,8,85.21,'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses (Town, Country, Streat, ZIP) VALUES
('Sofia','Bulgaria','18 Bul. Vasil levski','1000'),
('Athens','Greece','4342 McDonald Avenue','10435'),
('Zagreb','Croatia','4333 Lauren Drive','10000')

-- 3

update Cigars
set PriceForSingleCigar *= 1.2

update Brands
set BrandDescription = 'New description'
where BrandDescription is null

-- 4

delete from Clients
where AddressId in (select Id
					from Addresses
					where Country like 'C%')

delete from Addresses
where Country like 'C%'

-- 5

select CigarName,
	PriceForSingleCigar,
	ImageURL
from Cigars
order by PriceForSingleCigar, CigarName desc

-- 6

select c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
from Cigars c
join Tastes t on t.Id = c.TastId
where t.TasteType in ('Earthy', 'Woody')
order by c.PriceForSingleCigar desc

-- 7

select Id,
	concat(FirstName, ' ', LastName) as ClientName,
	Email
from Clients
where Id not in (select ClientId from ClientsCigars)
order by ClientName

-- 8

select top(5) 
	c.CigarName,
	c.PriceForSingleCigar,
	c.ImageURL
from Cigars c
join Sizes s on s.Id = c.SizeId
where ((s.Length >= 12) and (c.CigarName like '%ci%' or (c.PriceForSingleCigar > 50 and s.RingRange > 2.55)))
order by c.CigarName, c.PriceForSingleCigar desc

-- 9

select concat(c.FirstName, ' ', c.LastName) as FullName,
	a.Country,
	a.ZIP,
	concat('$', MAX(ci.PriceForSingleCigar)) as CigarPrice
from Clients c
join Addresses a on a.Id = c.AddressId
join ClientsCigars cc on cc.ClientId = c.Id
join Cigars ci on ci.Id = cc.CigarId
where a.ZIP NOT LIKE '%[^0-9]%'
group by c.FirstName, c.LastName, a.Country, a.ZIP

-- 10

select c.LastName,
	AVG(s.Length) AS CiagrLength,
	CEILING(AVG(s.RingRange)) as CiagrRingRange
from Clients c
join ClientsCigars cc on cc.ClientId = c.Id
join Cigars ci on ci.Id = cc.CigarId
join Sizes s on s.Id = ci.SizeId
group by c.Id, c.LastName
ORDER BY AVG(s.Length) DESC, CiagrRingRange asc

select c.LastName,
	AVG(s.Length) AS CiagrLength,
	CEILING(AVG(s.RingRange)) as CiagrRingRange
from Clients c
join ClientsCigars cc on cc.ClientId = c.Id
join Cigars ci on ci.Id = cc.CigarId
join Sizes s on s.Id = ci.SizeId
group by c.LastName
ORDER BY AVG(s.Length) DESC

-- 11

CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
BEGIN
	RETURN 
	(
		SELECT COUNT(*)
		FROM ClientsCigars
		WHERE ClientId = 
			(
				SELECT TOP(1) Id 
				FROM Clients 
				WHERE FirstName = @name
			)
	)
END

-- 12

CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
	SELECT c.CigarName,
		CONCAT('$', c.PriceForSingleCigar) AS Price,
		t.TasteType,
		b.BrandName,
		CONCAT(s.Length, ' cm') AS CigarLength,
		CONCAT(s.RingRange, ' cm') AS CigarRingRange
	FROM Cigars c
	JOIN Tastes t ON t.Id = c.TastId
	JOIN Sizes s ON s.Id = c.SizeId
	JOIN Brands b ON b.Id = c.BrandId
	WHERE T.TasteType = @taste
	ORDER BY s.Length, s.RingRange DESC