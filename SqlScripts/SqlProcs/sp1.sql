USE [ContactBookDB]
GO
/****** Object:  StoredProcedure [dbo].[ContactDelete]    Script Date: 4/30/2024 7:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContactDelete] AS' 
END
GO
ALTER PROCEDURE [dbo].[ContactDelete]
@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DELETE FROM [dbo].[Contact] 
 WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[ContactInsert]    Script Date: 4/30/2024 7:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContactInsert] AS' 
END
GO
ALTER PROCEDURE [dbo].[ContactInsert]
@FirstName nvarchar(max),
@LastName nvarchar(max),
@Email nvarchar(max),
@HomePhone nvarchar(max),
@MobilePhone nvarchar(max),
@OfficePhone nvarchar(max),
@Address nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  INSERT INTO [dbo].[Contact]
           ([FirstName]
		   ,[LastName]
           ,[Email]
           ,[HomePhone]
           ,[MobilePhone]
           ,[OfficePhone]
           ,[Address])
     VALUES
           (@FirstName,
		   @LastName,
           @Email,
           @HomePhone,
           @MobilePhone,
           @OfficePhone,
           @Address)
END
GO
/****** Object:  StoredProcedure [dbo].[ContactSelect]    Script Date: 4/30/2024 7:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactSelect]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContactSelect] AS' 
END
GO
ALTER PROCEDURE [dbo].[ContactSelect]
@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Contact]

END
GO
/****** Object:  StoredProcedure [dbo].[ContactSelectById]    Script Date: 4/30/2024 7:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactSelectById]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContactSelectById] AS' 
END
GO
ALTER PROCEDURE [dbo].[ContactSelectById]
@Id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	SELECT * FROM [dbo].[Contact] 
 WHERE Id=@Id

END
GO
/****** Object:  StoredProcedure [dbo].[ContactUpdate]    Script Date: 4/30/2024 7:36:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContactUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[ContactUpdate] AS' 
END
GO
ALTER PROCEDURE [dbo].[ContactUpdate]
@Id int,
@FirstName nvarchar(max),
@LastName nvarchar(max),
@Email nvarchar(max),
@HomePhone nvarchar(max),
@MobilePhone nvarchar(max),
@OfficePhone nvarchar(max),
@Address nvarchar(max)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	UPDATE [dbo].[Contact]
   SET [FirstName] = @FirstName
	  ,[LastName] = @LastName
      ,[Email] = @Email
      ,[HomePhone] = @HomePhone
      ,[MobilePhone] = @MobilePhone
      ,[OfficePhone] = @OfficePhone
      ,[Address] = @Address
 WHERE Id=@Id

END
GO
