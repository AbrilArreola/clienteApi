# ClienteApi (.NET Core Web API)

API REST en .NET Core para la gestión de clientes, utilizando Entity Framework Core y validación mediante API KEY.

## tecnologias

- ASP.NET Core 7.0
- Entity Framework Core
- MySQL (XAMPP)
- Thunder Client para pruebas manuales
- Swagger para documentación interactiva

## endpoints

| Metodo | Ruta                  | Descripcion                    |
|--------|-----------------------|--------------------------------|
| GET    | `/api/clientes`       | Listar todos los clientes      |
| GET    | `/api/clientes/{id}`  | Obtener cliente por ID         |
| POST   | `/api/clientes`       | Crear un nuevo cliente         |
| PUT    | `/api/clientes/{id}`  | Actualizar un cliente existente|
| DELETE | `/api/clientes/{id}`  | Eliminar cliente por ID        |

Se espera que en POST y PUT incluyan header:
Content-Type: application/json

y los datos esten el body como JSON

## API KEY

Todas las peticiones deben incluir el header:
X-API-KEY: S3cr3T4 
 o apikey configurable en appsettings.json

Si no se envía o es incorrecta, se responde con `401 Unauthorized`.


## validaciones

- Nombre: obligatorio
- Correo electrónico: obligatorio y válido
- Teléfono: obligatorio y con formato válido


## correr el proyecto

1. Clonar repositorio
2. Verificar la configuracion de conexión a MySQL en `Program.cs`
3. Crear base de datos `clientesdb`
4. Ejecutar migraciones:
```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
```
5.Correr el proyecto
```bash
   dotnet run
