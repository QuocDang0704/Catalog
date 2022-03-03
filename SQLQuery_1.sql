CREATE DATABASE CATALOG
go
USE CATALOG
go
-- Create a new table called '[TableName]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('Item') IS NOT NULL
DROP TABLE [dbo].[Item]
GO
-- Create the table in the specified schema
CREATE TABLE Item
(
    Id NVARCHAR(50) NOT NULL, 
    Name NVARCHAR(50) NOT NULL,
    Price DECIMAL NOT NULL,
    DateTimeOffset DATETIME
);
GO
-- Select rows from a Table or View '[TableOrViewName]' in schema '[dbo]'
SELECT * FROM [dbo].[Item]
GO

INSERT INTO [dbo].[Item]
( 
 [Id], [Name], [Price], [DateTimeOffset]
)
VALUES
 ('abcd', 'quoc', 8.9, '2022-05-07'
),
 ('abcde', 'quoc', 8.9, '2022-05-07'
)
-- Add more rows here
GO
IF OBJECT_ID('POC_IN') IS NOT NULL
	DROP PROCEDURE POC_IN
go
CREATE PROCEDURE POC_IN
@json NVARCHAR(max)
AS
BEGIN
INSERT INTO dbo.Item ([Id], [Name], [Price], [DateTimeOffset])
SELECT Id, Name, Price, DateTimeOffset
FROM OPENJSON(@json)
WITH (
	Id NVARCHAR(50) '$.Id',
	Name NVARCHAR(50) '$.Name',
	Price DECIMAL '$.Price',
	DateTimeOffset DATETIME '$.DateTimeOffset') AS jsonValues
END
GO

EXEC dbo.POC_IN @json = N'[ 
	{"Id": "quoc123","Name": "quoc"  ,  "Price": 8.9, "DateTimeOffset": "2022-02-20"},
	{"Id": "quoc1234","Name": "quoc12",  "Price": 10.2, "DateTimeOffset": "2022-02-20"}
]' -- nvarchar(max)

IF OBJECT_ID('POC_UP') IS NOT NULL
	DROP PROCEDURE POC_UP
go
CREATE PROCEDURE POC_UP
@json NVARCHAR(max)
AS
BEGIN
INSERT INTO dbo.Item ([Id], [Name], [Price], [DateTimeOffset])
SELECT Id, Name, Price, DateTimeOffset
FROM OPENJSON(@json)
WITH (
	Id NVARCHAR(50) '$.Id',
	Name NVARCHAR(50) '$.Name',
	Price DECIMAL '$.Price',
	DateTimeOffset DATETIME '$.DateTimeOffset') AS jsonValues
END
GO
