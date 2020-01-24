CREATE TABLE [dbo].[Konti]
(
	[Konto_ID] INT NOT NULL PRIMARY KEY, 
    [Kunde_id] INT NULL, 
    [Konto_NR] NVARCHAR(50) NULL, 
    [Saldo] INT NULL
)
