FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app

COPY ./CRM.Backend.sln ./

COPY ./CRM.API/CRM.Api.csproj ./CRM.Api/
COPY ./CRM.Application/CRM.Application.csproj ./CRM.Application/
COPY ./CRM.Infrastructure/CRM.Infrastructure.csproj ./CRM.Infrastructure/
COPY ./CRM.Core/CRM.Core.csproj ./CRM.Core/

RUN dotnet restore "./CRM.Api/CRM.Api.csproj"

COPY . .

WORKDIR "/app/CRM.Api"
ENTRYPOINT ["dotnet", "watch", "run", "--urls=http://+:8080"]