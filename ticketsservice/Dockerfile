# Use the official Microsoft ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 8080
EXPOSE 443

# Use the official Microsoft ASP.NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the .csproj and restore as distinct layers
COPY ["ticketsservice.csproj", "."]
RUN dotnet restore "ticketsservice.csproj"

# Copy the remaining code and build the application
COPY . .
WORKDIR "/src"
RUN dotnet build "ticketsservice.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "ticketsservice.csproj" -c Release -o /app/publish

# Build the final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ticketsservice.dll"]

