# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
EXPOSE 8080

# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/team-mapper-messaging-api/team-mapper-messaging-api.csproj", "src/team-mapper-messaging-api/"]
# RUN dotnet nuget add source https://api.nuget.org/v3/index.json --name nuget.org --configfile /tmp/NuGet.Config || true
# RUN dotnet restore "./src/team-mapper-messaging-api/team-mapper-messaging-api.csproj" --disable-parallel --no-cache
COPY . .
WORKDIR "/src/src/team-mapper-messaging-api"
RUN dotnet build "./team-mapper-messaging-api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./team-mapper-messaging-api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "team-mapper-messaging-api.dll"]

# Add healthcheck instruction
HEALTHCHECK --interval=30s --timeout=10s --start-period=5s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1