#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
RUN apt-get update; apt-get install curl -y

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app
COPY . .
WORKDIR /app/asp-net-core-api
RUN dotnet restore "asp-net-core-api.csproj"
RUN dotnet build "asp-net-core-api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "asp-net-core-api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "asp-net-core-api.dll", "--urls=http://+:5000"]
