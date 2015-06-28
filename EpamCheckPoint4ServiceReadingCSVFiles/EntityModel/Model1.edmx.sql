
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 06/28/2015 17:56:43
-- Generated from EDMX file: C:\Users\oag\Desktop\EpamCheckPoint4ServiceReadingCSVFiles\EntityModel\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Service];
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

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL,
    [age] int  NOT NULL
);
GO

-- Creating table 'Managers'
CREATE TABLE [dbo].[Managers] (
    [id] int IDENTITY(1,1) NOT NULL,
    [firstname] nvarchar(max)  NOT NULL,
    [lastname] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Orders'
CREATE TABLE [dbo].[Orders] (
    [id] int IDENTITY(1,1) NOT NULL,
    [idmanager] int  NOT NULL,
    [idclient] int  NOT NULL,
    [idproduct] int  NOT NULL,
    [sum] float  NOT NULL,
    [date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Managers'
ALTER TABLE [dbo].[Managers]
ADD CONSTRAINT [PK_Managers]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [PK_Orders]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [idmanager] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Managers]
    FOREIGN KEY ([idmanager])
    REFERENCES [dbo].[Managers]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Managers'
CREATE INDEX [IX_FK_Orders_Managers]
ON [dbo].[Orders]
    ([idmanager]);
GO

-- Creating foreign key on [idproduct] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Products]
    FOREIGN KEY ([idproduct])
    REFERENCES [dbo].[Products]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Products'
CREATE INDEX [IX_FK_Orders_Products]
ON [dbo].[Orders]
    ([idproduct]);
GO

-- Creating foreign key on [idclient] in table 'Orders'
ALTER TABLE [dbo].[Orders]
ADD CONSTRAINT [FK_Orders_Clients]
    FOREIGN KEY ([idclient])
    REFERENCES [dbo].[Clients]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Orders_Clients'
CREATE INDEX [IX_FK_Orders_Clients]
ON [dbo].[Orders]
    ([idclient]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------