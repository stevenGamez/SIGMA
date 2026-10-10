-- =============================================
-- Base de datos SIGMA
-- Sistema de mantenimiento de aire acondicionado
-- Proyecto de módulo - Problema 4
--
-- Para crearla se ejecuta todo el script con F5.
-- OJO: si la base ya existe la borra y la vuelve a crear.
-- =============================================

USE master;
GO

-- si ya existe se borra para crearla de cero
IF DB_ID('SIGMA') IS NOT NULL
BEGIN
    ALTER DATABASE SIGMA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE SIGMA;
END
GO

CREATE DATABASE SIGMA;
GO

-- para que no se tarde en abrir en SQL Express
ALTER DATABASE SIGMA SET AUTO_CLOSE OFF;
GO

USE SIGMA;
GO

-- =============================================
-- TABLAS DE ROLES, PERMISOS Y USUARIOS
-- =============================================

-- Roles del sistema (Administrador e Ingeniero)
CREATE TABLE Roles
(
    IdRol        INT            IDENTITY(1,1) PRIMARY KEY,
    Nombre       VARCHAR(30)    NOT NULL UNIQUE,      -- no se repite
    Descripcion  NVARCHAR(150)  NOT NULL
);
GO

-- Permisos que se le pueden dar a un rol
CREATE TABLE Permisos
(
    IdPermiso  INT            IDENTITY(1,1) PRIMARY KEY,
    Clave      VARCHAR(40)    NOT NULL UNIQUE,        -- la clave que usa el programa
    Nombre     NVARCHAR(80)   NOT NULL,
    Modulo     NVARCHAR(30)   NOT NULL                -- a qué pantalla pertenece
);
GO

-- Qué permisos tiene cada rol
CREATE TABLE RolesPermisos
(
    IdRol      INT  NOT NULL,
    IdPermiso  INT  NOT NULL,
    CONSTRAINT PK_RolesPermisos PRIMARY KEY (IdRol, IdPermiso),
    CONSTRAINT FK_RolesPermisos_Roles
        FOREIGN KEY (IdRol) REFERENCES Roles(IdRol),
    CONSTRAINT FK_RolesPermisos_Permisos
        FOREIGN KEY (IdPermiso) REFERENCES Permisos(IdPermiso)
);
GO

-- Usuarios que entran al sistema
CREATE TABLE Usuarios
(
    IdUsuario      INT            IDENTITY(1,1) PRIMARY KEY,
    Nombre         NVARCHAR(100)  NOT NULL,
    NombreUsuario  VARCHAR(30)    NOT NULL UNIQUE,        -- con este inicia sesión
    Contrasena     VARCHAR(100)   NOT NULL,               -- se guarda encriptada con BCrypt
    IdRol          INT            NOT NULL,
    Correo         VARCHAR(100)   NULL,
    Activo         BIT            NOT NULL DEFAULT 1,     -- 1 = activo, 0 = inactivo
    FechaCreacion  DATETIME       NOT NULL DEFAULT GETDATE(),
    UltimoAcceso   DATETIME       NULL,
    CONSTRAINT FK_Usuarios_Roles
        FOREIGN KEY (IdRol) REFERENCES Roles(IdRol)
);
GO

-- =============================================
-- TABLAS DEL SISTEMA
-- =============================================

-- Clientes: las empresas que contratan el mantenimiento
CREATE TABLE Clientes
(
    IdCliente  INT            IDENTITY(1,1) PRIMARY KEY,
    Nombre     NVARCHAR(100)  NOT NULL UNIQUE,        -- nombre de la empresa
    Nit        VARCHAR(17)    NOT NULL UNIQUE,        -- 0000-000000-000-0
    Contacto   NVARCHAR(100)  NOT NULL,               -- persona de contacto
    Telefono   VARCHAR(9)     NOT NULL,               -- 0000-0000
    Correo     VARCHAR(100)   NULL,
    Direccion  NVARCHAR(200)  NOT NULL
);
GO

