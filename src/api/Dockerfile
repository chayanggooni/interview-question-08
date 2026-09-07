FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["src/api/InterviewQuestion08.Api.csproj", "src/api/"]
RUN dotnet restore "src/api/InterviewQuestion08.Api.csproj"

COPY . .

RUN dotnet publish "src/api/InterviewQuestion08.Api.csproj" \
    -c Release \
    -o /app/publish \
    --no-restore


FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final

WORKDIR /app

COPY --from=build /app/publish .

RUN mkdir -p /app/data

EXPOSE 8080

ENTRYPOINT ["dotnet", "InterviewQuestion08.Api.dll"]