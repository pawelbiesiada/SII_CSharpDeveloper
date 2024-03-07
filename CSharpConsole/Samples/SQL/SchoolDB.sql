USE [master]
GO

CREATE DATABASE [TestSchoolScript]
GO

USE [TestSchoolScript]
GO
/****** Object:  Table [dbo].[Course]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] NOT NULL,
	[CourseName] [varchar](50) NULL,
	[Location] [geography] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] NOT NULL,
	[StudentName] [varchar](50) NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StudentCourse]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[View_StudentCourse]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_StudentCourse]
AS
SELECT     dbo.Student.StudentID, dbo.Student.StudentName, dbo.Course.CourseId, dbo.Course.CourseName
FROM         dbo.Student INNER JOIN
                      dbo.StudentCourse ON dbo.Student.StudentID = dbo.StudentCourse.StudentId INNER JOIN
                      dbo.Course ON dbo.StudentCourse.CourseId = dbo.Course.CourseId

GO
/****** Object:  Table [dbo].[StudentAddress]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentAddress](
	[StudentID] [int] NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentAddress] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[TeacherType] [int] NULL,
 CONSTRAINT [PK_Teacher_1] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (1, N'Maths', NULL, 1)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (2, N'Science', NULL, 2)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (3, N'History', NULL, 3)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (4, N'English', NULL, 4)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (5, N'Spanish', NULL, 5)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (6, N'Computer Science', NULL, 6)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (1, N'Bill')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (2, N'Steve')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (3, N'James')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (4, N'Tim')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (5, N'Rama')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (6, N'Mohan')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (7, N'Merry')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (8, N'Kapil')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (9, N'Imran')
GO
INSERT [dbo].[Student] ([StudentID], [StudentName]) VALUES (10, N'Don')
GO
INSERT [dbo].[StudentAddress] ([StudentID], [Address1], [Address2], [City], [State]) VALUES (1, N'Parkview', NULL, N'Seattle', N'Washington ')
GO
INSERT [dbo].[StudentAddress] ([StudentID], [Address1], [Address2], [City], [State]) VALUES (4, N'Sepulveda', N'TSquare', N'Culver', N'California')
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (1, N'Newton', 1)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (2, N'Kalidas', 2)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (3, N'John', 1)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (4, N'James', 3)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (5, N'Ravi', 2)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (6, N'Amir', 1)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (7, N'Bjarne', 2)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (8, N'Tomy', 2)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (9, N'Chris', 1)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [TeacherType]) VALUES (10, N'Brian', 2)
GO
ALTER TABLE [dbo].[Course]  WITH NOCHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] NOCHECK CONSTRAINT [FK_Course_Teacher]
GO
ALTER TABLE [dbo].[StudentAddress]  WITH CHECK ADD  CONSTRAINT [FK_StudentAddress_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAddress] CHECK CONSTRAINT [FK_StudentAddress_Student]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
/****** Object:  StoredProcedure [dbo].[GetCoursesByStudentId]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCoursesByStudentId]
	-- Add the parameters for the stored procedure here
	@StudentId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select c.courseid, c.coursename,c.Location, c.TeacherId
from student s left outer join studentcourse sc on sc.studentid = s.studentid left outer join course c on c.courseid = sc.courseid
where s.studentid = @StudentId
END

GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteStudent]
	-- Add the parameters for the stored procedure here
	@StudentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Student]
	where StudentID = @StudentId

END

GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStudentInfo]   ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertStudentInfo]
	-- Add the parameters for the stored procedure here
	@StudentName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     INSERT INTO [SchoolDB].[dbo].[Student]
           ([StudentName])
     VALUES
           (
           @StudentName
		   )
SELECT SCOPE_IDENTITY() AS StudentId

END

GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateStudent]
	-- Add the parameters for the stored procedure here
	@StudentId int,
	@StudentName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update [SchoolDB].[dbo].[Student] 
	set StudentName = @StudentName
	where StudentID = @StudentId;

END