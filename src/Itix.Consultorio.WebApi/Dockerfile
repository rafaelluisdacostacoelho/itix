FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 59050
EXPOSE 44331

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Itix.Consultorio.WebApi/Itix.Consultorio.WebApi.csproj Itix.Consultorio.WebApi/
RUN dotnet restore Itix.Consultorio.WebApi/Itix.Consultorio.WebApi.csproj
COPY . .
WORKDIR /src/Itix.Consultorio.WebApi
RUN dotnet build Itix.Consultorio.WebApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish Itix.Consultorio.WebApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Itix.Consultorio.WebApi.dll"]
