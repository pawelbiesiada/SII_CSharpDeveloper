USE Company

CREATE TABLE [dbo].[Factories]
(
	Id INT NOT NULL PRIMARY KEY,
	Localisation VARCHAR(50) NOT NULL
)
GO
--VARCHAR(10)  'Pawel'
--NVARCHAR(10) 'Paweł'

--CHAR(10)	'Pawel     '
--NCHAR(10) 'Paweł     '

CREATE TABLE [dbo].[Statuses]
(
	Id INT NOT NULL PRIMARY KEY,
	Status VARCHAR(15) NOT NULL
)
GO
CREATE TABLE [dbo].[Employees]
(
	Id INT NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	FactoryID INT NOT NULL,
	StatusID INT NOT NULL,    
	CONSTRAINT [FK_Emp_ToFactories] FOREIGN KEY ([FactoryId]) REFERENCES [Factories]([Id]),
	CONSTRAINT [FK_Emp_ToStatus] FOREIGN KEY ([StatusID]) REFERENCES [Statuses]([Id])
)
GO
CREATE TABLE [dbo].[Cars]
(
	Id INT NOT NULL PRIMARY KEY,
	Model VARCHAR(50) NOT NULL,
	RegistryPlates VARCHAR(10) NOT NULL UNIQUE,
	FactoryID INT NOT NULL,
	CONSTRAINT [FK_Cars_ToFactories] FOREIGN KEY ([FactoryId]) REFERENCES [Factories]([Id])
)
GO
CREATE TABLE [dbo].[Reservations]
(
	Id INT NOT NULL PRIMARY KEY,
	CarId INT NOT NULL,
	EmpId INT NOT NULL,
	ResDate DATE NOT NULL,
	CONSTRAINT [FK_Reservations_ToCars] FOREIGN KEY ([CarId]) REFERENCES [Cars]([Id]),
	CONSTRAINT [FK_Reservations_ToEmps] FOREIGN KEY ([EmpId]) REFERENCES [Employees]([Id])
)
GO


INSERT INTO Factories VALUES(1, 'Poznan')
INSERT INTO Factories VALUES(2, 'Wroclaw')
INSERT INTO Factories VALUES(3, 'Krakow')

INSERT INTO Statuses VALUES(1, 'Active')
INSERT INTO Statuses VALUES(2, 'InActive')
INSERT INTO Statuses VALUES(3, 'ToBeVerified')

INSERT INTO Employees VALUES(1, 'John', 1, 2)
INSERT INTO Employees VALUES(2, 'Nicole', 2, 1)
INSERT INTO Employees VALUES(3, 'Anna', 1, 3)
INSERT INTO Employees VALUES(4, 'Adam', 2, 1)

INSERT INTO Employees VALUES(5, 'Jack', 1,2)
INSERT INTO Employees VALUES(6, 'James', 1,1)
INSERT INTO Employees VALUES(7, 'William', 2,2)
INSERT INTO Employees VALUES(8, 'Liam', 2,1)
INSERT INTO Employees VALUES(9, 'Oliver', 1,1)
INSERT INTO Employees VALUES(10, 'Benjamin', 1,3)
INSERT INTO Employees VALUES(11, 'Olivia', 1,2)
INSERT INTO Employees VALUES(12, 'Mia', 2,3)

INSERT INTO Cars VALUES(1, 'Ford Focus', 'PA A1234', 1)
INSERT INTO Cars VALUES(2, 'Skoda Fabia', 'WW 1234', 2)
INSERT INTO Cars VALUES(3, 'Audi A3', 'XYZ 1111', 1)
INSERT INTO Cars VALUES(4, 'VW Polo', 'XYZ 2221', 1)
INSERT INTO Cars VALUES(5, 'Audi Q3', 'P1 FAST', 2)
INSERT INTO Cars VALUES (6, 'Mazda 3', 'ELC0421', 1);
INSERT INTO Cars VALUES (7, 'Honda Civic', 'EL2401', 2);
INSERT INTO Cars VALUES (8, 'Ford Mustang', 'GHI789', 1);
INSERT INTO Cars VALUES (9, 'Auti Q5', 'JKL012', 2);
INSERT INTO Cars VALUES (10, 'Tesla Model S', 'MNO345', 1);
INSERT INTO Cars VALUES (11, 'Fiat Panda', 'LT231', 2);


