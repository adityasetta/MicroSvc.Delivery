#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["MicroSvc.Delivery.Api/MicroSvc.Delivery.Api.csproj", "MicroSvc.Delivery.Api/"]
RUN dotnet restore "MicroSvc.Delivery.Api/MicroSvc.Delivery.Api.csproj"
COPY . .
WORKDIR "/src/MicroSvc.Delivery.Api"
RUN dotnet build "MicroSvc.Delivery.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroSvc.Delivery.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroSvc.Delivery.Api.dll"]