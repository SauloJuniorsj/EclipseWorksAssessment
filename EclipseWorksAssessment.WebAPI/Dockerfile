# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EclipseWorksAssessment.WebAPI/EclipseWorksAssessment.WebAPI.csproj", "EclipseWorksAssessment.WebAPI/"]
COPY ["EclipseWorksAssessment.Application/EclipseWorksAssessment.Application.csproj", "EclipseWorksAssessment.Application/"]
COPY ["EclipseWorksAssessment.Domain/EclipseWorksAssessment.Domain.csproj", "EclipseWorksAssessment.Domain/"]
COPY ["EclipseWorksAssessment.Persistence/EclipseWorksAssessment.Persistence.csproj", "EclipseWorksAssessment.Persistence/"]
RUN dotnet restore "./EclipseWorksAssessment.WebAPI/EclipseWorksAssessment.WebAPI.csproj"
RUN dotnet restore "./EclipseWorksAssessment.Application/EclipseWorksAssessment.Application.csproj"
RUN dotnet restore "./EclipseWorksAssessment.Domain/EclipseWorksAssessment.Domain.csproj"
RUN dotnet restore "./EclipseWorksAssessment.Persistence/EclipseWorksAssessment.Persistence.csproj"
COPY . .
WORKDIR "/src/EclipseWorksAssessment.WebAPI"
RUN dotnet build "./EclipseWorksAssessment.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./EclipseWorksAssessment.WebAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EclipseWorksAssessment.WebAPI.dll"]