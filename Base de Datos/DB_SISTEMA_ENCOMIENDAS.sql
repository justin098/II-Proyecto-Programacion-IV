--CREACION DE LA BASE DE DATOS
USE MASTER;

IF EXISTS(SELECT 1 FROM MASTER.SYS.SYSDATABASES WHERE NAME ='DB_SISTEMA_ENCOMIENDAS')
BEGIN
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

IF OBJECT_ID (N'T_Privilegios_Roles', N'U') IS NULL
BEGIN
  CREATE TABLE T_Privilegios_Roles 
  (
    Id_Privilegio_Rol INT NOT NULL IDENTITY(1,1),
	Id_Rol INT NOT NULL,
	Id_Privilegio INT NOT NULL,
    CONSTRAINT  PK_Id_Privilegio_Rol PRIMARY KEY NONCLUSTERED
    (
	  Id_Privilegio_Rol  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Privilegios_Roles_Sequential
  ON T_Privilegios_Roles (Id_Privilegio_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Privilegios_Roles_Id_Rol
  ON T_Privilegios_Roles(Id_Rol)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Privilegios_Roles_Id_Privilegio
  ON T_Privilegios_Roles(Id_Privilegio)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Privilegios_Roles
    ADD CONSTRAINT FK_T_Privilegios_Roles_Id_Rol
    FOREIGN KEY(Id_Rol)
    REFERENCES T_Roles(Id_Rol)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;

  ALTER TABLE T_Privilegios_Roles
    ADD CONSTRAINT FK_T_Privilegios_Roles_Id_Privilegio
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
	Provincia VARCHAR(10) NOT NULL,
	Canton VARCHAR(10) NOT NULL,
	Distrito VARCHAR(10) NOT NULL,
	Direccion_Exacta VARCHAR(250) NOT NULL,
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
	Cedula VARCHAR(15) NOT NULL,
	Nombre VARCHAR(25) NOT NULL,
	Primer_Apellido VARCHAR(25) NOT NULL,
	Segundo_Apellido VARCHAR(25) NOT NULL,
	Email VARCHAR(35) NOT NULL,
	Telefono1 VARCHAR(14) NOT NULL,
	Telefono2 VARCHAR (14) NULL,
	Usuario VARCHAR(15) NOT NULL,
	Contrasena VARCHAR(12) NOT NULL,
	Id_Direccion INT NULL,
	Super_Usuario BIT NOT NULL DEFAULT(0),
	Activo BIT NOT NULL DEFAULT(0),
    CONSTRAINT  PK_Cedula PRIMARY KEY NONCLUSTERED
    (
	  Cedula  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Personas_Unique
  ON T_Personas (Cedula,Email,Usuario)
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
	Numero_tarjeta VARCHAR(20) NOT NULL,
	Cedula VARCHAR(15) NOT NULL,
    CONSTRAINT  PK_Numero_tarjeta PRIMARY KEY NONCLUSTERED
    (
	  Numero_tarjeta  ASC
    ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
  ) ON [PRIMARY]

  CREATE UNIQUE CLUSTERED INDEX IX_T_Tarjetas_Unique
  ON T_Tarjetas (Numero_tarjeta)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  CREATE NONCLUSTERED INDEX FK_T_Tarjetas_Cedula
  ON T_Tarjetas(Cedula)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Tarjetas
    ADD CONSTRAINT FK_T_Tarjetas_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
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
	Cedula VARCHAR(15) NOT NULL,
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

  CREATE NONCLUSTERED INDEX FK_T_Roles_Personas_Cedula
  ON T_Roles_Personas(Cedula)
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
    ADD CONSTRAINT FK_T_Roles_Personas_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Promociones', N'U') IS NULL
BEGIN
  CREATE TABLE T_Promociones 
  (
    Id_Promocion INT NOT NULL IDENTITY(1,1),
	Descripcion VARCHAR(25) NOT NULL,
	Monto MONEY NOT NULL DEFAULT(0),
	Cedula VARCHAR(15) NOT NULL,
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

  CREATE NONCLUSTERED INDEX FK_T_Promociones_Cedula
  ON T_Promociones(Cedula)
    WITH(
    STATISTICS_NORECOMPUTE = OFF,
    IGNORE_DUP_KEY = OFF,
    ALLOW_ROW_LOCKS = ON,
    ALLOW_PAGE_LOCKS = ON
    ) ON [PRIMARY];

  ALTER TABLE T_Promociones
    ADD CONSTRAINT FK_T_Promociones_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
    ON UPDATE CASCADE
    ON DELETE CASCADE
    NOT FOR REPLICATION;
END;  

IF OBJECT_ID (N'T_Sucursales', N'U') IS NULL
BEGIN
  CREATE TABLE T_Sucursales 
  (
    Id_Sucursal INT NOT NULL IDENTITY(1,1),
	Nombre VARCHAR(25) NOT NULL,
	Id_Direccion INT NULL,
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
	Descripcion VARCHAR(25) NOT NULL,
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
	Nombre VARCHAR(25) NOT NULL,
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
	Descripcion VARCHAR(25) NOT NULL,
	Peso FLOAT NOT NULL DEFAULT(0),
	Id_Categoria INT NOT NULL,
	Id_Estado INT NOT NULL,
	Id_Sucursal INT NOT NULL,
	Cedula VARCHAR(15) NOT NULL,
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

  CREATE NONCLUSTERED INDEX FK_T_Paquetes_Cedula
  ON T_Paquetes(Cedula)
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
    ADD CONSTRAINT FK_T_Paquetes_Cedula
    FOREIGN KEY(Cedula)
    REFERENCES T_Personas(Cedula)
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
	,Cedula
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
    Cedula
	,Nombre
	,Primer_Apellido
	,Segundo_Apellido
	,Email
	,Telefono1
	,Telefono2
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
	,Cedula
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
	,Cedula
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
    Numero_tarjeta
	,Cedula
  FROM 
    T_Tarjetas
End;

IF OBJECT_ID('sp_Listar_Sucursales_Direccion') IS NOT NULL DROP PROCEDURE sp_Listar_Sucursales_Direccion
GO

CREATE PROCEDURE sp_Listar_Sucursales_Direccion
AS
BEGIN
  SELECT
    Id_Sucursal
    ,Nombre
	,TD.Id_Direccion
	,Activo
	,TD.Provincia
	,TD.Canton
	,TD.Distrito
	,TD.Direccion_Exacta
  FROM 
    T_Sucursales TS
	INNER JOIN T_Direcciones TD ON TS.Id_Direccion=TD.Id_Direccion
End;

--CREACION DE PROCEDURES FILTAR
IF OBJECT_ID('sp_Filtrar_Categorias') IS NOT NULL DROP PROCEDURE sp_Filtrar_Categorias
GO

CREATE PROCEDURE sp_Filtrar_Categorias
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Categoria
    ,Nombre
    ,Arancel
    ,Costo_Por_Kilo
  FROM 
    T_Categorias
  WHERE
    (Nombre like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Direcciones') IS NOT NULL DROP PROCEDURE sp_Filtrar_Direcciones
GO

CREATE PROCEDURE sp_Filtrar_Direcciones
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Direccion
	,Provincia
	,Canton
	,Distrito
	,Direccion_Exacta
  FROM 
    T_Direcciones
  WHERE
    (Provincia like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Estados') IS NOT NULL DROP PROCEDURE sp_Filtrar_Estados
GO

CREATE PROCEDURE sp_Filtrar_Estados
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Estado
	,Descripcion
  FROM 
    T_Estados
  WHERE
    (Id_Estado like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Paquetes') IS NOT NULL DROP PROCEDURE sp_Filtrar_Paquetes
GO

CREATE PROCEDURE sp_Filtrar_Paquetes
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Paquete
	,Descripcion
	,Peso
	,Id_Categoria
	,Id_Estado
	,Id_Sucursal
	,Cedula
	Id_Recibo
  FROM 
    T_Paquetes
  WHERE
    (Id_Paquete like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Personas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Personas
GO

CREATE PROCEDURE sp_Filtrar_Personas
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
	Cedula
	,Nombre
	,Primer_Apellido
	,Segundo_Apellido
	,Email
	,Telefono1
	,Telefono2
	,Usuario
	,Contrasena
	,Id_Direccion
	,Super_Usuario
	,Activo
  FROM 
    T_Personas
  WHERE
    (Nombre like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Privilegios') IS NOT NULL DROP PROCEDURE sp_Filtrar_Privilegios
GO

CREATE PROCEDURE sp_Filtrar_Privilegios
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Privilegio
	,Privilegio
	,Descripcion
  FROM 
    T_Privilegios
  WHERE
    (Privilegio like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Privilegios_Roles') IS NOT NULL DROP PROCEDURE sp_Filtrar_Privilegios_Roles
GO

CREATE PROCEDURE sp_Filtrar_Privilegios_Roles
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Privilegio_Rol
	,Id_Rol
	,Id_Privilegio
  FROM 
    T_Privilegios_Roles
  WHERE
    (Id_Privilegio_Rol like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Promociones') IS NOT NULL DROP PROCEDURE sp_Filtrar_Promociones
GO

CREATE PROCEDURE sp_Filtrar_Promociones
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Promocion 
	,Descripcion
	,Monto
	,Cedula
  FROM 
    T_Promociones
  WHERE
    (Id_Promocion like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Recibos') IS NOT NULL DROP PROCEDURE sp_Filtrar_Recibos
GO

CREATE PROCEDURE sp_Filtrar_Recibos
(
	@Filtro varchar(25)
)
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
  WHERE
    (Id_Recibo like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Roles') IS NOT NULL DROP PROCEDURE sp_Filtrar_Roles
GO

CREATE PROCEDURE sp_Filtrar_Roles
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Rol
	,Rol
	,Descripcion
  FROM 
    T_Roles
  WHERE
    (Descripcion like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Roles_Personas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Roles_Personas
GO

CREATE PROCEDURE sp_Filtrar_Roles_Personas
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Rol_Persona
	,Id_Rol
	,Cedula
  FROM 
    T_Roles_Personas
  WHERE
    (Id_Rol_Persona like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Sucursales') IS NOT NULL DROP PROCEDURE sp_Filtrar_Sucursales
GO

CREATE PROCEDURE sp_Filtrar_Sucursales
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Id_Sucursal
	,Nombre
	,Id_Direccion
	,Activo
  FROM 
    T_Sucursales
  WHERE
    (Nombre like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Filtrar_Tarjetas') IS NOT NULL DROP PROCEDURE sp_Filtrar_Tarjetas
GO

CREATE PROCEDURE sp_Filtrar_Tarjetas
(
	@Filtro varchar(25)
)
AS
BEGIN
  SELECT
    Numero_tarjeta
	,Cedula
  FROM 
    T_Tarjetas
  WHERE
    (Numero_tarjeta like '%'+@Filtro+'%')
End;

IF OBJECT_ID('sp_Listar_Sucursales_Direccion_Filtro') IS NOT NULL DROP PROCEDURE sp_Listar_Sucursales_Direccion_Filtro
GO

CREATE PROCEDURE sp_Listar_Sucursales_Direccion_Filtro
@pNombre VARCHAR(25)
AS
BEGIN
  SELECT
    Id_Sucursal
    ,Nombre
	,TD.Id_Direccion
	,Activo
	,TD.Provincia
	,TD.Canton
	,TD.Distrito
	,TD.Direccion_Exacta
  FROM 
    T_Sucursales TS
	INNER JOIN T_Direcciones TD ON TS.Id_Direccion=TD.Id_Direccion
	WHERE Nombre like '%'+@pNombre+'%'
End;

--CREACION DE PROCEDURES INSERTAR
IF OBJECT_ID('sp_Insertar_Persona]') IS NOT NULL DROP PROCEDURE sp_Insertar_Persona
GO

Create Procedure sp_Insertar_Persona

(
  @Cedula VARCHAR(15)
  ,@Nombre VARCHAR(25)
  ,@Primer_Apellido VARCHAR(25)
  ,@Segundo_Apellido VARCHAR(25)
  ,@Email VARCHAR(35)
  ,@Telefono1 VARCHAR(14)
  ,@Telefono2 VARCHAR(14)
  ,@Usuario VARCHAR(15)
  ,@Contrasena VARCHAR(12)
  ,@Id_Direccion INT
  ,@Super_Usuario BIT
  ,@Activo BIT
)
As
Begin

INSERT INTO T_Personas
           (Cedula,Nombre,Primer_Apellido,Segundo_Apellido,Email,Telefono1
           ,Telefono2,Usuario,Contrasena,Id_Direccion,Super_Usuario,Activo)
VALUES
           (@Cedula,@Nombre,@Primer_Apellido,@Segundo_Apellido,@Email,@Telefono1
           ,@Telefono2,@Usuario,@Contrasena,@Id_Direccion,@Super_Usuario,@Activo)

End


--CREACION DE PROCEDURES MODIFICAR
IF OBJECT_ID('sp_Modificar_Persona]') IS NOT NULL DROP PROCEDURE sp_Modificar_Persona
GO

Create Procedure sp_Modificar_Persona

(
  @Cedula VARCHAR(15)
  ,@Nombre VARCHAR(25)
  ,@Primer_Apellido VARCHAR(25)
  ,@Segundo_Apellido VARCHAR(25)
  ,@Email VARCHAR(35)
  ,@Telefono1 VARCHAR(14)
  ,@Telefono2 VARCHAR(14)
  ,@Usuario VARCHAR(15)
  ,@Contrasena VARCHAR(12)
  ,@Id_Direccion INT
  ,@Super_Usuario BIT
  ,@Activo BIT
)
As
Begin

  UPDATE 
    T_Personas
  SET
	Nombre = @Nombre,
	Primer_Apellido = @Primer_Apellido,
	Segundo_Apellido = @Segundo_Apellido,
	Email = @Email,
	Telefono1 = @Telefono1,
	Telefono2 = @Telefono2,
	Usuario = @Usuario,
	Contrasena = @Contrasena,
	Id_Direccion = @Id_Direccion,
	Super_Usuario = @Super_Usuario,
	Activo = @Activo
  WHERE
    (Cedula = @Cedula)

End


--CREACION DE PROCEDURES ELIMINAR
IF OBJECT_ID('sp_Eliminar_Persona') IS NOT NULL DROP PROCEDURE sp_Eliminar_Persona
GO

Create Procedure sp_Eliminar_Persona

(
	@Cedula varchar(15)
)
As
Begin

DELETE FROM T_Personas WHERE (Cedula = @Cedula);

End

--CREACION DE PROCEDURES MEMBERSHIP
IF OBJECT_ID('sp_Login') IS NOT NULL DROP PROCEDURE sp_Login
GO

CREATE PROCEDURE sp_Login

(
  @UserLogin VARCHAR(15)
  ,@Contrasena VARCHAR(12)
)
As
BEGIN
  SELECT
    1
  FROM
    T_Personas
  WHERE
    (Email = @UserLogin AND Contrasena = @Contrasena)
	OR (Usuario = @UserLogin AND Contrasena = @Contrasena)
End

IF OBJECT_ID('sp_Has_Privilege') IS NOT NULL DROP PROCEDURE sp_Has_Privilege
GO

CREATE PROCEDURE sp_Has_Privilege

(
  @Usuario VARCHAR(35)
  ,@Privilegio VARCHAR(20)
)
As
BEGIN
  DECLARE @superUsuario BIT;
  SET @superUsuario = 0;

  SELECT @superUsuario = Super_Usuario FROM T_Personas WHERE Usuario = @Usuario;

  IF @superUsuario = 1
  BEGIN
    SELECT @superUsuario Has_Privilege; 
  END
  ELSE
  BEGIN
    SELECT
	*
	FROM
	T_Personas P
	INNER JOIN
	T_Roles_Personas RP
	ON
	(RP.Cedula = P.Cedula)
	INNER JOIN
	T_Roles R
	ON
	(R.Id_Rol = RP.Id_Rol)
	INNER JOIN
	T_Privilegios_Roles PR
	ON
	(PR.Id_Rol = R.Id_Rol)
	INNER JOIN
	T_Privilegios PRI
	ON
	(PRI.Id_Privilegio = PR.Id_Privilegio)
	WHERE
	(P.Usuario = @Usuario AND PRI.Privilegio = @Privilegio)
  END
End

--INSERTS INICIALES
IF NOT EXISTS(SELECT 1 FROM T_Personas WHERE Usuario = 'admin')
  INSERT INTO T_Personas
    (Cedula, Nombre, Primer_Apellido, Segundo_Apellido, Email, Telefono1, Telefono2, Usuario, Contrasena, Super_Usuario, Activo)
  VALUES
    ('1-1111-1111', 'AAAA', 'SSSS', 'LLLL', 'admin@admin.com', '22222222', '88888888', 'admin', '1234', 1, 1);