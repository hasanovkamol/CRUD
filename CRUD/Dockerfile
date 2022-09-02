#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["CRUD/CRUD.csproj", "CRUD/"]
COPY ["CRUD.Infrasture/CRUD.Infrasture.csproj", "CRUD.Infrasture/"]
COPY ["CRUD.Application/CRUD.Application.csproj", "CRUD.Application/"]
COPY ["CRUD.Domain/CRUD.Domain.csproj", "CRUD.Domain/"]
COPY ["Common/Common.csproj", "Common/"]
RUN dotnet restore "CRUD/CRUD.csproj"
COPY . .
WORKDIR "/src/CRUD"
RUN dotnet build "CRUD.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CRUD.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CRUD.dll"]