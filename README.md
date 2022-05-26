# ChallengeBackend


Este proyecto contiene la API para la resolución del challenge planteado por MELI.

Arquitectura del proyecto se utilizo :

 **Clean Architecture**
  ![image](https://user-images.githubusercontent.com/97917509/165156466-bb1cf510-a24d-481a-a074-02632a88338c.png)

Patrones de diseños:
-Mediator
-CQRS
-Repository

 **Swagger**
 
Al ejecutar el proyecto, el levantara Swagger para poder testear la api.
 [**Swagger**](https://swagger.io/tools/swagger-editor/) para la documentacion de los endpoint.


## Solución propuesta

El sistema cuenta con 2 endpoints con los siguientes métodos: 

- GET /fraudes/{IP} devuelve los datos requeridos del país al cual pertenece la IP 
- GET /stats devuelve los datos de las estadísticas

Cuando se ejecuta el endpoint de fraudes mediante la ip, el proceso ira construyendo la informacion para luego mostrarla al cliente, el cual para obtener dicha informacion se fueron consultando diferentes APIs. Se utiliza REDIS para guardar dicha informacion para que cuando se consulte la misma IP,la respuesta sea mas rapida y mas performante.


Cuando se ejecuta el endpoint STATS, el devolvera las estatidisticas, la cual esta guardada en CACHE.


### Recursos externos
* [Geolocalización de IPs](http://api.ipapi.com/)
* [Información de paises](http://api.countrylayer.com/)
* [Información de monedas](https://restcountries.com/)
