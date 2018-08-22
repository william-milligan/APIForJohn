FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY SurveyAppApi/SurveyAppApi.csproj SurveyAppApi/
RUN dotnet restore SurveyAppApi/SurveyAppApi.csproj
COPY . .
WORKDIR /src/SurveyAppApi
RUN dotnet build SurveyAppApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish SurveyAppApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "SurveyAppApi.dll"]