-- Contratos de mantenimiento de cada cliente
CREATE TABLE Contratos
(
    IdContrato    INT            IDENTITY(1,1) PRIMARY KEY,
    IdCliente     INT            NOT NULL,
    FechaInicio   DATE           NOT NULL,
    FechaFin      DATE           NOT NULL,
    Frecuencia    VARCHAR(15)    NOT NULL,                -- cada cuánto se hace la visita
    MontoMensual  DECIMAL(10,2)  NOT NULL,
    Estado        VARCHAR(15)    NOT NULL,
    Descripcion   NVARCHAR(300)  NULL,
    CONSTRAINT FK_Contratos_Clientes
        FOREIGN KEY (IdCliente) REFERENCES Clientes(IdCliente),
    CONSTRAINT CK_Contratos_Fechas CHECK (FechaFin > FechaInicio),
    CONSTRAINT CK_Contratos_Monto CHECK (MontoMensual > 0),
    CONSTRAINT CK_Contratos_Frecuencia
        CHECK (Frecuencia IN ('Mensual', 'Bimestral', 'Trimestral', 'Semestral', 'Anual')),
    CONSTRAINT CK_Contratos_Estado
        CHECK (Estado IN ('Vigente', 'Suspendido', 'Finalizado'))
);
GO

-- Equipos de aire acondicionado que cubre cada contrato
CREATE TABLE Equipos
(
    IdEquipo          INT            IDENTITY(1,1) PRIMARY KEY,
    IdContrato        INT            NOT NULL,
    NumeroSerie       VARCHAR(30)    NOT NULL UNIQUE,
    Marca             NVARCHAR(40)   NOT NULL,
    Modelo            NVARCHAR(40)   NOT NULL,
    Tipo              VARCHAR(20)    NOT NULL,
    CapacidadBTU      INT            NOT NULL,
    Ubicacion         NVARCHAR(150)  NOT NULL,            -- dónde está instalado
    FechaInstalacion  DATE           NOT NULL,
    Estado            VARCHAR(20)    NOT NULL,
    CONSTRAINT FK_Equipos_Contratos
        FOREIGN KEY (IdContrato) REFERENCES Contratos(IdContrato),
    CONSTRAINT CK_Equipos_Capacidad CHECK (CapacidadBTU > 0),
    CONSTRAINT CK_Equipos_Tipo
        CHECK (Tipo IN ('Mini Split', 'Cassette', 'Piso-Techo', 'Central', 'Ventana', 'Chiller')),
    CONSTRAINT CK_Equipos_Estado
        CHECK (Estado IN ('Operativo', 'En mantenimiento', 'Fuera de servicio'))
);
GO

-- Repuestos (inventario)
CREATE TABLE Repuestos
(
    IdRepuesto      INT            IDENTITY(1,1) PRIMARY KEY,
    Nombre          NVARCHAR(80)   NOT NULL UNIQUE,
    Categoria       NVARCHAR(20)   NOT NULL,
    Existencia      INT            NOT NULL,              -- cuántos hay
    StockMinimo     INT            NOT NULL,              -- para avisar cuando queda poco
    PrecioUnitario  DECIMAL(10,2)  NOT NULL,
    CONSTRAINT CK_Repuestos_Existencia CHECK (Existencia >= 0),
    CONSTRAINT CK_Repuestos_StockMinimo CHECK (StockMinimo >= 0),
    CONSTRAINT CK_Repuestos_Precio CHECK (PrecioUnitario > 0),
    CONSTRAINT CK_Repuestos_Categoria
        CHECK (Categoria IN (N'Eléctrico', N'Mecánico', N'Refrigeración', N'Filtración', N'Otro'))
);
GO

