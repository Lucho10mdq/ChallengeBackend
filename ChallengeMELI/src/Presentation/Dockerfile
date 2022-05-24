#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["src/Presentation/ChallengeMELI.csproj", "src/Presentation/"]
COPY ["src/Infrastructure/Configuration/Challenge.MELI.Configuration.csproj", "src/Infrastructure/Configuration/"]
COPY ["src/Core/Application/Challenge.MELI.Application.csproj", "src/Core/Application/"]
COPY ["src/Infrastructure/Helpers/Challenge.MELI.Helpers.csproj", "src/Infrastructure/Helpers/"]
COPY ["src/Infrastructure/Persistence/Challenge.MELI.Persistence.csproj", "src/Infrastructure/Persistence/"]
COPY ["src/Core/Domain/Challenge.MELI.Domain.csproj", "src/Core/Domain/"]
COPY ["src/Infrastructure/ApiClient/Challenge.MELI.ApiClient.csproj", "src/Infrastructure/ApiClient/"]
RUN dotnet restore "src/Presentation/ChallengeMELI.csproj"
COPY . .
WORKDIR "/src/src/Presentation"
RUN dotnet build "ChallengeMELI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ChallengeMELI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ChallengeMELI.dll"]
