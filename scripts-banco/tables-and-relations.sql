/* INÍCIO CRIAÇÃO DE OBJETOS */
------ 1 ------------------------------------------------------------------------------
CREATE TABLE Endereco(
	Endereco_Id          INT          NOT NULL,
	Endereco_Logradouro  VARCHAR(50)  NOT NULL,
	Endereco_Numero      INT          NOT NULL,
	Endereco_Bairro      VARCHAR(50)  NOT NULL,
	Endereco_Cidade      VARCHAR(100) NOT NULL,
	Endereco_Estado      CHAR(2)      NOT NULL,
	Endereco_Complemento VARCHAR(100) NOT NULL,
	PRIMARY KEY CLUSTERED (Endereco_Id ASC)
);
GO
------ 2 ------------------------------------------------------------------------------
CREATE TABLE Cliente(
    Cliente_Id           INT          NOT NULL,
	Cliente_Nome         VARCHAR(255) NOT NULL,
	Cliente_CPF          VARCHAR(13)  NOT NULL,
	Cliente_RG           VARCHAR(14)  NOT NULL,
	Cliente_Email        VARCHAR(255) NOT NULL,
	Cliente_DtNascimento DATETIME     NOT NULL,
	Cliente_Telefone     VARCHAR(13)  NOT NULL,
	Cliente_Celular      VARCHAR(13)  NOT NULL,
	Endereco_Id          INT	      NOT NULL,
	PRIMARY KEY CLUSTERED (Cliente_Id ASC)
);
GO
------ 3 ------------------------------------------------------------------------------
CREATE TABLE Cargo(
	Cargo_Id   INT          NOT NULL,
	Cargo_Desc VARCHAR(255) NOT NULL,
	PRIMARY KEY CLUSTERED (Cargo_Id ASC)
);
GO
------ 4 ------------------------------------------------------------------------------
CREATE TABLE Funcionario(
    Funcionario_Id           INT          NOT NULL,	
    Funcionario_Nome         VARCHAR(255) NOT NULL,
    Funcionario_CPF			 VARCHAR(13)  NOT NULL,
    Funcionario_RG			 VARCHAR(14)  NOT NULL,
    Funcionario_DtNascimento DATETIME     NOT NULL,
    Endereco_Id              INT	      NOT NULL,
    Estabelecimento_Id       INT		  NOT NULL,
    PRIMARY KEY CLUSTERED (Funcionario_Id ASC)
);
GO
------ 5 ------------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE FuncionarioContato(
	Funcionario_Id			    INT          NOT NULL,
	FuncionarioContato_Telefone VARCHAR(20)  NOT NULL,
	FuncionarioContato_Celular  VARCHAR(20)  NOT NULL,
	FuncionarioContato_Email    VARCHAR(200) NOT NULL,
	PRIMARY KEY CLUSTERED (Funcionario_Id ASC)
);
GO
------ 6 ------------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE FuncionarioCargo(
	Funcionario_Id              INT      NOT NULL,
	FuncionarioCargo_DtAdmissao DATETIME NOT NULL,
	Cargo_Id                    INT      NOT NULL,
	PRIMARY KEY CLUSTERED (Funcionario_Id ASC)
);
GO
------ 7 ------------------------------------------------------------------------------
CREATE TABLE Usuario(
	Usuario_Id     INT         NOT NULL,
	Usuario_Login  VARCHAR(10) NOT NULL,
	Usuario_Senha  VARCHAR(20) NOT NULL,
	PRIMARY KEY CLUSTERED (Usuario_Id ASC)
);
GO
------ 8 ------------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE UsuarioFuncionario(
	Usuario_Id     INT NOT NULL,
	Funcionario_Id INT NOT NULL,
	PRIMARY KEY CLUSTERED (Usuario_Id ASC, Funcionario_Id ASC)
);
GO
------ 9 ------------------------------------------------------------------------------
CREATE TABLE Agendamento(
	Agendamento_Id        INT          NOT NULL,
	Agendamento_Descricao VARCHAR(200) NOT NULL,		
	PRIMARY KEY CLUSTERED (Agendamento_Id ASC)
);
GO
------ 10 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE AgendamentoCliente(
	Agendamento_Id INT NOT NULL,
	Cliente_Id     INT NOT NULL,
	PRIMARY KEY CLUSTERED (Agendamento_Id ASC)
);
GO
------ 11 -----------------------------------------------------------------------------
CREATE TABLE Estabelecimento(
	Estabelecimento_Id   INT          NOT NULL,
	Estabelecimento_Nome VARCHAR(200) NOT NULL,
    Estabelecimento_CNPJ VARCHAR(14)  NOT NULL,
	Endereco_Id          INT          NOT NULL,
	PRIMARY KEY CLUSTERED (Estabelecimento_Id ASC)
);
GO
------ 12 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE EstabelecimentoContato(
	Estabelecimento_Id              INT          NOT NULL,
	EstabelecimentoContato_Telefone VARCHAR(20)  NOT NULL,
	EstabelecimentoContato_Celular  VARCHAR(20)  NOT NULL,
	EstabelecimentoContato_Email	VARCHAR(200) NOT NULL,
	PRIMARY KEY CLUSTERED (Estabelecimento_Id)
);
GO
------ 13 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE AgendaEstabelecimento(
	Agendamento_Id                  INT      NOT NULL,
	Estabelecimento_Id              INT      NOT NULL,
	AgendaEstabelecimento_HrInicio  DATETIME NOT NULL,
	AgendaEstabelecimento_HrFim     DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED (Agendamento_Id ASC, Estabelecimento_Id ASC)
);
GO
------ 14 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE Horario(
	Horario_Id  INT      NOT NULL,
	Horario_De  DATETIME NOT NULL,
	Horario_Ate DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED (Horario_Id ASC)
);
GO
------ 15 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE HorarioEstabelecimento(
	Horario_Id		   INT NOT NULL,
	Estabelecimento_Id INT NOT NULL,
	DiaSemana_Id	   INT NOT NULL,
	PRIMARY KEY CLUSTERED (Horario_Id ASC, Estabelecimento_Id ASC)
);
GO
------ 16 -----------------------------------------------------------------------------
-- Cuidado com Tabela
CREATE TABLE DiaSemana(
	DiaSemana_Id   INT         NOT NULL,
	DiaSemana_Desc VARCHAR(13) NOT NULL,
	PRIMARY KEY CLUSTERED (DiaSemana_Id ASC)
);
GO
/* FIM CRIAÇÃO DE OBJETOS */

