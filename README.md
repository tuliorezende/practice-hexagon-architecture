# Practice Hexagon Architecture
Project to do some exercises on Hexagon Architecture.



# Referências de Projetos

- Adapters/Driving/API
  - Core/Application
  - Adapters/Driven/Infra.Database.InMemory
  - Adapters/Driven/Infra.Email

OBS: Projeto da API fazendo referencias a outras camadas para injeções de Dependencia

|=====================================================================================|

- Core/Domain
  - N/A

OBS: É um projeto "folha" pois é uma parte isolada da aplicação
OBS2: Provê as interfaces (PORTAS)

|=====================================================================================|

- Core/Application
  - Core/Domain

OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos services/usecases (ADAPTERS)

|=====================================================================================|

- Adapters/Driven/Infra.Database.InMemory
  - Core/Domain


OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos repositories (ADAPTERS)

|=====================================================================================|

- Adapters/Driven/Infra.Email
  - Core/Domain

OBS: Referencia para ter acesso as interfaces (PORTAS) para criação dos recipients (ADAPTERS)

=====================================================================================