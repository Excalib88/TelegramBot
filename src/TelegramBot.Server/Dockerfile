FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EmptyTelegramBot.Core/EmptyTelegramBot.Core.csproj", "EmptyTelegramBot.Core/"]
RUN dotnet restore "EmptyTelegramBot.Core/EmptyTelegramBot.Core.csproj"
COPY . .
WORKDIR "/src/EmptyTelegramBot.Core"
RUN dotnet build "EmptyTelegramBot.Core.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EmptyTelegramBot.Core.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EmptyTelegramBot.Core.dll"]