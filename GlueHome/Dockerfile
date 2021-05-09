FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["GlueHome/GlueHome.csproj", "GlueHome/"]
RUN dotnet restore "GlueHome/GlueHome.csproj"
COPY . .
WORKDIR "/src/GlueHome"
RUN dotnet build "GlueHome.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GlueHome.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GlueHome.dll"]