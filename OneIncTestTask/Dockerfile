FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OneIncTestTask/OneIncTestTask.csproj", "OneIncTestTask/"]
COPY ["OneIncTestTask.Facade/OneIncTestTask.Facade.csproj", "OneIncTestTask.Facade/"]
COPY ["OneIncTestTask.Utils/OneIncTestTask.Utils.csproj", "OneIncTestTask.Utils/"]
RUN dotnet restore "OneIncTestTask/OneIncTestTask.csproj"
COPY . .
WORKDIR "/src/OneIncTestTask"
RUN dotnet build "OneIncTestTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OneIncTestTask.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OneIncTestTask.dll"]
