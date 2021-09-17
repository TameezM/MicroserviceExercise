#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/ApiGateways/Web.Api.HttpAggregator/Web.Api.HttpAggregator.csproj", "src/ApiGateways/Web.Api.HttpAggregator/"]
COPY ["src/Common/ModelsClassLib/ModelsClassLib.csproj", "src/Common/ModelsClassLib/"]
RUN dotnet restore "src/ApiGateways/Web.Api.HttpAggregator/Web.Api.HttpAggregator.csproj"
COPY . .
WORKDIR "/src/src/ApiGateways/Web.Api.HttpAggregator"
RUN dotnet build "Web.Api.HttpAggregator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Web.Api.HttpAggregator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Web.Api.HttpAggregator.dll"]
