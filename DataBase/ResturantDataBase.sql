IF EXISTS(SELECT 1 FROM master.dbo.sysdatabases WHERE name = 'ResturantBD')
BEGIN
DROP DATABASE [ResturantBD]
print '' print '*** Dropping database ResturantBD'
END
GO

print '' print '*** Creating database ResturantBD'
GO 
CREATE DATABASE ResturantBD
GO

print '' print '*** Using database ResturantBD' 
GO 
USE ResturantBD
GO

print '' print'*** Creating Role table'
GO
CREATE TABLE [dbo].[Role](
[RoleID] [nvarchar] (50) NOT NULL,
[Description] [nvarchar](200),
CONSTRAINT [pk_RoleID] PRIMARY KEY ([RoleID] ASC)
)
GO

print '' print '*** Creating the Employee table'
GO
CREATE TABLE [dbo].[Employee](
[EmployeeID] [int] IDENTITY (100000, 1) NOT NULL,
[FirstName] [nvarchar] (50) NOT NULL,
[LastName] [nvarchar] (100) NOT NULL,
[PhoneNumber] [nvarchar] (11) NOT NULL,
[Email] [nvarchar] (255) ,
[PasswordHash] [nvarchar] (100) NOT NULL DEFAULT 
'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',
[Active] [bit] NOT NULL DEFAULT 1,
CONSTRAINT [pk_EmployeeID] PRIMARY KEY ([EmployeeID] ASC), 
CONSTRAINT [ak_Email] UNIQUE ([Email] ASC)
)
GO

print '' print'*** Creating EmployeeRole Table'
GO
CREATE TABLE [dbo].[EmployeeRole](
[EmployeeID] [int] NOT NULL,
[RoleID] [nvarchar](50) NOT NULL,
CONSTRAINT [pk_EmployeeID_RoleID] PRIMARY KEY ([EmployeeID] ASC, [RoleID])
)
GO

print '' print '*** Adding EmployeeRole foreign keys'
GO
ALTER TABLE [dbo].[EmployeeRole] WITH NOCHECK
ADD CONSTRAINT [fk_RoleID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role]([RoleID])
ON UPDATE CASCADE
GO

print '' print '*** Adding EmployeeID foreign keys'
GO
ALTER TABLE [dbo].[EmployeeRole] WITH NOCHECK
ADD CONSTRAINT [fk_EmployeeID] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee]([EmployeeID])
ON UPDATE CASCADE
GO

print '' print '*** Inserting Role records'
GO
INSERT INTO [dbo].[Role]
([RoleID], [Description])
VALUES
('Admin','Technolgy Support employee'),
('Employee','resturant process employee'),
('leader', 'resturant process lead'),
('Manager', 'mangement')
GO

print '' print '*** Inserting Employees records'
GO
INSERT INTO [dbo].[Employee]
([FirstName], [LastName],[PhoneNumber],[Email])
VALUES
('Admin','Admin','Admin','Admin'),
('Employee','Employee','Employee','Employee'),
('leader','leader','leader','leader'),
('Manager','Manager','Manager','Manager')
GO

print '' print '*** Inserting EmployeeRole records'
GO
INSERT INTO [dbo].[EmployeeRole]
([EmployeeID], [RoleID])
VALUES
(100000,'Admin'),
(100001,'Employee'),
(100002,'leader'),
(100003,'Manager')
GO

print '' print '*** Creating sp_add_new_employee'
GO
Create PROCEDURE [dbo].[sp_add_new_employee]
( 
  @FirstName [nvarchar](50),@LastName [nvarchar](100),@PhoneNumber [nvarchar](11)
  ,@Email [nvarchar](255),@password [nvarchar] (100),@role [nvarchar] (50)
)
AS
BEGIN
	INSERT INTO [dbo].[Employee]
           ([FirstName],[LastName],[PhoneNumber],[Email],[PasswordHash])
     	VALUES
           (@FirstName, @LastName, @PhoneNumber, @Email, @password);
	DECLARE @employeeId AS INT
	SET @employeeId = (SELECT EmployeeID FROM employee WHERE FirstName = @Firstname
				AND LastName = @Lastname AND Email = @Email);
	INSERT INTO [dbo].[EmployeeRole]
           ([EmployeeID], [RoleID])
     	VALUES
           (@employeeId, @role);
	return @@ROWCOUNT
END




