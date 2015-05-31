
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/27/2015 17:41:37
-- Generated from EDMX file: d:\documents\visual studio 2013\Projects\ProyectoNet\AccesoDatos\Modelo1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baseDeAplicacion];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CaracteristicaFactor]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracteristicaSet] DROP CONSTRAINT [FK_CaracteristicaFactor];
GO
IF OBJECT_ID(N'[dbo].[FK_GerenteProyecto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProyectoSet] DROP CONSTRAINT [FK_GerenteProyecto];
GO
IF OBJECT_ID(N'[dbo].[FK_FactorCaracterizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracterizacionSet] DROP CONSTRAINT [FK_FactorCaracterizacion];
GO
IF OBJECT_ID(N'[dbo].[FK_ProyectoCaracterizacion]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CaracterizacionSet] DROP CONSTRAINT [FK_ProyectoCaracterizacion];
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
IF OBJECT_ID(N'[dbo].[CaracterizacionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CaracterizacionSet];
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

-- Creating table 'CaracterizacionSet'
CREATE TABLE [dbo].[CaracterizacionSet] (
    [idCaracterizacion] int IDENTITY(1,1) NOT NULL,
    [Valor] smallint  NOT NULL,
    [Ponderacion] smallint  NOT NULL,
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

-- Creating primary key on [idCaracterizacion] in table 'CaracterizacionSet'
ALTER TABLE [dbo].[CaracterizacionSet]
ADD CONSTRAINT [PK_CaracterizacionSet]
    PRIMARY KEY CLUSTERED ([idCaracterizacion] ASC);
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

-- Creating foreign key on [Factor_idFactor] in table 'CaracterizacionSet'
ALTER TABLE [dbo].[CaracterizacionSet]
ADD CONSTRAINT [FK_FactorCaracterizacion]
    FOREIGN KEY ([Factor_idFactor])
    REFERENCES [dbo].[FactorSet]
        ([idFactor])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FactorCaracterizacion'
CREATE INDEX [IX_FK_FactorCaracterizacion]
ON [dbo].[CaracterizacionSet]
    ([Factor_idFactor]);
GO

-- Creating foreign key on [Proyecto_idProyecto] in table 'CaracterizacionSet'
ALTER TABLE [dbo].[CaracterizacionSet]
ADD CONSTRAINT [FK_ProyectoCaracterizacion]
    FOREIGN KEY ([Proyecto_idProyecto])
    REFERENCES [dbo].[ProyectoSet]
        ([idProyecto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProyectoCaracterizacion'
CREATE INDEX [IX_FK_ProyectoCaracterizacion]
ON [dbo].[CaracterizacionSet]
    ([Proyecto_idProyecto]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------