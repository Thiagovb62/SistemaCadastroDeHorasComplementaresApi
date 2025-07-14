# SistemaCadastroDeHorasApi

Este é um projeto em **C#** que implementa uma API para cadastro de horas utilizando **ASP.NET Core** e **PostgreSQL** como banco de dados.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **Entity Framework Core**
- **PostgreSQL**
- **Swagger**
- **Docker** e **Docker Compose**

## Estrutura do Projeto

- **Models**: Contém as classes que representam os dados da aplicação.
- **Dockerfile**: Configuração para criar a imagem Docker da aplicação.
- **compose.yaml**: Configuração para orquestrar os serviços da aplicação e do banco de dados.

## Pré-requisitos

Certifique-se de ter instalado:

- **Docker** e **Docker Compose**
- **.NET SDK 9.0**
- **.RIDER**
- **.VISUAL STUDIO**
- **PostgreSQL**

## Como Executar

1. Clone o repositório:
   ```bash
   git clone https://github.com/Thiagovb62/SistemaCadastroDeHorasApi.git
   cd SistemaCadastroDeHorasApi

2. Crie um arquivo `.env` na raiz do projeto com as seguintes variáveis de ambiente:
   ```env
   POSTGRES_USER=
   POSTGRES_PASSWORD=
   POSTGRES_HOST=
   POSTGRES_DB=
   ```
   Certifique-se de que as credenciais correspondam às usadas no `compose.yaml`.

3. Excute os containers
   docker-compose up -d --build

4. Acesse a API em `http://localhost:5004/index.html`.