# **Arquitectura Hexagonal**

## Contexto

para la implementacion se genera un docker compose con la generacion de la base de datos y la api en docker.

Para poder ejecutar el proyecto se debe modificar la cadena de conexion de la base de datos en el appseting con la ip local de la maquina donde se desea correr.

Luego se debe ejecutar actualizar la base de datos con la migracion que se tiene en el proyecto HexagonalBackend.Infrastucture.SQL

una vez se haya realizado la ejecucion de la migracion y se compruebe que se tiene la estructura de la base de datos, se debe ejecutar el archivo sql, para la carga de datos inicial.

Para las pruebas se puede creó un usuario gerente, UserName: juanpenagos@hotmail.com y Password: Holamundo123.

Para interactuar con algunos de los metodos de creacion de usuario se debe generar un toke a partir de la autenticacion.

