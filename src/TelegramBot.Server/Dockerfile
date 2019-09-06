FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["TelegramBot.Server/TelegramBot.Server.csproj", "TelegramBot.Server/"]
RUN dotnet restore "EmptyTelegramBot.Core/EmptyTelegramBot.Core.csproj"
COPY . .
WORKDIR "/src/TelegramBot.Server"
RUN dotnet build "TelegramBot.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TelegramBot.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TelegramBot.Server.dll"]