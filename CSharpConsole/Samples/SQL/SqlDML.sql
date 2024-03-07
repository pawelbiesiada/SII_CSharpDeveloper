USE [SampleDb]
GO

CREATE TABLE dbo.Users
(
	Id INT NOT NULL PRIMARY KEY, --IDENTITY(1,1)
	Name NVARCHAR(50) NOT NULL,
	IsActive BIT NOT NULL,
	GroupId INT NOT NULL REFERENCES Groups(Id) -- FOREIGN KEY to another table
)
GO
CREATE INDEX iUsersName ON dbo.Users (Name)
GO
--ALTER TABLE dbo.Users ADD CONSTRAINT FK_Users_GroupId FOREIGN KEY (GroupId) REFERENCES dbo.Groups (Id)

CREATE VIEW dbo.vActiveUsers
AS
	SELECT IsActive, COUNT(*) 'Count'
	FROM Users
	GROUP BY IsActive
GO

CREATE PROCEDURE dbo.pGetUsers
@IsActive BIT
AS
BEGIN
	SELECT * FROM dbo.Users
	WHERE IsActive = @IsActive
END
GO

CREATE TRIGGER dbo.trUpdUsers
ON dbo.Users
AFTER UPDATE
AS
	IF( UPDATE(Password))
	BEGIN
		IF ((SELECT LEN(Password) FROM INSERTED) > 0)
		BEGIN
			INSERT INTO Logs
			SELECT 'Password updated for UserId: ' + Id, GETDATE() FROM INSERTED
		END
		ELSE
		BEGIN
			RAISERROR('Password must not be empty', 16, 1)
			ROLLBACK TRANSACTION
		END
	END
GO