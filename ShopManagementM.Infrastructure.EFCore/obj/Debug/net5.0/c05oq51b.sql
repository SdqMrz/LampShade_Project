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

CREATE TABLE [ProductCategories] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NULL,
    [Description] nvarchar(500) NULL,
    [Picture] nvarchar(1000) NULL,
    [PictureAlt] nvarchar(255) NULL,
    [PictureTitle] nvarchar(500) NULL,
    [KeyWords] nvarchar(80) NOT NULL,
    [MetaDescription] nvarchar(150) NOT NULL,
    [Slug] nvarchar(300) NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ProductCategories] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Products] (
    [Id] bigint NOT NULL IDENTITY,
    [Name] nvarchar(255) NOT NULL,
    [Code] nvarchar(15) NOT NULL,
    [ShortDescription] nvarchar(500) NOT NULL,
    [Description] nvarchar(1000) NULL,
    [IsInStock] bit NOT NULL,
    [UnitPrice] float NOT NULL,
    [Picture] nvarchar(1000) NULL,
    [PictureTitle] nvarchar(500) NULL,
    [PictureAlt] nvarchar(255) NULL,
    [keyWords] nvarchar(100) NOT NULL,
    [MetaDescription] nvarchar(150) NOT NULL,
    [Slug] nvarchar(500) NOT NULL,
    [CategoryId] bigint NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Products_ProductCategories_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [ProductCategories] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProductPictures] (
    [Id] bigint NOT NULL IDENTITY,
    [ProductId] bigint NOT NULL,
    [Picture] nvarchar(1000) NOT NULL,
    [PictureAlt] nvarchar(500) NOT NULL,
    [PictureTitle] nvarchar(500) NOT NULL,
    [IsRemoved] bit NOT NULL,
    [CreationDate] datetime2 NOT NULL,
    CONSTRAINT [PK_ProductPictures] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ProductPictures_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_ProductPictures_ProductId] ON [ProductPictures] ([ProductId]);
GO

CREATE INDEX [IX_Products_CategoryId] ON [Products] ([CategoryId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20220729171808_initdatabase', N'5.0.5');
GO

COMMIT;
GO

