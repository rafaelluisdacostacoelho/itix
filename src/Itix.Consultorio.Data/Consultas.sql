CREATE TABLE [Consultorio].[Consultas]
(
	[Id] INT IDENTITY(1, 1) NOT NULL, 
    [DataInicial] DATETIME NOT NULL, 
    [DataFinal] DATETIME NOT NULL, 
    [Observacoes] VARCHAR(400) NULL, 
    [PacienteId] INT NOT NULL,
	CONSTRAINT PK_Consultas PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_Consultas_Pacientes FOREIGN KEY (PacienteId)
		REFERENCES [Consultorio].[Pacientes] (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)   