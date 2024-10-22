FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

COPY *.sln ./
COPY RedisExampleWithCleanArchitecture.Domain/*.csproj RedisExampleWithCleanArchitecture.Domain/
COPY RedisExampleWithCleanArchitecture.Application/*.csproj RedisExampleWithCleanArchitecture.Application/
COPY RedisExampleWithCleanArchitecture.Infrastructure/*.csproj RedisExampleWithCleanArchitecture.Infrastructure/
COPY RedisExampleWithCleanArchitecture.Persistence/*.csproj RedisExampleWithCleanArchitecture.Persistence/
COPY RedisExampleWithCleanArchitecture.WebApi/*.csproj RedisExampleWithCleanArchitecture.WebApi/

RUN dotnet restore

COPY . . 

RUN dotnet publish /app/RedisExampleWithCleanArchitecture.WebApi/RedisExampleWithCleanArchitecture.WebApi.csproj -c Release -o /out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

COPY --from=build /out .

EXPOSE 80

ENTRYPOINT ["dotnet", "RedisExampleWithCleanArchitecture.WebApi.dll"]
