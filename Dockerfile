# Usar a imagem base oficial do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /app

# Copiar csproj e restaurar dependências
COPY *.sln .
COPY tests/ToDoList.Domain.Tests/ToDoList.Domain.Tests.csproj ./tests/ToDoList.Domain.Tests/
COPY tests/ToDoList.Application.Tests/ToDoList.Application.Tests.csproj ./tests/ToDoList.Application.Tests/
COPY src/ToDoList.Application/ToDoList.Application.csproj ./src/ToDoList.Application/
COPY src/ToDoList.Domain/ToDoList.Domain.csproj ./src/ToDoList.Domain/
COPY src/ToDoList.Infra/ToDoList.Infra.Data/ToDoList.Infra.Data.csproj ./src/ToDoList.Infra/ToDoList.Infra.Data/
COPY src/ToDoList.Infra/ToDoList.Infra.IoC/ToDoList.Infra.IoC.csproj ./src/ToDoList.Infra/ToDoList.Infra.IoC/
COPY src/ToDoList.WebApi/ToDoList.WebApi.csproj ./src/ToDoList.WebApi/
RUN dotnet restore

# Copiar os arquivos do projeto e construir a aplicação
COPY tests/ToDoList.Application.Tests/. ./ToDoList.Application.Tests/
COPY tests/ToDoList.Domain.Tests/. ./ToDoList.Domain.Tests/
COPY src/ToDoList.Application/. ./ToDoList.Application/
COPY src/ToDoList.Application/. ./ToDoList.Application/
COPY src/ToDoList.Domain/. ./ToDoList.Domain/
COPY src/ToDoList.Infra/ToDoList.Infra.Data/. ./ToDoList.Infra/ToDoList.Infra.Data/
COPY src/ToDoList.Infra/ToDoList.Infra.IoC/. ./ToDoList.Infra/ToDoList.Infra.IoC/
COPY src/ToDoList.WebApi/. ./ToDoList.WebApi/
RUN dotnet publish ToDoList.WebApi/ -c Release -o out

# Gerar a imagem de runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "ToDoList.WebApi.dll"]