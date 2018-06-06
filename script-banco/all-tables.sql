/* INÍCIO CRIAÇÃO DE OBJETOS */

CREATE TABLE Pessoa(
	Pessoa_Id           INT PRIMARY KEY NOT NULL,
	Pessoa_Nome         VARCHAR(100)    NOT NULL,
	Pessoa_CPF			VARCHAR(11)     NOT NULL,
	Pessoa_RG			VARCHAR(20)     NOT NULL,
	Pessoa_Email        VARCHAR(100)    NOT NULL,
	Pessoa_DtNascimento DATETIME        NOT NULL,	
	Pessoa_TelUm        VARCHAR(13)     NOT NULL,
	Pessoa_TelDois      VARCHAR(13)     NOT NULL,
	Endereco_Id         INT			    NOT NULL
);
GO

CREATE TABLE Endereco(
	Endereco_Id         INT PRIMARY KEY NOT NULL,
	Endereco_Logradouro VARCHAR(50)     NOT NULL,
	Endereco_Numero     VARCHAR(10)     NOT NULL,
	Endereco_Bairro     VARCHAR(50)     NOT NULL,
	Endereco_Cidade     VARCHAR(100)    NOT NULL,
	Estado_Id           INT             NOT NULL
);
GO

CREATE TABLE Estado(
	Estado_Id    INT PRIMARY KEY NOT NULL,
	Estado_Desc  VARCHAR(20)     NOT NULL,
	Estado_Sigla CHAR(2)         NOT NULL
);
GO

CREATE TABLE Cliente(
	Cliente_Id INT PRIMARY KEY NOT NULL,
	Pessoa_Id  INT			   NOT NULL
);
GO

CREATE TABLE Funcionario(
	Funcionario_Id     INT PRIMARY KEY NOT NULL,
	Funcionario_Dono   BIT             NOT NULL,
	Funcionario_Login  VARCHAR(15)     NOT NULL,
	Funcionario_Senha  VARCHAR(20)     NOT NULL,
	Pessoa_Id          INT	           NOT NULL,
	Estabelecimento_Id INT		       NOT NULL
);
GO

CREATE TABLE Agendamento(
	Agendamento_Id        INT PRIMARY KEY NOT NULL,
	Agendamento_Descricao VARCHAR(100)    NOT NULL,
	Agendamento_HrInicio  DATETIME        NOT NULL,
	Agendamento_HrFim     DATETIME        NOT NULL,
	Cliente_Id            INT             NOT NULL
);
GO

CREATE TABLE Estabelecimento(
	Estabelecimento_Id   INT PRIMARY KEY NOT NULL,
	Estabelecimento_Nome VARCHAR(100)    NOT NULL,
	Endereco_Id          INT             NOT NULL,
	Estabelecimento_Tel  VARCHAR(13)     NOT NULL,
);
GO

CREATE TABLE AgendaEstabelecimento(
    AgendaEstabelecimento_Id INT PRIMARY KEY NOT NULL,
	Estabelecimento_Id       INT NOT NULL,
	Agendamento_Id           INT NOT NULL
);
GO

CREATE TABLE Horario(
	Horario_Id  INT PRIMARY KEY NOT NULL,
	Horario_De  DATETIME        NOT NULL,
	Horario_Ate DATETIME        NOT NULL
);
GO

CREATE TABLE HorarioEstabelecimento(
    HorarioEstabelecimento_Id INT PRIMARY KEY NOT NULL,
	Horario_Id		          INT NOT NULL,
	Estabelecimento_Id        INT NOT NULL,
	DiaSemana_Id	          INT NOT NULL
);
GO

CREATE TABLE DiaSemana(
	DiaSemana_Id   INT PRIMARY KEY NOT NULL,
	DiaSemana_Desc VARCHAR(13)
);
GO

/* FIM CRIAÇÃO DE OBJETOS */

ALTER TABLE Endereco
  ADD CONSTRAINT FK_Endereco_Estado FOREIGN KEY (Estado_Id) REFERENCES Estado (Estado_Id)

ALTER TABLE Pessoa
  ADD CONSTRAINT FK_Pessoa_Endereco FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id)

ALTER TABLE Cliente
  ADD CONSTRAINT FK_Cliente_Pessoa FOREIGN KEY (Pessoa_Id) REFERENCES Pessoa (Pessoa_Id)

ALTER TABLE Funcionario
  ADD CONSTRAINT FK_Funcionario_Pessoa          FOREIGN KEY (Pessoa_Id)          REFERENCES Pessoa          (Pessoa_Id),
	  CONSTRAINT FK_Funcionario_Estabelecimento FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id)

ALTER TABLE Agendamento
  ADD CONSTRAINT FK_Agendamento_Cliente FOREIGN KEY (Cliente_Id) REFERENCES Cliente (Cliente_Id)

ALTER TABLE Estabelecimento
  ADD CONSTRAINT FK_Estabelecimento_Endereco FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id)

ALTER TABLE AgendaEstabelecimento
  ADD CONSTRAINT FK_AgendaEstabelecimento_Estabelecimento FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id),
	  CONSTRAINT FK_AgendaEstabelecimento_Agendamento     FOREIGN KEY (Agendamento_Id)     REFERENCES Agendamento     (Agendamento_Id)

ALTER TABLE HorarioEstabelecimento
  ADD CONSTRAINT FK_HorarioEstabelecimento_Horario         FOREIGN KEY (Horario_Id)         REFERENCES Horario         (Horario_Id),
      CONSTRAINT FK_HorarioEstabelecimento_Estabelecimento FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id),
      CONSTRAINT FK_HorarioEstabelecimento_DiaSemana       FOREIGN KEY (DiaSemana_Id)       REFERENCES DiaSemana       (DiaSemana_Id)