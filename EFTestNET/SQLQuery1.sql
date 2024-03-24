select Id, Name, Password, IsActive from users


select * from groups


SELECT u.Name as UserName, g.Name as GroupName
FROM Users u
JOIN UserGroups ug
	ON u.Id = ug.UserId
JOIN Groups g
	ON g.Id = ug.GroupId


	UPDATE Users
	SET Password = 'qaz'
	WHERE Id = 13