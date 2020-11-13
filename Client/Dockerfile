FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Client/BlazorClient.csproj", "Client/"] 
COPY ["Shared/Shared.csproj", "Shared/"]
RUN dotnet restore "Client/BlazorClient.csproj"
COPY . .
WORKDIR "/src/Client"
#RUN dotnet build "BlazorClient.csproj" -c Release -o /app/build

#FROM build AS publish
RUN dotnet publish "BlazorClient.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY --from=publish /app/publish/BlazorClient/dist .
COPY nginx.conf /etc/nginx/nginx.conf