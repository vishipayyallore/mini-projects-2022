#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["source/BooksStore.Web/BooksStore.Web.csproj", "source/BooksStore.Web/"]
COPY ["source/BooksStore.Repository/BooksStore.Repository.csproj", "source/BooksStore.Repository/"]
COPY ["source/BooksStore.Core/BooksStore.Core.csproj", "source/BooksStore.Core/"]
COPY ["source/BooksStore.Data/BooksStore.Data.csproj", "source/BooksStore.Data/"]
RUN dotnet restore "source/BooksStore.Web/BooksStore.Web.csproj"
COPY . .
WORKDIR "/src/source/BooksStore.Web"
RUN dotnet build "BooksStore.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BooksStore.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BooksStore.Web.dll"]