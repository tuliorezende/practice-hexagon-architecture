# Practice Hexagon Architecture
Project to do some exercises on Hexagon Architecture.

# Referências de Projetos

- Adapters/Driving/API
  - Core/Application
  - Adapters/Driven/Infra.Database.InMemory
  - Adapters/Driven/Infra.Email

OBS: Projeto da API fazendo referencias a outras camadas para injeções de Dependencia

-----
## Domain

- Core/Domain
  - N/A

OBS: É um projeto "folha" pois é uma parte isolada da aplicação
OBS2: Provê as interfaces (PORTAS)

### Pastas

- `<Domain>\Dtos`: Objetos para trafego entre camadas e uso nas requests
- `<Domain>\Entities`: Implementação das entidades como um todo
- `<Domain>\Ports\In`: Criação das interfaces a serem usadas pela `Application`
- `<Domain>\Ports\Out`: Criação das interfaces a serem usadas por Repositories (Projetos na pasta `Driven`)
- `<Domain>\ValueObjects`: Objetos de valor a serem usados para composição das entidades



-----
## Application

- Core/Application
  - Core/Domain

OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos services/usecases (ADAPTERS)

### Pastas
- `Services`: Implementação "fisica" das interaces do projeto de `Domain`

-----

## Adapters

- Adapters/Driven/Infra.Database.InMemory
  - Core/Domain

OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos repositories (ADAPTERS)

- Adapters/Driven/Infra.Email
  - Core/Domain

OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos recipients (ADAPTERS)

### Pastas
- `Repositories`: Criação de acesso ao banco
- `Operations`: Operações que não precisam de repostas e etc

### Pasta Entities
Caso utilize uma estrutura de banco (EX: Entity Framework) pode-se criar as classes de tabela (replicando o conteúdo da domain)

-----

Fluxo da Aplicação

```
- Controller (API)
  - Application/Service (Manager)
    - Domain Object
    - Driven/Repository
    - Driven/Operation
```

## Relacionamentos
### Como implementar

Usando o conceito de agregados, a classe agregadora é responsável por "operar" as sub classes (independente do armazenamento)

Como exemplo nessa implementação

Student -> Classe agregadora
AcademicalHistory -> Lista de entradas de histórico academico

1. Criar métodos "externos" para operar a lista
2. Usar o repositório do "Agregador" para operar os sub-objetos

### A nivel de banco
[Referencia para criar os relacionamentos](https://www.linkedin.com/pulse/understanding-navigation-properties-entity-framework-youssef-nour-jt8ff)
[Referencia da Microsoft](https://learn.microsoft.com/en-us/ef/core/modeling/relationships)
- 
- Além de ter a propriedade de ID, ter um objeto de navegação e configurar via relacionamentos
- Criar as classes na Camada de Infra (Infra/Entities) para representar o que seriam as tabelas de banco de dados, conforme projeto da POC

## Criação de Setup Local
- [Artigo Base de uso de EF Core](https://medium.com/@ravipatel.it/a-beginners-guide-to-entity-framework-core-ef-core-5cde48fc7f7a)
- Instalação de Container Docker do SQL Server
  - [Artigo 1 - Microsoft](https://learn.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017&tabs=cli&pivots=cs1-bash)
  - [Artigo 2 - Macoratti](https://macoratti.net/19/01/dock_mssql1.htm)

1. Instalar Pacotes nos projetos
- Projeto de SqlServer
  - Microsoft.EntityFrameworkCore
  - Microsoft.EntityFrameworkCore.SqlServer
  - Microsoft.EntityFrameworkCore.Tools
- Projeto de API (Para a publicação)
  - Microsoft.EntityFrameworkCore.Design

2. Criação de Classes de Dados
   3. Replicando o conteúdo do projeto de Domain

3. Criação de Classe de Contexto (AppDBContext)

4. Adicionar Migration

```
dotnet ef migrations add --project src/Adapters/Driven/Infra.Database.SqlServer/Infra.Database.SqlServer.csproj --startup-project src/Adapters/Driven/Infra.Database.SqlServer/Infra.Database.SqlServer.csproj --context Infra.Database.SqlServer.AppDbContext --configuration Debug InitialMigration --output-dir Migrations
```

5. Atualizar o banco

```
dotnet ef database update --project src/Adapters/Driven/Infra.Database.SqlServer/Infra.Database.SqlServer.csproj --startup-project src/Adapters/Driving/PracticeHexagonArchitecture.API/PracticeHexagonArchitecture.API.csproj --context Infra.Database.SqlServer.AppDbContext --configuration Debug 20250419230146_InitialMigration --connection "Data Source=localhost,1433;Database=PocHexagonArchitecture;Integrated Security=false;TrustServerCertificate=true;User ID=sa;Password=Numsey@Password!"
```

## Tratamentos de Exceção
https://medium.com/codenx/exception-handling-in-net-core-web-api-e0c4aad1db06

## Resolução de Dependencia em Tempo de execução
Permitir injetar varias implementações do mesmo tipo e descobrir qual o tipo desejado em tempo de execução

https://www.c-sharpcorner.com/article/net-core-dependency-injection-one-interface-multiple-implementation/

# To-Do
[Testar configurações de construtores](https://learn.microsoft.com/en-us/ef/core/modeling/constructors)