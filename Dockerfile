FROM mcr.microsoft.com/dotnet/sdk:8.0 AS base
WORKDIR /WebApi
COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM  mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /WebApi
COPY --from=base /WebApi/out ./
EXPOSE 8080
ENTRYPOINT [ "dotnet", "WebApi.dll", "--environment=Development" ]
  