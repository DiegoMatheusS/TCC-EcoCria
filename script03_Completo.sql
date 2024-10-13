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

CREATE TABLE [TB_COMENTARIOS] (
    [IdComentario] int NOT NULL IDENTITY,
    [MomentoComentario] datetime2 NOT NULL,
    [TextoComentario] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_COMENTARIOS] PRIMARY KEY ([IdComentario])
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

CREATE TABLE [TB_COLETAS] (
    [IdColeta] int NOT NULL IDENTITY,
    [MomentoColeta] datetime2 NOT NULL,
    [IdPonto] int NULL,
    [IdUsuario] int NULL,
    CONSTRAINT [PK_TB_COLETAS] PRIMARY KEY ([IdColeta]),
    CONSTRAINT [FK_TB_COLETAS_TB_PONTOS_IdPonto] FOREIGN KEY ([IdPonto]) REFERENCES [TB_PONTOS] ([IdPonto]),
    CONSTRAINT [FK_TB_COLETAS_TB_USUARIOS_IdUsuario] FOREIGN KEY ([IdUsuario]) REFERENCES [TB_USUARIOS] ([IdUsuario])
);
GO

CREATE TABLE [TB_COLETAITENS] (
    [IdItemColeta] int NOT NULL IDENTITY,
    [QuantidadeColeta] int NOT NULL,
    [IdColeta] int NULL,
    [IdMaterial] int NULL,
    [IdOrdemGrandeza] int NULL,
    CONSTRAINT [PK_TB_COLETAITENS] PRIMARY KEY ([IdItemColeta]),
    CONSTRAINT [FK_TB_COLETAITENS_TB_COLETAS_IdColeta] FOREIGN KEY ([IdColeta]) REFERENCES [TB_COLETAS] ([IdColeta]),
    CONSTRAINT [FK_TB_COLETAITENS_TB_MATERIAIS_IdMaterial] FOREIGN KEY ([IdMaterial]) REFERENCES [TB_MATERIAIS] ([IdMaterial]),
    CONSTRAINT [FK_TB_COLETAITENS_TB_ORDEMGRANDEZA_IdOrdemGrandeza] FOREIGN KEY ([IdOrdemGrandeza]) REFERENCES [TB_ORDEMGRANDEZA] ([IdOrdemGrandeza])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdItemColeta', N'IdColeta', N'IdMaterial', N'IdOrdemGrandeza', N'QuantidadeColeta') AND [object_id] = OBJECT_ID(N'[TB_COLETAITENS]'))
    SET IDENTITY_INSERT [TB_COLETAITENS] ON;
INSERT INTO [TB_COLETAITENS] ([IdItemColeta], [IdColeta], [IdMaterial], [IdOrdemGrandeza], [QuantidadeColeta])
VALUES (1, NULL, NULL, NULL, 1),
(2, NULL, NULL, NULL, 2),
(3, NULL, NULL, NULL, 1),
(4, NULL, NULL, NULL, 2),
(5, NULL, NULL, NULL, 1),
(6, NULL, NULL, NULL, 2),
(7, NULL, NULL, NULL, 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdItemColeta', N'IdColeta', N'IdMaterial', N'IdOrdemGrandeza', N'QuantidadeColeta') AND [object_id] = OBJECT_ID(N'[TB_COLETAITENS]'))
    SET IDENTITY_INSERT [TB_COLETAITENS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdColeta', N'IdPonto', N'IdUsuario', N'MomentoColeta') AND [object_id] = OBJECT_ID(N'[TB_COLETAS]'))
    SET IDENTITY_INSERT [TB_COLETAS] ON;
INSERT INTO [TB_COLETAS] ([IdColeta], [IdPonto], [IdUsuario], [MomentoColeta])
VALUES (1, NULL, NULL, '2024-09-20T14:10:13.5229043-03:00'),
(2, NULL, NULL, '2024-09-20T14:10:13.5229057-03:00'),
(3, NULL, NULL, '2024-09-20T14:10:13.5229059-03:00'),
(4, NULL, NULL, '2024-09-20T14:10:13.5229061-03:00'),
(5, NULL, NULL, '2024-09-20T14:10:13.5229063-03:00'),
(6, NULL, NULL, '2024-09-20T14:10:13.5229064-03:00'),
(7, NULL, NULL, '2024-09-20T14:10:13.5229066-03:00');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdColeta', N'IdPonto', N'IdUsuario', N'MomentoColeta') AND [object_id] = OBJECT_ID(N'[TB_COLETAS]'))
    SET IDENTITY_INSERT [TB_COLETAS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'Material', N'NomeMaterial') AND [object_id] = OBJECT_ID(N'[TB_MATERIAIS]'))
    SET IDENTITY_INSERT [TB_MATERIAIS] ON;
INSERT INTO [TB_MATERIAIS] ([IdMaterial], [Material], [NomeMaterial])
VALUES (1, 1, 'Garrafa Pet'),
(2, 4, 'Papelão'),
(3, 1, 'Saco Plástico'),
(4, 2, 'Lata de Feijoada'),
(5, 2, 'Latinha'),
(6, 1, 'Garrafa Pet'),
(7, 3, 'Jarra de Vidro');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'Material', N'NomeMaterial') AND [object_id] = OBJECT_ID(N'[TB_MATERIAIS]'))
    SET IDENTITY_INSERT [TB_MATERIAIS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParceiro', N'DataDoacao', N'DoacaoParceiro', N'IdUsuario', N'NomeParceiro', N'StatusParceiro', N'UsuarioIdUsuario') AND [object_id] = OBJECT_ID(N'[TB_PARCEIROS]'))
    SET IDENTITY_INSERT [TB_PARCEIROS] ON;
INSERT INTO [TB_PARCEIROS] ([IdParceiro], [DataDoacao], [DoacaoParceiro], [IdUsuario], [NomeParceiro], [StatusParceiro], [UsuarioIdUsuario])
VALUES (1, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa BlaBla', CAST(0 AS bit), NULL),
(2, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Market Empresa', CAST(0 AS bit), NULL),
(3, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa Eletro', CAST(0 AS bit), NULL),
(4, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa Papel', CAST(0 AS bit), NULL),
(5, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa Rainiken', CAST(0 AS bit), NULL),
(6, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa squol', CAST(0 AS bit), NULL),
(7, '0001-01-01T00:00:00.0000000', 500.0E0, NULL, 'Empresa suifiti', CAST(0 AS bit), NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParceiro', N'DataDoacao', N'DoacaoParceiro', N'IdUsuario', N'NomeParceiro', N'StatusParceiro', N'UsuarioIdUsuario') AND [object_id] = OBJECT_ID(N'[TB_PARCEIROS]'))
    SET IDENTITY_INSERT [TB_PARCEIROS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTipoPonto', N'DescricaoTipoPonto', N'StatusTipoPonto') AND [object_id] = OBJECT_ID(N'[TB_TIPOPONTO]'))
    SET IDENTITY_INSERT [TB_TIPOPONTO] ON;
INSERT INTO [TB_TIPOPONTO] ([IdTipoPonto], [DescricaoTipoPonto], [StatusTipoPonto])
VALUES (1, 'Ferro velho em geral', CAST(0 AS bit)),
(2, 'Reciclagem', CAST(0 AS bit)),
(3, 'Reciclagem em geral', CAST(0 AS bit)),
(4, 'Ecoponto', CAST(0 AS bit)),
(5, 'Recilagem de metais', CAST(0 AS bit)),
(6, 'Recilcagem de papel e celulose', CAST(0 AS bit)),
(7, 'Recilcagem ', CAST(0 AS bit));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdTipoPonto', N'DescricaoTipoPonto', N'StatusTipoPonto') AND [object_id] = OBJECT_ID(N'[TB_TIPOPONTO]'))
    SET IDENTITY_INSERT [TB_TIPOPONTO] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([IdUsuario], [DataAcesso], [EmailUsuario], [Latitude], [Longitude], [NomeUsuario], [PasswordHash], [PasswordSalt], [Perfil])
VALUES (1, NULL, 'seuEmail@gmail.com', -23.520024100000001E0, -46.596497999999997E0, 'admin', 0xC9AF3CED2B9EA8D3E2067F4CA9D92858E20293599EAC6A3C04C9BE4D1D00BCBBA531C5C96C3CED925E9ED043AF37173792D330C927DFB5EB7CCB920B893912D8620095E8A0DF90B0ED5DF29FD3E2995086B3ED98949A8563B0675C5E12734200C7725D049F3A2016B956D2FCC057E6F234B4DFA277D1A7DA75F42D3EE66C5B57, NULL, 'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPonto', N'CepEndereco', N'CidadeEndereco', N'EnderecoPonto', N'IdTipoPonto', N'NomePonto', N'UfEndereco') AND [object_id] = OBJECT_ID(N'[TB_PONTOS]'))
    SET IDENTITY_INSERT [TB_PONTOS] ON;
INSERT INTO [TB_PONTOS] ([IdPonto], [CepEndereco], [CidadeEndereco], [EnderecoPonto], [IdTipoPonto], [NomePonto], [UfEndereco])
VALUES (1, 1986, 'São Paulo', 'Rua São Quirino, 468 - Vila Guilherme', 1, 'São Quirino Sucatas', 'SP'),
(2, 2995, 'São Paulo', 'R. Santa Clara, 350 - Brás', 2, 'Reciclagem, Sucatas e Aparas Farpec', 'SP'),
(3, 2995, 'São Paulo', 'R. Dr. Miguel Paulo Capalbo, 75 - Pari', 3, 'Helio & Richard Reciclagem', 'SP'),
(4, 2054, 'São Paulo', 'Rua José Bernardo Pinto, 1480 - Vila Guilherme', 4, 'Ecoponto Vila Guilherme', 'SP'),
(5, 2103, 'São Paulo', 'Av. Guilherme Cotching, 726 - Vila Maria Baixa', 5, 'Latasa Reciclagem', 'SP'),
(6, 2004, 'São Paulo', 'R. Henrique Felipe da Costa, 650 - Vila Guilherme', 6, 'Ciclopel Com de Aparas de Papel', 'SP'),
(7, 2104, 'São Paulo', 'R. Eli, 190 - Vila Maria Baixa', 7, 'COLETATEC', 'SP');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdPonto', N'CepEndereco', N'CidadeEndereco', N'EnderecoPonto', N'IdTipoPonto', N'NomePonto', N'UfEndereco') AND [object_id] = OBJECT_ID(N'[TB_PONTOS]'))
    SET IDENTITY_INSERT [TB_PONTOS] OFF;
GO

CREATE INDEX [IX_TB_COLETAITENS_IdColeta] ON [TB_COLETAITENS] ([IdColeta]);
GO

CREATE INDEX [IX_TB_COLETAITENS_IdMaterial] ON [TB_COLETAITENS] ([IdMaterial]);
GO

CREATE INDEX [IX_TB_COLETAITENS_IdOrdemGrandeza] ON [TB_COLETAITENS] ([IdOrdemGrandeza]);
GO

CREATE INDEX [IX_TB_COLETAS_IdPonto] ON [TB_COLETAS] ([IdPonto]);
GO

CREATE INDEX [IX_TB_COLETAS_IdUsuario] ON [TB_COLETAS] ([IdUsuario]);
GO

CREATE INDEX [IX_TB_PARCEIROS_UsuarioIdUsuario] ON [TB_PARCEIROS] ([UsuarioIdUsuario]);
GO

CREATE UNIQUE INDEX [IX_TB_PONTOS_IdTipoPonto] ON [TB_PONTOS] ([IdTipoPonto]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240920171014_InitialCreate', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD [IdPontoMaterial] int NOT NULL DEFAULT 0;
GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946752-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946762-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946763-03:00'
WHERE [IdColeta] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946764-03:00'
WHERE [IdColeta] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946766-03:00'
WHERE [IdColeta] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946767-03:00'
WHERE [IdColeta] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:34:51.3946768-03:00'
WHERE [IdColeta] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x22EED722C73E489CD98F2FBDDC9499AC1B62E592A2139CA3ACE2A97BA43FA0CD8826227D344425A7A1BF01F93AD9B2E844F5E5CC767AFB2FE1B84D797DC80938ED72307F39160A9196E6DE4D5DD5518256E5A56CBE6CA6BA3FA6979394F3B65EDF721336AA0F950377FBEEE9D32B3B5033F6F948C071CF1D01A45A8943B77A57
WHERE [IdUsuario] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240920183452_PontosMateriais', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [TB_PONTUACAO] ADD [IdPontuacao] int NOT NULL IDENTITY;
GO

ALTER TABLE [TB_PONTUACAO] ADD [ColetasIdColeta] int NULL;
GO

ALTER TABLE [TB_PONTUACAO] ADD [IdColeta] int NULL;
GO

ALTER TABLE [TB_PONTUACAO] ADD [IdUsuario] int NULL;
GO

ALTER TABLE [TB_PONTUACAO] ADD [UsuarioIdUsuario] int NULL;
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD [IdMaterial] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD [IdPonto] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD [MateriaisIdMaterial] int NULL;
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD [PontosIdPonto] int NULL;
GO

ALTER TABLE [TB_MATERIAIS] ADD [IdOrdemGrandeza] int NOT NULL DEFAULT 0;
GO

ALTER TABLE [TB_MATERIAIS] ADD [OrdemDeGrandezaIdOrdemGrandeza] int NULL;
GO

ALTER TABLE [TB_PONTUACAO] ADD CONSTRAINT [PK_TB_PONTUACAO] PRIMARY KEY ([IdPontuacao]);
GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143901-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143918-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143920-03:00'
WHERE [IdColeta] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143921-03:00'
WHERE [IdColeta] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143923-03:00'
WHERE [IdColeta] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143924-03:00'
WHERE [IdColeta] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-09-20T15:59:45.5143926-03:00'
WHERE [IdColeta] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_MATERIAIS] SET [IdOrdemGrandeza] = 0, [OrdemDeGrandezaIdOrdemGrandeza] = NULL
WHERE [IdMaterial] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x5DC264CF739475824E61B655D89D5AC9471C6A0B4C09E7E5DF0960B4A91B8BD40782375FA2793B900009E659F233D2C1B029AD7E467150C04B0B84D74F82612B04563EB8119748543E32B4BAD90D0B1C2D421ACCD0F7572166F9273EEDBBFE3BE09640B2371B1D969B756AFC1735ACF03CB420A002B2C9A65F712D73A1E9D6C8
WHERE [IdUsuario] = 1;
SELECT @@ROWCOUNT;

GO

CREATE INDEX [IX_TB_PONTUACAO_ColetasIdColeta] ON [TB_PONTUACAO] ([ColetasIdColeta]);
GO

CREATE INDEX [IX_TB_PONTUACAO_UsuarioIdUsuario] ON [TB_PONTUACAO] ([UsuarioIdUsuario]);
GO

CREATE INDEX [IX_TB_PONTOSMATERIAIS_MateriaisIdMaterial] ON [TB_PONTOSMATERIAIS] ([MateriaisIdMaterial]);
GO

CREATE INDEX [IX_TB_PONTOSMATERIAIS_PontosIdPonto] ON [TB_PONTOSMATERIAIS] ([PontosIdPonto]);
GO

CREATE INDEX [IX_TB_MATERIAIS_OrdemDeGrandezaIdOrdemGrandeza] ON [TB_MATERIAIS] ([OrdemDeGrandezaIdOrdemGrandeza]);
GO

ALTER TABLE [TB_MATERIAIS] ADD CONSTRAINT [FK_TB_MATERIAIS_TB_ORDEMGRANDEZA_OrdemDeGrandezaIdOrdemGrandeza] FOREIGN KEY ([OrdemDeGrandezaIdOrdemGrandeza]) REFERENCES [TB_ORDEMGRANDEZA] ([IdOrdemGrandeza]);
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD CONSTRAINT [FK_TB_PONTOSMATERIAIS_TB_MATERIAIS_MateriaisIdMaterial] FOREIGN KEY ([MateriaisIdMaterial]) REFERENCES [TB_MATERIAIS] ([IdMaterial]);
GO

ALTER TABLE [TB_PONTOSMATERIAIS] ADD CONSTRAINT [FK_TB_PONTOSMATERIAIS_TB_PONTOS_PontosIdPonto] FOREIGN KEY ([PontosIdPonto]) REFERENCES [TB_PONTOS] ([IdPonto]);
GO

ALTER TABLE [TB_PONTUACAO] ADD CONSTRAINT [FK_TB_PONTUACAO_TB_COLETAS_ColetasIdColeta] FOREIGN KEY ([ColetasIdColeta]) REFERENCES [TB_COLETAS] ([IdColeta]);
GO

ALTER TABLE [TB_PONTUACAO] ADD CONSTRAINT [FK_TB_PONTUACAO_TB_USUARIOS_UsuarioIdUsuario] FOREIGN KEY ([UsuarioIdUsuario]) REFERENCES [TB_USUARIOS] ([IdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240920185946_Pontuacao', N'8.0.10');
GO

COMMIT;
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

CREATE TABLE [TB_COMENTARIOS] (
    [IdComentario] int NOT NULL IDENTITY,
    [MomentoComentario] datetime2 NOT NULL,
    [TextoComentario] Varchar(200) NOT NULL,
    CONSTRAINT [PK_TB_COMENTARIOS] PRIMARY KEY ([IdComentario])
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

CREATE TABLE [TB_PONTOS] (
    [IdPonto] int NOT NULL IDENTITY,
    [NomePonto] Varchar(200) NOT NULL,
    [EnderecoPonto] Varchar(200) NOT NULL,
    [CepEndereco] int NOT NULL,
    [UfEndereco] Varchar(200) NOT NULL,
    [CidadeEndereco] Varchar(200) NOT NULL,
    [IdTipoPonto] int NOT NULL,
    CONSTRAINT [PK_TB_PONTOS] PRIMARY KEY ([IdPonto])
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

CREATE TABLE [TB_TIPOPONTO] (
    [IdTipoPonto] int NOT NULL,
    [DescricaoTipoPonto] Varchar(200) NOT NULL,
    [StatusTipoPonto] bit NOT NULL,
    CONSTRAINT [PK_TB_TIPOPONTO] PRIMARY KEY ([IdTipoPonto]),
    CONSTRAINT [FK_TB_TIPOPONTO_TB_PONTOS_IdTipoPonto] FOREIGN KEY ([IdTipoPonto]) REFERENCES [TB_PONTOS] ([IdPonto]) ON DELETE CASCADE
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

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'Material', N'NomeMaterial') AND [object_id] = OBJECT_ID(N'[TB_MATERIAIS]'))
    SET IDENTITY_INSERT [TB_MATERIAIS] ON;
INSERT INTO [TB_MATERIAIS] ([IdMaterial], [Material], [NomeMaterial])
VALUES (1, 1, 'Garrafa Pet'),
(2, 4, 'Papelão'),
(3, 1, 'Saco Plástico'),
(4, 2, 'Lata de Feijoada'),
(5, 2, 'Latinha'),
(6, 1, 'Garrafa Pet'),
(7, 3, 'Jarra de Vidro');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdMaterial', N'Material', N'NomeMaterial') AND [object_id] = OBJECT_ID(N'[TB_MATERIAIS]'))
    SET IDENTITY_INSERT [TB_MATERIAIS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParceiro', N'DataDoacao', N'DoacaoParceiro', N'IdUsuario', N'NomeParceiro', N'StatusParceiro', N'UsuarioIdUsuario') AND [object_id] = OBJECT_ID(N'[TB_PARCEIROS]'))
    SET IDENTITY_INSERT [TB_PARCEIROS] ON;
INSERT INTO [TB_PARCEIROS] ([IdParceiro], [DataDoacao], [DoacaoParceiro], [IdUsuario], [NomeParceiro], [StatusParceiro], [UsuarioIdUsuario])
VALUES (1, '0001-01-01T00:00:00.0000000', 500.0E0, 1, 'Empresa BlaBla', CAST(0 AS bit), NULL),
(2, '0001-01-01T00:00:00.0000000', 500.0E0, 2, 'Market Empresa', CAST(0 AS bit), NULL),
(3, '0001-01-01T00:00:00.0000000', 500.0E0, 3, 'Empresa Eletro', CAST(0 AS bit), NULL),
(4, '0001-01-01T00:00:00.0000000', 500.0E0, 4, 'Empresa Papel', CAST(0 AS bit), NULL),
(5, '0001-01-01T00:00:00.0000000', 500.0E0, 5, 'Empresa Rainiken', CAST(0 AS bit), NULL),
(6, '0001-01-01T00:00:00.0000000', 500.0E0, 6, 'Empresa squol', CAST(0 AS bit), NULL),
(7, '0001-01-01T00:00:00.0000000', 500.0E0, 7, 'Empresa suifiti', CAST(0 AS bit), NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdParceiro', N'DataDoacao', N'DoacaoParceiro', N'IdUsuario', N'NomeParceiro', N'StatusParceiro', N'UsuarioIdUsuario') AND [object_id] = OBJECT_ID(N'[TB_PARCEIROS]'))
    SET IDENTITY_INSERT [TB_PARCEIROS] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] ON;
INSERT INTO [TB_USUARIOS] ([IdUsuario], [DataAcesso], [EmailUsuario], [Latitude], [Longitude], [NomeUsuario], [PasswordHash], [PasswordSalt], [Perfil])
VALUES (1, NULL, 'seuEmail@gmail.com', -23.520024100000001E0, -46.596497999999997E0, 'admin', 0xEBDA9414787368146C76FB9475E24A7D37E227C8A087C303C52C94A552F366351FAC1A8F97194BEA2FB0250874A33A0F0DC3ED1E26A7593B1884204F4594E86E5784DD132ED2291CAB3E0F77E833134486E9837BD009B7D855B78C90CAC2791CC4C5DBE1EC0197E0F5D2B17F7E057CB527B8A8B1054ED17845682573290C3E74, NULL, 'Admin');
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'IdUsuario', N'DataAcesso', N'EmailUsuario', N'Latitude', N'Longitude', N'NomeUsuario', N'PasswordHash', N'PasswordSalt', N'Perfil') AND [object_id] = OBJECT_ID(N'[TB_USUARIOS]'))
    SET IDENTITY_INSERT [TB_USUARIOS] OFF;
GO

CREATE INDEX [IX_TB_PARCEIROS_UsuarioIdUsuario] ON [TB_PARCEIROS] ([UsuarioIdUsuario]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240921192733_InicialMigration', N'8.0.10');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164937-03:00'
WHERE [IdColeta] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164938-03:00'
WHERE [IdColeta] = 2;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164939-03:00'
WHERE [IdColeta] = 3;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164940-03:00'
WHERE [IdColeta] = 4;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164941-03:00'
WHERE [IdColeta] = 5;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164942-03:00'
WHERE [IdColeta] = 6;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COLETAS] SET [MomentoColeta] = '2024-10-12T20:58:10.1164943-03:00'
WHERE [IdColeta] = 7;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_COMENTARIOS] SET [MomentoComentario] = '2024-10-12T20:58:10.1164853-03:00'
WHERE [IdComentario] = 1;
SELECT @@ROWCOUNT;

GO

UPDATE [TB_USUARIOS] SET [PasswordHash] = 0x1C6CF7E5B9002D35B09343EC2E1A41CD97232406BF6446FB53B05D9117A6E9964DA6642FBCD3C828580FD7EEC675610BF9ED737431DDDB439B6A3A523CBF0034F881002B3ED2A7C284F5188B5B30FA0FAF501B81CBB75E7C3E0502D31A02F4833AA252488F2DCC6B9DBADE007E6690B49EE937452F5E2D62197BA11BA0E5D26A
WHERE [IdUsuario] = 1;
SELECT @@ROWCOUNT;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20241012235810_SeedTipoDePontoData', N'8.0.10');
GO

COMMIT;
GO

