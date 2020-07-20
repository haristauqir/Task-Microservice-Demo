FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["Solution/User.API/User.API.csproj", "Solution/User.API/"]
COPY ["Solution/User.Domain/User.Domain.csproj", "Solution/User.Domain/"]
COPY ["Solution/User.Data/User.Data.csproj", "Solution/User.Data/"]
RUN dotnet restore "Solution/User.API/User.API.csproj"
COPY . .
WORKDIR "/src/Solution/User.API"
RUN dotnet build "User.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.API.dll"]