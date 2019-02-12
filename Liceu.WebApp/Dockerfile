FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Liceu.WebApp/Liceu.WebApp.csproj", "Liceu.WebApp/"]
RUN dotnet restore "Liceu.WebApp/Liceu.WebApp.csproj"
COPY . .
WORKDIR "/src/Liceu.WebApp"
RUN dotnet build "Liceu.WebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Liceu.WebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Liceu.WebApp.dll"]