
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/06/2015 19:32:17
-- Generated from EDMX file: D:\Documents\Visual Studio 2013\Projects\Tp2\Tp2\Modelo1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [D:\DOCUMENTS\MIBASEPRUEBA.MDF];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CaracteristicaFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracteristicaSet] DROP CONSTRAINT [FK_CaracteristicaFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_FactorProyecto_Factor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactorProyecto] DROP CONSTRAINT [FK_FactorProyecto_Factor];
GO
IF OBJECT_ID(N'[dbo].[FK_FactorProyecto_Proyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FactorProyecto] DROP CONSTRAINT [FK_FactorProyecto_Proyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_GerenteProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyectoSet] DROP CONSTRAINT [FK_GerenteProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_PonderacionFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PonderacionSet] DROP CONSTRAINT [FK_PonderacionFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_PonderacionProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PonderacionSet] DROP CONSTRAINT [FK_PonderacionProyecto];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FactorSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactorSet];
GO
IF OBJECT_ID(N'[dbo].[CaracteristicaSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaracteristicaSet];
GO
IF OBJECT_ID(N'[dbo].[ProyectoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProyectoSet];
GO
IF OBJECT_ID(N'[dbo].[GerenteSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GerenteSet];
GO
IF OBJECT_ID(N'[dbo].[PonderacionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PonderacionSet];
GO
IF OBJECT_ID(N'[dbo].[FactorProyecto]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FactorProyecto];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'FactorSet'
CREATE TABLE [dbo].[FactorSet] (
    [idFactor] int IDENTITY(1,1) NOT NULL,
    [nombreFactor] nvarchar(max)  NULL
);
GO

-- Creating table 'CaracteristicaSet'
CREATE TABLE [dbo].[CaracteristicaSet] (
    [idCaracteristica] int IDENTITY(1,1) NOT NULL,
    [denominacion] nvarchar(max)  NULL,
    [valor] int  NULL,
    [Factor_idFactor] int  NOT NULL
);
GO

-- Creating table 'ProyectoSet'
CREATE TABLE [dbo].[ProyectoSet] (
    [idProyecto] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NULL,
    [descripcion] nvarchar(max)  NULL,
    [fecha] datetime  NULL,
    [Gerente_idGerente] int  NOT NULL
);
GO

-- Creating table 'GerenteSet'
CREATE TABLE [dbo].[GerenteSet] (
    [idGerente] int IDENTITY(1,1) NOT NULL,
    [nombre] nvarchar(max)  NULL,
    [apellido] nvarchar(max)  NULL
);
GO

-- Creating table 'PonderacionSet'
CREATE TABLE [dbo].[PonderacionSet] (
    [idPonderacion] int IDENTITY(1,1) NOT NULL,
    [valor] int  NULL,
    [Factor_idFactor] int  NOT NULL,
    [Proyecto_idProyecto] int  NOT NULL
);
GO

-- Creating table 'FactorProyecto'
CREATE TABLE [dbo].[FactorProyecto] (
    [Factor_idFactor] int  NOT NULL,
    [Proyecto_idProyecto] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [idFactor] in table 'FactorSet'
ALTER TABLE [dbo].[FactorSet]
ADD CONSTRAINT [PK_FactorSet]
    PRIMARY KEY CLUSTERED ([idFactor] ASC);
GO

-- Creating primary key on [idCaracteristica] in table 'CaracteristicaSet'
ALTER TABLE [dbo].[CaracteristicaSet]
ADD CONSTRAINT [PK_CaracteristicaSet]
    PRIMARY KEY CLUSTERED ([idCaracteristica] ASC);
GO

-- Creating primary key on [idProyecto] in table 'ProyectoSet'
ALTER TABLE [dbo].[ProyectoSet]
ADD CONSTRAINT [PK_ProyectoSet]
    PRIMARY KEY CLUSTERED ([idProyecto] ASC);
GO

-- Creating primary key on [idGerente] in table 'GerenteSet'
ALTER TABLE [dbo].[GerenteSet]
ADD CONSTRAINT [PK_GerenteSet]
    PRIMARY KEY CLUSTERED ([idGerente] ASC);
GO

-- Creating primary key on [idPonderacion] in table 'PonderacionSet'
ALTER TABLE [dbo].[PonderacionSet]
ADD CONSTRAINT [PK_PonderacionSet]
    PRIMARY KEY CLUSTERED ([idPonderacion] ASC);
GO

-- Creating primary key on [Factor_idFactor], [Proyecto_idProyecto] in table 'FactorProyecto'
ALTER TABLE [dbo].[FactorProyecto]
ADD CONSTRAINT [PK_FactorProyecto]
    PRIMARY KEY CLUSTERED ([Factor_idFactor], [Proyecto_idProyecto] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Factor_idFactor] in table 'CaracteristicaSet'
ALTER TABLE [dbo].[CaracteristicaSet]
ADD CONSTRAINT [FK_CaracteristicaFactor]
    FOREIGN KEY ([Factor_idFactor])
    REFERENCES [dbo].[FactorSet]
        ([idFactor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CaracteristicaFactor'
CREATE INDEX [IX_FK_CaracteristicaFactor]
ON [dbo].[CaracteristicaSet]
    ([Factor_idFactor]);
GO

-- Creating foreign key on [Factor_idFactor] in table 'FactorProyecto'
ALTER TABLE [dbo].[FactorProyecto]
ADD CONSTRAINT [FK_FactorProyecto_Factor]
    FOREIGN KEY ([Factor_idFactor])
    REFERENCES [dbo].[FactorSet]
        ([idFactor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Proyecto_idProyecto] in table 'FactorProyecto'
ALTER TABLE [dbo].[FactorProyecto]
ADD CONSTRAINT [FK_FactorProyecto_Proyecto]
    FOREIGN KEY ([Proyecto_idProyecto])
    REFERENCES [dbo].[ProyectoSet]
        ([idProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactorProyecto_Proyecto'
CREATE INDEX [IX_FK_FactorProyecto_Proyecto]
ON [dbo].[FactorProyecto]
    ([Proyecto_idProyecto]);
GO

-- Creating foreign key on [Gerente_idGerente] in table 'ProyectoSet'
ALTER TABLE [dbo].[ProyectoSet]
ADD CONSTRAINT [FK_GerenteProyecto]
    FOREIGN KEY ([Gerente_idGerente])
    REFERENCES [dbo].[GerenteSet]
        ([idGerente])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GerenteProyecto'
CREATE INDEX [IX_FK_GerenteProyecto]
ON [dbo].[ProyectoSet]
    ([Gerente_idGerente]);
GO

-- Creating foreign key on [Factor_idFactor] in table 'PonderacionSet'
ALTER TABLE [dbo].[PonderacionSet]
ADD CONSTRAINT [FK_PonderacionFactor]
    FOREIGN KEY ([Factor_idFactor])
    REFERENCES [dbo].[FactorSet]
        ([idFactor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PonderacionFactor'
CREATE INDEX [IX_FK_PonderacionFactor]
ON [dbo].[PonderacionSet]
    ([Factor_idFactor]);
GO

-- Creating foreign key on [Proyecto_idProyecto] in table 'PonderacionSet'
ALTER TABLE [dbo].[PonderacionSet]
ADD CONSTRAINT [FK_PonderacionProyecto]
    FOREIGN KEY ([Proyecto_idProyecto])
    REFERENCES [dbo].[ProyectoSet]
        ([idProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PonderacionProyecto'
CREATE INDEX [IX_FK_PonderacionProyecto]
ON [dbo].[PonderacionSet]
    ([Proyecto_idProyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------