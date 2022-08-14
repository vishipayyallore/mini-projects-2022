# .NET 6 Microservices demonstrating CQRS & Event Sourcing with Kafka

I am learning this from a Video Course.

## Creating SQL Server inside Docker Container
```
docker run -it -d --name smp-es-write-mongo -p 27017:27017 --restart always -v smp-es-write-mongo-datavolume:/data/db -v smp-es-write-mongo-configvolume:/data/configdb mongo:latest
```

## Creating SQL Server inside Docker Container

```
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Sample@123$" -p 1433:1433 --name smp-read-sqlserver --hostname smp-read-sqlserver -e 'MSSQL_PID=Standard' -v smp-read-sqlservervolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2022-latest
```
