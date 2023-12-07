#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base
WORKDIR /app
RUN apk add --no-cache icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
USER app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/BallastLane/BallastLane.csproj", "/src/BallastLane/"]
COPY ["src/BallastLane.Api/BallastLane.Api.csproj", "/src/BallastLane.Api/"]
COPY ["src/BallastLane.Client/BallastLane.Client.csproj", "/src/BallastLane.Client/"]
COPY ["src/BallastLane.Infraestructure/BallastLane.Infraestructure.csproj", "/src/BallastLane.Infraestructure/"]
COPY ["src/BallestLane.Business/BallestLane.Business.csproj", "/src/BallestLane.Business/"]
COPY ["src/BallestLane.Dal/BallestLane.Dal.csproj", "/src/BallestLane.Dal/"]
COPY ["src/BallestLane.Dtos/BallestLane.Dtos.csproj", "/src/BallestLane.Dtos/"]
COPY ["src/BallestLane.Entities/BallestLane.Entities.csproj", "/src/BallestLane.Entities/"]

RUN dotnet restore "/src/BallastLane/BallastLane.csproj"
RUN dotnet restore "/src/BallastLane.Api/BallastLane.Api.csproj"
RUN dotnet restore "/src/BallastLane.Client/BallastLane.Client.csproj"
RUN dotnet restore "/src/BallastLane.Infraestructure/BallastLane.Infraestructure.csproj"
RUN dotnet restore "/src/BallestLane.Business/BallestLane.Business.csproj"
RUN dotnet restore "/src/BallestLane.Dal/BallestLane.Dal.csproj"
RUN dotnet restore "/src/BallestLane.Dtos/BallestLane.Dtos.csproj"
RUN dotnet restore "/src/BallestLane.Entities/BallestLane.Entities.csproj"
WORKDIR /src
COPY /src .
WORKDIR /src/BallastLane.Client
RUN dotnet build "/src/BallastLane/BallastLane.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "/src/BallastLane/BallastLane.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BallastLane.dll"]