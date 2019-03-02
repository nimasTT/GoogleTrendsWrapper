FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["GoogleTrendsASPCoreServer/GoogleTrendsASPCoreServer.csproj", "GoogleTrendsASPCoreServer/"]
RUN dotnet restore "GoogleTrendsASPCoreServer/GoogleTrendsASPCoreServer.csproj"
COPY . .
WORKDIR "/src/GoogleTrendsASPCoreServer"
RUN dotnet build "GoogleTrendsASPCoreServer.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GoogleTrendsASPCoreServer.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GoogleTrendsASPCoreServer.dll"]