-- Mantenimientos: las visitas, aquí también se guarda la hoja de servicio
CREATE TABLE Mantenimientos
(
    IdMantenimiento   INT            IDENTITY(1,1) PRIMARY KEY,
    IdEquipo          INT            NOT NULL,
    IdIngeniero       INT            NOT NULL,            -- el ingeniero asignado (es un usuario)
    Tipo              VARCHAR(12)    NOT NULL,
    FechaProgramada   DATE           NOT NULL,
    FechaRealizada    DATE           NULL,                -- se llena cuando se hace la visita
    Estado            VARCHAR(15)    NOT NULL,
    Diagnostico       NVARCHAR(500)  NULL,
    TrabajoRealizado  NVARCHAR(500)  NULL,
    Observaciones     NVARCHAR(300)  NULL,
    CONSTRAINT FK_Mantenimientos_Equipos
        FOREIGN KEY (IdEquipo) REFERENCES Equipos(IdEquipo),
    CONSTRAINT FK_Mantenimientos_Usuarios
        FOREIGN KEY (IdIngeniero) REFERENCES Usuarios(IdUsuario),
    CONSTRAINT CK_Mantenimientos_Tipo
        CHECK (Tipo IN ('Preventivo', 'Correctivo')),
    CONSTRAINT CK_Mantenimientos_Estado
        CHECK (Estado IN ('Programado', 'En proceso', 'Completado', 'Cancelado'))
);
GO

-- Repuestos que se usaron en cada mantenimiento
CREATE TABLE MantenimientoRepuestos
(
    IdDetalle        INT            IDENTITY(1,1) PRIMARY KEY,
    IdMantenimiento  INT            NOT NULL,
    IdRepuesto       INT            NOT NULL,
    Cantidad         INT            NOT NULL,
    PrecioUnitario   DECIMAL(10,2)  NOT NULL,
    CONSTRAINT FK_Detalle_Mantenimientos
        FOREIGN KEY (IdMantenimiento) REFERENCES Mantenimientos(IdMantenimiento),
    CONSTRAINT FK_Detalle_Repuestos
        FOREIGN KEY (IdRepuesto) REFERENCES Repuestos(IdRepuesto),
    CONSTRAINT UQ_Detalle_Repuesto UNIQUE (IdMantenimiento, IdRepuesto),
    CONSTRAINT CK_Detalle_Cantidad CHECK (Cantidad > 0)
);
GO

-- Bitácora: lo que hace cada usuario en el sistema
CREATE TABLE RegistroActividad
(
    IdRegistro  INT            IDENTITY(1,1) PRIMARY KEY,
    IdUsuario   INT            NOT NULL,
    Accion      NVARCHAR(200)  NOT NULL,
    Fecha       DATETIME       NOT NULL,
    CONSTRAINT FK_RegistroActividad_Usuarios
        FOREIGN KEY (IdUsuario) REFERENCES Usuarios(IdUsuario)
);
GO

-- =============================================
-- VISTAS
-- =============================================

-- usuarios con el nombre de su rol
CREATE VIEW VistaUsuarios AS
SELECT  Usuarios.IdUsuario, Usuarios.Nombre, Usuarios.NombreUsuario, Usuarios.Contrasena,
        Usuarios.IdRol, Roles.Nombre AS Rol,
        Usuarios.Correo, Usuarios.Activo, Usuarios.FechaCreacion, Usuarios.UltimoAcceso
FROM        Usuarios
INNER JOIN  Roles ON Roles.IdRol = Usuarios.IdRol;
GO

-- permisos de cada rol
CREATE VIEW VistaRolesPermisos AS
SELECT  Roles.IdRol, Roles.Nombre AS Rol,
        Permisos.IdPermiso, Permisos.Clave, Permisos.Nombre AS Permiso, Permisos.Modulo
FROM        RolesPermisos
INNER JOIN  Roles    ON Roles.IdRol        = RolesPermisos.IdRol
INNER JOIN  Permisos ON Permisos.IdPermiso = RolesPermisos.IdPermiso;
GO

-- contratos con el nombre del cliente y cuántos equipos tienen
CREATE VIEW VistaContratos AS
SELECT  Contratos.IdContrato, Contratos.IdCliente, Clientes.Nombre AS Cliente,
        Contratos.FechaInicio, Contratos.FechaFin, Contratos.Frecuencia,
        Contratos.MontoMensual, Contratos.Estado, Contratos.Descripcion,
        (SELECT COUNT(*) FROM Equipos WHERE Equipos.IdContrato = Contratos.IdContrato) AS Equipos
FROM        Contratos
INNER JOIN  Clientes ON Clientes.IdCliente = Contratos.IdCliente;
GO

