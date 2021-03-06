
CREATE TABLE [dbo].[tbl_Registrations](
	[RegistrationId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL CONSTRAINT [DF_tbl_Registration_UserId]  DEFAULT ((1)),
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[PhotoName] [nvarchar](50) NULL,
	[DateOfBirth] [datetime] NULL,
	[Address] [nvarchar](250) NULL,
	[Gender] [smallint] NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[Location] [nvarchar](50) NULL,
	[MobileNumber] [nvarchar](50) NULL,
	[Status] [smallint] NOT NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_tbl_Registrations_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [int] NULL,
 CONSTRAINT [PK_tbl_Registration] PRIMARY KEY CLUSTERED 
(
	[RegistrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Roles]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Roles](
	[RoleId] [smallint] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](25) NOT NULL,
	[ShortName] [nvarchar](10) NOT NULL,
	[RoleStatus] [smallint] NOT NULL,
	[SortOrder] [smallint] NULL,
	[CreatedDate] [datetime] NULL CONSTRAINT [DF_tbl_Roles_CreatedDate]  DEFAULT (getdate()),
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK__tbl_Role__D80AB4BB1992CA90] PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_RoleUserAccessMap]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_RoleUserAccessMap](
	[UserAccessId] [smallint] NOT NULL,
	[RoleId] [smallint] NOT NULL,
	[AddPermission] [bit] NOT NULL,
	[EditPermission] [bit] NOT NULL,
	[ViewPermission] [bit] NOT NULL,
	[DeletePermission] [bit] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserAccess]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserAccess](
	[UserAccessId] [smallint] IDENTITY(1,1) NOT NULL,
	[ParentId] [smallint] NOT NULL,
	[UserAccessTitle] [nvarchar](50) NULL,
	[Url] [nvarchar](250) NULL,
	[CssClass] [nvarchar](50) NULL,
	[SortOrder] [smallint] NULL,
	[UserAccessStatus] [smallint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [int] NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [int] NULL,
 CONSTRAINT [PK_tbl_UserAccess] PRIMARY KEY CLUSTERED 
(
	[UserAccessId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_UserRoleMap]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_UserRoleMap](
	[UserId] [int] NOT NULL,
	[RoleId] [smallint] NOT NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tbl_Users]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[UserStatus] [smallint] NOT NULL,
	[PasswordSalt] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL CONSTRAINT [DF_tbl_Users_UserCreatedDate]  DEFAULT (getdate()),
 CONSTRAINT [PK__tbl_User__206D91702FCF1A8A] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_Registrations] ON 

INSERT [dbo].[tbl_Registrations] ([RegistrationId], [UserId], [FirstName], [LastName], [PhotoName], [DateOfBirth], [Address], [Gender], [CountryId], [StateId], [Location], [MobileNumber], [Status], [CreatedDate], [CreatedBy]) VALUES (1, 1, N'admin', N'admin', N'af533ac3-40c4-4fb1-aff4-573466d99d26.jpg', CAST(N'2015-08-18 00:00:00.000' AS DateTime), N'address', 1, 0, 0, N'Cochin', N'12345', 1, CAST(N'2010-01-01 00:00:00.000' AS DateTime), 1)
INSERT [dbo].[tbl_Registrations] ([RegistrationId], [UserId], [FirstName], [LastName], [PhotoName], [DateOfBirth], [Address], [Gender], [CountryId], [StateId], [Location], [MobileNumber], [Status], [CreatedDate], [CreatedBy]) VALUES (2, 2, N'user n', N'user n', N'55298bfd-4804-47c0-808a-dd0e5de0dfe4.jpg', CAST(N'2015-08-23 00:00:00.000' AS DateTime), N'address', 1, 0, 0, N'Cochin', N'123456', 1, CAST(N'2010-01-01 00:00:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_Registrations] OFF
SET IDENTITY_INSERT [dbo].[tbl_Roles] ON 

INSERT [dbo].[tbl_Roles] ([RoleId], [RoleName], [ShortName], [RoleStatus], [SortOrder], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (1, N'Admin', N'Admin', 2, 1, CAST(N'2015-08-15 21:21:59.923' AS DateTime), 1, CAST(N'2015-08-21 00:08:26.213' AS DateTime), 1)
INSERT [dbo].[tbl_Roles] ([RoleId], [RoleName], [ShortName], [RoleStatus], [SortOrder], [CreatedDate], [CreatedBy], [ModifiedDate], [ModifiedBy]) VALUES (2, N'User', N'User', 2, 2, CAST(N'2015-08-15 22:59:49.103' AS DateTime), 1, CAST(N'2015-08-24 09:37:44.360' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[tbl_Roles] OFF
INSERT [dbo].[tbl_UserRoleMap] ([UserId], [RoleId]) VALUES (1, 1)
INSERT [dbo].[tbl_UserRoleMap] ([UserId], [RoleId]) VALUES (2, 2)
SET IDENTITY_INSERT [dbo].[tbl_Users] ON 

INSERT [dbo].[tbl_Users] ([UserId], [UserEmail], [Password], [UserStatus], [PasswordSalt], [CreatedDate]) VALUES (1, N'admin@gmail.com', N'hRO0v1vzxXtsblsQsSngiNycSNIpk3ko', 2, N'Uiezi+x+Bds=', CAST(N'2015-08-15 21:02:02.480' AS DateTime))
INSERT [dbo].[tbl_Users] ([UserId], [UserEmail], [Password], [UserStatus], [PasswordSalt], [CreatedDate]) VALUES (2, N'user@gmail.com', N'jXdaTFcbr45THsISJk74+/2FE77TwtKG', 2, N'v7gLua+cjpg=', CAST(N'2015-08-15 23:10:31.280' AS DateTime))
SET IDENTITY_INSERT [dbo].[tbl_Users] OFF
/****** Object:  Index [RoleUserAccessMapUniqueConstraint]    Script Date: 8/24/2015 11:08:07 AM ******/
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] ADD  CONSTRAINT [RoleUserAccessMapUniqueConstraint] UNIQUE NONCLUSTERED 
(
	[UserAccessId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [UserRoleMapUniqueConstraint]    Script Date: 8/24/2015 11:08:07 AM ******/
ALTER TABLE [dbo].[tbl_UserRoleMap] ADD  CONSTRAINT [UserRoleMapUniqueConstraint] UNIQUE NONCLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] ADD  CONSTRAINT [DF_tbl_RoleUserAccessMap_AddPermission]  DEFAULT ((0)) FOR [AddPermission]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] ADD  CONSTRAINT [DF_tbl_RoleUserAccessMap_EditPermission]  DEFAULT ((0)) FOR [EditPermission]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] ADD  CONSTRAINT [DF_tbl_RoleUserAccessMap_ViewPermission]  DEFAULT ((0)) FOR [ViewPermission]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] ADD  CONSTRAINT [DF_tbl_RoleUserAccessMap_DeletePermission]  DEFAULT ((0)) FOR [DeletePermission]
GO
ALTER TABLE [dbo].[tbl_UserAccess] ADD  CONSTRAINT [DF_tbl_UserAccess_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[tbl_Registrations]  WITH CHECK ADD  CONSTRAINT [FK_tbl_Registrations_tbl_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[tbl_Users] ([UserId])
GO
ALTER TABLE [dbo].[tbl_Registrations] CHECK CONSTRAINT [FK_tbl_Registrations_tbl_Users]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoleUserAccessMap_tbl_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tbl_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] CHECK CONSTRAINT [FK_tbl_RoleUserAccessMap_tbl_Roles]
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap]  WITH CHECK ADD  CONSTRAINT [FK_tbl_RoleUserAccessMap_tbl_UserAccess] FOREIGN KEY([UserAccessId])
REFERENCES [dbo].[tbl_UserAccess] ([UserAccessId])
GO
ALTER TABLE [dbo].[tbl_RoleUserAccessMap] CHECK CONSTRAINT [FK_tbl_RoleUserAccessMap_tbl_UserAccess]
GO
ALTER TABLE [dbo].[tbl_UserRoleMap]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserRoleMap_tbl_Roles] FOREIGN KEY([RoleId])
REFERENCES [dbo].[tbl_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[tbl_UserRoleMap] CHECK CONSTRAINT [FK_tbl_UserRoleMap_tbl_Roles]
GO
ALTER TABLE [dbo].[tbl_UserRoleMap]  WITH CHECK ADD  CONSTRAINT [FK_tbl_UserRoleMap_tbl_Users] FOREIGN KEY([UserId])
REFERENCES [dbo].[tbl_Users] ([UserId])
GO
ALTER TABLE [dbo].[tbl_UserRoleMap] CHECK CONSTRAINT [FK_tbl_UserRoleMap_tbl_Users]
GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelDelete]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelDelete]
    (
      @Flag INT ,
      @RegistrationId INT ,
      @Result INT OUTPUT
    )
AS
    BEGIN

        SET @Result = 0;
        IF ( @Flag = 3 )
            BEGIN
                DELETE  FROM tbl_Registrations
                WHERE   RegistrationId = @RegistrationId
			 
                IF ( @@ERROR = 0 )
                    SET @Result = 1
                ELSE
                    SET @Result = 0
            END
	
	
    END











GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelInsert]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelInsert] 
	-- Add the parameters for the stored procedure here
    @UserId INT ,
    @RoleId SMALLINT ,
    @FirstName NVARCHAR(50) ,
	@LastName NVARCHAR(50) ,
	@PhotoName NVARCHAR(50) ,
    @DateOfBirth DATETIME ,
    @Gender INT ,
	@CountryId INT,
	@StateId INT,
    @Location NVARCHAR(50) ,
    @MobileNumber NVARCHAR(50) ,
    @UserEmail NVARCHAR(50) ,
    @Password NVARCHAR(50) ,
	@PasswordSalt NVARCHAR(50) ,
    @Status SMALLINT ,
    @RegistrationId INT OUTPUT ,
    @Result INT OUTPUT
