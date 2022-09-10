API REST Net Core

Para que los servicio funcionen se agrega script de base de datos "CotizadorTablas" para que los servicios esten en funcionamiento.

Pasos: 

1.- Creacion de las tablas

2.- Antes de ejecutar los querys de los join, se debe de poblar la tabla de Repositorio,
en el back end hay un servicio que se llama /Catalogos/api/AgregarMarcas esto lo que hace es ir por los registros del servicio de
https://api-test.aarco.com.mx/examen-insumos/ListaDeAutos.txt y los llena en la tabla de Repositorio.

3.- Una vez ya ejecutado el servicio de AgregarMarcas se pueden ejecutar los querys de los join

4.- Probar desde los servicios desde el api

