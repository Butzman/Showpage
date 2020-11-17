FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Client/BlazorClient.csproj", "Client/"] 
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Client/BlazorClient.csproj"
COPY . .
WORKDIR "/src/Client"
RUN dotnet build "BlazorClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BlazorClient.csproj" -c Release -o /app/publish

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/wwwroot .
#COPY Client/nginx.conf /etc/nginx/nginx.conf