AS
    BEGIN

        SET @Result = 0;
        SET @RegistrationId = 0;
        IF NOT EXISTS ( SELECT  *
                        FROM    tbl_Users
                        WHERE   UserEmail = @UserEmail )
            BEGIN 
   
    -- insert to user table	FROM tbl_Registrationss TABLE		     
			     
			    
                INSERT  INTO tbl_Users
                        ( [Password] , 
						PasswordSalt,                        
                          UserEmail ,
                          UserStatus
                        )
                VALUES  ( @Password ,  
				@PasswordSalt,                       
                          @UserEmail ,
                          @Status
                        )
					
		        
                 
                SET @UserId = @@IDENTITY;  
				  
				-- Insert into user role map
				INSERT INTO tbl_UserRoleMap (UserId,
				RoleId) VALUES  ( @UserId ,@RoleId);     				
                  

    -- Insert statements for procedure here
                INSERT  INTO tbl_Registrations
                        ( UserId ,                          
                          FirstName ,
						  LastName,
						  PhotoName,                          
                          DateOfBirth ,
                          Gender ,
						   CountryId,  
						   StateId,                     
                          Location ,
                          MobileNumber ,
                         
                        
                          [Status]
	                    )
                VALUES  ( @UserId ,                         
                          @FirstName ,  
						  @LastName,
						  @PhotoName,                        
                          @DateOfBirth ,
                          @Gender ,
						  @CountryId,
						   @StateId,                        
                          @Location ,
                          @MobileNumber ,
                        
                        
                          @Status 
                         
	
	
	                    )
                IF ( @@ERROR = 0 )
                    BEGIN
                        SET @RegistrationId = @@IDENTITY;
                        SET @Result = 1;
                    END 
                ELSE
                    SET @Result = 0;
			   
            END
        ELSE
            SET @Result = -1 --  ALREADY EXIST		   
    END










GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RegistrationViewModelSelect]
    (
      @Flag INT ,
      @RegistrationId INT
    )
AS
    BEGIN
--
        IF ( @Flag = 1 )
            BEGIN
	  
                SELECT  RegistrationId ,
                        UserId ,
                        (select RoleId from tbl_UserRoleMap where 
						
						tbl_UserRoleMap.UserId= tbl_Registrations.UserId
						)RoleId ,
                        FirstName ,
						LastName,
						PhotoName,
                        DateOfBirth ,
                        Address ,
                        Gender ,
                        CountryId ,
                        StateId ,
                        Location ,
                        MobileNumber ,
                        
                     
                        Status 
                      
                FROM    tbl_Registrations
                WHERE   RegistrationId = @RegistrationId


            END
        ELSE
            IF ( @Flag = 2 ) --
                BEGIN


                    SELECT  RegistrationId ,
                            UserId ,
                              (select  RoleId from tbl_UserRoleMap where 
						
						tbl_UserRoleMap.UserId= tbl_Registrations.UserId
						)RoleId ,
                            FirstName ,
						LastName,
						PhotoName,
                            DateOfBirth ,
                            Address ,
                            Gender ,
                            CountryId ,
							 StateId ,
                            
                            Location ,
                            MobileNumber ,
                           
                          
                            Status 
                          
                    FROM    tbl_Registrations


                END
  
    END











