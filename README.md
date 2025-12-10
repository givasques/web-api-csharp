# Filmes API

Uma Web API construída em C# (.NET) para gerenciamento de filmes, utilizando Entity Framework Core, AutoMapper e seguindo boas práticas de desenvolvimento REST.

## Tecnologias Utilizadas

- .NET 6 / ASP.NET Core Web API

- Entity Framework Core

- AutoMapper

- NewtonsoftJson

- MySQL

- Swagger

## Endpoints Disponíveis
### Criar Filme

```POST /Filme```

Request (JSON):
```
{
  "titulo": "Interestelar",
  "genero": "Ficção Científica",
  "duracao": 169
}
```

Response:

- 201 Created

- Corpo contendo o filme criado

### Listar Filmes

```GET /Filme?skip=0&take=50```

- Retorna uma lista paginada de filmes.

Buscar Filme por ID

```GET /Filme/{id}```

Response:

- 200 Ok

- 404 Not Found, se não existir

### Atualizar Filme (PUT)

```PUT /Filme/{id}```

Substitui todos os campos do filme.

### Atualizar parcialmente (PATCH)

```PATCH /Filme/{id}```

Exemplo de JSON Patch:
```
[
  { "op": "replace", "path": "/titulo", "value": "Filme Atualizado" }
]
```
### Deletar Filme

```DELETE /Filme/{id}```

Response:

- 204 NoContent

- 404 NotFound
