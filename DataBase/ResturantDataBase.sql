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
[Active] [bit] NOT NULL DEFAULT 1,
CONSTRAINT [pk_EmployeeID] PRIMARY KEY ([EmployeeID] ASC), 
CONSTRAINT [ak_Email] UNIQUE ([Email] ASC)
)
GO
print '' print '*** Creating the Users table'
GO
CREATE TABLE [dbo].[Users](
	[EmployeeID] [int] NOT NULL,
	[Email] [nvarchar] (255) ,
	[PasswordHash] [nvarchar] (100) NOT NULL DEFAULT 
'5e884898da28047151d0e56f8dc6292773603d0d6aabbdd62a11ef721d1542d8',
	[Active] [bit] NOT NULL DEFAULT 1,
	CONSTRAINT [pk_EmployeeID_Password] PRIMARY KEY ([EmployeeID] ASC), 
	CONSTRAINT [ak_Email_employee] UNIQUE ([Email] ASC),
	CONSTRAINT [fk_EmployeeID_Password] FOREIGN KEY([EmployeeID])
	REFERENCES [dbo].[Employee]([EmployeeID])
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
print '' print '*** Creating the Users table'
GO

CREATE TABLE [dbo].[Products](
	[ProductID] [int] IDENTITY (100000, 1) NOT NULL,
	[Name] [nvarchar] (255) ,
	[QTY] [nvarchar] (100) NOT NULL DEFAULT '0',
	[Price] [nvarchar] (100) NOT NULL DEFAULT '0',
	[UPC] [nvarchar] (100) NOT NULL DEFAULT '0',
	CONSTRAINT [pk_Products_ProductID] PRIMARY KEY ([ProductID] ASC), 
	CONSTRAINT [ak_Products_UPC] UNIQUE ([UPC] ASC)
)
GO
print '' print '*** Inserting Products records'
GO
INSERT INTO [dbo].[Products]
([Name], [QTY], [Price], [UPC])
VALUES
('Prod1','10','100','123456789'),
('Prod2','10','200','9987654321'),
('Prod3', '10','300','678954321'),
('Prod4', '10', '400','543216789')


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

print '' print '*** Inserting users records'
GO
INSERT INTO [dbo].[users]
([EmployeeID], [Email])
VALUES
(100000,'Admin'),
(100001,'Employee'),
(100002,'leader'),
(100003,'Manager')
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
  ,@Email [nvarchar](255),@role [nvarchar] (50)
)
AS
BEGIN
	INSERT INTO [dbo].[Employee]
           ([FirstName],[LastName],[PhoneNumber],[Email])
     	VALUES
           (@FirstName, @LastName, @PhoneNumber, @Email);
	DECLARE @employeeId AS INT
	SET @employeeId = (SELECT EmployeeID FROM employee WHERE FirstName = @Firstname
				AND LastName = @Lastname AND Email = @Email);
	INSERT INTO [dbo].[EmployeeRole]
           ([EmployeeID], [RoleID])
     	VALUES
           (@employeeId, @role);
	return @@ROWCOUNT
END
GO

print '' print '*** Creating sp_select_all_employees'
GO
Create PROCEDURE [dbo].[sp_select_all_employees]
AS
	BEGIN
		SELECT EmployeeID, FirstName, LastName, PhoneNumber, Email 
		FROM employee
		WHERE Active = 1;
	END
GO

GO

print '' print '*** Creating sp_update_employee'
GO
Create PROCEDURE [dbo].[sp_update_employee](
@EmployeeId [int], @FirstName [nvarchar] (50), @LastName [nvarchar] (100), @PhoneNumber [nvarchar] (11), @Email [nvarchar] (255)
)
AS
	BEGIN
		UPDATE employee
		SET	FirstName = @FirstName,
			LastName = @LastName,
			PhoneNumber = @PhoneNumber,
			Email = @Email
		WHERE	EmployeeId = @EmployeeId	
	END
GO

print '' print '*** Creating sp_select_all_users'
GO
Create PROCEDURE [dbo].[sp_select_all_users]
AS
	BEGIN
		SELECT EmployeeID, Email, PasswordHash, Active FROM users;	
	END
GO

print '' print '*** Creating sp_active_deactive_user'
GO
Create PROCEDURE [dbo].[sp_active_deactive_user](
	@EmployeeId [int], @Email [nvarchar] (255), @Password [nvarchar] (100), @Active [bit]
)
AS
	BEGIN
		UPDATE users
		SET	Email = @Email,
			PasswordHash = @Password,
			Active = @Active
		WHERE	EmployeeId = @EmployeeId	
	END
GO

