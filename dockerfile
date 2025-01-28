# 1) Build stage using the .NET 8 SDK
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Publish the application in Release mode to the /app folder
RUN dotnet publish -c Release -o /app

# 2) Runtime stage using the .NET 8 ASP.NET runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app ./

# Expose port 80 inside the container
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "MerchantCategoriesApi.dll"]
