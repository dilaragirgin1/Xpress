FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
COPY . .

EXPOSE 8080
EXPOSE 443

RUN dotnet restore src/BG.Express.API/BG.Express.API.csproj

RUN dotnet publish src/BG.Express.API/BG.Express.API.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=base /app .

ENV TZ=Europe/Istanbul
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

ENTRYPOINT ["dotnet", "BG.Express.API.dll"]