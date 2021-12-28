IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Endereco] (
    [Id] uniqueidentifier NOT NULL,
    [Logradouro] varchar(200) NOT NULL,
    [Numero] varchar(100) NULL,
    [Complemento] varchar(100) NULL,
    [Bairro] varchar(100) NULL,
    [Cep] varchar(7) NOT NULL,
    [Cidade] varchar(500) NOT NULL,
    [UF] varchar(2) NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Telefone] (
    [Id] uniqueidentifier NOT NULL,
    [DDD] varchar(100) NULL,
    [Numero] varchar(100) NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Telefone] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Agenda] (
    [Id] uniqueidentifier NOT NULL,
    [DataAgenda] datetime2 NOT NULL,
    [Titulo] varchar(200) NOT NULL,
    [Descricao] varchar(100) NULL,
    [Ativo] int NOT NULL,
    [ClienteId] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Agenda] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Contato] (
    [Id] uniqueidentifier NOT NULL,
    [TelefoneId] uniqueidentifier NULL,
    [CelularId] uniqueidentifier NULL,
    [Principal] bit NOT NULL,
    [EhWhatsApp] bit NOT NULL,
    [ClienteId] uniqueidentifier NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Contato] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contato_Telefone_CelularId] FOREIGN KEY ([CelularId]) REFERENCES [Telefone] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Contato_Telefone_TelefoneId] FOREIGN KEY ([TelefoneId]) REFERENCES [Telefone] ([Id]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Cliente] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(200) NOT NULL,
    [CPF] varchar(100) NULL,
    [Email] varchar(100) NULL,
    [Grupo] int NOT NULL,
    [ContatoId] uniqueidentifier NOT NULL,
    [EnderecoId] uniqueidentifier NOT NULL,
    [DataCadastro] datetime2 NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_Contato_ContatoId] FOREIGN KEY ([ContatoId]) REFERENCES [Contato] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Cliente_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_Agenda_ClienteId] ON [Agenda] ([ClienteId]);
GO

CREATE INDEX [IX_Cliente_ContatoId] ON [Cliente] ([ContatoId]);
GO

CREATE INDEX [IX_Cliente_EnderecoId] ON [Cliente] ([EnderecoId]);
GO

CREATE INDEX [IX_Contato_CelularId] ON [Contato] ([CelularId]);
GO

CREATE INDEX [IX_Contato_ClienteId] ON [Contato] ([ClienteId]);
GO

CREATE INDEX [IX_Contato_TelefoneId] ON [Contato] ([TelefoneId]);
GO

ALTER TABLE [Agenda] ADD CONSTRAINT [FK_Agenda_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION;
GO

ALTER TABLE [Contato] ADD CONSTRAINT [FK_Contato_Cliente_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [Cliente] ([Id]) ON DELETE NO ACTION;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20211228115214_Initial', N'5.0.13');
GO

COMMIT;
GO

