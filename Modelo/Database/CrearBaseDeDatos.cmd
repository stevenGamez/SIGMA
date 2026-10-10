@echo off
setlocal enabledelayedexpansion
title SIGMA - Crear la base de datos
color 0F

rem ------------------------------------------------------------------
rem  Crea la base de datos SIGMA ejecutando SIGMA_Script.sql con sqlcmd.
rem  Si tu servidor tiene otro nombre, cambia la linea SERVIDOR.
rem ------------------------------------------------------------------
set SERVIDOR=localhost\SQLEXPRESS
set SCRIPT=%~dp0SIGMA_Script.sql
set REGISTRO=%TEMP%\SIGMA-base-de-datos.log

echo.
echo   ============================================
echo     SIGMA - Crear la base de datos
echo   ============================================
echo.
echo     Servidor:  %SERVIDOR%
echo     Base:      SIGMA
echo.

if not exist "%SCRIPT%" (
    echo     No encontre el archivo SIGMA_Script.sql.
    echo     Tiene que estar en esta misma carpeta:
    echo     %~dp0
    goto final
)

set SQLCMD=
for /f "delims=" %%A in ('where sqlcmd 2^>nul') do if not defined SQLCMD set "SQLCMD=%%A"
if not defined SQLCMD call :buscar "%ProgramFiles%\Microsoft SQL Server"
if not defined SQLCMD call :buscar "%ProgramFiles(x86)%\Microsoft SQL Server"

if not defined SQLCMD (
    echo     No encontre la herramienta sqlcmd en esta computadora.
    echo.
    echo     Abre SIGMA_Script.sql con SQL Server Management Studio
    echo     y ejecutalo con el boton Execute ^(F5^).
    goto final
)

echo     Probando la conexion...
"%SQLCMD%" -S %SERVIDOR% -E -b -l 15 -Q "SELECT 1;" >nul 2>&1
if errorlevel 1 (
    echo.
    echo     No pude conectarme a %SERVIDOR%.
    echo.
    echo     Revisa que SQL Server este instalado y encendido, y que
    echo     el nombre del servidor sea el correcto.
    echo.
    echo     El servicio SQL Server ^(SQLEXPRESS^) se enciende desde
    echo     Servicios de Windows o con este comando, como administrador:
    echo.
    echo         net start MSSQL$SQLEXPRESS
    goto final
)

"%SQLCMD%" -S %SERVIDOR% -E -h -1 -W -Q "SET NOCOUNT ON; SELECT CASE WHEN DB_ID('SIGMA') IS NULL THEN 'NO' ELSE 'SI' END;" > "%TEMP%\sigma-existe.txt" 2>nul
set EXISTE=NO
for /f "usebackq delims=" %%A in ("%TEMP%\sigma-existe.txt") do set EXISTE=%%A
del "%TEMP%\sigma-existe.txt" >nul 2>&1

if /I "%EXISTE%"=="SI" (
    echo.
    echo     ATENCION: la base de datos SIGMA ya existe aqui.
    echo     Si continuas se borra y se vuelve a crear desde cero,
    echo     con los datos de ejemplo. Lo que tengas guardado se pierde.
    echo.
    set RESPUESTA=N
    echo     Escribe S y presiona ENTER para continuar, o N para salir.
    echo.
    set /p RESPUESTA=Respuesta:
    if /I not "!RESPUESTA!"=="S" (
        echo.
        echo     No se cambio nada. La base de datos quedo como estaba.
        goto final
    )
)

echo.
echo     Creando la base de datos. Esto tarda unos segundos...
"%SQLCMD%" -S %SERVIDOR% -E -b -f 65001 -i "%SCRIPT%" > "%REGISTRO%" 2>&1
if errorlevel 1 (
    echo.
    echo     No se pudo crear la base de datos. Esto fue lo que paso:
    echo.
    type "%REGISTRO%"
    echo.
    echo     El detalle completo quedo en:
    echo     %REGISTRO%
    goto final
)

echo.
echo     Listo. La base de datos SIGMA quedo creada.
echo     Ya puedes abrir SIGMA.
echo.
echo     Usuarios de prueba:
echo         admin      /  Admin123
echo         ingeniero  /  Ingeniero123

:final
echo.
echo   ============================================
echo.
pause
exit /b

:buscar
if not exist "%~1" goto :eof
for /f "delims=" %%A in ('dir /b /s "%~1\sqlcmd.exe" 2^>nul') do if not defined SQLCMD set "SQLCMD=%%A"
goto :eof