print '' print '*** Creating sp_insert_users'
GO
Create PROCEDURE [dbo].[sp_insert_users]
(@EmployeeId [int], @Email [nvarchar] (255))
AS
	BEGIN
		INSERT INTO [dbo].[users]([EmployeeId],[Email])
     		VALUES    (@EmployeeId, @Email);	
	END
GO

print '' print '*** Creating sp_select_all_roles'
GO
Create PROCEDURE [dbo].[sp_select_all_roles]
AS
	BEGIN
		SELECT RoleID FROM Role;	
	END
GO

print '' print '*** Creating sp_update_employee_role'
GO
Create PROCEDURE [dbo].[sp_update_employee_role]
(@EmployeeId [int], @RoleId [nvarchar](50))
AS
	BEGIN
		UPDATE EmployeeRole
		SET	RoleID = @RoleId
		WHERE	EmployeeId = @EmployeeId	
	END
GO

print '' print '*** Creating sp_is_autherize'
GO
Create PROCEDURE [dbo].[sp_is_autherize]
(@username [nvarchar] (255), @password [nvarchar] (100))
AS
	BEGIN
		SELECT Count(EmployeeId)
		FROM	Users
		WHERE	Email = @username
		AND	PasswordHash = @Password
		AND	Active = 1	
	END
GO

print '' print '*** Creating sp_select_employee_role'
GO
Create PROCEDURE [dbo].[sp_select_employee_role]
(@username [nvarchar] (255))
AS
	BEGIN
		DECLARE @employeeId AS INT
		SET @employeeId = (SELECT EmployeeID FROM employee WHERE Email = @username);
		SELECT RoleID
		FROM	EmployeeRole
		WHERE	EmployeeID = @employeeId	
	END
GO

print '' print '*** Creating sp_insert_product'
GO
Create PROCEDURE [dbo].[sp_insert_product]
(@Name [nvarchar](255), @QTY [nvarchar](100), @Price [nvarchar](100), @UPC [nvarchar](100))
AS
	BEGIN
		INSERT INTO [dbo].[Products]([Name], [QTY], [Price], [UPC])
     		VALUES    (@Name, @QTY, @Price, @UPC);	
	END
GO


print '' print '*** Creating sp_select_all_products'
GO
Create PROCEDURE [dbo].[sp_select_all_products]
AS
	BEGIN
		SELECT [ProductID], [Name], [QTY], [Price], [UPC]
		FROM	Products;
	END
GO
print '' print '*** Creating sp_select_product_by_id'
GO
Create PROCEDURE [dbo].[sp_select_product_by_id]
(@Id INT)
AS
	BEGIN
		SELECT [ProductID], [Name], [QTY], [Price], [UPC]
		FROM	Products
		WHERE  ProductID = @Id;
	END
GO
print '' print '*** Creating sp_update_product'
GO
Create PROCEDURE [dbo].[sp_update_product]
(@ProductID INT, @Name [nvarchar] (255), @QTY [nvarchar] (100),@Price [nvarchar] (100),@UPC [nvarchar] (100))
AS
	BEGIN
		UPDATE Products
		SET	Name = @Name, QTY = @QTY, Price = @Price, UPC = @UPC
		WHERE	ProductID = @ProductID;
	END
GO
print '' print '*** Creating sp_delete_product'
GO
Create PROCEDURE [dbo].[sp_delete_product]
(@ProductID INT)
AS
	BEGIN
		DELETE FROM Products WHERE ProductID = @ProductID;
	END
GO

print '' print '*** Creating sp_select_employee_by_id'
GO
Create PROCEDURE [dbo].[sp_select_employee_by_id]
(@EmployeeID INT)
AS
	BEGIN
		SELECT EmployeeID, FirstName, LastName, PhoneNumber, Email 
		FROM employee
		WHERE EmployeeID = @EmployeeID
		And Active = 1;
	END
GO

Create PROCEDURE [dbo].[sp_delete_employee_by_id]
(@EmployeeID INT)
AS
	BEGIN
		UPDATE employee
		SET	[Active] =0
		WHERE	EmployeeID = @EmployeeID;

	END
GO
print '' print '*** Creating sp_update_user'
GO
Create PROCEDURE [dbo].[sp_update_user]
(@EmployeeId INT, @EmailAddress [nvarchar] (255), @Password [nvarchar] (100),@Active [bit])
AS
	BEGIN
		UPDATE users
		SET	Email = @EmailAddress, PasswordHash = @Password, Active = @Active
		WHERE	EmployeeID = @EmployeeId;
	END
GO
print '' print '*** Creating sp_select_user_by_id'
GO
Create PROCEDURE [dbo].[sp_select_user_by_id]
(@Id INT)
AS
	BEGIN
		SELECT	EmployeeID, Email, PasswordHash, Active
		FROM 	users
		WHERE	EmployeeID = @Id;
	END
GO
