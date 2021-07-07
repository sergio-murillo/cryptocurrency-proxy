FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 433

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /CryptoCurrency
COPY ["CryptoCurrency/CryptoCurrency.Application/CryptoCurrency.Application.csproj", "CryptoCurrency/CryptoCurrency.Application/"]
COPY ["CryptoCurrency/CryptoCurrency.Infrastructure.Services/CryptoCurrency.Infrastructure.Services.csproj", "CryptoCurrency/CryptoCurrency.Infrastructure.Services/"]
COPY ["CryptoCurrency/CryptoCurrency.WebApi/CryptoCurrency.WebApi.csproj", "CryptoCurrency/CryptoCurrency.WebApi/"]
COPY ["CryptoCurrency/CryptoCurrency.Application.UnitTests/CryptoCurrency.Application.UnitTests.csproj", "CryptoCurrency/CryptoCurrency.Application.UnitTests/"]
RUN dotnet restore "CryptoCurrency/CryptoCurrency.WebApi/CryptoCurrency.WebApi.csproj"
COPY . .
WORKDIR "/CryptoCurrency/CryptoCurrency/CryptoCurrency.WebApi"
RUN dotnet build "CryptoCurrency.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoCurrency.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoCurrency.WebApi.dll"]