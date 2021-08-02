# Boilerplate .Net Core 3.1

Api em .Net contemplando:

- Arquitetura DDD - Clean
- IoC
- Entity Framework
- AutoMapper
- Swagger
- JWT
- Redis (Lembrete para UI FastoRedis)
- Serilog(Implementação para salvar no banco na tabela logs)
- Unit Of Work (para gerenciar os commits)
- DockerFile com Mysql com configuração para Timezone
  Executar: docker image build -t <nome-imagem> . (para buildar a imagem)
- Docker yml para inicializar os containers do postgre e mysql e redis
  Executar: docker-compose up -d

## Instalar dependências para executar o projeto

Na pasta src

```bash
dotnet restore

...

dotnet build
```

## EF

Alguns comandos para lembrar

```bash
set ASPNETCORE_ENVIRONMENT=Development (para setar as variáveis de ambiente)
dotnet ef migrations add <nome-migration> (Adicionar migrations seguindo MyContext)
dotnet ef database update (usar migration para inicializar a base)
dotnet ef database drop (dropar a base)
```

## Observação

Detalhe ao executar projeto

```bash
- Se executar projeto com o Run and Debug as variaveis de ambiente vão estar setadas no launch.json. Caso rodar com dotnet run, lembrar de setar as variáveis
- Variável de ambiente "MIGRATION" com o valor "APLICAR" sempre executa a migration ao executar o projeto, caso não queria, apenas mudar o valor dessa migration
```

## Swagger

Foi adicionado a documentação com swagger para simplificar e testar o consumo dos endpoints

```python
/index.html
```
