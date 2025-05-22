ทดสอบโปรแกรมในวงไฟฟ้าได้ที่ 172.30.7.58/devpool

1 โหลดโปรแกรม Visual Studio (ไม่ใช่ VS Code) 
2 ดับเบิ้ลคลิก Devpool/DevPool.sln  เพื่อเปิดโปรเจค
3 แก้ไข WebConfig ก่อนรัน (ส่งใน Email PMO  // เชื่อมต่อฐานข้อมูลได้ในวงไฟฟ้า)
 - server name
 - db
 - user
 - pass

หรือเอาโครงสร้าง DB ไปสร้างใหม่ ที่ท้าย Read ME

4 กดรัน   ลองเลือก index.aspx เป็น default 
5 ทำไม่ได้ติดต่อ ไลน gaf_pea  หรือ email  apptempoit@gmail.com


DATABASE และ StoreProcedure


USE [DevPool]
GO
/****** Object:  User [Surasak]    Script Date: 5/22/2025 11:44:59 PM ******/
CREATE USER [Surasak] FOR LOGIN [Surasak] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_datareader] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_denydatareader] ADD MEMBER [Surasak]
GO
ALTER ROLE [db_denydatawriter] ADD MEMBER [Surasak]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[RecipesAutoID] [int] IDENTITY(1,1) NOT NULL,
	[RecipesName] [varchar](255) NOT NULL,
	[RecipesDetail] [varchar](max) NULL,
	[RecipesTime] [int] NULL,
	[RecipesKeyword] [varchar](255) NULL,
	[RecipesLevel] [varchar](20) NULL,
	[RecipesOther] [varchar](255) NULL,
	[RecipesStatus] [varchar](1) NULL,
	[DatetimeCreate] [datetime] NULL,
	[DatetimeUpdate] [datetime] NULL,
	[RecipesPicturePath] [varchar](255) NULL,
 CONSTRAINT [PK__Recipes__8DC653EF769C504F] PRIMARY KEY CLUSTERED 
