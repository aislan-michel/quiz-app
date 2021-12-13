FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Quiz.App/Quiz.App.csproj", "Quiz.App/"]
RUN dotnet restore "src/Quiz.App/Quiz.App.csproj"
COPY . .
WORKDIR "/src/Quiz.App"
RUN dotnet build "Quiz.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Quiz.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Quiz.App.dll"]
