# TDDTestingMVC

Un proyecto de desarrollo dirigido por pruebas (TDD) que implementa una aplicación web ASP.NET Core MVC con un completo conjunto de pruebas unitarias, de integración y automatizadas usando Reqnroll (SpecFlow).

## 📋 Descripción del Proyecto

Este proyecto demuestra las mejores prácticas de desarrollo dirigido por pruebas (TDD) implementando:
- Una aplicación web MVC con gestión de clientes y pedidos
- Pruebas unitarias con xUnit
- Pruebas de comportamiento (BDD) con Reqnroll
- Automatización de pruebas web con Selenium WebDriver
- Modelos de cálculo matemático (calculadora, área de círculo)

## 🏗️ Arquitectura del Proyecto

La solución está organizada en tres proyectos principales:

### 📁 TDDTestingMVC (Aplicación Principal)
Aplicación web ASP.NET Core MVC con las siguientes características:
- **Framework**: .NET 8.0
- **Patrón**: Model-View-Controller (MVC)
- **Base de datos**: SQL Server con Entity Framework Core

#### Estructura:
```
TDDTestingMVC/
├── Controllers/          # Controladores MVC
│   ├── ClienteController.cs    # CRUD de clientes
│   ├── HomeController.cs       # Controlador principal
│   └── PedidoController.cs     # Gestión de pedidos
├── data/                 # Capa de acceso a datos
│   ├── Cliente.cs             # Modelo de entidad Cliente
│   ├── ClienteDataAccessLayer.cs # DAL para clientes
│   ├── Pedidos.cs             # Modelo de entidad Pedidos
│   └── PedidosDataAccessLayer.cs # DAL para pedidos
├── Models/               # Modelos de dominio
│   ├── AreaCirculo.cs         # Cálculo de área de círculo
│   ├── Calculadora.cs         # Operaciones matemáticas
│   └── ErrorViewModel.cs      # Modelo para manejo de errores
├── Views/                # Vistas Razor
│   ├── Cliente/              # Vistas CRUD de clientes
│   ├── Home/                 # Vistas principales
│   ├── Pedido/               # Vistas de pedidos
│   └── Shared/               # Vistas compartidas
└── wwwroot/              # Archivos estáticos (CSS, JS, imágenes)
```

### 🧪 TestClientes (Pruebas Unitarias)
Proyecto de pruebas unitarias usando xUnit:
- **Framework de pruebas**: xUnit
- **Assertions**: FluentAssertions
- **Cobertura**: Pruebas para modelos y lógica de negocio

### 🎭 ReqnrollTesting (Pruebas BDD/E2E)
Proyecto de pruebas de comportamiento y end-to-end:
- **Framework BDD**: Reqnroll (sucesor de SpecFlow)
- **Automatización web**: Selenium WebDriver
- **Navegadores soportados**: Chrome, Edge, Firefox
- **Reportes**: ExtentReports

#### Features disponibles:
```
Features/
├── AreaCirculo.feature      # Pruebas de cálculo de área
├── Calculator.feature       # Pruebas de calculadora
├── CRUDSTestCliente.feature # Pruebas CRUD de clientes
├── InsertarPedido.feature   # Pruebas de inserción de pedidos
├── InsertCRUD.feature       # Pruebas generales de CRUD
├── Login.feature            # Pruebas de autenticación
└── Registro.feature         # Pruebas de registro
```

## 🚀 Tecnologías Utilizadas

### Backend
- **.NET 8.0** - Framework principal
- **ASP.NET Core MVC** - Framework web
- **Entity Framework Core** - ORM para base de datos
- **SQL Server** - Base de datos

### Testing
- **xUnit** - Framework de pruebas unitarias
- **Reqnroll** - Framework BDD (Behavior Driven Development)
- **Selenium WebDriver** - Automatización de navegadores
- **FluentAssertions** - Librería de assertions fluidas
- **ExtentReports** - Generación de reportes de pruebas

### Herramientas de Desarrollo
- **Visual Studio 2022** - IDE principal
- **MSTest** - Runner de pruebas integrado

## 🛠️ Configuración del Entorno

### Prerrequisitos
- .NET 8.0 SDK
- Visual Studio 2022 o VS Code
- SQL Server LocalDB o SQL Server
- Navegadores web (Chrome, Edge, Firefox)

### Instalación

1. **Clonar el repositorio**
```bash
git clone https://github.com/EdJGM/TDDTestingMVC.git
cd TDDTestingMVC
```

2. **Restaurar paquetes NuGet**
```bash
dotnet restore
```

3. **Configurar la base de datos**
   - Actualizar la cadena de conexión en `appsettings.json`
   - Ejecutar migraciones si están disponibles

4. **Compilar la solución**
```bash
dotnet build
```

## 🏃‍♂️ Ejecución

### Ejecutar la aplicación web
```bash
cd TDDTestingMVC
dotnet run
```
La aplicación estará disponible en `https://localhost:7xxx`

### Ejecutar pruebas unitarias
```bash
cd TestClientes
dotnet test
```

