
# iVertion-Palladium

A proposta dessa aplicação é oferecer um ERP completo com módulos que vão desde a administração do sistema e configuração, RH, Financeiro e Fiscal até Linha de Produção, Estoque e E-Commerce.



## Autores

- [@Eduardo Rodrigo Spada](https://www.github.com/eduardorspada)

## Ambiente de desenvolvimento

### Windows

As configurações a seguir devem ser executadas no ambiente de desenvolvimento para executar as aplicações no Windows. Recomenda-se usar distribuições do Windows 10 ou 11.

#### XAMPP
Para rodar localmente, precisamos configurar inicialmente um banco de dados MySql ou MariaDB. Vamos utilizar o Xampp para Windows, ele virá preparado para rodar localmente sem muitas dificuldades no Windows.

Inicialmente realize o download abaixo:

- [Xampp 8.2.12](https://sourceforge.net/projects/xampp/files/XAMPP%20Windows/8.2.12/xampp-windows-x64-8.2.12-0-VS16-installer.exe)

Realize a instalação segundo wizard, apenas clique em next, next!

Após instalar, inicie os serviços Apache e MySql (MariaDB).

Quando os serviços estiverem ativos, clique admin no serviço do MySql, nesse momento o seu navegador padrão deve entrar no PhpMyAdmin.

No PhpMyAdmin crie um novo banco de dados com a nomeclatura *ivertion*, na codificação deixe padrão do PhpMyAdmin.


## iVertion WebApi
O iVertion WebApi é o backend da aplicação, foi desenvolvido com .NET 6, MySql como banco de dados (opcional MariaDB).

O projeto tem toda a estrutura com *Clean Architecture*, usa os padrões do *S.O.L.I.D* como princípios de boas práticas.

A abordagem *Code First* foi utilizada em conjunto com o ORM *Entity Framework*, isso tende a facilitar o deploy, assim como possíveis adaptações a certas necessidades como por exemplo a mudança da tecnologia de banco de dados empregada caso necessário.

A documentação é gerada automaticamente pelo *Swagger*, o que facilita o entendimento dos endpoints.

A proposta da API é servir um ERP robusto com inúmeras opções de módulos, e o objetivo é se tornar uns dos maiores ERPs do mercado na atualidade. 

### .NET

Para o projeto API em ambiente de desenvolvimento, vamos instalar as dependências a seguir:

 - Versão Atual: 6.0.418
 - [Baixe aqui](https://dotnet.microsoft.com/pt-br/download/dotnet/thank-you/sdk-6.0.418-windows-x64-installer)

#### Testando a instalação:

Teste a instalação do .NET com o seguinte comando:

```bash
dotnet --list-sdks
```

Se a versão *6.0.418* estiver na lista, isso significa que a instalação do .NET 6 foi um sucesso.

### Entity Framework Core .NET Command-line Tools 6.0.13

Após a instalação do .NET 6, precisamos instalar a ferramenta do Entity Framework para habilitar as migrações de banco de dados. Para isso execute no terminal o seguinte comando. 

```bash
dotnet tool install --global dotnet-ef --version 6.0.13
```
#### Testando o Entity Framework
Agora vamos testar o Entity Framework.

Em um terminal execute o comando abaixo:

```bash
dotnet ef
```

A saída deve ser algo como isto:

```bash

                     _/\__       
               ---==/    \\      
         ___  ___   |.    \|\    
        | __|| __|  |  )   \\\   
        | _| | _|   \_/ |  //|\\ 
        |___||_|       /   \\\/\\

Entity Framework Core .NET Command-line Tools 6.0.13

Usage: dotnet ef [options] [command]

Options:
  --version        Show version information
  -h|--help        Show help information
  -v|--verbose     Show verbose output.
  --no-color       Don't colorize output.
  --prefix-output  Prefix output with level.

Commands:
  database    Commands to manage the database.
  dbcontext   Commands to manage DbContext types.
  migrations  Commands to manage migrations.

Use "dotnet ef [command] --help" for more information about a command.

```


### Gerando os arquivos de migração com o Entity Framework

Para gerar os arquivos de migração, vamos executar alguns passos no terminal.

Certifique-se de estar na raiz do projeto **API**.

Execute o comando abaixo para gerar uma nova migração:

```bash
dotnet ef  migrations add initial --project iVertion.Infra.Data -s iVertion.WebApi -c ApplicationDbContext --verbose
```

Ao decorrer do desenvolvimento teremos novas migrações, o padrão adotado para o nome será *release-x.x.x*.

O projeto atualiza as migrações sempre no momento da execução, nesse caso não é necessário executar o update, mas para deixar documentado, caso execute, o comando é:

```bash
dotnet ef  database update --project iVertion.Infra.Data -s iVertion.WebApi -c ApplicationDbContext --verbose 
```

### Executando a **API**

Após o ambiente de desenvolvimento do .NET configurado, vamos iniciar o projeto **API**, lembre-se de estar na raiz do projeto API para executar os comandos.

A seguir vamos atualizar os pacotes do projeto, dessa forma garantimos que as dependências sejam instaladas corretamente.

```bash
dotnet restore
```
Agora vamos compilar a aplicação para evitar erros na execução do projeto.

```bash
dotnet build
```
E por fim, vamos executar o projeto, o comando abaixo executa o projeto **API** a partir da camada *iVertion.WebApi*, o argumento *watch* é opcional, é utilizado especialmente para realizar algumas alterações com o projeto em execução, mas não necessário para o consumo da API em si.


```bash
dotnet watch run --project .\iVertion.WebApi\iVertion.WebApi.csproj
```

### Acessando a documentação da **API**.

Quando o projeto estiver executando, acesse a documentação do Swagger no link abaixo:

- [iVertion WebApi - Swagger](http://localhost:5001/swagger/index.html)

A documentação apresentada terá as informações necessárias para o consumo correto da **API** no frontend. Recomendamos o uso do [Postman](https://www.postman.com/) para testes.

Para facilitar os testes, criamos o arquivo [iVertion.postman_collection.json](https://github.com/eduardorspada/iVertion-Palladium/blob/main/API/iVertion.postman_collection.json) que pode ser importado já com algumas coleções devidamente configuradas.

Os testes podem ser executados diretamente no Swagger, mas não será possível salvar os parâmetros.


## iVertion Client

O iVertion Client é o frontend da aplicação, desenvolvido com Angular JS.

A arquitetura utilizada é MVC (Model, View, Controler) que é um padrão do Angular JS, essa camada usa alguns preceitos importantes para uma aplicação segura e ao mesmo tempo eficiente.

### Node JS

Realize o download da versão atual utilizada na aplicação no link a seguir:

- [Node JS - v20.9.0](https://nodejs.org/dist/v20.9.0/node-v20.9.0-x64.msi)

Realize a instalação seguindo os passos do *wizard*. 

#### Realizando testes da instalação


Em um terminal execute o comando a seguir:

```bash
node -v
```

Esse comando deve retornar a versão instalada.

```
v20.9.0
```

Se o retorno for o mesmo que o valor acima, o processo de instalação foi um sucesso.

Verifique o **npm** executando o comando:

```bash
npm -v
```
Se o retorno for algo parecido com o resultado abaixo, o **npm** está ativo para uso também

```
10.1.0
```

### Angular JS

Para instalar a versão atual do Angular JS, abra um terminal e execute o comando abaixo:

```bash
npm install -g @angular/cli@16.2.10
```

** *Não execute o comando acima dentro do projeto.*

#### Testando a instalação

Execute o comando abaixo para verificar se o ambiente está preparado para o desenvolvimento.

```bash
npx ng version
```

O retorno deve ser semelhante a isto:

```result

     _                      _                 ____ _     ___
    / \   _ __   __ _ _   _| | __ _ _ __     / ___| |   |_ _|
   / △ \ | '_ \ / _` | | | | |/ _` | '__|   | |   | |    | |
  / ___ \| | | | (_| | |_| | | (_| | |      | |___| |___ | |
 /_/   \_\_| |_|\__, |\__,_|_|\__,_|_|       \____|_____|___|
                |___/


Angular CLI: 16.2.10
Node: 20.9.0 (Unsupported)
Package Manager: npm 10.1.0
OS: win32 x64

Angular: 16.2.12
... animations, common, compiler, compiler-cli, core, forms
... platform-browser, platform-browser-dynamic, router

Package                         Version
---------------------------------------------------------
@angular-devkit/architect       0.1602.10
@angular-devkit/build-angular   16.2.10
@angular-devkit/core            16.2.10
@angular-devkit/schematics      16.2.10
@angular/cli                    16.2.10
@schematics/angular             16.2.10
rxjs                            7.8.1
typescript                      5.1.6
webpack                         5.89.0
zone.js                         0.13.3

Warning: The current version of Node (20.9.0) is not supported by Angular.
```

### Instalando as dependências do projeto

Agora que o ambiente de desenvolvimento Angular JS está funcionando, vamos instalar as dependências do projeto, para isso, certifique-se de estar na raiz do projeto **Client** e execute o comando abaixo:

```bash
npm install
```

### Executando o projeto **Client**

O projeto **Client** é dependente do projeto **API**, portanto, execute-o primeiro.

Quando o projeto **API** estiver executando conforme a documentação, vamos executar o projeto **Client** executando o comando abaixo na raiz do projeto **Client**.

```bash
npx ng serve
```

Se não houver nenhum erro, após o build, o prjeto deve estar disponível no link abaixo:

- [Projeto **Client**](http://localhost:4200/)



## Contribuindo

Contribuições são sempre bem-vindas!

Por favor, siga o `código de conduta` desse projeto.


### Projeto **Client**

#### Tratamento dos dados

Nesse projeto estamos trabalhando com dois tipos de tratamento de dados, o primeiro é a *concatenação* e o segundo é o *two way data binding*

- ***Concatenação*** - Para concatenar dados estáticos em uma view, user a seguinte sintaxe `{{model.data}}`, onde `model` é o objeto da view e `data` trata-se da propriedade a ser disponibilizada.

Exemplo:

```html
<div class="card-header">
    <div class="row">
        <div class="col-sm-1">
            <h3>Artigo</h3>
        </div>
        <div class="col-sm-5">
            <dl class="row">
                <dt class="col-sm-1">ID:</dt>
                <dl class="col-sm-2"># {{article.id}}</dl>
            </dl>
        </div>
    </div>
</div>
```

- ***Two Way Data Binding*** - Esse é um conceito central no AngularJS, onde as alterações feitas no modelo são refletidas automaticamente na visão e vice-versa, eliminando a necessidade de manipulação manual do DOM. A sintaxe utilizada será `[(ngModel)]="model.data"` onde `model` é o objeto da view e `data` trata-se da propriedade a ser disponibilizada. `ngModel` é uma palavra reservada do *Angular JS*.

Exemplo:

```html
<div class="col-md-6">
    <div class="form-group">
        <label for="title">Título</label>
        <input type="text" name="title" id="title" class="form-control" [(ngModel)]="article.title">
    </div>
</div>
```

** *Note que o **Two Way Data Binding** é utilizado em formulários*.


#### Criando views

O *Angular JS* é modular, isso significa que as views são componentes que podem ou não fazer parte de um módulo criado pelo desenvolvedor, quando não fazem parde de um módulo criado pelo desenvolvedor, quando não, farão parte do `app.module.ts` que é o módulo principal do projeto.

Para criar um módulo usaremos o comando a seguir:

```bash
npx ng g m nome-do-modulo
```

** *Note que em `nome-do-modulo` separamos cada palavra por hifens, esse será o padrão para módulos e componentes*.

Exemplos:

```bash
npx ng g m articles
```
```bash
npx ng g m users-groups
```

Um módulo pode conter rotas, recomendamos especialmente quando tiver muitos componentes. Para criar um módulo com rotas, use o parâmetro `--routing` no final do comando.

Exemplo:
```bash
npx ng g m users --routing
```

Entendendo os comandos acima.

- `npx` - É um utilitário do Node.js que permite executar pacotes Node.js como se fossem aplicativos instalados globalmente. A sigla "npx" significa Node Package eXecute. Ele é útil para executar comandos de pacotes que normalmente não estão instalados globalmente.

- `ng` - Este é o comando principal do Angular CLI. É uma ferramenta de linha de comando para criar, gerenciar, construir e testar aplicações Angular.

- `g` - É a abreviação de "generate" (gerar, em português). Esse comando é usado para gerar novos elementos em uma aplicação Angular, como componentes, serviços, módulos, etc.

- `m` - É a abreviação de "module" (módulo, em português). Módulos são conjuntos de funcionalidades agrupadas, que podem incluir componentes, serviços, diretivas, pipes, e outros módulos.

- `users` - Este é o nome do módulo que será criado. Neste caso, o comando criará um módulo chamado "users".

- `--routing` - Esta opção indica que o Angular CLI deve também criar um arquivo de roteamento específico para o módulo. Normalmente, este arquivo é usado para definir as rotas associadas aos componentes dentro do módulo. A inclusão da opção --routing gera um arquivo adicional de configuração de rotas (como users-routing.module.ts), que facilita a organização das rotas do módulo "users".

Agora vamos conhecer os comandos para criar as views de fato que nesse caso serão nossos componentes, neles teremos o html, as folhas de estilos, estamos usando `SCSS` para esse projeto, um arquivo de testes e o arquivo do componente em si.

Para gerar um componente usaremos o comando a seguir:

```bash
npx ng g c nome-do-componente
```

O padrão para nomenclatura é a mesma apresentada anteriomente,

- `c` - É a abreviação de "component". No Angular, componentes são peças fundamentais que controlam uma parte da tela (uma view) - tudo, desde a lógica de como os dados devem ser processados até a definição dos elementos da interface do usuário.

Exemplo:

```bash
npx ng g c dashboard
```

Para gerar um componente vinculado a um módulo use o seguinte comando:

```bash
npx ng g c nome-do-modulo/nome-do-componente
```

Exemplo:

```bash
npx ng g c users/users-list
```
## Deploy

### Realizando um deploy no Docker
Para compilar as imagens execute o comando

```bash
docker-compose build --force-rm --no-cache 
```
Para subir os contêiners rode o comando

```bash
docker-compose up
```

