# 🏨 Sistema de Gestión Hotelera

Sistema completo de gestión hotelera desarrollado en **ASP.NET** que permite administrar habitaciones y reservas de manera eficiente, con interfaz intuitiva y funcionalidades avanzadas de calendario.

## 📋 Características Principales

### 🛏️ Gestión de Habitaciones
- **CRUD completo** de habitaciones (Crear, Leer, Actualizar, Eliminar)
- Administración de tipos de habitación y características
- Control de disponibilidad en tiempo real

### 📅 Sistema de Reservas
- **CRUD completo** de reservas
- **Calendar interactivo** con datos precargados desde la base de datos
- **Indicadores visuales por colores**:
  - 🟢 Habitaciones disponibles
  - 🔴 Habitaciones ocupadas
- **Bloqueo automático** de fechas no disponibles
- Sincronización en tiempo real con la base de datos

### 🔍 Sistema de Filtros Avanzados
- Búsqueda por **cliente**
- Búsqueda por **habitación**
- Búsqueda por **rango de fechas**
- Filtros combinables para búsquedas precisas

### 🔐 Sistema de Autenticación
- Login seguro con validación en base de datos
- Control de acceso a las funcionalidades del sistema

## 🛠️ Tecnologías Utilizadas

- **Frontend**: HTML, CSS, JavaScript
- **Backend**: C#, ASP.NET Framework
- **Base de Datos**: SQL Server (Azure SQL Database / SQL Server Management Studio)
- **Acceso a Datos**: ADO.NET con consultas SQL directas

## 📁 Estructura del Proyecto

```
Solución ProyectoHoteleria/
├── Dominio/             # Clases y objetos del sistema
├── Negocio/             # Lógica de negocio y conexión a BD
└── ProyectoHoteleria/   # Interfaz web (pantallas y vistas)
```
