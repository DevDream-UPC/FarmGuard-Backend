FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Establece la variable de entorno ASPNETCORE_ENVIRONMENT
ENV ASPNETCORE_ENVIRONMENT=Production



FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY FarmGuard-Backend.csproj .
RUN dotnet restore "FarmGuard-Backend.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "FarmGuard-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FarmGuard-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV PORT 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:$PORT
EXPOSE 8080

ENTRYPOINT ["dotnet", "FarmGuard-Backend.dll"]



