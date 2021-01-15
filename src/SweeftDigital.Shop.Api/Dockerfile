#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/SweeftDigital.Shop.Api/SweeftDigital.Shop.Api.csproj", "src/SweeftDigital.Shop.Api/"]
COPY ["src/SweeftDigital.Shop.Application/SweeftDigital.Shop.Application.csproj", "src/SweeftDigital.Shop.Application/"]
COPY ["src/SweeftDigital.Shop.Core/SweeftDigital.Shop.Core.csproj", "src/SweeftDigital.Shop.Core/"]
COPY ["src/SweeftDigital.Shop.Infrastructure/SweeftDigital.Shop.Infrastructure.csproj", "src/SweeftDigital.Shop.Infrastructure/"]
RUN dotnet restore "src/SweeftDigital.Shop.Api/SweeftDigital.Shop.Api.csproj"
COPY . .
WORKDIR "/src/src/SweeftDigital.Shop.Api"
RUN dotnet build "SweeftDigital.Shop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SweeftDigital.Shop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SweeftDigital.Shop.Api.dll"]
