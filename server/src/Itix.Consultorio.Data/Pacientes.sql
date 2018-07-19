CREATE TABLE [dbo].[Pacientes]
(
	[Id] INT NOT NULL, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Nascimento] DATE NOT NULL,
	CONSTRAINT PK_Pacientes PRIMARY KEY NONCLUSTERED (Id)
)
