Feature: Login

A short summary of the feature

@tag1
Scenario: Usuario inicia sesion correctamente
	Given El usuario esta en la pagina del login
	When Ingresa las credenciales correo "test_user@mail.com" y la contraseña "pass123"
	And Hace clic en el boton de Login
	Then Mostrar un mensaje de error 