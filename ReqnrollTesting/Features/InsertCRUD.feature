Feature: InsertCRUD

Ingreso de la información del formulario cliente a la BDD

@tag1
Scenario: Insertar clientes
	Given llenar los campos dentro del Formulario
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 1727857870 | Meza      | Edgar   | 01/01/1990      | edgar@mail.com | 0987654321 | Quito     | Activo |
	When Registros ingresados en la BDD
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 1727857870 | Meza      | Edgar   | 01/01/1990      | edgar@mail.com | 0987654321 | Quito     | Activo |
	Then Resultado del ingreso a la BDD
	| Cedula     | Apellidos | Nombres | FechaNacimiento | Mail           | Telefono   | Direccion | Estado |
	| 1727857870 | Meza      | Edgar   | 01/01/1990      | edgar@mail.com | 0987654321 | Quito     | Activo |
