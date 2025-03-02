FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Api/*.csproj", "UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Api/"]
COPY ["UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Domain/*.csproj", "UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Domain/"]
COPY ["UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Infrastructure/*.csproj", "UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Infrastructure/"]

COPY ["UsersManagement/TrialsSystem.IdentityService/*.sln", "UsersManagement/TrialsSystem.IdentityService/"]

RUN dotnet restore "UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.sln"
COPY . .


WORKDIR UsersManagement/TrialsSystem.IdentityService/TrialsSystem.IdentityService.Api
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TrialsSystem.IdentityService.Api.dll"]