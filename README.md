# Desafio Fullstack
 Desenvolver um CRUD para um serviço de leilão online.


### Instalação
 - Executar o script que está na pasta database/DB_LEILAO.sql
 - Clonar o repositório
```sh
$ cd git clone https://github.com/VilasBoas1407/leilao.git
$ cd leilao
```

### Sobre a API
 - Foi desenvolvida em C# com .Net Framework e utilizando o Entity framework para realizar as consultas no banco de dados.
 - Após clonar o projeto e executar ele irá rodar em https://localhost:44344/.
 - Após realizar o login você recebera um token de autenticação, que deverá ser passado no body das requisições como tokenAuth.
### Rotas
 [Post] - /api/user  : Cadastro de usúario
 [Get] - /api/user : Login de usuário
 
[Post] - /api/leilao : Cadastro de leilão
[Get] - /api/leilao/GetAll : Lista todos os leilões
[Get] - /api/leilao/GetById : Buscar leilão por id
[Put] - /api/leilao : Atualizar leilão
[Delete] - /api/leilao : Deletar leilão

### Sobre o FrontEnd
Desenvolvido em Angular9 e utilizando a biblioteca de css MaterialUI.
