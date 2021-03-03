#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["DiscountTracker.Api/DiscountTracker.Api.csproj", "DiscountTracker.Api/"]
RUN dotnet restore "DiscountTracker.Api/DiscountTracker.Api.csproj"
COPY . .
WORKDIR "/src/DiscountTracker.Api"
RUN dotnet build "DiscountTracker.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DiscountTracker.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DiscountTracker.Api.dll"]