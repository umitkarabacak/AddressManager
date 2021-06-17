#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AddressManager/AddressManager.csproj", "AddressManager/"]
RUN dotnet restore "AddressManager/AddressManager.csproj"
COPY . .
WORKDIR "/src/AddressManager"
RUN dotnet build "AddressManager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AddressManager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AddressManager.dll"]