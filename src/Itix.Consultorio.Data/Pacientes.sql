CREATE TABLE [Consultorio].[Pacientes]
(
	[Id] INT IDENTITY(1, 1) NOT NULL, 
    [Nome] VARCHAR(100) NOT NULL, 
    [Nascimento] DATE NOT NULL,
	CONSTRAINT PK_Pacientes PRIMARY KEY NONCLUSTERED (Id)
)