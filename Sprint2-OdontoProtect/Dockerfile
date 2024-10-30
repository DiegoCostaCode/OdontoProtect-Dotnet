FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Sprint2-OdontoProtect/Sprint2-OdontoProtect.csproj", "Sprint2-OdontoProtect/"]
RUN dotnet restore "Sprint2-OdontoProtect/Sprint2-OdontoProtect.csproj"
COPY . .
WORKDIR "/src/Sprint2-OdontoProtect"
RUN dotnet build "Sprint2-OdontoProtect.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Sprint2-OdontoProtect.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sprint2-OdontoProtect.dll"]
