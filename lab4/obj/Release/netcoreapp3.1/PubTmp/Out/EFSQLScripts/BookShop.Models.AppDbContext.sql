IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155317_Initial')
BEGIN
    CREATE TABLE [Category] (
        [ID] int NOT NULL IDENTITY,
        [CategoryName] nvarchar(max) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_Category] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155317_Initial')
BEGIN
    CREATE TABLE [Book] (
        [BookID] int NOT NULL IDENTITY,
        [BookName] nvarchar(max) NULL,
        [Author] nvarchar(max) NULL,
        [Img] nvarchar(max) NULL,
        [Price] decimal(18,2) NOT NULL,
        [CategoryID] int NOT NULL,
        CONSTRAINT [PK_Book] PRIMARY KEY ([BookID]),
        CONSTRAINT [FK_Book_Category_CategoryID] FOREIGN KEY ([CategoryID]) REFERENCES [Category] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155317_Initial')
BEGIN
    CREATE INDEX [IX_Book_CategoryID] ON [Book] ([CategoryID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155317_Initial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201020155317_Initial', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155602_ShopCart')
BEGIN
    CREATE TABLE [ShopCartItem] (
        [ID] int NOT NULL IDENTITY,
        [BookID] int NULL,
        [Price] decimal(18,2) NOT NULL,
        [ShopCartID] nvarchar(max) NULL,
        CONSTRAINT [PK_ShopCartItem] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_ShopCartItem_Book_BookID] FOREIGN KEY ([BookID]) REFERENCES [Book] ([BookID]) ON DELETE NO ACTION
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155602_ShopCart')
BEGIN
    CREATE INDEX [IX_ShopCartItem_BookID] ON [ShopCartItem] ([BookID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155602_ShopCart')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201020155602_ShopCart', N'3.1.9');
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155842_Order')
BEGIN
    CREATE TABLE [Order] (
        [ID] int NOT NULL IDENTITY,
        [Name] nvarchar(10) NOT NULL,
        [Surname] nvarchar(10) NOT NULL,
        [Adress] nvarchar(20) NOT NULL,
        [Phone] nvarchar(11) NOT NULL,
        [Email] nvarchar(15) NOT NULL,
        [OrderTime] datetime2 NOT NULL,
        CONSTRAINT [PK_Order] PRIMARY KEY ([ID])
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155842_Order')
BEGIN
    CREATE TABLE [OrderDetail] (
        [ID] int NOT NULL IDENTITY,
        [OrderID] int NOT NULL,
        [BookID] int NOT NULL,
        [Price] decimal(18,2) NOT NULL,
        CONSTRAINT [PK_OrderDetail] PRIMARY KEY ([ID]),
        CONSTRAINT [FK_OrderDetail_Book_BookID] FOREIGN KEY ([BookID]) REFERENCES [Book] ([BookID]) ON DELETE CASCADE,
        CONSTRAINT [FK_OrderDetail_Order_OrderID] FOREIGN KEY ([OrderID]) REFERENCES [Order] ([ID]) ON DELETE CASCADE
    );
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155842_Order')
BEGIN
    CREATE INDEX [IX_OrderDetail_BookID] ON [OrderDetail] ([BookID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155842_Order')
BEGIN
    CREATE INDEX [IX_OrderDetail_OrderID] ON [OrderDetail] ([OrderID]);
END;

GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20201020155842_Order')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20201020155842_Order', N'3.1.9');
END;

GO

