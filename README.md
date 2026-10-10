# SIGMA

**Sistema Integral de Gestión de Mantenimiento de Aire acondicionado**

Proyecto de módulo · Problema 4 · Instituto Técnico Ricaldone · Desarrollo de Software

Aplicación de escritorio (C#, Windows Forms, SQL Server) para una empresa de mantenimiento de
aire acondicionado. Gestiona los contratos de mantenimiento preventivo, las visitas de revisión,
los repuestos y los ingenieros asignados, reemplazando las bitácoras físicas.

## Qué incluye

| Requisito | Dónde está |
|---|---|
| Arquitectura Modelo-Vista | Proyecto `Modelo` (datos) y proyecto `Vista` (formularios) |
| Login con BCrypt.Net | `Vista/Formularios/FrmLogin.cs` y `Modelo/Modelo/Clave.cs` |
| Roles: Administrador e Ingeniero | Tablas `Roles`, `Permisos`, `RolesPermisos` |
| Gestión de usuarios, roles y permisos | `FrmUsuarios` y `FrmRoles` |
| CRUD de Equipos, Mantenimientos, Repuestos y Contratos | `FrmEquipos`, `FrmMantenimientos`, `FrmRepuestos`, `FrmContratos` (además `FrmClientes`) |
| Hoja de servicio y repuestos consumidos | `FrmHojaServicio` |
| Try-Catch y MessageBox | Clases `*Datos` del Modelo, `Errores.cs` y `Vista/Utilidades/Mensajes.cs` |
| Script de base de datos comentado | `Modelo/Database/SIGMA_Script.sql` |
| Documentación | `Documentacion/Documentacion_SIGMA.docx` (y `.pdf`) |

## Permisos por rol

- **Administrador:** gestión de contratos, equipos, repuestos, clientes, usuarios, roles y
  permisos; programa las visitas y asigna al ingeniero; consulta el historial de mantenimiento
  y la bitácora.
- **Ingeniero:** ve sus visitas asignadas y registra la hoja de servicio con los repuestos
  consumidos (se descuentan del inventario). Consulta equipos y repuestos.

Los clientes no tienen usuario: son las empresas dueñas de los contratos y los equipos, y nunca
interactúan directamente con el sistema. El administrador registra sus datos y consulta su
historial de mantenimiento.

## Cómo ejecutarlo

Requisitos: Windows 10/11, Visual Studio 2022 (.NET Framework 4.8) y SQL Server Express.

1. **Crear la base de datos.** Abrir `Modelo/Database/SIGMA_Script.sql` en SQL Server Management
   Studio y presionar *Execute* (F5), o hacer doble clic en `Modelo/Database/CrearBaseDeDatos.cmd`.
2. **Abrir** `SIGMA.sln` en Visual Studio. Los paquetes NuGet (`BCrypt.Net-Next` y
   `Guna.UI2.WinForms`) se restauran al compilar.
3. Si el servidor no es `localhost\SQLEXPRESS`, cambiar el `Data Source` en `Vista/App.config`.
4. Dejar **Vista** como proyecto de inicio y presionar **F5**.

## Usuarios de prueba

| Usuario | Contraseña | Rol |
|---|---|---|
| `admin` | `Admin123` | Administrador |
| `ingeniero` | `Ingeniero123` | Ingeniero |
| `shernandez` | `Ingeniero123` | Ingeniero |

Las contraseñas están guardadas como hash de BCrypt; el script nunca las guarda en texto plano.

## Estructura del proyecto

```
SIGMA/
├── SIGMA.sln
├── README.md
├── Documentacion/              Documento técnico, diagramas y capturas
├── Modelo/                     PROYECTO MODELO (biblioteca de clases)
│   ├── ConexionDB/             Conexion.cs
│   ├── Database/               SIGMA_Script.sql, CrearBaseDeDatos.cmd
│   └── Modelo/                 Entidades (Usuario, Contrato, Equipo...) y
│                               clases de datos (UsuarioDatos, ContratoDatos...)
└── Vista/                      PROYECTO VISTA (Windows Forms)
    ├── Program.cs, App.config
    ├── Formularios/            FrmLogin, FrmMain, FrmInicio, FrmContratos, FrmEquipos,
    │                           FrmMantenimientos, FrmHojaServicio, FrmRepuestos,
    │                           FrmClientes, FrmUsuarios, FrmRoles, FrmBitacora
    ├── Estilos/                Tema, EstiloGrid, EstiloBotones, Combos
    ├── Utilidades/             Mensajes, Validaciones, Filtro, Ventanas
    └── Resources/              sigma.ico
```

## Tecnologías

C# · .NET Framework 4.8 · Windows Forms · SQL Server Express · ADO.NET ·
BCrypt.Net-Next 4.0.3 · Guna.UI2.WinForms 2.0.4.8