(
	[RecipesAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipesRating]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipesRating](
	[RecipesAutoID] [int] NOT NULL,
	[UserAutoID] [int] NOT NULL,
	[RecipesRating] [int] NULL,
	[DatetimeCreate] [datetime] NULL,
 CONSTRAINT [PK__RecipesR__2FAC7ED507637200] PRIMARY KEY CLUSTERED 
(
	[RecipesAutoID] ASC,
	[UserAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserAutoID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [varchar](20) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[UserFullname] [varchar](50) NULL,
	[UserEmail] [varchar](50) NULL,
	[UserTel] [varchar](20) NULL,
	[UserDetail] [varchar](255) NULL,
	[UserRole] [varchar](1) NULL,
	[UserOther] [varchar](20) NULL,
	[UserStatus] [varchar](1) NULL,
	[DatetimeCreate] [datetime] NULL,
	[DatetimeUpdate] [datetime] NULL,
 CONSTRAINT [PK__User__26A2D3AB4D7BBDE7] PRIMARY KEY CLUSTERED 
(
	[UserAutoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRole]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRole](
	[UserRoleID] [int] NOT NULL,
	[UserRoleDetail] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserRoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Recipes] ADD  CONSTRAINT [DF__Recipes__Datetim__29572725]  DEFAULT (getdate()) FOR [DatetimeCreate]
GO
ALTER TABLE [dbo].[RecipesRating] ADD  CONSTRAINT [DF__RecipesRa__Datet__2D27B809]  DEFAULT (getdate()) FOR [DatetimeCreate]
GO
ALTER TABLE [dbo].[User] ADD  CONSTRAINT [DF__User__DatetimeCr__24927208]  DEFAULT (getdate()) FOR [DatetimeCreate]
GO
ALTER TABLE [dbo].[RecipesRating]  WITH CHECK ADD  CONSTRAINT [FK__RecipesRa__Recip__2E1BDC42] FOREIGN KEY([RecipesAutoID])
REFERENCES [dbo].[Recipes] ([RecipesAutoID])
GO
ALTER TABLE [dbo].[RecipesRating] CHECK CONSTRAINT [FK__RecipesRa__Recip__2E1BDC42]
GO
ALTER TABLE [dbo].[RecipesRating]  WITH CHECK ADD  CONSTRAINT [FK__RecipesRa__UserA__2F10007B] FOREIGN KEY([UserAutoID])
REFERENCES [dbo].[User] ([UserAutoID])
GO
ALTER TABLE [dbo].[RecipesRating] CHECK CONSTRAINT [FK__RecipesRa__UserA__2F10007B]
GO
ALTER TABLE [dbo].[RecipesRating]  WITH CHECK ADD  CONSTRAINT [CK__RecipesRa__Recip__2C3393D0] CHECK  (([RecipesRating]>=(1) AND [RecipesRating]<=(5)))
GO
ALTER TABLE [dbo].[RecipesRating] CHECK CONSTRAINT [CK__RecipesRa__Recip__2C3393D0]
GO
/****** Object:  StoredProcedure [dbo].[RecipesCreate]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesCreate]
    @RecipesName VARCHAR(255),
    @RecipesDetail VARCHAR(MAX),
    @RecipesTime INT,
    @RecipesKeyword VARCHAR(255),
    @RecipesLevel VARCHAR(1),
    @RecipesOther VARCHAR(255),
    @RecipesStatus VARCHAR(1),
    @RecipesPicturePath VARCHAR(255),
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        INSERT INTO Recipes (
            RecipesName,
            RecipesDetail,
            RecipesTime,
            RecipesKeyword,
            RecipesLevel,
            RecipesOther,
            RecipesStatus,
            DatetimeCreate,
            DatetimeUpdate,
            RecipesPicturePath
        )
        VALUES (
            @RecipesName,
            @RecipesDetail,
            @RecipesTime,
            @RecipesKeyword,
            @RecipesLevel,
            @RecipesOther,
            @RecipesStatus,
            GETDATE(),
            GETDATE(),
            @RecipesPicturePath
        );

        SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;
 
GO
/****** Object:  StoredProcedure [dbo].[RecipesDelete]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesDelete]
    @RecipesAutoID INT,
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE Recipes
        SET
            RecipesStatus = '0',
            DatetimeUpdate = GETDATE()
        WHERE
            RecipesAutoID = @RecipesAutoID;

        IF @@ROWCOUNT = 0
            SET @ResultMessage = 'error: not found';
        ELSE
            SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;



GO
/****** Object:  StoredProcedure [dbo].[RecipesEdit]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesEdit]
    @RecipesAutoID INT,
    @RecipesName VARCHAR(255),
    @RecipesDetail VARCHAR(MAX),
    @RecipesTime INT,
    @RecipesKeyword VARCHAR(255),
    @RecipesLevel VARCHAR(1),
    @RecipesOther VARCHAR(255),
    @RecipesStatus VARCHAR(1),
    @RecipesPicturePath VARCHAR(255),
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        UPDATE Recipes
        SET
            RecipesName = @RecipesName,
            RecipesDetail = @RecipesDetail,
            RecipesTime = @RecipesTime,
            RecipesKeyword = @RecipesKeyword,
            RecipesLevel = @RecipesLevel,
            RecipesOther = @RecipesOther,
            RecipesStatus = @RecipesStatus,
            RecipesPicturePath = @RecipesPicturePath,
            DatetimeUpdate = GETDATE()
        WHERE
            RecipesAutoID = @RecipesAutoID;

        IF @@ROWCOUNT = 0
            SET @ResultMessage = 'error: not found';
        ELSE
            SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[RecipesGiveRating]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesGiveRating]
    @RecipesAutoID INT,
    @UserAutoID NVARCHAR(50),
    @RecipesRating INT,
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;


SELECT @UserAutoID = UserAutoID FROM [User] WHERE UserID = @UserAutoID;

IF @UserAutoID IS NULL
BEGIN
    SET @ResultMessage = 'user_not_found';
    RETURN;
END

    IF EXISTS (
        SELECT 1 FROM RecipesRating
        WHERE RecipesAutoID = @RecipesAutoID AND UserAutoID = @UserAutoID
    )
    BEGIN
        SET @ResultMessage = 'duplicate';
        RETURN;
    END

    INSERT INTO RecipesRating (
        RecipesAutoID,
        UserAutoID,
        RecipesRating,
        DatetimeCreate
    )
    VALUES (
        @RecipesAutoID,
        @UserAutoID,
        @RecipesRating,
        GETDATE()
    );

    SET @ResultMessage = 'success';
END
GO
/****** Object:  StoredProcedure [dbo].[RecipesMyself]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RecipesMyself]
    @RecipesAutoID INT,
    @UserAutoID VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath,
        ISNULL(AVG(CAST(RR.RecipesRating AS DECIMAL(5,2))), 0) AS AverageRating
    FROM Recipes R
    LEFT JOIN RecipesRating RR ON R.RecipesAutoID = RR.RecipesAutoID
    WHERE R.RecipesOther =@UserAutoID  -- เช็คเจ้าของเมนู
    GROUP BY
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath;
END;

GO
/****** Object:  StoredProcedure [dbo].[RecipesSearch]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RecipesSearch]
    @keyword NVARCHAR(255),
    @UseTime INT,
    @RecipesLevel VARCHAR(1)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath,
        ISNULL(AVG(CAST(RR.RecipesRating AS DECIMAL(5,2))), 0) AS AverageRating
    FROM Recipes R
    LEFT JOIN RecipesRating RR ON R.RecipesAutoID = RR.RecipesAutoID
    WHERE
        -- เงื่อนไข keyword (LIKE ทั้งชื่อและรายละเอียด)
        (
            @keyword = '' OR
            R.RecipesName LIKE '%' + @keyword + '%' OR
            R.RecipesDetail LIKE '%' + @keyword + '%'
        )
        -- เงื่อนไข RecipesLevel
        AND (
            @RecipesLevel = '0' OR
            R.RecipesLevel = @RecipesLevel
        )
        -- เงื่อนไขเวลา (UseTime)
        AND (
            @UseTime = 0 OR
            (@UseTime = 1 AND R.RecipesTime BETWEEN 0 AND 10) OR
            (@UseTime = 2 AND R.RecipesTime BETWEEN 11 AND 30) OR
            (@UseTime = 3 AND R.RecipesTime BETWEEN 31 AND 60) OR
            (@UseTime = 4 AND R.RecipesTime > 60)
        )
    GROUP BY
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath
    ORDER BY R.DatetimeCreate DESC;
END;

GO
/****** Object:  StoredProcedure [dbo].[RecipesShowAll]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesShowAll]
    @start NVARCHAR(10)
AS
BEGIN
    SET NOCOUNT ON;

    IF @start = 'all'
    BEGIN
        SELECT
            R.RecipesAutoID,
            R.RecipesName,
            R.RecipesDetail,
            R.RecipesTime,
            R.RecipesKeyword,
            R.RecipesLevel,
            R.RecipesOther,
            R.RecipesStatus,
            R.DatetimeCreate,
            R.DatetimeUpdate,
            R.RecipesPicturePath,
            ISNULL(AVG(CAST(RR.RecipesRating AS DECIMAL(5,2))), 0) AS AverageRating
        FROM Recipes R
        LEFT JOIN RecipesRating RR
            ON R.RecipesAutoID = RR.RecipesAutoID
        GROUP BY
            R.RecipesAutoID,
            R.RecipesName,
            R.RecipesDetail,
            R.RecipesTime,
            R.RecipesKeyword,
            R.RecipesLevel,
            R.RecipesOther,
            R.RecipesStatus,
            R.DatetimeCreate,
            R.DatetimeUpdate,
            R.RecipesPicturePath
        ORDER BY R.DatetimeCreate DESC;
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[RecipesShowDetail]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RecipesShowDetail]
    @RecipesAutoID INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath,
        ISNULL(AVG(CAST(RR.RecipesRating AS DECIMAL(5,2))), 0) AS AverageRating
    FROM Recipes R
    LEFT JOIN RecipesRating RR ON R.RecipesAutoID = RR.RecipesAutoID
    WHERE R.RecipesAutoID = @RecipesAutoID
    GROUP BY
        R.RecipesAutoID,
        R.RecipesName,
        R.RecipesDetail,
        R.RecipesTime,
        R.RecipesKeyword,
        R.RecipesLevel,
        R.RecipesOther,
        R.RecipesStatus,
        R.DatetimeCreate,
        R.DatetimeUpdate,
        R.RecipesPicturePath;
END;

GO
/****** Object:  StoredProcedure [dbo].[RecipesShowRating]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RecipesShowRating]
    @RecipesAutoID INT,
    @AverageRating DECIMAL(5,2) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT @AverageRating = 
        AVG(CAST(RecipesRating AS DECIMAL(5,2)))
    FROM RecipesRating
    WHERE RecipesAutoID = @RecipesAutoID;

    -- ถ้าไม่มีการให้คะแนนเลย ให้เป็น NULL หรือ 0
    IF @AverageRating IS NULL
        SET @AverageRating = 0;
END;

GO
/****** Object:  StoredProcedure [dbo].[UserAll]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UserAll]
    @start NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;

    IF @start = 'all'
    BEGIN
        SELECT
            UserAutoID,
            UserID,
            [Password],
            UserFullname,
            UserEmail,
            UserTel,
            UserDetail,
            UserRole,
            UserOther,
            UserStatus,
            DatetimeCreate,
            DatetimeUpdate
        FROM [User]
        ORDER BY UserAutoID DESC;
    END
    ELSE
    BEGIN
        SELECT
            UserAutoID,
            UserID,
            [Password],
            UserFullname,
            UserEmail,
            UserTel,
            UserDetail,
            UserRole,
            UserOther,
            UserStatus,
            DatetimeCreate,
            DatetimeUpdate
        FROM [User]
        WHERE UserAutoID = CAST(@start AS INT);
    END
END;

GO
/****** Object:  StoredProcedure [dbo].[UserCheckLogin]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserCheckLogin]
    @UserID VARCHAR(20),
    @Password VARCHAR(20),
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (
        SELECT 1 FROM [User]
        WHERE UserID = @UserID
          AND [Password] = @Password
          AND UserStatus = '1'  -- เฉพาะผู้ใช้ที่ยังเปิดใช้งาน
    )
    BEGIN
        SET @ResultMessage = 'success';
    END
    ELSE
    BEGIN
        SET @ResultMessage = 'false';
    END
END
GO
/****** Object:  StoredProcedure [dbo].[UserCreate]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserCreate]
    @UserID VARCHAR(20),
    @Password VARCHAR(20),
    @UserFullname VARCHAR(50),
    @UserEmail VARCHAR(50),
    @UserTel VARCHAR(20),
    @UserDetail VARCHAR(255),
    @UserRole VARCHAR(1),
    @UserOther VARCHAR(20),
    @UserStatus VARCHAR(1),
    @ResultMessage NVARCHAR(500) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- 🔍 ตรวจสอบว่า UserID ซ้ำหรือไม่
    IF EXISTS (SELECT 1 FROM [User] WHERE UserID = @UserID)
    BEGIN
        SET @ResultMessage = 'duplicate';
        RETURN;
    END

    BEGIN TRY
        INSERT INTO [User] (
            UserID,
            [Password],
            UserFullname,
            UserEmail,
            UserTel,
            UserDetail,
            UserRole,
            UserOther,
            UserStatus,
            DatetimeCreate,
            DatetimeUpdate
        )
        VALUES (
            @UserID,
            @Password,
            @UserFullname,
            @UserEmail,
            @UserTel,
            @UserDetail,
            @UserRole,
            @UserOther,
            @UserStatus,
            GETDATE(),
            GETDATE()
        );

        SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[UserDelete]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserDelete]
    @UserAutoID INT,
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- ตรวจสอบว่าผู้ใช้มีอยู่หรือไม่
    IF NOT EXISTS (
        SELECT 1 FROM [User] WHERE UserAutoID = @UserAutoID
    )
    BEGIN
        SET @ResultMessage = 'error: user not found';
        RETURN;
    END

    BEGIN TRY
        UPDATE [User]
        SET
            UserStatus = '0',
            DatetimeUpdate = GETDATE()
        WHERE
            UserAutoID = @UserAutoID;

        SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[UserEdit]    Script Date: 5/22/2025 11:44:59 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UserEdit]
    @UserAutoID INT,
    @UserID VARCHAR(20),
    @Password VARCHAR(20),
    @UserFullname VARCHAR(50),
    @UserEmail VARCHAR(50),
    @UserTel VARCHAR(20),
    @UserDetail VARCHAR(255),
    @UserRole VARCHAR(1),
    @UserOther VARCHAR(20),
    @UserStatus VARCHAR(1),
    @ResultMessage NVARCHAR(50) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- ตรวจสอบว่า UserAutoID มีอยู่จริงไหม
    IF NOT EXISTS (
        SELECT 1 FROM [User] WHERE UserAutoID = @UserAutoID
    )
    BEGIN
        SET @ResultMessage = 'error: user not found';
        RETURN;
    END

    BEGIN TRY
        UPDATE [User]
        SET
            UserID = @UserID,
            [Password] = @Password,
            UserFullname = @UserFullname,
            UserEmail = @UserEmail,
            UserTel = @UserTel,
            UserDetail = @UserDetail,
            UserRole = @UserRole,
            UserOther = @UserOther,
            UserStatus = @UserStatus,
            DatetimeUpdate = GETDATE()
        WHERE
            UserAutoID = @UserAutoID;

        SET @ResultMessage = 'success';
    END TRY
    BEGIN CATCH
        SET @ResultMessage = 'error: ' + ERROR_MESSAGE();
    END CATCH
END;

GO
