#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Source/eShop.UsersAPI/eShop.UsersAPI.csproj", "Source/eShop.UsersAPI/"]
RUN dotnet restore "Source/eShop.UsersAPI/eShop.UsersAPI.csproj"
COPY . .
WORKDIR "/src/Source/eShop.UsersAPI"
RUN dotnet build "eShop.UsersAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eShop.UsersAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eShop.UsersAPI.dll"]