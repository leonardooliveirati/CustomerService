# CustomerService API

Este repositório contém o código-fonte de uma API para gerenciamento de clientes, construída com ASP.NET Core.

## Funcionalidades

- **Criar cliente**: Adicionar um novo cliente.
- **Buscar clientes**: Lista todos os clientes cadastrados.
- **Buscar cliente por ID**: Detalhes de um cliente específico.
- **Atualizar cliente**: Atualizar informações de um cliente existente.
- **Excluir cliente**: Remover um cliente existente.

## Estrutura do Projeto

- **CustomerService.API**: Contém os controladores da API.
- **CustomerService.Domain**: Define entidades de domínio e interfaces de serviços.
- **CustomerService.Service**: Implementações concretas dos serviços e validadores.
- **CustomerService.Infrastructure:** Este projeto contém implementações de infraestrutura, como repositórios de dados e serviços de acesso a dados.

## Requisitos

- SDK do .NET Core instalado.

## Como Usar

1. Clone este repositório.
2. Execute `dotnet run` na pasta raiz.
3. Acesse a API em `http://localhost:7071/api/CustomerService`.

4
## Documentação da API

A documentação da API está disponível em `https://localhost:7071/swagger/index.html`, onde você pode encontrar informações sobre os endpoints disponíveis e como usá-los.

## Endpoints

- **POST /api/CustomerService**: Criar cliente.
- **GET /api/CustomerService**: Listar clientes.
- **GET /api/CustomerService/{id}**: Detalhes de cliente.
- **PUT /api/CustomerService**: Atualizar cliente.
- **DELETE /api/CustomerService/{id}**: Excluir cliente.

## Testes

- Testes de unidade usando xUnit na pasta `CustomerService.Tests`.

## Contribuição

Contribuições são bem-vindas! Abra uma issue ou envie um pull request.

## Licença

Licenciado sob a [Licença MIT](LICENSE).
