#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MusalaSoft.Gateway.Api/MusalaSoft.Gateway.Api.csproj", "MusalaSoft.Gateway.Api/"]
RUN dotnet restore "MusalaSoft.Gateway.Api/MusalaSoft.Gateway.Api.csproj"
COPY . .
WORKDIR "/src/MusalaSoft.Gateway.Api"
RUN dotnet build "MusalaSoft.Gateway.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MusalaSoft.Gateway.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MusalaSoft.Gateway.Api.dll"]