-- equipos con su cliente
CREATE VIEW VistaEquipos AS
SELECT  Equipos.IdEquipo, Equipos.IdContrato, Contratos.IdCliente, Clientes.Nombre AS Cliente,
        Equipos.NumeroSerie, Equipos.Marca, Equipos.Modelo, Equipos.Tipo,
        Equipos.CapacidadBTU, Equipos.Ubicacion, Equipos.FechaInstalacion, Equipos.Estado
FROM        Equipos
INNER JOIN  Contratos ON Contratos.IdContrato = Equipos.IdContrato
INNER JOIN  Clientes  ON Clientes.IdCliente   = Contratos.IdCliente;
GO

-- mantenimientos con los datos del equipo, cliente, ingeniero y lo gastado en repuestos
CREATE VIEW VistaMantenimientos AS
SELECT  Mantenimientos.IdMantenimiento, Mantenimientos.IdEquipo,
        Equipos.NumeroSerie, Equipos.Marca, Equipos.Modelo, Equipos.Ubicacion,
        Contratos.IdContrato, Contratos.IdCliente, Clientes.Nombre AS Cliente,
        Mantenimientos.IdIngeniero, Usuarios.Nombre AS Ingeniero,
        Mantenimientos.Tipo, Mantenimientos.FechaProgramada, Mantenimientos.FechaRealizada,
        Mantenimientos.Estado, Mantenimientos.Diagnostico, Mantenimientos.TrabajoRealizado,
        Mantenimientos.Observaciones,
        ISNULL((SELECT SUM(MantenimientoRepuestos.Cantidad * MantenimientoRepuestos.PrecioUnitario)
                FROM MantenimientoRepuestos
                WHERE MantenimientoRepuestos.IdMantenimiento = Mantenimientos.IdMantenimiento), 0)
            AS CostoRepuestos
FROM        Mantenimientos
INNER JOIN  Equipos   ON Equipos.IdEquipo     = Mantenimientos.IdEquipo
INNER JOIN  Contratos ON Contratos.IdContrato = Equipos.IdContrato
INNER JOIN  Clientes  ON Clientes.IdCliente   = Contratos.IdCliente
INNER JOIN  Usuarios  ON Usuarios.IdUsuario   = Mantenimientos.IdIngeniero;
GO

-- repuestos usados en cada mantenimiento
CREATE VIEW VistaRepuestosUsados AS
SELECT  MantenimientoRepuestos.IdDetalle, MantenimientoRepuestos.IdMantenimiento,
        MantenimientoRepuestos.IdRepuesto, Repuestos.Nombre AS Repuesto,
        MantenimientoRepuestos.Cantidad, MantenimientoRepuestos.PrecioUnitario,
        MantenimientoRepuestos.Cantidad * MantenimientoRepuestos.PrecioUnitario AS Subtotal
FROM        MantenimientoRepuestos
INNER JOIN  Repuestos ON Repuestos.IdRepuesto = MantenimientoRepuestos.IdRepuesto;
GO

-- bitácora con el nombre del usuario
CREATE VIEW VistaActividad AS
SELECT  RegistroActividad.IdRegistro, RegistroActividad.IdUsuario,
        Usuarios.NombreUsuario AS Usuario, Usuarios.Nombre,
        RegistroActividad.Accion, RegistroActividad.Fecha
FROM        RegistroActividad
INNER JOIN  Usuarios ON Usuarios.IdUsuario = RegistroActividad.IdUsuario;
GO

-- =============================================
-- DATOS INICIALES
-- =============================================

-- Roles (el Administrador tiene que quedar con IdRol = 1)
INSERT INTO Roles (Nombre, Descripcion) VALUES
    ('Administrador', N'Gestión de contratos, repuestos, usuarios y asignación de personal'),
    ('Ingeniero',     N'Registra las hojas de servicio y los repuestos consumidos en sus visitas');
GO

