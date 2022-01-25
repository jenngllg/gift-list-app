#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["GiftList.Clients.Web/GiftList.Clients.Web.csproj", "GiftList.Clients.Web/"]
RUN dotnet restore "GiftList.Clients.Web/GiftList.Clients.Web.csproj"
COPY . .
WORKDIR "/src/GiftList.Clients.Web"
RUN dotnet build "GiftList.Clients.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GiftList.Clients.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GiftList.Clients.Web.dll"]