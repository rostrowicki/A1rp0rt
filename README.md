# AIRPORTS backend

This sample backend solution is designed to provide extendable project structure with initial functionallity implementation.

## Setup

### Database Initialization
* Ensure that connection string is properly set.
	Default value assumes localhost db server and db name equals to 'Airports' (refer to Airports.Data > ORM > AirportsContext.cs

If database exists and connection string is properly defined initialize code firts migration. But first ensure Migrations folder is empty then run in Airports.Data project folder:

``` 
dotnet ef  migrations add CreateDatabase
```

then

```
dotnet ef database update
```

Database structure is now in place.

### dotnetcore backend
target version: 2.2.x

* in solution folder run: 

``` 
dotnet restore
```

* to run application in Airports project folder run: 

``` 
dotnet run
```

Once application is running populate database by visiting following URL:
https://localhost:5001/api/airports/refresh

### Unit test

In Airports.Test project run:

```
dotnet test
```