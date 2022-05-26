# ChallengeBackend


Este proyecto contiene la API para la resolución del challenge planteado por MELI.

Arquitectura del proyecto se utilizo :

 **Clean Architecture**
  ![image](https://user-images.githubusercontent.com/97917509/165156466-bb1cf510-a24d-481a-a074-02632a88338c.png)

Patrones de diseños:
-Mediator
-CQRS
-Repository

Al ejecutar el proyecto, el levantara Swagger para poder testear la api y ver la documentacion.

 **Swagger**
  
   The boilerplate uses [**Swagger**](https://swagger.io/tools/swagger-editor/) for endpoint documentation


## Solución propuesta

El sistema cuenta con 2 endpoints con los siguientes métodos: 

- GET /traceIP/{IP} devuelve los datos requeridos del país al cual pertenece la IP 
- GET /stats devuelve los datos de las estadísticas

Cuando se consultan los datos de un país mediante traceIP, primero se utiliza la API de geolocalización para determinar a qué país pertenece dicha IP, luego se consulta el caché de REDIS para ver si la información ya se encuentra almacenada allí, por último en caso de no estarlo, se consultan las APIs con información de paises y monedas.


### Consideraciones

- Los datos sobre paises se almacenan en cache por 1 hora
- Los datos sobre las estadísticas se almacenan en cache por 1 día


### Recursos externos
* [Geolocalización de IPs](https://ip2country.info/) 
* [Información de paises](https://ip2country.info/) 
* [Información de monedas](https://ip2country.info/) - API key: 1d36ca93d4899bf443eaea7223b4c078