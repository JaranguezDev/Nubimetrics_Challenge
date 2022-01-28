-- DATABASE CREATION
CREATE DATABASE		[Nubimetrics]
GO

-- TABLES CREATION
USE		[Nubimetrics]
GO

CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Nombre] [nvarchar](150) NOT NULL,
	[Apellido] [nvarchar](150) NOT NULL,
	[Email] [nvarchar](150) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	PRIMARY KEY(Id)
);
GO

-- TABLES POPULATION
INSERT INTO [dbo].[User]
           ([Id]
           ,[Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           (NEWID()
		   ,'Jonatan'
           ,'Aranguez'
           ,'jony.utn@gmail.com'
           ,'qwerty')
GO

INSERT INTO [dbo].[User]
           ([Id]
           ,[Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           (NEWID()
		   ,'Noelia'
           ,'Servi'
           ,'noelia@gmail.com'
           ,'zxcasd')
GO

INSERT INTO [dbo].[User]
           ([Id]
           ,[Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           (NEWID()
		   ,'Francesca'
           ,'Aranguez'
           ,'francesca@gmail.com'
           ,'123qwe')
GO

INSERT INTO [dbo].[User]
           ([Id]
           ,[Nombre]
           ,[Apellido]
           ,[Email]
           ,[Password])
     VALUES
           (NEWID()
		   ,'Giovanni'
           ,'Aranguez'
           ,'giovanni@gmail.com'
           ,'654ytr')
GO