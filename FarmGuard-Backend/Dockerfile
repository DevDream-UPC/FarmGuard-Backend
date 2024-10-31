FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081
ENV DB_CONNECTION_STRING="server=34.125.41.179;port=3306;user=root;password=devdream33216;database=db-farmguard"


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release

WORKDIR /src
COPY ["FarmGuard-Backend/FarmGuard-Backend.csproj", "FarmGuard-Backend/"]
RUN dotnet restore "FarmGuard-Backend/FarmGuard-Backend.csproj"
COPY . .
WORKDIR "/src/FarmGuard-Backend"
RUN dotnet build "FarmGuard-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FarmGuard-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FarmGuard-Backend.dll"]
