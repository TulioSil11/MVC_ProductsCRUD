#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MVC_TesteSomaVantagens/MVC_TesteSomaVantagens.csproj", "MVC_TesteSomaVantagens/"]
RUN dotnet restore "MVC_TesteSomaVantagens/MVC_TesteSomaVantagens.csproj"
COPY . .
WORKDIR "/src/MVC_TesteSomaVantagens"
RUN dotnet build "MVC_TesteSomaVantagens.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MVC_TesteSomaVantagens.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MVC_TesteSomaVantagens.dll"]