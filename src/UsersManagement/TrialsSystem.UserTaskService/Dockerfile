FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

COPY ["UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Api/*.csproj", "UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Api/"]
COPY ["UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Domain/*.csproj", "UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Domain/"]
COPY ["UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Infrastructure/*.csproj", "UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Infrastructure/"]

COPY ["UsersManagement/TrialsSystem.UserTaskService/*.sln", "UsersManagement/TrialsSystem.UserTaskService/"]

RUN dotnet restore "UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.sln"
COPY . .


WORKDIR UsersManagement/TrialsSystem.UserTaskService/TrialsSystem.UserTaskService.Api
RUN dotnet publish --no-restore -c Release -o /app/publish

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "TrialsSystem.UserTaskService.Api.dll"]