-- Permisos
INSERT INTO Permisos (Clave, Nombre, Modulo) VALUES
    ('CONTRATOS_VER',            N'Consultar contratos',                               N'Contratos'),
    ('CONTRATOS_GESTIONAR',      N'Crear, editar y eliminar contratos',                N'Contratos'),
    ('EQUIPOS_VER',              N'Consultar equipos',                                 N'Equipos'),
    ('EQUIPOS_GESTIONAR',        N'Crear, editar y eliminar equipos',                  N'Equipos'),
    ('REPUESTOS_VER',            N'Consultar repuestos',                               N'Repuestos'),
    ('REPUESTOS_GESTIONAR',      N'Crear, editar y eliminar repuestos',                N'Repuestos'),
    ('MANTENIMIENTOS_VER',       N'Consultar el historial de mantenimientos',          N'Mantenimientos'),
    ('MANTENIMIENTOS_GESTIONAR', N'Programar visitas y asignar ingenieros',            N'Mantenimientos'),
    ('HOJAS_REGISTRAR',          N'Registrar hojas de servicio y repuestos consumidos', N'Mantenimientos'),
    ('CLIENTES_GESTIONAR',       N'Crear, editar y eliminar clientes corporativos',    N'Clientes'),
    ('USUARIOS_GESTIONAR',       N'Gestionar usuarios, roles y permisos',              N'Administración'),
    ('BITACORA_VER',             N'Consultar la bitácora de actividad',                N'Administración');
GO

-- el Administrador tiene todos los permisos
INSERT INTO RolesPermisos (IdRol, IdPermiso)
SELECT Roles.IdRol, Permisos.IdPermiso
FROM   Roles, Permisos
WHERE  Roles.Nombre = 'Administrador';

-- permisos del Ingeniero
INSERT INTO RolesPermisos (IdRol, IdPermiso)
SELECT Roles.IdRol, Permisos.IdPermiso
FROM   Roles, Permisos
WHERE  Roles.Nombre = 'Ingeniero'
  AND  Permisos.Clave IN ('EQUIPOS_VER', 'REPUESTOS_VER', 'MANTENIMIENTOS_VER', 'HOJAS_REGISTRAR');
GO

-- =============================================
-- DATOS DE PRUEBA
-- =============================================

-- Clientes
INSERT INTO Clientes (Nombre, Nit, Contacto, Telefono, Correo, Direccion) VALUES
    (N'Corporación Los Próceres', '0614-150395-102-4', N'Andrea Menjívar',  '2245-8800',
     'mantenimiento@losproceres.com.sv', N'Bulevar Los Próceres #1200, San Salvador'),
    (N'Hotel Vista Real',         '0614-220708-103-1', N'Mauricio Escobar', '2260-4411',
     'operaciones@vistareal.com.sv',     N'Colonia Escalón, 79 Avenida Norte #415, San Salvador'),
    (N'Clínica Santa Elena',      '0511-031112-101-7', N'Patricia Alfaro',  '2278-9034',
     'administracion@santaelena.com.sv', N'Calle El Pedregal #18, Antiguo Cuscatlán');
GO

-- Usuarios de prueba (las contraseñas ya van encriptadas con BCrypt)
--     admin       ->  Admin123        (Administrador)
--     ingeniero   ->  Ingeniero123    (Ingeniero)
--     shernandez  ->  Ingeniero123    (Ingeniero)
INSERT INTO Usuarios (Nombre, NombreUsuario, Contrasena, IdRol, Correo, Activo) VALUES
    (N'Administrador General', 'admin',
     '$2a$11$.3VvSF3qdTbsFuVMygkWAu0LX2PL//hHSdb5me603F7.P8.y2TNG6', 1, 'admin@sigma.com.sv', 1),
    (N'Roberto Martínez',      'ingeniero',
     '$2a$11$48KVZ2tULiNccTllyzEgR.i/m.VFqCj3DPRr5mwG.tr/7gNuEmhKS', 2, 'rmartinez@sigma.com.sv', 1),
    (N'Sofía Hernández',       'shernandez',
     '$2a$11$48KVZ2tULiNccTllyzEgR.i/m.VFqCj3DPRr5mwG.tr/7gNuEmhKS', 2, 'shernandez@sigma.com.sv', 1);
GO

-- Contratos
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

