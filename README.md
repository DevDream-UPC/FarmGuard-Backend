# FarmGuard-Backend
Api de FarmGuard desarrollado por Brayan y Alesandro. Desarrollada con Microsoft C#, ASP.NET Core, Entity Framework Core and MySQL persistence. Siguiendo una arquitectura en capas basada en el dominio. Ademas de implementar un patron CQRS

# RESTful API
* OpenAPI Documentation
* Swagger UI
* ASP.NET Framework
* Entity Framework Core
* Audit Creation and Update Date
* Custom Route Naming Conventions
* Custom Object-Relational Mapping Naming Conventions.
* MySQL Database
* Domain-Driven Design

## Comandos para dockerizar 

```
cd FarmGuard-Backend

docker buildx build -t farmguard-backend --platform linux/amd64 .

docker buildx build -t farmguard-backend --platform linux/amd64 .

docker images

docker tag farmguard-backend:latest gcr.io/dotted-embassy-440305-i5/farmguard-backend:v10

docker push gcr.io/dotted-embassy-440305-i5/farmguard-backend:v8

```
