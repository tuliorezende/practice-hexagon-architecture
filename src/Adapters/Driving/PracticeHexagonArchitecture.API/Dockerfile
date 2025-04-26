#FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Adapters/Driving/PracticeHexagonArchitecture.API/PracticeHexagonArchitecture.API.csproj", "src/Adapters/Driving/PracticeHexagonArchitecture.API/"]
COPY ["src/Core/Application/Application.csproj", "src/Core/Application/"]
COPY ["src/Core/Domain/Domain.csproj", "src/Core/Domain/"]
COPY ["src/Adapters/Driven/Infra.Database.Memory/Infra.Database.Memory.csproj", "src/Adapters/Driven/Infra.Database.Memory/"]
COPY ["src/Adapters/Driven/Infra.Database.SqlServer/Infra.Database.SqlServer.csproj", "src/Adapters/Driven/Infra.Database.SqlServer/"]
RUN dotnet restore "src/Adapters/Driving/PracticeHexagonArchitecture.API/PracticeHexagonArchitecture.API.csproj"
COPY . .
WORKDIR "/src/src/Adapters/Driving/PracticeHexagonArchitecture.API"
RUN dotnet build "./PracticeHexagonArchitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PracticeHexagonArchitecture.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app

# The following 2 lines are required for solving: 
# "Globalization Invariant Mode is not supported" error.

ENV \
    DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false \
    LC_ALL=en_US.UTF-8 \
    LANG=en_US.UTF-8

RUN apk add --no-cache \
    icu-data-full \
    icu-libs

COPY --from=publish /app/publish .

#RUN apt update
#RUN apt upgrade -y
#RUN apt install tzdata libicu72
#RUN apk add --no-cache icu-libs icu-data-full


USER $APP_UID

ENTRYPOINT ["dotnet", "PracticeHexagonArchitecture.API.dll"]
