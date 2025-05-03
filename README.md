# 📱 PersonAPI-DotNet

Sistema web desarrollado en **ASP.NET Core MVC** que gestiona personas, teléfonos, profesiones y estudios. Utiliza **Entity Framework Core** para interactuar con **SQL Server**.

---

## ✨ Características

- CRUD completo de:
  - 👤 Personas
  - 📱 Teléfonos
  - 🎓 Profesiones
  - 📘 Estudios (relación Persona ↔ Profesión)
- Interfaz visual con Razor Pages + Bootstrap
- API RESTful para consumo externo
- Arquitectura MVC monolítica
- Soporte para SQL Server
- Compatible con Visual Studio o Visual Studio Code

---

## 🔧 Requisitos previos

- [.NET SDK 7.0 o 8.0](https://dotnet.microsoft.com/en-us/download)
- SQL Server 2019 o superior (local o en Docker)
- [Docker Desktop](https://www.docker.com/products/docker-desktop)
- Visual Studio o Visual Studio Code con la extensión C#

---

## 🛠️ Tecnologías

- .NET 7 / .NET 8  
- ASP.NET Core MVC  
- Entity Framework Core  
- SQL Server 2019  
- Razor Views (CSHTML)  
- Bootstrap 5  
- Docker (opcional)  

---

## 📦 Paquetes NuGet necesarios

Ejecuta los siguientes comandos para instalar los paquetes requeridos:

```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
dotnet add package Microsoft.EntityFrameworkCore.Proxies
```

## 🐳 Base de datos con Docker

Levantar el docker-compose.yml para acceder a la base de datos:
docker-compose up --build

acceder al contenedor de la base de datos desde SSMS:
Servidor (Server name): localhost,1433
Tipo de autenticación: SQL Server Authentication
Login (User name): sa
Password: La que esta definida en el docker-compose

dotnet ef migrations add InitialCreate
dotnet ef database update

## 🗂️ Estructura del proyecto

- `Controllers/` - Controladores MVC y API
- `Models/Entities/` - Entidades de la base de datos
- `Models/Repositories/` - Interfaces y repositorios
- `Views/` - Razor Views para cada entidad
- `appsettings.json` - Configuración de la base de datos

