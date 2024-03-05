
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["TaskMaster.Web/TaskMaster.Web.csproj", "TaskMaster.Web/"]
COPY ["TaskMaster.Application/TaskMaster.Application.csproj", "TaskMaster.Application/"]
COPY ["TaskMaster.Core/TaskMaster.Core.csproj", "TaskMaster.Core/"]
COPY ["TaskMaster.Persistence/TaskMaster.Persistence.csproj", "TaskMaster.Persistence/"]
COPY ["TaskMaster.Shared/TaskMaster.Shared.csproj", "TaskMaster.Shared/"]
RUN dotnet restore "./TaskMaster.Web/./TaskMaster.Web.csproj"
COPY . .
WORKDIR "/src/TaskMaster.Web"
RUN dotnet build "./TaskMaster.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./TaskMaster.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskMaster.Web.dll"]