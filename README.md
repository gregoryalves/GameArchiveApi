# GameArchiveApi
API para cadastro de catálogo de games.

Esta API oferece um cadastro dos seguintes itens:

- Plataformas - Consoles ou plataformas como PC
- Desenvolvedoras - EA, Naughty Dog etc
- Gêneros - Ação, aventura, etc
- Jogos
- Usuários
- Jogos por usuário e também plataformas por usuário, para que o usuário possa administrar sua coleção de jogos e consoles.

## 🚀 Melhorias Implementadas

### Segurança
- ✅ **BCrypt para hash de senhas**: Substituído MD5 (inseguro) por BCrypt para criptografia de senhas
- ✅ **Configuração segura**: Credenciais movidas para `appsettings.Development.json` (não versionado)
- ✅ **CORS configurado**: Política de CORS implementada para controle de acesso

### Arquitetura
- ✅ **Injeção de Dependência**: Business classes agora utilizam DI ao invés de instanciação direta
- ✅ **Validações nos Models**: Data Annotations adicionadas para validação de dados
- ✅ **Códigos HTTP corretos**: Controllers retornam códigos de status apropriados (200, 201, 400, 404, 401)
- ✅ **Tratamento de erros**: Try-catch implementado em todos os endpoints
- ✅ **Login seguro**: Método de login alterado de GET para POST

### Boas Práticas
- ✅ **ModelState validação**: Validação automática de dados de entrada
- ✅ **Mensagens de erro padronizadas**: Respostas de erro consistentes
- ✅ **CreatedAtAction**: POST retorna 201 com localização do recurso criado

## ⚙️ Configuração

### Pré-requisitos
- .NET 7.0 ou superior
- SQL Server
- Visual Studio 2022 ou VS Code

### Instalação

1. Clone o repositório
2. Configure a connection string em `appsettings.Development.json`:
```json
{
  "ConnectionStrings": {
    "DataBase": "Server=SEU_SERVIDOR;Database=Game_Archive_DB;User Id=SEU_USUARIO;Password=SUA_SENHA"
  }
}
```

3. Execute as migrations:
```bash
dotnet ef database update
```

4. Execute o projeto:
```bash
dotnet run
```

A API estará disponível em `https://localhost:7xxx` e o Swagger em `https://localhost:7xxx/swagger`

## 📝 Endpoints Principais

- **POST** `/api/Usuario/Logar` - Autenticação de usuário
- **GET** `/api/Usuario/BuscarTodos` - Lista todos os usuários
- **POST** `/api/Usuario/Cadastrar` - Cadastra novo usuário
- **GET** `/api/Jogo/BuscarTodos` - Lista todos os jogos
- **POST** `/api/Jogo/Cadastrar` - Cadastra novo jogo

## 🔒 Segurança

⚠️ **IMPORTANTE**: Nunca versione o arquivo `appsettings.Development.json` que contém credenciais sensíveis. Este arquivo já está no `.gitignore`.
