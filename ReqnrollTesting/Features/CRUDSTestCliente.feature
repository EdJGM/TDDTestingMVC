Feature: CRUDSTestCliente
  Como administrador del sistema
  Quiero gestionar la información de clientes
  Para mantener actualizada la base de datos de clientes

# ---- PRUEBAS DE INSERCIÓN DE CLIENTES ----

@Cliente @InsertarCliente @DatosValidos
Scenario: Insertar cliente con datos válidos
	Given el usuario navega a la página de crear cliente
	When completa el formulario con datos válidos
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado  |
	| 1727857870 | Nelson   | Agustin    | 01/01/1990      | juan@mail.com  | 0987654321 | Quito     | Activo  |
	And hace clic en el botón crear valido "Crear Cliente"
	Then debe redirigirse a la página de listado de clientes
	And el cliente debe aparecer en la lista
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado  |
	| 1727857870 | Nelson   | Agustin    | 01/01/1990      | juan@mail.com  | 0987654321 | Quito     | Activo  |

@Cliente @InsertarCliente @DatosInvalidos
Scenario: Insertar cliente con correo inválido
	Given el usuario navega a la página de crear cliente
	When completa el formulario con correo inválido
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado  |
	| 1727857870 | Agustin   | Nelson    | 01/01/1990      | correo_invalido| 0987654321 | Quito     | Activo  |
	And hace clic en el botón crear invalido "Crear Cliente"
	Then debe mostrarse un mensaje de error para el campo "Mail"

# ---- PRUEBAS DE ACTUALIZACIÓN DE CLIENTES ----

@Cliente @ActualizarCliente @DatosValidos
Scenario: Actualizar cliente con datos válidos
	Given existe un cliente con código "12" en el sistema
	And el usuario navega a la página de editar cliente "12"
	When actualiza los datos del formulario
	| Cedula     | Apellidos   | Nombres      | FechaNacimiento | Mail               | Telefono   | Direccion      | Estado  |
	| 1727857870 | Salazar Ruiz| Juan Carlos  | 05/10/1992      | juanc@mail.com     | 0998765432 | Quito Centro   | Activo  |
	And hace clic en el botón guardar actualizado "Guardar"
	Then debe redirigirse a la página de listado de clientes
	And el cliente debe aparecer actualizado en la lista
	| Codigo | Cedula     | Apellidos  | Nombres     | Mail           | Telefono   | Direccion    | Estado |
	| 12     | 2468101213 | Agustin | Nelson | juanc@mail.com | 0998765432 | Quito Centro | Activo |

@Cliente @ActualizarCliente @DatosInvalidos
Scenario: Actualizar cliente con correo inválido
	Given existe un cliente con código "12" en el sistema
	And el usuario navega a la página de editar cliente "12"
	When actualiza el correo con un valor inválido "correo_invalido"
	And hace clic en el botón guardar invalido "Guardar"
	Then debe mostrarse un mensaje de error para el campo "Mail"