/* CRIANDO FKs */
------ 1 ------------------------------------------------------------------------------
  ALTER TABLE Cliente
    ADD CONSTRAINT FK_Cliente_Endereco 
FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id);
GO
------ 2 ------------------------------------------------------------------------------
  ALTER TABLE Funcionario
    ADD CONSTRAINT FK_Funcionario_Endereco
FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id),
        CONSTRAINT FK_Funcionario_Estabelecimento 
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id);
GO
------ 3 ------------------------------------------------------------------------------
  ALTER TABLE FuncionarioContato
    ADD CONSTRAINT FK_FuncionarioContato_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id);
GO
------ 4 ------------------------------------------------------------------------------
  ALTER TABLE FuncionarioCargo
    ADD CONSTRAINT FK_FuncionarioCargo_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id),
        CONSTRAINT FK_FuncionarioCargo_Cargo
FOREIGN KEY (Cargo_Id) REFERENCES Cargo (Cargo_Id);
GO
------ 5 ------------------------------------------------------------------------------
  ALTER TABLE UsuarioFuncionario
    ADD CONSTRAINT FK_UsuarioFuncionario_Usuario
FOREIGN KEY (Usuario_Id) REFERENCES Usuario (Usuario_Id),
        CONSTRAINT FK_UsuarioFuncionario_Funcionario
FOREIGN KEY (Funcionario_Id) REFERENCES Funcionario (Funcionario_Id);
GO
------ 6 ------------------------------------------------------------------------------
  ALTER TABLE AgendamentoCliente
    ADD CONSTRAINT FK_AgendamentoCliente_Agendamento
FOREIGN KEY (Agendamento_Id) REFERENCES Agendamento (Agendamento_Id),
        CONSTRAINT FK_AgendamentoCliente_Cliente
FOREIGN KEY (Cliente_Id) REFERENCES Cliente (Cliente_Id);
GO
------ 7 ------------------------------------------------------------------------------
  ALTER TABLE Estabelecimento
    ADD CONSTRAINT FK_Estabelecimento_Endereco
FOREIGN KEY (Endereco_Id) REFERENCES Endereco (Endereco_Id);
GO
------ 8 ------------------------------------------------------------------------------
  ALTER TABLE EstabelecimentoContato
    ADD CONSTRAINT FK_EstabelecimentoContato_Estabelecimento
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id);
GO
------ 9 ------------------------------------------------------------------------------
  ALTER TABLE AgendaEstabelecimento
    ADD CONSTRAINT FK_AgendaEstabelecimento_Agendamento
FOREIGN KEY (Agendamento_Id) REFERENCES Agendamento (Agendamento_Id),
	    CONSTRAINT FK_AgendaEstabelecimento_Estabelecimento
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id);
GO
------ 10 -----------------------------------------------------------------------------
  ALTER TABLE HorarioEstabelecimento
    ADD CONSTRAINT FK_HorarioEstabelecimento_Horario
FOREIGN KEY (Horario_Id) REFERENCES Horario (Horario_Id),
	    CONSTRAINT FK_HorarioEstabelecimento_Estabelecimento
FOREIGN KEY (Estabelecimento_Id) REFERENCES Estabelecimento (Estabelecimento_Id),
	    CONSTRAINT FK_HorarioEstabelecimento_DiaSemana
FOREIGN KEY (DiaSemana_Id) REFERENCES DiaSemana (DiaSemana_Id);
GO
/* FIM CRIANDO FKs */
