# SistemaCadastroDeHorasApi

Este é um projeto em **C#** que implementa uma API para cadastro de horas utilizando **ASP.NET Core** e **PostgreSQL** como banco de dados.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **PostgreSQL**
- **Docker** e **Docker Compose**

## Estrutura do Projeto

- **Models**: Contém as classes que representam os dados da aplicação.
- **Dockerfile**: Configuração para criar a imagem Docker da aplicação.
- **compose.yaml**: Configuração para orquestrar os serviços da aplicação e do banco de dados.

## Pré-requisitos

Certifique-se de ter instalado:

- **Docker** e **Docker Compose**
- **.NET SDK 9.0**
- **PostgreSQL**

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/Thiagovb62/SistemaCadastroDeHorasApi.git
   cd SistemaCadastroDeHorasApi
2. Excute os containers
   docker-compose up -d --build
3. Rode as migrations
   docker run --rm -it -v ${PWD}:/app -w /app mcr.microsoft.com/dotnet/sdk:9.0 bash -c 'dotnet tool install --global dotnet-ef --version 9.0.5 && export PATH=$PATH:/root/.dotnet/tools && dotnet ef migrations add InitialCreate && dotnet ef database update'