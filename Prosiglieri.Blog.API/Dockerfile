FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Prosiglieri.Blog.API/Prosiglieri.Blog.API.csproj", "Prosiglieri.Blog.API/"]
COPY ["Prosiglieri.Blog.Application/Prosiglieri.Blog.Application.csproj", "Prosiglieri.Blog.Application/"]
COPY ["Prosiglieri.Blog.Domain/Prosiglieri.Blog.Domain.csproj", "Prosiglieri.Blog.Domain/"]
COPY ["Prosiglieri.Blog.Infra/Prosiglieri.Blog.Infra.csproj", "Prosiglieri.Blog.Infra/"]
RUN dotnet restore "./Prosiglieri.Blog.API/./Prosiglieri.Blog.API.csproj"
COPY . .
WORKDIR "/src/Prosiglieri.Blog.API"
RUN dotnet build "./Prosiglieri.Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Prosiglieri.Blog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prosiglieri.Blog.API.dll"]