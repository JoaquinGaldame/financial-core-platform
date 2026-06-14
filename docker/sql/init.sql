IF DB_ID(N'financialdb26') IS NULL
BEGIN
    CREATE DATABASE financialdb26;
END;
GO

IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = N'finance')
BEGIN
    CREATE LOGIN finance WITH PASSWORD = 'Finance#621535', CHECK_POLICY = OFF;
END;
GO

USE financialdb26;
GO

IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = N'finance')
BEGIN
    CREATE USER finance FOR LOGIN finance;
END;
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members drm
    INNER JOIN sys.database_principals role_principal
        ON drm.role_principal_id = role_principal.principal_id
    INNER JOIN sys.database_principals member_principal
        ON drm.member_principal_id = member_principal.principal_id
    WHERE role_principal.name = N'db_owner'
      AND member_principal.name = N'finance'
)
BEGIN
    ALTER ROLE db_owner ADD MEMBER finance;
END;
GO
