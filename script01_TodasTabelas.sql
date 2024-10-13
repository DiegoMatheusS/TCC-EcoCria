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

CREATE TABLE [TB_COLETAITENS] (
    [IdItemColeta] int NOT NULL IDENTITY,
    [QuantidadeColeta] int NOT NULL,
    CONSTRAINT [PK_TB_COLETAITENS] PRIMARY KEY ([IdItemColeta])
);
GO

CREATE TABLE [TB_COLETAS] (
    [IdColeta] int NOT NULL IDENTITY,
    [MomentoColeta] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_COLETAS] PRIMARY KEY ([IdColeta])
);
GO

CREATE TABLE [TB_MATERIAIS] (
    [IdMaterial] int NOT NULL IDENTITY,
    [NomeMaterial] Varchar(200) NOT NULL,
    [Material] int NOT NULL,
    CONSTRAINT [PK_TB_MATERIAIS] PRIMARY KEY ([IdMaterial])
);
GO

CREATE TABLE [TB_ORDEMGRANDEZA] (
    [IdOrdemGrandeza] int NOT NULL IDENTITY,
    [DescricaoOrdemGrandeza] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_ORDEMGRANDEZA] PRIMARY KEY ([IdOrdemGrandeza])
);
GO

CREATE TABLE [TB_PONTOSMATERIAIS] (
    [DescricaoPontomaterial] Varchar(200) NOT NULL,
    [StatusPontoMaterial] bit NOT NULL
);
GO

CREATE TABLE [TB_PONTUACAO] (
    [QuantidadePontos] int NOT NULL,
    [StatusPontos] bit NOT NULL
);
GO

CREATE TABLE [TB_PREMIOS] (
    [IdPremio] int NOT NULL IDENTITY,
    [DescricaoPremio] Varchar(200) NOT NULL,
    [QuantidadePremio] int NOT NULL,
    [PontosPremio] int NOT NULL,
    CONSTRAINT [PK_TB_PREMIOS] PRIMARY KEY ([IdPremio])
);
GO

CREATE TABLE [TB_PUBLICACAO] (
    [IdPublicacao] int NOT NULL IDENTITY,
    [DataPublicacao] datetime2 NOT NULL,
    [TituloPublicacao] Varchar(200) NOT NULL,
    [TextoPublicacao] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_PUBLICACAO] PRIMARY KEY ([IdPublicacao])
);
GO

CREATE TABLE [TB_TIPOPONTO] (
    [IdTipoPonto] int NOT NULL IDENTITY,
    [DescricaoTipoPonto] Varchar(200) NOT NULL,
    [StatusTipoPonto] bit NOT NULL,
    CONSTRAINT [PK_TB_TIPOPONTO] PRIMARY KEY ([IdTipoPonto])
);
GO

CREATE TABLE [TB_TROCAS] (
    [IdTroca] int NOT NULL IDENTITY,
    [MomentoTroca] datetime2 NOT NULL,
    CONSTRAINT [PK_TB_TROCAS] PRIMARY KEY ([IdTroca])
);
GO

CREATE TABLE [TB_USUARIOS] (
    [IdUsuario] int NOT NULL IDENTITY,
    [NomeUsuario] Varchar(200) NOT NULL,
    [Latitude] float NULL,
    [Longitude] float NULL,
    [Perfil] Varchar(200) NOT NULL DEFAULT 'Cliente',
    [EmailUsuario] Varchar(200) NOT NULL,
    [PasswordHash] varbinary(max) NULL,
    [PasswordSalt] varbinary(max) NULL,
    [DataAcesso] datetime2 NULL,
    CONSTRAINT [PK_TB_USUARIOS] PRIMARY KEY ([IdUsuario])
);
GO

CREATE TABLE [TB_PONTOS] (
    [IdPonto] int NOT NULL IDENTITY,
    [NomePonto] Varchar(200) NOT NULL,
    [EnderecoPonto] Varchar(200) NOT NULL,
    [CepEndereco] int NOT NULL,
    [UfEndereco] Varchar(200) NOT NULL,
    [CidadeEndereco] Varchar(200) NOT NULL,
    [IdTipoPonto] int NOT NULL,
    CONSTRAINT [PK_TB_PONTOS] PRIMARY KEY ([IdPonto]),
    CONSTRAINT [FK_TB_PONTOS_TB_TIPOPONTO_IdTipoPonto] FOREIGN KEY ([IdTipoPonto]) REFERENCES [TB_TIPOPONTO] ([IdTipoPonto]) ON DELETE CASCADE
);
GO

CREATE TABLE [TB_PARCEIROS] (
    [IdParceiro] int NOT NULL IDENTITY,
    [NomeParceiro] Varchar(200) NOT NULL,
    [StatusParceiro] bit NOT NULL,
    [DoacaoParceiro] float NOT NULL,
    [DataDoacao] datetime2 NOT NULL,
    [IdUsuario] int NULL,
    [UsuarioIdUsuario] int NULL,
    CONSTRAINT [PK_TB_PARCEIROS] PRIMARY KEY ([IdParceiro]),
    CONSTRAINT [FK_TB_PARCEIROS_TB_USUARIOS_UsuarioIdUsuario] FOREIGN KEY ([UsuarioIdUsuario]) REFERENCES [TB_USUARIOS] ([IdUsuario])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([IdUsuario], [DataAcesso], [EmailUsuario], [Latitude], [Longitude], [NomeUsuario], [PasswordHash], [PasswordSalt], [Perfil])
VALUES (1, NULL, 'seuEmail@gmail.com', -23.520024100000001E0, -46.596497999999997E0, 'admin', 0xC48CEF4EF9D8BA3370989988498AE6FADAA55074C069B7944B40959E247D91D45480AEA8614B71D5E1F8B57AB9699CA695C8A29AD0F7A056C22F28CBC0B0609CC4D1FF0CCA7F15AF7CD0A8C91E8DA6DCD3A2AABC19BBFC4F928B912D304C01E2B46EC69DA5E78C92D9365F1605C7DDFBF711BCF64014297759E90D8B7DC0933D, NULL, 'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_PARCEIROS_UsuarioIdUsuario] ON [TB_PARCEIROS] ([UsuarioIdUsuario]);
GO

CREATE UNIQUE INDEX [IX_TB_PONTOS_IdTipoPonto] ON [TB_PONTOS] ([IdTipoPonto]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240918124903_InitialCreate', N'8.0.8');
GO

COMMIT;
GO

