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
- `Entities`: Implementação das entidades como um todo
- `Services`: Criação das interfaces a serem usadas pela `Application`
- `Adapters`: Criação das interfaces a serem usadas por Repositories (Projetos na pasta `Driven`)

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


-----

Fluxo da Aplicação

```
- Controller (API)
  - Application/Service (Manager)
    - Domain Object
    - Driven/Repository
    - Driven/Operation
```