INSERT INTO Contratos (IdCliente, FechaInicio, FechaFin, Frecuencia, MontoMensual, Estado, Descripcion) VALUES
    (1, DATEADD(MONTH, -9, @Hoy),  DATEADD(MONTH, 15, @Hoy), 'Trimestral', 450.00, 'Vigente',
     N'Mantenimiento preventivo de oficinas administrativas y sala de servidores'),
    (2, DATEADD(MONTH, -8, @Hoy),  DATEADD(MONTH, 16, @Hoy), 'Mensual',    780.00, 'Vigente',
     N'Mantenimiento preventivo de habitaciones, lobby y sistema central'),
    (3, DATEADD(MONTH, -3, @Hoy),  DATEADD(MONTH, 9, @Hoy),  'Bimestral',  320.00, 'Vigente',
     N'Mantenimiento preventivo de consultorios y quirófano'),
    (1, DATEADD(MONTH, -30, @Hoy), DATEADD(MONTH, -18, @Hoy), 'Semestral', 300.00, 'Finalizado',
     N'Contrato anterior de las oficinas administrativas');
GO

-- Equipos
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

INSERT INTO Equipos (IdContrato, NumeroSerie, Marca, Modelo, Tipo, CapacidadBTU, Ubicacion, FechaInstalacion, Estado) VALUES
    (1, 'LG-MS-240118',  N'LG',      N'DualCool S4-W24', 'Mini Split', 24000,
     N'Oficina de gerencia, nivel 2',  DATEADD(MONTH, -30, @Hoy), 'Operativo'),
    (1, 'CAR-CS-360221', N'Carrier', N'40KMC036',        'Cassette',   36000,
     N'Sala de juntas, nivel 2',       DATEADD(MONTH, -28, @Hoy), 'Operativo'),
    (1, 'DAI-PT-600320', N'Daikin',  N'FHQ60',           'Piso-Techo', 60000,
     N'Sala de servidores, nivel 1',   DATEADD(MONTH, -24, @Hoy), 'Operativo'),
    (2, 'YRK-CH-120419', N'York',    N'YCAL0120',        'Chiller',    120000,
     N'Azotea de la torre principal',  DATEADD(MONTH, -40, @Hoy), 'Operativo'),
    (2, 'SAM-MS-180522', N'Samsung', N'AR18TV',          'Mini Split', 18000,
     N'Habitación 204',                DATEADD(MONTH, -20, @Hoy), 'Operativo'),
    (2, 'SAM-MS-180523', N'Samsung', N'AR18TV',          'Mini Split', 18000,
     N'Habitación 205',                DATEADD(MONTH, -20, @Hoy), 'Fuera de servicio'),
    (3, 'TRN-CN-480121', N'Trane',   N'4TTR4048',        'Central',    48000,
     N'Quirófano 1',                   DATEADD(MONTH, -36, @Hoy), 'Operativo'),
    (3, 'MID-MS-120623', N'Midea',   N'Xtreme Save 12',  'Mini Split', 12000,
     N'Consultorio 3',                 DATEADD(MONTH, -10, @Hoy), 'Operativo');
GO

-- Repuestos
INSERT INTO Repuestos (Nombre, Categoria, Existencia, StockMinimo, PrecioUnitario) VALUES
    (N'Capacitor de marcha 35 uF',            N'Eléctrico',     18,  5,  8.50),
    (N'Capacitor de arranque 45 uF',          N'Eléctrico',     12,  5,  9.75),
    (N'Contactor 30 A con bobina de 24 V',    N'Eléctrico',      9,  4, 14.90),
    (N'Filtro de aire lavable',               N'Filtración',    25, 10,  6.25),
    (N'Filtro secador de 3/8',                N'Refrigeración',  7,  4, 11.40),
    (N'Gas refrigerante R-410A (libra)',      N'Refrigeración', 60, 20,  7.80),
    (N'Motor de ventilador 1/4 HP',           N'Mecánico',       4,  2, 68.00),
    (N'Tarjeta electrónica universal',        N'Eléctrico',      3,  2, 54.50),
    (N'Termostato digital programable',       N'Eléctrico',      6,  3, 32.00),
    (N'Bomba de condensado',                  N'Mecánico',       2,  3, 45.00),
    (N'Correa de transmisión A-42',           N'Mecánico',      10,  4,  5.60),
    (N'Sensor de temperatura 10K',            N'Eléctrico',      3,  5,  4.20);
GO

