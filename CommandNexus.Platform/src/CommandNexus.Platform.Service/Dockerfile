FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build-env

WORKDIR /src

COPY CommandNexus.Common/src/CommandNexus.Common/CommandNexus.Common.csproj CommandNexus.Common/src/CommandNexus.Common/

COPY CommandNexus.Platform/src/CommandNexus.Platform.Service/CommandNexus.Platform.Service.csproj CommandNexus.Platform/src/CommandNexus.Platform.Service/

RUN dotnet restore CommandNexus.Platform/src/CommandNexus.Platform.Service/CommandNexus.Platform.Service.csproj

COPY . .

WORKDIR /src/CommandNexus.Platform/src/CommandNexus.Platform.Service

RUN dotnet publish -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 8080

ENTRYPOINT ["dotnet", "CommandNexus.Platform.Service.dll"]