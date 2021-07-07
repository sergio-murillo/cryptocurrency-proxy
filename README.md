# Contents

* [Global Requisites](#global-requisites)
* [Install, Configure & Run](#install-configure--run)
* [API Docs]("#swagger)

# Global Requisites

* asp .net 5

# Install, Configure & Run

Below mentioned are the steps to install, configure & run in your platform.

```bash
# Without Docker

# Restore solution

dotnet restore CryptoCurrency/CryptoCurrency.WebApi/CryptoCurrency.WebApi.csproj

# Build solution
dotnet build "CryptoCurrency/CryptoCurrency.WebApi.csproj" -c Release -o /app/build

# Publish solution
dotnet publish "CryptoCurrency/CryptoCurrency.WebApi.csproj" -c Release -o /app/publish

# Run solution
dotnet CryptoCurrency.WebApi.dll

```

```bash
# With Docker

# Run the app in docker as a foreground process
docker-compose up

# Run the app in docker as a background process
docker-compose up -d


```


```
# Swagger

```sh
# To view Swagger you must access http://localhost:5000//swagger/index.html
```