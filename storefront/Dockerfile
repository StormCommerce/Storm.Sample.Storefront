FROM mcr.microsoft.com/dotnet/aspnet:7.0-bookworm-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM pull mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["storefront/storefront.csproj", "storefront/"]
RUN dotnet restore "storefront/storefront.csproj"
COPY . .
WORKDIR "/src/storefront"
RUN dotnet build "storefront.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "storefront.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENV TZ=Europe/Stockholm
ENV ASPNETCORE_URLS=http://+:1800

ENTRYPOINT ["dotnet", "storefront.dll"]