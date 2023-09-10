# Use the SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dev

# Set the working directory
WORKDIR /app

# Copy csproj and restore dependencies
COPY SimpleCRUDAPI/SimpleCRUDAPI.csproj ./
RUN dotnet restore

# Copy all other files
COPY SimpleCRUDAPI/ ./

# Expose the port that the app runs on
# EXPOSE 5000

# Define the entry point of the application
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:5000"]