-- Mantenimientos (el ingeniero 2 es Roberto y el 3 es Sofía)
DECLARE @Hoy DATE = CAST(GETDATE() AS DATE);

INSERT INTO Mantenimientos
    (IdEquipo, IdIngeniero, Tipo, FechaProgramada, FechaRealizada, Estado, Diagnostico, TrabajoRealizado, Observaciones)
VALUES
    (1, 2, 'Preventivo', DATEADD(DAY, -75, @Hoy), DATEADD(DAY, -75, @Hoy), 'Completado',
     N'Filtros con acumulación de polvo. Presiones y amperaje dentro del rango.',
     N'Limpieza de filtros y serpentines, revisión del drenaje y medición de amperaje.',
     NULL),
    (3, 2, 'Correctivo', DATEADD(DAY, -40, @Hoy), DATEADD(DAY, -39, @Hoy), 'Completado',
     N'Capacitor de marcha dañado: el compresor no arrancaba.',
     N'Sustitución del capacitor de marcha y recarga de 2 libras de refrigerante.',
     N'Se recomienda instalar un protector de voltaje.'),
    (4, 3, 'Preventivo', DATEADD(DAY, -30, @Hoy), DATEADD(DAY, -30, @Hoy), 'Completado',
     N'Operación normal. Correa de transmisión con desgaste leve.',
     N'Cambio de correa, lubricación de rodamientos y limpieza del condensador.',
     NULL),
    (7, 3, 'Preventivo', DATEADD(DAY, -20, @Hoy), DATEADD(DAY, -20, @Hoy), 'Completado',
     N'Sin novedades. Temperatura de suministro correcta.',
     N'Cambio de filtros y desinfección de ductos.',
     NULL),
    (6, 2, 'Correctivo', DATEADD(DAY, -3, @Hoy),  NULL, 'En proceso',
     N'La tarjeta electrónica no responde al control remoto.',
     NULL,
     N'En espera de autorización del cliente para cambiar la tarjeta.'),
    (3, 3, 'Preventivo', DATEADD(DAY, -10, @Hoy), NULL, 'Cancelado',
     NULL, NULL,
     N'Cancelada a solicitud del cliente por mantenimiento eléctrico del edificio.'),
    (2, 2, 'Preventivo', DATEADD(DAY, 5, @Hoy),   NULL, 'Programado', NULL, NULL, NULL),
    (5, 3, 'Preventivo', DATEADD(DAY, 9, @Hoy),   NULL, 'Programado', NULL, NULL, NULL),
    (8, 3, 'Preventivo', DATEADD(DAY, 14, @Hoy),  NULL, 'Programado', NULL, NULL, NULL),
    (1, 2, 'Preventivo', DATEADD(DAY, 16, @Hoy),  NULL, 'Programado', NULL, NULL, NULL);
GO

-- Repuestos usados en las visitas completadas
INSERT INTO MantenimientoRepuestos (IdMantenimiento, IdRepuesto, Cantidad, PrecioUnitario) VALUES
    (1,  4, 1, 6.25),
    (2,  1, 1, 8.50),
    (2,  6, 2, 7.80),
    (3, 11, 1, 5.60),
    (4,  4, 2, 6.25);
GO

-- para revisar cuántos registros quedaron en cada tabla
SELECT 'Roles' AS Tabla, COUNT(*) AS Filas FROM Roles
UNION ALL SELECT 'Permisos',               COUNT(*) FROM Permisos
UNION ALL SELECT 'RolesPermisos',          COUNT(*) FROM RolesPermisos
UNION ALL SELECT 'Usuarios',               COUNT(*) FROM Usuarios
UNION ALL SELECT 'Clientes',               COUNT(*) FROM Clientes
UNION ALL SELECT 'Contratos',              COUNT(*) FROM Contratos
UNION ALL SELECT 'Equipos',                COUNT(*) FROM Equipos
UNION ALL SELECT 'Repuestos',              COUNT(*) FROM Repuestos
UNION ALL SELECT 'Mantenimientos',         COUNT(*) FROM Mantenimientos
UNION ALL SELECT 'MantenimientoRepuestos', COUNT(*) FROM MantenimientoRepuestos;
GO
