FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV Logging__Console__FormatterName=Simple

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Server/RunSynopsis.Server.csproj", "Server/"]
COPY ["Application/RunSynopsis.Application.csproj", "Application/"]
COPY ["Domain/RunSynopsis.Domain.csproj", "Domain/"]
COPY ["../../Mesh/Bus/RunSynopsis.Mesh.Bus.csproj", "../../Mesh/Bus/"]
RUN dotnet restore "Server/RunSynopsis.Server.csproj"
COPY . .
WORKDIR "/src/Server"
RUN dotnet build "RunSynopsis.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RunSynopsis.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RunSynopsis.Server.dll"]