### Ejecutar pruebas BDD/E2E
```bash
cd ReqnrollTesting
dotnet test
```

### Ejecutar todas las pruebas
```bash
dotnet test
```

## 📊 Funcionalidades

### Gestión de Clientes
- ✅ Crear nuevos clientes
- ✅ Listar clientes existentes
- ✅ Editar información de clientes
- ✅ Eliminar clientes
- ✅ Validación de datos

### Gestión de Pedidos
- ✅ Crear pedidos
- ✅ Asociar pedidos a clientes
- ✅ Gestión de estado de pedidos

### Herramientas Matemáticas
- ✅ Calculadora básica (suma, resta, multiplicación, división)
- ✅ Cálculo de área de círculo
- ✅ Validación de entrada de datos

### Sistema de Autenticación
- ✅ Login de usuarios
- ✅ Registro de nuevos usuarios
- ✅ Validación de credenciales

## 🧪 Estrategia de Pruebas

### Niveles de Prueba Implementados

1. **Pruebas Unitarias** (`TestClientes`)
   - Validación de modelos de dominio
   - Pruebas de lógica de negocio
   - Cálculos matemáticos

2. **Pruebas de Integración** (`ReqnrollTesting`)
   - Pruebas de controladores
   - Validación de flujos de datos

3. **Pruebas End-to-End** (`ReqnrollTesting`)
   - Automatización de interfaz de usuario
   - Pruebas de flujos completos de usuario
   - Pruebas multi-navegador

### Cobertura de Pruebas
- **Funcionalidades CRUD**: Cliente y Pedidos
- **Cálculos matemáticos**: Calculadora y geometría
- **Autenticación**: Login y registro
- **Validaciones**: Entrada de datos y reglas de negocio

## 📁 Estructura de Directorios Detallada

```
TDDTestingMVC/
├── 📁 TDDTestingMVC/                 # Aplicación principal MVC
│   ├── 📁 Controllers/               # Controladores MVC
│   ├── 📁 data/                      # Modelos de datos y DAL
│   ├── 📁 Models/                    # Modelos de dominio
│   ├── 📁 Views/                     # Vistas Razor
│   ├── 📁 wwwroot/                   # Contenido estático
│   ├── 📁 Properties/                # Configuración del proyecto
│   ├── 📄 Program.cs                 # Punto de entrada de la aplicación
│   ├── 📄 appsettings.json          # Configuración de la aplicación
│   └── 📄 TDDTestingMVC.csproj      # Archivo de proyecto
├── 📁 TestClientes/                  # Pruebas unitarias
│   ├── 📄 TestCliente.cs            # Pruebas del modelo Cliente
│   ├── 📄 UnitTest1.cs              # Pruebas unitarias adicionales
│   └── 📄 TestClientes.csproj       # Archivo de proyecto de pruebas
├── 📁 ReqnrollTesting/               # Pruebas BDD y E2E
│   ├── 📁 Features/                  # Archivos .feature (Gherkin)
│   ├── 📁 StepDefinitions/           # Implementación de pasos
│   ├── 📁 Hooks/                     # Hooks de configuración
│   ├── 📁 Utilities/                 # Utilidades (WebDriverManager)
│   ├── 📁 Reports/                   # Reportes generados
│   └── 📄 ReqnrollTesting.csproj    # Archivo de proyecto de pruebas
├── 📄 TDDTestingMVC.sln             # Archivo de solución
├── 📄 README.md                      # Este archivo
└── 📄 .gitignore                     # Archivos ignorados por Git
```

## 🔧 Configuración de Pruebas

### WebDriver Configuration
El proyecto incluye soporte para múltiples navegadores:
- **Chrome**: ChromeDriver
- **Edge**: EdgeDriver  
- **Firefox**: FirefoxDriver

### Reportes de Pruebas
Los reportes se generan automáticamente en la carpeta `Reports/` usando ExtentReports.

## 📝 Convenciones de Código

### Naming Conventions
- **Clases**: PascalCase (`ClienteController`)
- **Métodos**: PascalCase (`CrearCliente`)
- **Variables**: camelCase (`nombreCliente`)
- **Constantes**: UPPER_CASE (`MAX_ITEMS`)

### Testing Conventions
- **Archivos Feature**: Descriptivos en español (`CRUDSTestCliente.feature`)
- **Step Definitions**: Métodos claros y descriptivos
- **Test Methods**: Patrón Arrange-Act-Assert

## 🤝 Contribución

1. Fork el proyecto
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## 📄 Licencia

Este proyecto es parte de un ejercicio académico para la materia de Pruebas de Software.

## 👨‍💻 Autor

**EdJGM** - [GitHub Profile](https://github.com/EdJGM)

---

## 📚 Recursos Adicionales

- [Documentación de ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/)
- [Guía de xUnit](https://xunit.net/docs/getting-started/netcore/cmdline)
- [Documentación de Reqnroll](https://reqnroll.net/)
- [Selenium WebDriver Documentation](https://selenium-python.readthedocs.io/)