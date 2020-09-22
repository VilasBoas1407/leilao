# Desafio Fullstack
 Desenvolver um CRUD para um serviço de leilão online.


### Instalação
 - Executar o script que está na pasta database/DB_LEILAO.sql
 - Clonar o repositório
 - Instalar os pacotes com o npm 
 - Iniciar o frontend
```sh
$ cd git clone https://github.com/VilasBoas1407/leilao.git
$ cd leilao
$ cd frontend 
$ npm install 
$ ng serve --port 333 -o
```

### Sobre a API
 - Foi desenvolvida em C# com .Net Framework e utilizando o Entity framework para realizar as consultas no banco de dados.
 - Após clonar o projeto e executar ele irá rodar em https://localhost:44344/.
 
### Rotas
 [Post] - /api/user  : Cadastro de usúario <br>
 [Get] - /api/user : Login de usuário  <br>
 
[Post] - /api/leilao : Cadastro de leilão  <br>
[Get] - /api/leilao/GetAll : Lista todos os leilões  <br>
[Get] - /api/leilao/GetById : Buscar leilão por id  <br>
[Put] - /api/leilao : Atualizar leilão  <br>
[Delete] - /api/leilao : Deletar leilão  <br>

### Sobre o FrontEnd
Desenvolvido em Angular9 e utilizando a biblioteca de css MaterialUI.
