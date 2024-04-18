# dinner reservation api

A microservice project following Amichai Mantinband's series on Clean Architecture and Domain Driven Design (available on youtube).

# Features
 - Domain
 - Application
 - Infrastructure (with db access)
 - Presentation (web api)

![ss1](https://github.com/duszakpawel/dinner-reservation-api/assets/17085237/1bbc6a08-c16e-4b2f-9bf6-d9d27945e16d)
![ss2](https://github.com/duszakpawel/dinner-reservation-api/assets/17085237/42a19bab-abfe-434a-8a04-749f20e0ac52)
![ss3](https://github.com/duszakpawel/dinner-reservation-api/assets/17085237/77ab4013-8426-4fc7-b3d9-d346292e660c)


# Stack

 - .NET 8 with EF Core (sql lite provider)
 - ErrorOr
 - FluentValidation
 - Mapster
 - MediatR

## Guide

```
dotnet run --project .\BuberDinner.Api\
```
or

```
docker-compose up -d --build
```

if you have docker installed

before actually using, create your sql server and populate your database with tables:
```
docker pull mcr.microsoft.com/mssql/server:2022-latest

docker run -d 'HOMEBREW_NO_ENV_FILTERING=1'  -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=password' -p 1433:1433 -d %mcr.microsoft.com/mssql/server:2022-latest

dotnet ef database update -p BuberDinner.Infrastructure -s BuberDinner.Api --connection "Server=localhost; Database=BuberDinner; User Id=sa; Password=password;Encrypt=false"
```
