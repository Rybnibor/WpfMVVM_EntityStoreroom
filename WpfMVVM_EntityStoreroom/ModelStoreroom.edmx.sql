
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 08/18/2015 15:51:51
-- Generated from EDMX file: C:\Users\PACKARD\Documents\Visual Studio 2013\Projects\marka\WpfMVVM_EntityStoreroom\WpfMVVM_EntityStoreroom\ModelStoreroom.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [baza];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ProductsSet'
CREATE TABLE [dbo].[ProductsSet] (
    [ProductID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [Quantity] int  NOT NULL,
    [Rack] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ProductID] in table 'ProductsSet'
ALTER TABLE [dbo].[ProductsSet]
ADD CONSTRAINT [PK_ProductsSet]
    PRIMARY KEY CLUSTERED ([ProductID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------