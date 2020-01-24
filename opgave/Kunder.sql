CREATE TABLE [dbo].[Kunder] (
    [Kunde_ID] INT NOT NULL,
    [Navn]     VARCHAR(50) NULL,
    [adresse]  VARCHAR(50) NULL,
    [CPR]      INT           NULL,
    [Konto_NR] INT           NULL,
    PRIMARY KEY CLUSTERED ([Kunde_ID] ASC)
);

