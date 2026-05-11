# LogiSync - Sistema de Normalización de Estados Logísticos

## Descripción del Proyecto

LogiSync es un sistema desarrollado como proyecto de título de la carrera Analista Programador en IPLACEX. Su objetivo es normalizar los distintos estados logísticos entregados por operadores como Chilexpress, Bluexpress y Starken, permitiendo traducir automáticamente descripciones heterogéneas a estados estandarizados.

Por ejemplo:

- "Sin moradores"
- "Cliente ausente"
- "No se pudo entregar"

pueden ser traducidos al estado normalizado:

- "El cliente no se encontraba disponible para recibir el envío"

---

## Objetivo General

Desarrollar un sistema web que permita centralizar y normalizar estados logísticos provenientes de distintos operadores, reduciendo el tiempo de clasificación manual y mejorando la calidad de la información utilizada para análisis y reportes.

---

## Tecnologías Utilizadas

- C#
- ASP.NET Core 8 Web API
- Entity Framework Core 8
- SQL Server
- Swagger / OpenAPI
- Visual Studio 2022
- GitHub

---

## Estructura del Proyecto

```text
LogiSync/
├── .gitignore
├── README.md
├── LogiSync.sln
└── LogiSyncAPI/
    ├── Controllers/
    ├── Data/
    ├── Migrations/
    ├── Models/
    ├── Program.cs
    ├── appsettings.json
    └── LogiSyncAPI.csproj