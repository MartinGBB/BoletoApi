# Cadastro de Boleto e Banco

## Descrição

Esta API foi desenvolvida para gerenciar o cadastro de **Boletos** e **Bancos**. O objetivo é permitir a criação, consulta e gerenciamento desses dados, além de calcular juros para boletos vencidos com base no banco associado.

## Tecnologias Utilizadas

- **.NET 6** (C#)
- **Entity Framework** para ORM
- **PostgreSQL** como banco de dados
- **Swagger** para documentação da API
- **AutoMapper** para mapeamento de DTOs

## Endpoints

### Banco

#### 1. **Listar Todos os Bancos** - `GET /api/banco`

Recupera a lista de todos os bancos cadastrados.

**Resposta de Sucesso:**

```json
[
  {
    "id": 1,
    "nome": "Banco do Brasil",
    "codigo": "001",
    "percentualJuros": 5
  },
  {
    "id": 2,
    "nome": "Caixa Econômica",
    "codigo": "104",
    "percentualJuros": 4.5
  }
]
```

#### 2. Buscar Banco por Código - GET `/api/banco/{codigo}`

**Recupera os dados de um banco específico a partir do seu código.**

Parâmetros de Entrada:

- codigo: O código do banco a ser pesquisado.

**Resposta de Sucesso:**

```json
{
  "id": 1,
  "nome": "Banco do Brasil",
  "codigo": "001",
  "percentualJuros": 5
}
```

**Resposta de Erro:**

```json
{
  "message": "Banco não encontrado.",
  "erro": 404
}
```

#### 3. Criar um Novo Banco - POST `/api/banco`

Cria um novo banco com os dados fornecidos.

### Corpo da Requisição:

```json
{
  "nome": "Itaú",
  "codigo": "341",
  "percentualJuros": 5
}
```

**Resposta de Sucesso:**

```json
{
  "message": "Banco criado com o ID: 3",
  "status": 201
}
```

**Resposta de Erro (exemplo de banco já existente):**

```json
{
  "message": "Já existe um banco com este código.",
  "erro": 409
}
```

### Boleto

#### 1. Buscar Boleto por ID - `GET /api/boleto/{id}`

**Recupera os dados de um boleto específico a partir do seu ID.**
Parâmetros de Entrada:

- id: O ID do boleto a ser pesquisado.

**Resposta de Sucesso:**

```json
{
  "id": 1,
  "nomePagador": "José Silva",
  "cpfCnpjPagador": "12345678900",
  "nomeBeneficiario": "Empresa XYZ",
  "cpfCnpjBeneficiario": "98765432100",
  "valor": 100.0,
  "dataVencimento": "2025-05-01T00:00:00",
  "observacao": "Pagamento referente à fatura de abril.",
  "bancoId": 1
}
```

**Resposta de Erro:**

```json
{
  "message": "Boleto não encontrado.",
  "erro": 404
}
```

#### 2. Criar um Novo Boleto - `POST /api/boleto`

**Cria um novo boleto com os dados fornecidos..**

### Corpo da Requisição:

```json
{
  "nomePagador": "José Silva",
  "cpfCnpjPagador": "12345678900",
  "nomeBeneficiario": "Empresa XYZ",
  "cpfCnpjBeneficiario": "98765432100",
  "valor": 100.0,
  "dataVencimento": "2025-05-01T00:00:00",
  "observacao": "Pagamento referente à fatura de abril.",
  "bancoId": 1
}
```

**Resposta de Sucesso:**

```json
{
  "message": "Boleto criado com o ID: 1",
  "status": 201
}
```

**Resposta de Erro (Caso o banco não exista):**

```json
{
  "message": "Banco não encontrado",
  "erro": 404
}
```

> Também são validados campos obrigatorios.

### Funcionalidades Adicionais

#### Cálculo de Juros

Quando um boleto é consultado e a data de vencimento já passou, o valor do boleto é automaticamente ajustado, incluindo juros com base no percentual configurado para o banco associado.

- Valor original do boleto: R$100,00
- Percentual de juros do banco: 5%
- Novo valor do boleto: R$105,00 (após a data de vencimento)

### Como Executar o Projeto

#### 1. Clone o repositório:

**HTTPS**:

```zsh
    git clone https://github.com/MartinGBB/BoletoApi.git
```

Ou **SSH** (se você tiver configurado chaves SSH no GitHub):

```zsh
    git clone git@github.com:MartinGBB/BoletoApi.git
```

#### 2. Instale as dependências: Certifique-se de ter o .NET 6 SDK instalado e execute o comando abaixo:

```zsh
    dotnet restore
```

#### 3. Configure o banco de dados:

Este projeto utiliza uma conexão com o banco de dados PostgreSQL, configurada através de uma variável de ambiente chamada `DATABASE_CONNECTION_STRING`. Para facilitar a configuração, o arquivo `.env` já foi incluído no repositório.

**Atenção**: Embora eu saiba que não é uma boa prática subir arquivos de configuração contendo informações sensíveis (como senhas e credenciais de banco) em repositórios públicos, fiz isso por questão de praticidade, já que este é um projeto de teste de habilidades.

#### 4. Execute o projeto:

```zsh
    dotnet run
```

#### 5. Acesse a API via [Swegger](https://localhost:7271/swagger/index.html) para visualizar a documentação interativa e testar os endpoints.

### Testando a API com Insomnia/Postman

Você pode testar a API usando o arquivo de exemplos de requisição [BoletoApi-Request-Sample.json](./Resources/BoletoApi-Request-Sample). Basta importar esse arquivo para o **Insomnia** ou **Postman** para carregar as requisições e testar os endpoints da API.

### Considerações Finais

Este projeto foi desenvolvido com o objetivo de mostrar o domínio das principais tecnologias como .NET 6, Entity Framework, PostgreSQL e Swagger. A API permite gerenciar os cadastros de Boletos e Bancos, com funcionalidades básicas de criação e busca de registros, além de calcular juros para boletos vencidos.
