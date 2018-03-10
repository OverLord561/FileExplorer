use FileExplorer

--From SQL Server 2016 you can use
DROP TABLE IF EXISTS Folders

CREATE TABLE [dbo].[Folders]
(   
 [Id] int IDENTITY(1,1) NOT NULL Primary key,
 [ParentId] int FOREIGN KEY REFERENCES Folders(Id),
 [Name] nvarchar(50) NOT NULL,
 [CreationDate] Date NULL,
) ON [PRIMARY]

--Name should contain only alphabets and whitespaces
ALTER TABLE Folders
ADD CONSTRAINT only_alphabets_and_whitespaces check([NAME] NOT LIKE '%[^A-Z ]%' );
 

-- custom error 561561
EXEC sp_dropmessage 561561, @lang='us_english'; 


EXEC sp_addmessage @msgnum = 561561, @severity = 16,   
   @msgtext = N'Name should be unique per current catalogue',   
   @lang = 'us_english';
GO


-- validate name
CREATE TRIGGER [dbo].[folders_validate_name_before_insert]
	ON [dbo].[Folders]
instead of UPDATE, INSERT
AS
BEGIN
DECLARE @name nvarchar(50);
DECLARE @parentId int;
SELECT    @name = (select i.Name from inserted i);
SELECT    @parentId = (select i.ParentId from inserted i);

--unique names
if  (select top(1) COUNT(*) from [Folders] f
where f.Name = @name and f.ParentId = @parentId or f.ParentId IS NULL and @parentId is null
)> 0
begin

ROLLBACK TRANSACTION;
 
RAISERROR(561561,-1,-1);
return;

end;
else 
insert into Folders (ParentId,Name,CreationDate) select i.ParentId, i.Name,i.CreationDate from inserted i
END;
Go

declare @Creating_Digital_Images_ID int;
declare @Resources int;
declare @Evidence int;
declare @Graphic_Products int;


insert into Folders values(null,'Creating Digital Images',GETDATE());
set @Creating_Digital_Images_ID= @@IDENTITY;


insert into Folders values (@Creating_Digital_Images_ID,'Resources',DATEADD(dd, @@IDENTITY, GETDATE()));
set @Resources= @@IDENTITY;

insert into Folders values (@Creating_Digital_Images_ID,'Evidence',DATEADD(dd, @@IDENTITY, GETDATE()));
set @Evidence= @@IDENTITY;

insert into Folders values (@Creating_Digital_Images_ID,'Graphic Products',DATEADD(dd, @@IDENTITY, GETDATE()));
set @Graphic_Products= @@IDENTITY;

insert into Folders values (@Resources,'Primary Sources',DATEADD(dd, @@IDENTITY, GETDATE()));
insert into Folders values (@Resources,'Secondary Sources',DATEADD(dd, @@IDENTITY, GETDATE()));
insert into Folders values (@Graphic_Products,'Process',DATEADD(dd, @@IDENTITY, GETDATE()));
insert into Folders values (@Graphic_Products,'Final Product',DATEADD(dd, @@IDENTITY, GETDATE()));


select * from Folders