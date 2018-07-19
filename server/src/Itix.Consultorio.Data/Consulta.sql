CREATE TABLE [dbo].[Consulta]
(
	[Id] INT NOT NULL, 
    [DataInicial] DATETIME NOT NULL, 
    [DataFinal] DATETIME NOT NULL, 
    [Observacoes] VARCHAR(400) NULL, 
    [PacienteId] INT NOT NULL,
	CONSTRAINT PK_Consultas PRIMARY KEY NONCLUSTERED (Id),
	CONSTRAINT FK_Consultas_Pacientes FOREIGN KEY (PacienteId)
		REFERENCES dbo.Pacientes (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)   