INSERT INTO Reservations VALUES(1, 5, 4, '2024-05-01')
INSERT INTO Reservations VALUES(2, 1, 1, '2024-05-01') 
INSERT INTO Reservations VALUES (3,6,1, '2024-04-04')
INSERT INTO Reservations VALUES (4,7,7, '2024-04-08')
INSERT INTO Reservations VALUES (5,8,5, '2024-04-09')
INSERT INTO Reservations VALUES (6,9,7, '2024-04-08')
INSERT INTO Reservations VALUES (7,9,7, '2024-04-07')
INSERT INTO Reservations VALUES (9,8,5, '2024-04-07')


DELETE FROM Reservations WHERE Id = 4

--'06.04.2024'
--'2024-04-06'


SELECT Id, Name, FactoryId, StatusID 
FROM Employees
WHERE StatusID IN(2,3) -- (StatusID = 2 OR StatusID = 3)

SELECT FactoryId, COUNT(FactoryID) AS 'Count'
FROM Employees
WHERE  StatusID IN(2,3) -- (StatusID = 2 OR StatusID = 3)
GROUP BY FactoryID





SELECT C.Model, C.RegistryPlates, E.Name, r.ResDate
FROM 
    Reservations R
JOIN 
    Cars C ON R.CarId = C.Id
JOIN 
    Employees E ON R.EmpId = E.Id




SELECT F.Localisation, E.Name
FROM Factories F 
LEFT JOIN Employees E
	ON E.FactoryID = F.Id
	--WHERE E.Name IS NULL
ORDER BY Localisation



--select employees with status 'Active'
select Employees.Id as 'EmpId', Employees.Name, Statuses.Status from Employees join Statuses
on Employees.StatusID = Statuses.Id
where Status = 'Active'

--select cars that are not reserved at all
SELECT C.Model, C.RegistryPlates, R.ResDate
FROM  Reservations R
FULL OUTER JOIN Cars C ON R.CarId = C.Id
WHERE R.ResDate IS NULL


--select cars and employee names that are reserved for today   ResDate =  CAST(GETDATE() AS DATE)
SELECT R.Id,  E.Name, C.Model,R.ResDate
FROM  Reservations R 
JOIN Cars C ON R.CarId = C.Id
JOIN Employees E ON R.EmpId = E.Id
WHERE R.ResDate = CAST(GETDATE() AS DATE)

GO

CREATE VIEW CurrentDayReservations
AS
	SELECT R.Id,  E.Name, C.Model,R.ResDate
	FROM  Reservations R 
	JOIN Cars C ON R.CarId = C.Id
	JOIN Employees E ON R.EmpId = E.Id
	WHERE R.ResDate = CAST(GETDATE() AS DATE)
GO


SELECT * FROM CurrentDayReservations

GO
CREATE PROCEDURE RemoveReservation
@EmpId INT,
@Date DATE
AS
	DECLARE @msg VARCHAR(100)

	IF(EXISTS(SELECT * FROM Reservations WHERE ResDate = @Date AND EmpId = @EmpId))
	BEGIN

		SET @msg = 'There is one reservation that will be deleted'

		SELECT *
		INTO #ResTemp
		FROM Reservations 
		WHERE ResDate = @Date AND EmpId = @EmpId
		
		DELETE FROM Reservations
		WHERE ResDate = @Date AND EmpId = @EmpId


		--SELECT EmpId FROM #ResTemp

		--
		--
		--
	END
	ELSE
	BEGIN
		SET @msg = 'There is no reservation for given date and employee'
	END
		
	PRINT(@msg)
GO


--EXEC RemoveReservation 7, '2024-04-07'


CREATE FUNCTION GetReservations(@day DATE)
RETURNS TABLE
AS
RETURN
	SELECT R.Id,  E.Name, C.Model,R.ResDate
	FROM  Reservations R 
	JOIN Cars C ON R.CarId = C.Id
	JOIN Employees E ON R.EmpId = E.Id
	WHERE r.ResDate = @day
GO

SELECT * FROM GetReservations('2024-04-08')


UPDATE Reservations
SET ResDate = '2024-04-08'
WHERE Id = 9


--  INSERT INTO Reservations VALUES (9,8,5, '2024-04-07')