CREATE TABLE dbo.People(
	PersonID int IDENTITY(1,1) PRIMARY KEY
	,FirstName nvarchar(40) NOT NULL
	,LastName nvarchar(40)  NOT NULL
	,DateOfBirth datetime  NOT NULL
	,IsManager bit  NOT NULL
	,Prefix nvarchar(6)  NOT NULL
	,Postfix nvarchar(8)  NOT NULL
	,Phone nvarchar(15)  NOT NULL
	,Email nvarchar(250)  NOT NULL
	,Homepage nvarchar(400) NOT NULL
)
GO

CREATE PROCEDURE dbo.sprocPeopleGetAll
AS
BEGIN
	SET NOCOUNT ON
	SELECT * FROM People
END
GO

CREATE PROCEDURE dbo.sprocPersonGet
@PersonID int 
AS
BEGIN
	SELECT * FROM People WHERE PersonID = @PersonID
END
GO

CREATE PROCEDURE dbo.sproc_PersonAdd
	 @FirstName nvarchar(40)
	,@LastName nvarchar(40) 
	,@DateOfBirth datetime 
	,@IsManager bit 
	,@Prefix nvarchar(6) 
	,@Postfix nvarchar(8) 
	,@Phone nvarchar(15) 
	,@Email nvarchar(250) 
	,@Homepage nvarchar(400)
AS
BEGIN
	INSERT INTO People (FirstName,LastName,DateOfBirth,IsManager,
					Prefix,Postfix,Phone,Email,Homepage) 
					VALUES(@FirstName,@LastName,@DateOfBirth,@IsManager,
					@Prefix,@Postfix,@Phone,@Email,@Homepage)
END
GO
