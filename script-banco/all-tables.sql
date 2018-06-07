/* INÍCIO CRIAÇÃO DE OBJETOS */

-- OK
CREATE TABLE Endereco(
	Endereco_Id         INT          NOT NULL,
	Endereco_Logradouro VARCHAR(50)  NOT NULL,
	Endereco_Numero     INT          NOT NULL,
	Endereco_Bairro     VARCHAR(50)  NOT NULL,
	Endereco_Cidade     VARCHAR(100) NOT NULL,
	Endereco_Estado     CHAR(2)      NOT NULL,
	PRIMARY KEY CLUSTERED (Endereco_Id ASC)
);
GO

-- OK
CREATE TABLE Cliente(
    Cliente_Id           INT          NOT NULL
	Cliente_Nome         VARCHAR(100) NOT NULL,
	Cliente_CPF			 VARCHAR(11)  NOT NULL,
	Cliente_RG			 VARCHAR(20)  NOT NULL,
	Cliente_Email        VARCHAR(255) NOT NULL,
	Cliente_DtNascimento DATETIME     NOT NULL,	
	Cliente_TelUm        VARCHAR(13)  NOT NULL,
	Cliente_TelDois      VARCHAR(13)  NOT NULL,
	Endereco_Id          INT	      NOT NULL,
	PRIMARY KEY CLUSTERED (Cliente_Id ASC)
);
GO

-- OK
CREATE TABLE Funcionario(
	Funcionario_Id           INT          NOT NULL,	
	Funcionario_Nome         VARCHAR(100) NOT NULL,
	Funcionario_CPF			 VARCHAR(11)  NOT NULL,
	Funcionario_RG			 VARCHAR(20)  NOT NULL,
	Funcionario_DtNascimento DATETIME     NOT NULL,	
	Funcionario_TelUm        VARCHAR(13)  NOT NULL,
	Funcionario_TelDois      VARCHAR(13)  NOT NULL,
	Funcionario_Dono         BIT          NOT NULL,
	Endereco_Id              INT	      NOT NULL,
	Estabelecimento_Id       INT		  NOT NULL,
	Usuario_Id               INT		  NOT NULL,
	PRIMARY KEY CLUSTERED (Funcionario_Id ASC)
);
GO

-- OK
CREATE TABLE Usuario(
	Usuario_Id     INT          NOT NULL,
	Usuario_Login  VARCHAR(10)  NOT NULL,
	Usuario_Senha  VARCHAR(20)  NOT NULL,
	Usuario_Email  VARCHAR(255) NOT NULL,
	PRIMARY KEY CLUSTERED (Usuario_Id ASC)
);
GO

-- OK
CREATE TABLE Agendamento(
	Agendamento_Id        INT          NOT NULL,
	Agendamento_Descricao VARCHAR(100) NOT NULL,		
	PRIMARY KEY CLUSTERED (Agendamento_Id ASC)
);
GO

-- OK
CREATE TABLE Estabelecimento(
	Estabelecimento_Id   INT          NOT NULL,
	Estabelecimento_Nome VARCHAR(100) NOT NULL,
    Estabelecimento_CNPJ VARCHAR(20)  NOT NULL,	
	Estabelecimento_Tel  VARCHAR(13)  NOT NULL,
	Endereco_Id          INT          NOT NULL,
	PRIMARY KEY CLUSTERED (Estabelecimento_Id ASC)
);
GO

-- OK
-- Cuidado
CREATE TABLE AgendaEstabelecimento(
	Agendamento_Id                  INT      NOT NULL,
	Estabelecimento_Id              INT      NOT NULL,
    Cliente_Id                      INT      NOT NULL,
	AgendaEstabelecimento_HrInicio  DATETIME NOT NULL,
	AgendaEstabelecimento_HrFim     DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED (Agendamento_Id ASC, Estabelecimento_Id ASC, Cliente_Id ASC)
);
GO

CREATE TABLE Horario(
	Horario_Id  INT      NOT NULL,
	Horario_De  DATETIME NOT NULL,
	Horario_Ate DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED (Horario_Id ASC)
);
GO

-- Cuidado
CREATE TABLE HorarioEstabelecimento(
	Horario_Id		          INT NOT NULL,
	Estabelecimento_Id        INT NOT NULL,
	DiaSemana_Id	          INT NOT NULL,
	PRIMARY KEY CLUSTERED (Horario_Id ASC, Estabelecimento_Id ASC)
);
GO

CREATE TABLE DiaSemana(
	DiaSemana_Id   INT         NOT NULL,
	DiaSemana_Desc VARCHAR(13) NOT NULL,
	PRIMARY KEY CLUSTERED (DiaSemana_Id ASC)
);
GO

/* FIM CRIAÇÃO DE OBJETOS */

ALTER TABLE Cliente
  ADD CONSTRAINT FK_Cliente_Endereco FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id);

ALTER TABLE Funcionario
  ADD CONSTRAINT FK_Funcionario_Endereco        FOREIGN KEY (Endereco_Id)        REFERENCES Endereco        (Endereco_Id),
      CONSTRAINT FK_Funcionario_Estabelecimento FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id),
	  CONSTRAINT FK_Funcionario_Usuario         FOREIGN KEY (Usuario_Id)         REFERENCES Usuario         (Usuario_Id);

ALTER TABLE Estabelecimento
  ADD CONSTRAINT FK_Estabelecimento_Endereco FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id);

ALTER TABLE HorarioEstabelecimento
 
  ADD CONSTRAINT FK_HorarioEstabelecimento_DiaSemana FOREIGN KEY (DiaSemana_Id) REFERENCES DiaSemana (DiaSemana_Id);
