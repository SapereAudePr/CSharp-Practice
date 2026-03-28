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

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    CREATE TABLE [Corporates] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [Capacity] int NOT NULL,
        CONSTRAINT [PK_Corporates] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    CREATE TABLE [Persons] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(50) NOT NULL,
        [LastName] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Persons] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    CREATE TABLE [Employees] (
        [Id] int NOT NULL IDENTITY,
        [Role] nvarchar(50) NOT NULL,
        [PersonId] int NOT NULL,
        [CorporateId] int NOT NULL,
        CONSTRAINT [PK_Employees] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Employees_Corporates_CorporateId] FOREIGN KEY ([CorporateId]) REFERENCES [Corporates] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Employees_Persons_PersonId] FOREIGN KEY ([PersonId]) REFERENCES [Persons] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacity', N'Name') AND [object_id] = OBJECT_ID(N'[Corporates]'))
        SET IDENTITY_INSERT [Corporates] ON;
    EXEC(N'INSERT INTO [Corporates] ([Id], [Capacity], [Name])
    VALUES (1, 150, N''NyxTech''),
    (2, 85, N''NyxAudio''),
    (3, 75, N''NyxStudio'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Capacity', N'Name') AND [object_id] = OBJECT_ID(N'[Corporates]'))
        SET IDENTITY_INSERT [Corporates] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastName', N'Name') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] ON;
    EXEC(N'INSERT INTO [Persons] ([Id], [LastName], [Name])
    VALUES (1, N''Fernandez'', N''Alicia''),
    (2, N''Smith'', N''Raven''),
    (3, N''Stall'', N''Mike'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'LastName', N'Name') AND [object_id] = OBJECT_ID(N'[Persons]'))
        SET IDENTITY_INSERT [Persons] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorporateId', N'PersonId', N'Role') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] ON;
    EXEC(N'INSERT INTO [Employees] ([Id], [CorporateId], [PersonId], [Role])
    VALUES (1, 1, 1, N''Developer''),
    (2, 2, 2, N''Manager''),
    (3, 3, 3, N''Designer'')');
    IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CorporateId', N'PersonId', N'Role') AND [object_id] = OBJECT_ID(N'[Employees]'))
        SET IDENTITY_INSERT [Employees] OFF;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    CREATE INDEX [IX_Employees_CorporateId] ON [Employees] ([CorporateId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    CREATE UNIQUE INDEX [IX_Employees_PersonId] ON [Employees] ([PersonId]);
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260324230614_InitialMigration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260324230614_InitialMigration', N'8.0.25');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Persons] ADD [CreatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Persons] ADD [UpdatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Employees] ADD [CreatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Employees] ADD [UpdatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Corporates] ADD [CreatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    ALTER TABLE [Corporates] ADD [UpdatedBy] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Corporates] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Corporates] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Corporates] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Employees] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Employees] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Employees] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Persons] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 1;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Persons] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 2;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    EXEC(N'UPDATE [Persons] SET [CreatedBy] = NULL, [UpdatedBy] = NULL
    WHERE [Id] = 3;
    SELECT @@ROWCOUNT');
END;
GO

IF NOT EXISTS (
    SELECT * FROM [__EFMigrationsHistory]
    WHERE [MigrationId] = N'20260327144240_NewFieldsAndUsingTypeConfiguration'
)
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20260327144240_NewFieldsAndUsingTypeConfiguration', N'8.0.25');
END;
GO

COMMIT;
GO

