# 🎮 Esports Arena Management System

<p align="center">
  <img src="https://img.shields.io/badge/Architecture-4--Layer-00f2fe?style=for-the-badge" />
  &nbsp;&nbsp;
  <img src="https://img.shields.io/badge/.NET%208.0-512BD4?style=for-the-badge&logo=.net&logoColor=white" />
  &nbsp;&nbsp;
  <img src="https://img.shields.io/badge/MySQL-4479A1?style=for-the-badge&logo=mysql&logoColor=white" />
  &nbsp;&nbsp;
  <img src="https://img.shields.io/badge/UI-Gamer--Neumorphism-f25c54?style=for-the-badge" />
</p>

## 📝 Descripción del Proyecto
**Esports Arena** es una solución de vanguardia para la gestión de ligas de deportes electrónicos. Diseñada con una estética **Gamer Neumorphism**, la plataforma permite administrar encuentros, equipos, usuarios y patrocinios bajo una arquitectura sólida y escalable.

---

## 🏗️ Arquitectura de Software
El proyecto implementa una **Arquitectura de N-Capas**, garantizando el desacoplamiento entre la lógica de negocio y el acceso a datos:
* **Capa de Entidades:** Modelos de datos compartidos.
* **Capa de Datos (DAO):** Repositorios genéricos para persistencia en MySQL.
* **Capa de Lógica (Services):** Reglas de negocio y motor de simulación.
* **Capa de Presentación:** Controladores MVC y Endpoints de API REST.

---

## 🚀 Módulos Destacados
* **Arena de Torneos:** Simulación de encuentros con temporizadores dinámicos.
* **API REST Patrocinadores:** Módulo independiente con CRUD completo (GET, POST, PUT, DELETE).
* **Centro de Reportes:** Exportación masiva de datos a **Excel (ClosedXML)** y **PDF (iText7)**.

---

## 🔧 Instalación y Setup
Para poner en marcha la Arena de Esports en tu entorno local, sigue estos pasos:

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/EsportsArena.git](https://github.com/tu-usuario/EsportsArena.git)
    ```
2.  **Configurar la Base de Datos:**
    * Abrir **XAMPP** e iniciar los módulos Apache y MySQL.
    * Importar el archivo `Script_DB_Esports.sql` (incluido en la carpeta raíz) mediante **phpMyAdmin**.
3.  **Configurar el Proyecto:**
    * Abrir la solución en **Visual Studio 2022**.
    * Ajustar el archivo `appsettings.json` con tu `ConnectionString` local de MySQL.
4.  **Ejecución:**
    * Compilar la solución (`Ctrl + Shift + B`).
    * Presionar `F5` para iniciar el servidor local.

---

## 📋 Documentación de la API (Sponsors)
| Verbo | Endpoint | Función |
| :--- | :--- | :--- |
| `GET` | `/api/PatrocinadoresApi` | Lista todos los patrocinadores activos. |
| `POST` | `/api/PatrocinadoresApi` | Crea un nuevo registro vía JSON. |
| `PUT` | `/api/PatrocinadoresApi` | Actualiza datos de un sponsor existente. |
| `DELETE` | `/api/PatrocinadoresApi/{id}` | Elimina un registro por ID. |

---

## 👤 Autor
* **Desarrollador:** Estudiante de Ingeniería de Software (7mo Semestre) Samuel Junieles.
* **Proyecto:** Desarrollo de Aplicaciones Web.
* **Institución:** Facultad de Ingeniería.
  
---

## ⚖️ Licencia
Este proyecto está bajo la **Licencia MIT**. Para más detalles, consulta el archivo [LICENSE](LICENSE) incluido en este repositorio.
---
<p align="center">Sistema desarrollado para la excelencia en la gestión de eSports ⚡</p>
