
# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env

WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 8081

ENV ASPNETCORE_HTTP_PORTS=8081

ENTRYPOINT ["dotnet", "PlatformService.dll"]
