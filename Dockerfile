# Build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files and restore (better layer caching)
COPY DevOps.WebAPI/*.csproj ./DevOps.WebAPI/
RUN dotnet restore DevOps.WebAPI/DevOps.WebAPI.csproj

# Copy everything else and publish
COPY DevOps.WebAPI/. ./DevOps.WebAPI/
WORKDIR /src/DevOps.WebAPI
RUN dotnet publish -c Release -o /app/publish --no-restore

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# Render injects PORT env var; bind to it
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "DevOps.WebAPI.dll"]