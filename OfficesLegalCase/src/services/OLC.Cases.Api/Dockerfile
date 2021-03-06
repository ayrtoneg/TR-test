#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/OLC.Cases.Api/OLC.Cases.Api.csproj", "services/OLC.Cases.Api/"]
COPY ["./core/OLC.Core/OLC.Core.csproj", "core/OLC.Core/"]

RUN dotnet restore "services/OLC.Cases.Api/OLC.Cases.Api.csproj"
COPY . .
WORKDIR "services/OLC.Cases.Api"
RUN dotnet build "OLC.Cases.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OLC.Cases.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OLC.Cases.Api.dll"]