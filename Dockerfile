FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /App
COPY --from=build-env /App/out .
ENV DOTNET_EnableDiagnostics=0
ENTRYPOINT ["dotnet", "ApiOLSoftwareRest.dll"]

EXPOSE 8088

