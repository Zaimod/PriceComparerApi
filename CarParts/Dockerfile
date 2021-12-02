FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base

WORKDIR /app

EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /src

COPY ["CarParts/PriceComparer.csproj", "CarParts/"]
COPY ["ClassLibrary1/ParserApplication.csproj", "ClassLibrary1/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["LoggerService/LoggerService.csproj", "LoggerService/"]
COPY ["Repository/Repository.csproj", "Repository/"]

RUN dotnet restore "CarParts/PriceComparer.csproj"

COPY . .

WORKDIR "/src/CarParts"
RUN dotnet build "PriceComparer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PriceComparer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV ASPNETCORE_URLS="http://0.0.0.0:5000/"

ENTRYPOINT ["dotnet", "PriceComparer.dll"]