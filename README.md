# ChallengeBackend


Este proyecto contiene la API para la resoluci�n del challenge planteado por MELI.

Arquitectura del proyecto se utilizo :

 **Clean Architecture**
  ![image](https://user-images.githubusercontent.com/97917509/165156466-bb1cf510-a24d-481a-a074-02632a88338c.png)

Patrones de dise�os:
-Mediator
-CQRS
-Repository

Al ejecutar el proyecto, el levantara Swagger para poder testear la api y ver la documentacion.

 **Swagger**
  
   The boilerplate uses [**Swagger**](https://swagger.io/tools/swagger-editor/) for endpoint documentation


## Soluci�n propuesta

El sistema cuenta con 2 endpoints con los siguientes m�todos: 

- GET /traceIP/{IP} devuelve los datos requeridos del pa�s al cual pertenece la IP 
- GET /stats devuelve los datos de las estad�sticas

Cuando se consultan los datos de un pa�s mediante traceIP, primero se utiliza la API de geolocalizaci�n para determinar a qu� pa�s pertenece dicha IP, luego se consulta el cach� de REDIS para ver si la informaci�n ya se encuentra almacenada all�, por �ltimo en caso de no estarlo, se consultan las APIs con informaci�n de paises y monedas.


### Consideraciones

- Los datos sobre paises se almacenan en cache por 1 hora
- Los datos sobre las estad�sticas se almacenan en cache por 1 d�a


### Recursos externos
* [Geolocalizaci�n de IPs](https://ip2country.info/) 
* [Informaci�n de paises](https://ip2country.info/) 
* [Informaci�n de monedas](https://ip2country.info/) - API key: 1d36ca93d4899bf443eaea7223b4c078