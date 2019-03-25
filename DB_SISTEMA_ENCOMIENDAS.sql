

--CREACION DE LA BASE DE DATOS
IF EXISTS(SELECT 1 FROM MASTER.SYS.SYSDATABASES WHERE NAME ='DB_SISTEMA_ENCOMIENDAS')
BEGIN
  USE MASTER;
  DROP DATABASE DB_SISTEMA_ENCOMIENDAS;
END;

CREATE DATABASE DB_SISTEMA_ENCOMIENDAS;

--CREACION DE LAS TABLAS
USE DB_SISTEMA_ENCOMIENDAS;
IF OBJECT_ID (N'T_Privilegios', N'U') IS NULL
BEGIN
  CREATE TABLE T_Privilegios 
  (
    Id_Privilegio INT NOT NULL IDENTITY(1,1),
	Privilegio VARCHAR(20) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Privilegio  PRIMARY KEY NONCLUSTERED
    (
	  Id_Privilegio  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Privilegios_Sequential
  ON T_Privilegios (Id_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Roles', N'U') IS NULL
BEGIN
  CREATE TABLE T_Roles 
  (
    Id_Rol INT NOT NULL IDENTITY(1,1),
	Rol VARCHAR(20) NOT NULL,
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Rol PRIMARY KEY NONCLUSTERED
    (
	  Id_Rol  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Roles_Sequential
  ON T_Roles (Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Roles_Privilegios', N'U') IS NULL
BEGIN
  CREATE TABLE T_Roles_Privilegios 
  (
    Id_Rol_Privilegio INT NOT NULL IDENTITY(1,1),
	Id_Rol INT NOT NULL,
	Id_Privilegio INT NOT NULL,
    CONSTRAINT  PK_Id_Rol_Privilegio PRIMARY KEY NONCLUSTERED
    (
	  Id_Rol_Privilegio  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Roles_Privilegios_Sequential
  ON T_Roles_Privilegios (Id_Rol_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Privilegios_Id_Rol
  ON T_Roles_Privilegios(Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Privilegios_Id_Privilegio
  ON T_Roles_Privilegios(Id_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Roles_Privilegios
    ADD CONSTRAINT FK_T_Roles_Privilegios_Id_Rol
    FOREIGN KEY(Id_Rol)
    REFERENCES T_Roles(Id_Rol)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Roles_Privilegios
    ADD CONSTRAINT FK_T_Roles_Privilegios_Id_Privilegio
    FOREIGN KEY(Id_Privilegio)
    REFERENCES T_Privilegios(Id_Privilegio)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Direcciones', N'U') IS NULL
BEGIN
  CREATE TABLE T_Direcciones 
  (
    Id_Direccion INT NOT NULL IDENTITY(1,1),
	Provincia VARCHAR(50) NOT NULL,
	Canton VARCHAR(50) NOT NULL,
	Distrito VARCHAR(50) NOT NULL,
	Direccion_Exacta VARCHAR(MAX) NOT NULL,
    CONSTRAINT  PK_Id_Direccion PRIMARY KEY NONCLUSTERED
    (
	  Id_Direccion  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Direcciones_Sequential
  ON T_Direcciones (Id_Direccion)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Personas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Personas 
  (
    Id_Persona INT NOT NULL IDENTITY(1,1),
	Cedula VARCHAR(30) NOT NULL,
	Nombre VARCHAR(50) NOT NULL,
	Primer_Apellido VARCHAR(50) NOT NULL,
	Segundo_Apellido VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL,
	Telefono VARCHAR(30) NOT NULL,
	Usuario VARCHAR(30) NOT NULL,
	Contrasena VARCHAR(30) NOT NULL,
	Id_Direccion INT NOT NULL,
	Super_Usuario BIT NOT NULL DEFAULT(0),
	Activo BIT NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Id_Persona PRIMARY KEY NONCLUSTERED
    (
	  Id_Persona  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Personas_Sequential
  ON T_Personas (Id_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Personas_Id_Direccion
  ON T_Personas(Id_Direccion)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Personas
    ADD CONSTRAINT FK_T_Personas_Id_Direccion
    FOREIGN KEY(Id_Direccion)
    REFERENCES T_Direcciones(Id_Direccion)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Tarjetas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Tarjetas 
  (
    Id_Tarjeta INT NOT NULL IDENTITY(1,1),
	Numero_tarjeta VARCHAR(50) NOT NULL,
	Id_Persona INT NOT NULL,
    CONSTRAINT  PK_Id_Tarjeta PRIMARY KEY NONCLUSTERED
    (
	  Id_Tarjeta  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Tarjetas_Sequential
  ON T_Tarjetas (Id_Tarjeta)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Tarjetas_Id_Persona
  ON T_Tarjetas(Id_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Tarjetas
    ADD CONSTRAINT FK_T_Tarjetas_Id_Persona
    FOREIGN KEY(Id_Persona)
    REFERENCES T_Personas(Id_Persona)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Roles_Personas', N'U') IS NULL
BEGIN
  CREATE TABLE T_Roles_Personas 
  (
    Id_Rol_Persona INT NOT NULL IDENTITY(1,1),
	Id_Rol INT NOT NULL,
	Id_Persona INT NOT NULL,
    CONSTRAINT  PK_Id_Rol_Persona PRIMARY KEY NONCLUSTERED
    (
	  Id_Rol_Persona  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Roles_Personas_Sequential
  ON T_Roles_Personas (Id_Rol_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Personas_Id_Rol
  ON T_Roles_Personas(Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Roles_Personas_Id_Persona
  ON T_Roles_Personas(Id_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Roles_Personas
    ADD CONSTRAINT FK_T_Roles_Personas_Id_Rol
    FOREIGN KEY(Id_Rol)
    REFERENCES T_Roles(Id_Rol)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Roles_Personas
    ADD CONSTRAINT FK_T_Roles_Personas_Id_Persona
    FOREIGN KEY(Id_Persona)
    REFERENCES T_Personas(Id_Persona)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Promociones', N'U') IS NULL
BEGIN
  CREATE TABLE T_Promociones 
  (
    Id_Promocion INT NOT NULL IDENTITY(1,1),
	Descripcion VARCHAR(50) NOT NULL,
	Monto MONEY NOT NULL DEFAULT(0),
	Id_Persona INT NOT NULL,
    CONSTRAINT  PK_Id_Promocion PRIMARY KEY NONCLUSTERED
    (
	  Id_Promocion  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Promociones_Sequential
  ON T_Promociones (Id_Promocion)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Promociones_Id_Persona
  ON T_Promociones(Id_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Promociones
    ADD CONSTRAINT FK_T_Promociones_Id_Persona
    FOREIGN KEY(Id_Persona)
    REFERENCES T_Personas(Id_Persona)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Sucursales', N'U') IS NULL
BEGIN
  CREATE TABLE T_Sucursales 
  (
    Id_Sucursal INT NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Id_Direccion INT NOT NULL,
	Activo BIT NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Id_Sucursal PRIMARY KEY NONCLUSTERED
    (
	  Id_Sucursal  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Sucursales_Sequential
  ON T_Sucursales (Id_Sucursal)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Sucursales_Id_Direccion
  ON T_Sucursales(Id_Direccion)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Sucursales
    ADD CONSTRAINT FK_T_Sucursales_Id_Direccion
    FOREIGN KEY(Id_Direccion)
    REFERENCES T_Direcciones(Id_Direccion)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Estados', N'U') IS NULL
BEGIN
  CREATE TABLE T_Estados 
  (
    Id_Estado INT NOT NULL IDENTITY(1,1),
	Descripcion VARCHAR(50) NOT NULL,
    CONSTRAINT  PK_Id_Estados PRIMARY KEY NONCLUSTERED
    (
	  Id_Estado  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Estados_Sequential
  ON T_Estados (Id_Estado)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Recibos', N'U') IS NULL
BEGIN
  CREATE TABLE T_Recibos 
  (
    Id_Recibo INT NOT NULL IDENTITY(1,1),
	Sub_Total MONEY NOT NULL DEFAULT(0),
	Impuesto MONEY NOT NULL DEFAULT(0),
	Envio MONEY NOT NULL DEFAULT(0),
	Total MONEY NOT NULL DEFAULT(0),
	Pagado BIT NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Id_Recibo PRIMARY KEY NONCLUSTERED
    (
	  Id_Recibo  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Recibos_Sequential
  ON T_Recibos (Id_Recibo)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Categorias', N'U') IS NULL
BEGIN
  CREATE TABLE T_Categorias 
  (
    Id_Categoria INT NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Arancel MONEY NOT NULL DEFAULT(0),
	Costo_Por_Kilo MONEY NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Id_Categoria PRIMARY KEY NONCLUSTERED
    (
	  Id_Categoria  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Categorias_Sequential
  ON T_Categorias (Id_Categoria)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];
END;  

IF OBJECT_ID (N'T_Paquetes', N'U') IS NULL
BEGIN
  CREATE TABLE T_Paquetes 
  (
    Id_Paquete INT NOT NULL IDENTITY(1,1),
	Descripcion VARCHAR(50) NOT NULL,
	Peso FLOAT NOT NULL DEFAULT(0),
	Id_Categoria INT NOT NULL,
	Id_Estado INT NOT NULL,
	Id_Sucursal INT NOT NULL,
	Id_Persona INT NOT NULL,
	Id_Recibo INT NOT NULL
    CONSTRAINT  PK_Id_Paquete PRIMARY KEY NONCLUSTERED
    (
	  Id_Paquete  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Paquetes_Sequential
  ON T_Paquetes (Id_Paquete)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Id_Categoria
  ON T_Paquetes(Id_Categoria)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Id_Estado
  ON T_Paquetes(Id_Estado)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Id_Sucursal
  ON T_Paquetes(Id_Sucursal)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Id_Persona
  ON T_Paquetes(Id_Persona)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Id_Recibo
  ON T_Paquetes(Id_Recibo)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Paquetes
    ADD CONSTRAINT FK_T_Paquetes_Id_Categoria
    FOREIGN KEY(Id_Categoria)
    REFERENCES T_Categorias(Id_Categoria)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Paquetes
    ADD CONSTRAINT FK_T_Paquetes_Id_Estado
    FOREIGN KEY(Id_Estado)
    REFERENCES T_Estados(Id_Estado)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Paquetes
    ADD CONSTRAINT FK_T_Paquetes_Id_Sucursal
    FOREIGN KEY(Id_Sucursal)
    REFERENCES T_Sucursales(Id_Sucursal)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Paquetes
    ADD CONSTRAINT FK_T_Paquetes_Id_Persona
    FOREIGN KEY(Id_Persona)
    REFERENCES T_Personas(Id_Persona)
    ON UPDATE NO ACTION
    ON DELETE NO ACTION
    NOT FOR REPLICATION;

  ALTER TABLE T_Paquetes
    ADD CONSTRAINT FK_T_Paquetes_Id_Recibo
    FOREIGN KEY(Id_Recibo)
    REFERENCES T_Recibos(Id_Recibo)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

--CREACION DE PROCEDURES LISTAR
IF OBJECT_ID('sp_Listar_Categorias') IS NOT NULL DROP PROCEDURE sp_Listar_Categorias
GO

CREATE PROCEDURE sp_Listar_Categorias
AS
BEGIN
  SELECT
    Id_Categoria
    ,Nombre
    ,Arancel
    ,Costo_Por_Kilo
  FROM 
    T_Categorias
End;

IF OBJECT_ID('sp_Listar_Direcciones') IS NOT NULL DROP PROCEDURE sp_Listar_Direcciones
GO

CREATE PROCEDURE sp_Listar_Direcciones
AS
BEGIN
  SELECT
    Id_Direccion
    ,Provincia
    ,Canton
    ,Distrito
	Direccion_Exacta
  FROM 
    T_Direcciones
End;

IF OBJECT_ID('sp_Listar_Estados') IS NOT NULL DROP PROCEDURE sp_Listar_Estados
GO

CREATE PROCEDURE sp_Listar_Estados
AS
BEGIN
  SELECT
    Id_Estado
    ,Descripcion
  FROM 
    T_Estados
End; 

IF OBJECT_ID('sp_Listar_Paquetes') IS NOT NULL DROP PROCEDURE sp_Listar_Paquetes
GO

CREATE PROCEDURE sp_Listar_Paquetes
AS
BEGIN
  SELECT
    Id_Paquete
    ,Descripcion
	,Peso
	,Id_Categoria
	,Id_Estado
	,Id_Sucursal
	,Id_Persona
	,Id_Recibo
  FROM 
    T_Paquetes
End; 

IF OBJECT_ID('sp_Listar_Personas') IS NOT NULL DROP PROCEDURE sp_Listar_Personas
GO

CREATE PROCEDURE sp_Listar_Personas
AS
BEGIN
  SELECT
    Id_Persona
    ,Cedula
	,Nombre
	,Primer_Apellido
	,Segundo_Apellido
	,Email
	,Telefono
	,Usuario
	,Contrasena
	,Id_Direccion
	,Super_Usuario
	,Activo
  FROM 
    T_Personas
End; 

IF OBJECT_ID('sp_Listar_Privilegios') IS NOT NULL DROP PROCEDURE sp_Listar_Privilegios
GO

CREATE PROCEDURE sp_Listar_Privilegios
AS
BEGIN
  SELECT
    Id_Privilegio
    ,Privilegio
	,Descripcion
  FROM 
    T_Privilegios
End; 

IF OBJECT_ID('sp_Listar_Promociones') IS NOT NULL DROP PROCEDURE sp_Listar_Prmociones
GO

CREATE PROCEDURE sp_Listar_Promociones
AS
BEGIN
  SELECT
    Id_Promocion
    ,Descripcion
	,Monto
	,Id_Persona
  FROM 
    T_Promociones
End;

IF OBJECT_ID('sp_Listar_Recibos') IS NOT NULL DROP PROCEDURE sp_Listar_Recibos
GO

CREATE PROCEDURE sp_Listar_Recibos
AS
BEGIN
  SELECT
    Id_Recibo
    ,Sub_Total
	,Impuesto
	,Envio
	,Total
	,Pagado
  FROM 
    T_Recibos
End; 

IF OBJECT_ID('sp_Listar_Roles') IS NOT NULL DROP PROCEDURE sp_Listar_Roles
GO

CREATE PROCEDURE sp_Listar_Roles
AS
BEGIN
  SELECT
    Id_Rol
    ,Rol
	,Descripcion
  FROM 
    T_Roles
End; 

IF OBJECT_ID('sp_Listar_Roles_Personas') IS NOT NULL DROP PROCEDURE sp_Listar_Roles_Personas
GO

CREATE PROCEDURE sp_Listar_Roles_Personas
AS
BEGIN
  SELECT
    Id_Rol_Persona
    ,Id_Rol
	,Id_Persona
  FROM 
    T_Roles_Personas
End;

IF OBJECT_ID('sp_Listar_Roles_Privilegios') IS NOT NULL DROP PROCEDURE sp_Listar_Roles_Privilegios
GO

CREATE PROCEDURE sp_Listar_Roles_Privilegios
AS
BEGIN
  SELECT
    Id_Rol_Privilegio
    ,Id_Rol
	,Id_Privilegio
  FROM 
    T_Roles_Privilegios
End;

IF OBJECT_ID('sp_Listar_Sucursales') IS NOT NULL DROP PROCEDURE sp_Listar_Sucursales
GO

CREATE PROCEDURE sp_Listar_Sucursales
AS
BEGIN
  SELECT
    Id_Sucursal
    ,Nombre
	,Id_Direccion
	,Activo
  FROM 
    T_Sucursales
End;

IF OBJECT_ID('sp_Listar_Tarjetas') IS NOT NULL DROP PROCEDURE sp_Listar_Tarjetas
GO

CREATE PROCEDURE sp_Listar_Tarjetas
AS
BEGIN
  SELECT
    Id_Tarjeta
    ,Numero_tarjeta
	,Id_Persona
  FROM 
    T_Tarjetas
End;