GO
/****** Object:  StoredProcedure [dbo].[sps_RegistrationViewModelUpdate]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_RegistrationViewModelUpdate]
    (
      @Flag INT ,
      @RegistrationId INT ,
      @UserId INT ,
      @FirstName NVARCHAR(50) ,
	@LastName NVARCHAR(50) ,
	@PhotoName NVARCHAR(50) ,
    
      @DateOfBirth DATETIME ,
      @Gender NVARCHAR(50) ,
      @CountryId INT ,
      @StateId INT ,
      @Location NVARCHAR(50) ,
      @MobileNumber NVARCHAR(50) ,
     
      @Result INT OUTPUT

    )
AS
    BEGIN
        SET @Result = 0;
        IF ( @Flag = 4 )
            BEGIN 

                UPDATE  dbo.tbl_Registrations
                SET     FirstName = @FirstName ,
				LastName=@LastName,
				PhotoName= @PhotoName,
                 
                        DateOfBirth = @DateOfBirth ,
                        Gender = @Gender ,
                        CountryId = @CountryId ,
                       StateId = @StateId ,
                        Location = @Location ,
                        MobileNumber = @MobileNumber 
                     
                WHERE   RegistrationId = @RegistrationId
                IF ( @@ERROR = 0 )
                    BEGIN
				

                        SET @Result = 1;  

                    END
                ELSE
                    SET @Result = 0  
            END
	
    END











GO
/****** Object:  StoredProcedure [dbo].[sps_RoleUserAccessMapViewModelInsert]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_RoleUserAccessMapViewModelInsert]
(
    
    @RoleId SMALLINT,
	@SelectedRoleUserAccessMapXML XML,
	@Result INT OUTPUT

    
)
AS
BEGIN


 DELETE FROM tbl_RoleUserAccessMap WHERE RoleId= @RoleId;
  -- Add Handle to XML Data
				Declare @xmlDataHandle Int
				Exec sp_xml_preparedocument @xmlDataHandle Output, @SelectedRoleUserAccessMapXML
				
				Insert Into tbl_RoleUserAccessMap(UserAccessId,RoleId,AddPermission,EditPermission,ViewPermission,DeletePermission)
				Select xmlUserAccessId,
				xmlRoleId,
				xmlAddPermission,
				xmlEditPermission,
				xmlViewPermission,
				xmlDeletePermission
				 From OpenXml(@xmlDataHandle, '/BulkData/SelectedRoleUserAccessMap', 2)
				With(
						xmlUserAccessId smallint,
						xmlRoleId smallint,
						xmlAddPermission bit,
						xmlEditPermission bit,
						xmlViewPermission bit,
						xmlDeletePermission bit
												
					
					)
					
				-- Remove Handle to Free-Up Memory
				Exec sp_xml_removedocument @xmlDataHandle
				IF(@@ERROR = 0)  
			 
			    SET @Result = 1;			    
				 ELSE  
			   SET @Result = 0;
		


	
	  
		
	 
  
   
END



GO
/****** Object:  StoredProcedure [dbo].[sps_RoleUserAccessMapViewModelSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_RoleUserAccessMapViewModelSelect]
(
    @Flag INT, 
    @UserAccessId smallint,
	@RoleId smallint

    
)
AS
BEGIN
  IF (@Flag=1)
	  BEGIN

			--SELECT     RUAM.UserAccessId,

			--(  SELECT     UserAccessTitle
			--FROM         tbl_UserAccess UA WHERE UA.UserAccessId = RUAM.UserAccessId ) AS UserAccessTitle,
			--	RUAM.RoleId, RUAM.AddPermission, RUAM.EditPermission, RUAM.ViewPermission, RUAM.DeletePermission
			--FROM         tbl_RoleUserAccessMap RUAM

			SELECT     tbl_RoleUserAccessMap.UserAccessId, tbl_RoleUserAccessMap.RoleId, tbl_RoleUserAccessMap.AddPermission, tbl_RoleUserAccessMap.EditPermission, 
                      tbl_RoleUserAccessMap.ViewPermission, tbl_RoleUserAccessMap.DeletePermission, tbl_UserAccess.UserAccessTitle
FROM         tbl_RoleUserAccessMap RIGHT OUTER JOIN
                      tbl_UserAccess ON tbl_RoleUserAccessMap.UserAccessId = tbl_UserAccess.UserAccessId

			 WHERE tbl_RoleUserAccessMap.UserAccessId=@UserAccessId and tbl_RoleUserAccessMap.RoleId=@RoleId;


	
	  
		
	  END
  ELSE IF (@Flag=2)
  BEGIN
		
		--SELECT     tbl_UserAccess.UserAccessId, tbl_UserAccess.UserAccessTitle,
		-- (IIF (  tbl_RoleUserAccessMap.RoleId IS NULL , 0, tbl_RoleUserAccessMap.RoleId )) AS RoleId,
		-- (IIF (  tbl_RoleUserAccessMap.AddPermission IS NULL , convert(BIT,0), tbl_RoleUserAccessMap.AddPermission )) AS AddPermission,
		-- 	 (IIF (  tbl_RoleUserAccessMap.EditPermission IS NULL , convert(BIT,0), tbl_RoleUserAccessMap.EditPermission )) AS EditPermission,
		--	 	 (IIF (  tbl_RoleUserAccessMap.ViewPermission IS NULL , convert(BIT,0), tbl_RoleUserAccessMap.ViewPermission)) AS ViewPermission,
		--		 	 (IIF (  tbl_RoleUserAccessMap.DeletePermission IS NULL ,convert(BIT,0), DeletePermission )) AS DeletePermission

				SELECT     tbl_UserAccess.UserAccessId, tbl_UserAccess.UserAccessTitle,
		 (0) AS RoleId,
		 (convert(BIT,0)) AS AddPermission,
		 	 (convert(BIT,0)) AS EditPermission,
			 	 (convert(BIT,0)) AS ViewPermission,
				 	 (convert(BIT,0)) AS DeletePermission
		
		 
FROM         tbl_UserAccess  

  END
  ELSE  IF (@Flag=5)
	  BEGIN

	  SELECT     
UA.UserAccessTitle,
(@RoleId)AS RoleId,
UA.UserAccessId,

(IIF (
 (
SELECT RUAM.AddPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId
)
IS NULL ,convert(BIT,0), 
(
SELECT RUAM.AddPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId
)

 )) AS AddPermission,
(IIF ( 
(
SELECT RUAM.EditPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId
) IS NULL ,convert(BIT,0), 

(SELECT RUAM.EditPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId)


 )) AS EditPermission,
(IIF ( 
(
SELECT RUAM.ViewPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId

) IS NULL ,convert(BIT,0), 


(SELECT RUAM.ViewPermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId)

 )) AS ViewPermission,
(IIF ( 
(
SELECT RUAM.DeletePermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId
)
 IS NULL ,convert(BIT,0),
 
  (
SELECT RUAM.DeletePermission FROM tbl_RoleUserAccessMap RUAM WHERE 
 RUAM.UserAccessId=UA.UserAccessId AND RUAM.RoleId=@RoleId
)
  
  )) AS DeletePermission

FROM         tbl_UserAccess UA
--where( UA.UserAccessId !=1 and  UA.UserAccessId !=2 and  UA.UserAccessId !=3)

--SELECT     tbl_UserAccess.UserAccessTitle, tbl_RoleUserAccessMap.UserAccessId, tbl_RoleUserAccessMap.RoleId, tbl_RoleUserAccessMap.AddPermission, 
--                      tbl_RoleUserAccessMap.EditPermission, tbl_RoleUserAccessMap.ViewPermission, tbl_RoleUserAccessMap.DeletePermission
--FROM         tbl_UserAccess LEFT OUTER JOIN
--                      tbl_RoleUserAccessMap ON tbl_UserAccess.UserAccessId = tbl_RoleUserAccessMap.UserAccessId			 
			 
--			 WHERE  tbl_RoleUserAccessMap.RoleId=@RoleId;


	
	  
		
	  END
   
END



GO
/****** Object:  StoredProcedure [dbo].[sps_RoleViewModelDelete]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RoleViewModelDelete]
	@Flag INT,
@RoleId INT,
@Result INT OUTPUT
AS
BEGIN
	SET @Result=0;
	IF (@Flag = 3)
		BEGIN
			DELETE FROM dbo.tbl_Roles  WHERE RoleId=@RoleId 
			 
			 IF(@@ERROR =0)

				  SET @Result = 1
			 ELSE 
				  SET @Result = 0
		END
	
	
END



GO
/****** Object:  StoredProcedure [dbo].[sps_RoleViewModelInsert]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sps_RoleViewModelInsert] 
( 
@RoleName nvarchar(25),
@ShortName nvarchar(10),
@RoleStatus smallint,
@SortOrder smallint,
@CreatedBy INT,
@RoleId INT OUTPUT,
@Result INT OUTPUT
)
AS
BEGIN

SET @RoleId=0;
SET @Result=0;

 IF Not Exists (SELECT RoleName from tbl_Roles where RoleName= @RoleName )  
   BEGIN  


	INSERT INTO [dbo].[tbl_Roles]
           ([RoleName]
           ,[ShortName]
           ,[RoleStatus]
           ,[SortOrder]
           
           ,[CreatedBy])
          
           
		VALUES (@RoleName,@ShortName,@RoleStatus,@SortOrder,@CreatedBy);
			IF(@@ERROR = 0)  
			  begin
			   SET @RoleId = @@IDENTITY ; 
			   
			   
			 

			    SET @Result = 1;
			   end 
				 ELSE  
			   SET @Result = 0;
   END
   ELSE
  SET @Result = -1 -- RoleName ALREADY EXIST
 
END



GO
/****** Object:  StoredProcedure [dbo].[sps_RoleViewModelSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_RoleViewModelSelect]
(
    @Flag INT, 
    @RoleId INT
    
)
AS
BEGIN
  IF (@Flag=1)
	  BEGIN

SELECT     RoleId, RoleName, ShortName, RoleStatus, SortOrder, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM         tbl_Roles

WHERE RoleId=@RoleId

	
	  
		
	  END
  ELSE IF (@Flag=2)
  BEGIN

SELECT     RoleId, RoleName, ShortName, RoleStatus, SortOrder, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM         tbl_Roles

order by  SortOrder

  END

   ELSE IF (@Flag=5)
  BEGIN

SELECT     RoleId, RoleName, ShortName, RoleStatus, SortOrder, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM         tbl_Roles
-- where RoleId != 1            
--role  dropdown hide for admin

order by  SortOrder

  END
   
END



GO
/****** Object:  StoredProcedure [dbo].[sps_RoleViewModelUpdate]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sps_RoleViewModelUpdate]
    @Flag INT ,
    @RoleId INT  ,
    @RoleName NVARCHAR(25) ,
    @ShortName NVARCHAR(10) ,
	@SortOrder SMALLINT ,
    @RoleStatus SMALLINT ,
	@ModifiedDate DATETIME, 
	@ModifiedBy INT, 
    
    @Result INT OUTPUT
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON;

    -- Insert statements for procedure here
        UPDATE  dbo.tbl_Roles
        SET     RoleName = @RoleName ,
                ShortName = @ShortName,
				SortOrder=@SortOrder,
				RoleStatus=@RoleStatus,
				ModifiedDate=@ModifiedDate,
				ModifiedBy=@ModifiedBy
        WHERE   RoleId = @RoleId

        IF ( @@ERROR = 0 )
            BEGIN
				

                SET @Result = 1;  

            END
        ELSE
            SET @Result = 0  
    END









GO
/****** Object:  StoredProcedure [dbo].[sps_UserAccessViewModelInsert]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_UserAccessViewModelInsert] 
( 
@ParentId SMALLINT,
@UserAccessTitle nvarchar(50),
@Url nvarchar(250),
@CssClass nvarchar(50),
@SortOrder smallint,
@UserAccessStatus smallint,
@CreatedBy INT,


@UserAccessId INT OUTPUT,
@Result INT OUTPUT
)
AS
BEGIN

SET @UserAccessId=0;
SET @Result=0;

 IF Not Exists (SELECT UserAccessTitle from tbl_UserAccess where UserAccessTitle= @UserAccessTitle )  
   BEGIN  


	INSERT INTO tbl_UserAccess
          (ParentId,
		  UserAccessTitle,
		  Url,
		  CssClass,
		  SortOrder,
		  UserAccessStatus,
		   CreatedBy

		  )
          
           
		VALUES  (@ParentId,
		  @UserAccessTitle,
		  @Url,
		  @CssClass,
		  @SortOrder,
		  @UserAccessStatus,
		  @CreatedBy

		  )
			IF(@@ERROR = 0)  
			  begin
			   SET @UserAccessId = @@IDENTITY ; 
			   
			   
			 

			    SET @Result = 1;
			   end 
				 ELSE  
			   SET @Result = 0;
   END
   ELSE
  SET @Result = -1 -- UserAccessName ALREADY EXIST
 
END


GO
/****** Object:  StoredProcedure [dbo].[sps_UserAccessViewModelMenuSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sps_UserAccessViewModelMenuSelect]
(
    @Flag INT, 
    @RoleId INT,
	@Url nvarchar(250)
    
)
AS
BEGIN
  IF (@Flag=6)
	  BEGIN
			SELECT     UA.UserAccessId, UA.ParentId, UA.UserAccessTitle, UA.Url, UA.CssClass, UA.SortOrder, 
								  UA.UserAccessStatus, RUAM.RoleId, RUAM.AddPermission, RUAM.EditPermission, 
								  RUAM.ViewPermission, RUAM.DeletePermission
			FROM         tbl_UserAccess UA INNER JOIN
								  tbl_RoleUserAccessMap RUAM ON UA.UserAccessId = RUAM.UserAccessId
			 WHERE
			 RUAM.ViewPermission =1 
			 AND
			 RUAM.RoleId = @RoleId
			 ORDER BY UA.SortOrder;
		END

		 IF (@Flag=7)
	  BEGIN
			--SELECT     UA.UserAccessId, UA.ParentId, UA.UserAccessTitle, UA.Url, UA.CssClass, UA.SortOrder, 
			--					  UA.UserAccessStatus, RUAM.RoleId, RUAM.AddPermission, RUAM.EditPermission, 
			--					  RUAM.ViewPermission, RUAM.DeletePermission
			--FROM         tbl_UserAccess UA INNER JOIN
			--					  tbl_RoleUserAccessMap RUAM ON UA.UserAccessId = RUAM.UserAccessId


			SELECT     UA.UserAccessId, UA.ParentId, UA.UserAccessTitle, UA.Url, UA.CssClass, UA.SortOrder, UA.UserAccessStatus, RUAM.RoleId, RUAM.AddPermission, 
                      RUAM.EditPermission, RUAM.ViewPermission, RUAM.DeletePermission
FROM         tbl_UserAccess AS UA INNER JOIN
                      tbl_RoleUserAccessMap AS RUAM ON UA.UserAccessId = RUAM.UserAccessId INNER JOIN
                      tbl_Roles RS ON RUAM.RoleId = RS.RoleId

			 WHERE
				UA.Url=@Url 
				AND UA.UserAccessStatus =2  --STATUS
				AND RS.RoleStatus =2  --STATUS
				AND RUAM.RoleId = @RoleId
		END
   
END



GO
/****** Object:  StoredProcedure [dbo].[sps_UserAccessViewModelSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_UserAccessViewModelSelect]
(
    @Flag INT, 
    @UserAccessId INT
    
)
AS
BEGIN
  IF (@Flag=1)
	  BEGIN

SELECT     UserAccessId, ParentId, UserAccessTitle, Url, CssClass, SortOrder, UserAccessStatus, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM         tbl_UserAccess
 WHERE UserAccessId=@UserAccessId

	
	  
		
	  END
  ELSE IF (@Flag=2)
  BEGIN
SELECT     UserAccessId, ParentId, UserAccessTitle, Url, CssClass, SortOrder, UserAccessStatus, CreatedDate, CreatedBy, ModifiedDate, ModifiedBy
FROM         tbl_UserAccess order by  SortOrder
  END


  


  
   
END



GO
/****** Object:  StoredProcedure [dbo].[sps_UserAccessViewModelUpdate]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sps_UserAccessViewModelUpdate] 
( 
@ParentId SMALLINT,
@UserAccessTitle nvarchar(50),
@Url nvarchar(250),
@CssClass nvarchar(50),
@SortOrder smallint,
@UserAccessStatus smallint,



@UserAccessId INT ,
@Result INT OUTPUT
)
AS
    BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
        SET NOCOUNT ON;

    -- Insert statements for procedure here
        UPDATE  [dbo].[tbl_UserAccess]
        SET    ParentId=@ParentId ,
UserAccessTitle=@UserAccessTitle,
Url=@Url,
CssClass=@CssClass,
SortOrder=@SortOrder,
UserAccessStatus =@UserAccessStatus
        WHERE   UserAccessId = @UserAccessId

        IF ( @@ERROR = 0 )
            BEGIN
				

                SET @Result = 1;  

            END
        ELSE
            SET @Result = 0  
    END


GO
/****** Object:  StoredProcedure [dbo].[sps_UserViewModelSelect]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sps_UserViewModelSelect]
(
    @Flag INT, 
    @UserId INT,
    @UserEmail VARCHAR(50),
    @Password VARCHAR(50),
    @RoleId INT
)
AS
BEGIN


  IF (@Flag=1)
	  BEGIN
			SELECT     UserId,
			(
			SELECT     RegistrationId
			FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

			) as RegistrationId,
			(
			SELECT     PhotoName
			FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

			) as PhotoName,
			(
			select  RoleId from tbl_UserRoleMap where tbl_UserRoleMap.UserId= tbl_Users.UserId
			)RoleId ,

			(
			SELECT     tbl_Roles.RoleName
			FROM         tbl_UserRoleMap INNER JOIN
								  tbl_Roles ON tbl_UserRoleMap.RoleId = tbl_Roles.RoleId
			WHERE     (tbl_UserRoleMap.UserId = tbl_Users.UserId)
			)RoleName ,

			UserEmail, [Password], UserStatus, PasswordSalt, CreatedDate FROM tbl_Users WHERE UserID=@UserID

	  END
  ELSE IF (@Flag=2)
  BEGIN
				SELECT     UserId,
				(
				SELECT     RegistrationId
				FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

				) as RegistrationId,
				(
				SELECT     PhotoName
				FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

				) as PhotoName,

				(select  RoleId from tbl_UserRoleMap where 
						
									tbl_UserRoleMap.UserId= tbl_Users.UserId
									)RoleId ,
									(
						SELECT     tbl_Roles.RoleName
						FROM         tbl_UserRoleMap INNER JOIN
												tbl_Roles ON tbl_UserRoleMap.RoleId = tbl_Roles.RoleId
						WHERE     (tbl_UserRoleMap.UserId = tbl_Users.UserId)
						)RoleName ,
				UserEmail, [Password], UserStatus, PasswordSalt, CreatedDate FROM tbl_Users
				
  END
   ELSE IF (@Flag=6)
  BEGIN

		WITH CTEUser(UserId,RegistrationId,PhotoName,RoleId,RoleName,UserEmail, [Password], UserStatus, PasswordSalt, CreatedDate)
		as
		(

				SELECT tbl_Users.UserId,
				(
				SELECT     RegistrationId
				FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

				)  AS RegistrationId,
				(
				SELECT     PhotoName
				FROM         tbl_Registrations where tbl_Registrations.UserId=tbl_Users.UserId

				) AS PhotoName,

 
				(select  RoleId from tbl_UserRoleMap where tbl_UserRoleMap.UserId= tbl_Users.UserId
				) AS RoleId ,
				(
				SELECT     tbl_Roles.RoleName
				FROM         tbl_UserRoleMap INNER JOIN
										tbl_Roles ON tbl_UserRoleMap.RoleId = tbl_Roles.RoleId
				WHERE     (tbl_UserRoleMap.UserId = tbl_Users.UserId)
				)RoleName ,
						

				tbl_Users.UserEmail, tbl_Users.Password, tbl_Users.UserStatus, tbl_Users.PasswordSalt, tbl_Users.CreatedDate
				FROM         tbl_Users
		
				WHERE 
				tbl_Users.UserEmail=@UserEmail 	
				AND 
				tbl_Users.UserStatus=2 
		
	)
	select CTEUser.UserId,CTEUser.RegistrationId,CTEUser.PhotoName,CTEUser.RoleId,CTEUser.RoleName,CTEUser.UserEmail, CTEUser.[Password], CTEUser.UserStatus, CTEUser.PasswordSalt, CTEUser.CreatedDate from CTEUser JOIN tbl_Roles ON  CTEUser.RoleId = tbl_Roles.RoleId
	WHERE tbl_Roles.RoleStatus =2 
  END
END










GO
/****** Object:  StoredProcedure [dbo].[sps_UserViewModelUpdate]    Script Date: 8/24/2015 11:08:07 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROC [dbo].[sps_UserViewModelUpdate]  
( 
@UserId INT,
@Flag INT,
@OldPassword nvarchar(50),
@Password nvarchar(50),
@PasswordSalt NVARCHAR(50) ,
@RoleId smallint,
@UserEmail nvarchar(50),
@UserStatus smallint ,
@Result INT OUTPUT

)
AS
BEGIN
SET @Result =0;

 IF (@Flag = 5)  
	BEGIN  
	UPDATE tbl_Users SET UserStatus=@UserStatus  
		WHERE UserId = @UserId  
		 IF(@@ERROR =0)  
		SET @Result = 1;  
		 ELSE   
		SET @Result = 0  
	END  
	ELSE IF (@Flag = 7)  
	BEGIN  

	

	UPDATE tbl_Users SET [Password]=@Password,  
	 PasswordSalt=@PasswordSalt
		WHERE UserEmail = @UserEmail; --and UserStatus=1;
		 IF(@@ERROR =0)  
		SET @Result = 1;  
		 ELSE   
		SET @Result = 0    
   
	

	END  
	ELSE  IF (@Flag = 8)  
	BEGIN  
	UPDATE tbl_Users SET UserStatus=@UserStatus WHERE UserId = @UserId ;
	--update roles
	DELETE tbl_UserRoleMap WHERE UserId = @UserId ;

	 INSERT  INTO tbl_UserRoleMap (UserId,RoleId)  VALUES  (@UserId ,@RoleId)
       IF(@@ERROR =0)  
		SET @Result = 1;  
		 ELSE   
		SET @Result = 0  
	END  

END


GO
