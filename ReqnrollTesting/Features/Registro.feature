Feature: Registro

A short summary of the feature

@tag1
Scenario: Usuario ingresa sus datos iniciales correctamente
	Given El usuario esta en la pagina de login
	When Ingresa las credenciales correo "edgar@mail.com" y la contraseña"edgar12345"
    And Hace clic en el boton de Signup
	Then El usuario debe ser redirigido a la pagina de registro

@tag2
Scenario: Usuario registra sus datos correctamente
    Given El usuario esta en la pagina de registro
    When Ingresa los datos solicitados
        | Title | Name  | Email          | Password | DateOfBirth | Newsletter | Optin | FirstName | LastName | Company | Address1 | Address2 | Country       | State | City | Zipcode | MobileNumber |
        | Mr    | edgar | edgar@mail.com | edgar123 | 01/01/1990  | true       | true  | Edgar     | Meza     |   Espe  | Calle 1  | Calle 2  | United States | NY    | NY   | 10001   | 1234567890   |
    And Hace clic en el boton de Create Account
    Then El usuario debe ser redirigido a la pagina de bienvenida
