
## Índice
* [Índice](#%C3%ADndice)
* [Introdução](#iVertion-Palladium)
    * [Autores](#Autores)
    * [Ambiente de desenvolvimento](#Ambiente-de-desenvolvimento)
        * [Xampp](#XAMPP)
        * [iVertion WebApi](#iVertion-WebApi)
# iVertion-Palladium

Simples, Poderoso, iVertion: O ERP da Sua Empresa.

Em um momento de intensa reflexão sobre a missão de revolucionar a gestão empresarial, a equipe fundadora do iVertion se encontrou imersa em um redemoinho de ideias. Buscavam não apenas um nome, mas uma identidade que encapsulasse a essência do que estavam prestes a oferecer ao mundo dos negócios.

A primeira sílaba, o "i", foi escolhida como um elo simbólico com a era digital, representando a interconexão e a inteligência que impulsionaria o software. Era mais do que uma simples referência à internet; era um convite para a integração, a inovação e a inteligência, os pilares essenciais que moldariam cada linha de código.

A segunda parte, "Vertion", foi criada a partir de uma fusão de duas palavras poderosas: "versão" e "inovação". Essa fusão foi um epifânico insight da equipe, simbolizando não apenas a evolução constante do produto, mas também a inversão de paradigmas tradicionais nos processos de gestão. Era uma promessa de transformar a maneira como as empresas operavam, uma versão completamente nova do que o mundo corporativo já conhecia.

Assim, "iVertion" nasceu não apenas como um nome, mas como uma declaração de intenções. Cada letra, cada sílaba, carrega consigo o compromisso de impulsionar as empresas para o futuro, através de uma plataforma que não apenas acompanha, mas antecipa e inspira a mudança.

A proposta dessa aplicação é oferecer um ERP completo com módulos que vão desde a administração do sistema e configuração, RH, Financeiro e Fiscal até Linha de Produção, Estoque e E-Commerce.



## Autores

- [@Eduardo Rodrigo Spada](https://www.github.com/eduardorspada)

- [@Rudymar Renato Spada](https://github.com/rudymarspd?tab=overview&from=2024-01-01&to=2024-01-17)

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

#### Alimentando as views com dados da **API**

Para consumir a nossa **API**, serão necessários a criação de serviços, os quais, segundo a autenticação implementada devem realizar requisições na **API** e retornar os dados em forma de objeto.

Para criar nosso serviço vamos usar o seguinte comando:

```bash
npx ng g s nome-do-servico
```

- `s` - É a abreviação de "service" (serviço, em português). Um serviço é um componente Angular que fornece funcionalidade para outros componentes.

Exemplo:

```bash
npx ng g s users
```

O comando acima gerou na raiz do diretório `src/app/` o arquivo `users.service.ts`

Antes de começar a editar esse arquivo, vamos criar manualmente uma classe no módulo *users* com a nomenclatura `user`. Para isso criaremos um arquivo denominado `user.ts` na raiz do módulo *users*.

```typescript
export class User {
    id: string;
    userName: string;
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    password: string;
    confirmPassword: string;
    isEnabled: boolean;
    profilePicture: string;
    profileCover: string;
    profileDescription: string;
    occupation: string;
    birthday: Date;
    phoneNumber: string;

    constructor (){
        this.id = "";
        this.userName = "";
        this.firstName = "";
        this.lastName = "";
        this.fullName = "";
        this.email = "";
        this.password = "";
        this.confirmPassword = "";
        this.isEnabled = false;
        this.profilePicture = "";
        this.profileCover = "";
        this.profileDescription = "";
        this.occupation = "";
        this.birthday = new Date();
        this.phoneNumber = "";
    }
}
```

Os atributos da classe são os mesmos da documentação da **API**, é importante respeitar o nome e o tipo de cada propriedade.

Criamos a classe `user` porque o *TypeScript* é tipado, diferente do *JavaScript*, nossos métodos devem retornar somente os objetos que esperamos.

Agora vamos editar o nosso serviço. Inicialmente iremos atualizar os imports, essa etapa acontece automaticamente enquanto vamos codificando, mas para fins didáticos, vamos explicar os imports no momento.

```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';
```

Para ter acesso aos endpoints da **API**, vamos usar a biblioteca `HttpClient`, com ela, nosso código será capaz de executar os métodos `http`.

A biblioteca `Injectable` é padrão do serviço, já deve vir importado, mas em resumo, permite a injeção do serviço.

Para poder acessar as variáveis de ambiente, temos o `environment` como o nome já diz, ele vai permitir configurar tanto em ambiente de desenvolvimento como em produção.

O nosso objeto que criamos a pouco `User` servirá para tipificar nossos retornos dos métodos.

E para que possamos operar de forma assícrona, temos o `Observable` que deve esperar o retorno da requisição sem bloquear o aplicativo.

Agora vamos ver como ficou o nosso `users.service.ts`.


```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {

  constructor() {
  }

}
```
Agora vamos recuperar o valor da url da **API** das configurações de `environment`, da forma que está configurado no diretório `src/environments`, nosso código será capaz de identificar tanto no ambiente de desenvovimento como em produção qual é o url correto.

```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = environment.apiUrl;
  constructor() {
  }

}
```

Perfeito, agora precisamos configurar o `HttpClient` no contrutor para que os métodos possam ser acessados por nosso serviço.

```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

}
```

Agora com esses detalhes configurados, podemos criar nosso primeiro método. Lembra que a pouco criamos um componente chamado `users-list`? Que tal popularmos essa view primeiro?

Vamos criar o método `getUsers()` que irá retornar um *Array* de `User`.

```typescript
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment.development';
import { User } from './users/user';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  apiUrl: string = environment.apiUrl;
  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(`${this.apiUrl}/User`, 
      {
        headers: {
        'Content-Type': 'application/json'
      },
    })
  }

}
```
Ótimo, agora que temos nosso método `getUsers()`, vamos para nosso componente implementar nosso serviço. Inicialmente, o ideal é configurar nossa rota para ir testando a visualização da listagem.

Abra o arquivo `users-routing.module.ts` e vamos fazer algumas alterações nele.

```typescript
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
```

Como falamos anteriormente, os imports vão atualizando conforme incluímos nossos objetos no código, então vamos pular essa parte e vamos editar diretamente a constante `routes`.

Nosso projeto usa um template do [AdminLTE 3](https://adminlte.io/docs/3.2/), já configuramos a base do template no componente `manager`, além disso, como esses dados que vamos resgatar necessitam da autenticação, vamos usar nosso `authGuard` com a diretiva `canActivate` para inibir o acesso as rotas de pessoas não autorizadas.

```typescript
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerComponent } from '../manager/manager.component';
import { authGuard } from '../auth.guard';

const routes: Routes = [
    {path: 'manager/users', component: ManagerComponent, canActivate: [authGuard]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
```
Agora se acessarmos a rota `http://localhost:4200/manager/users` será possível enxergar a base do template, precisamos configurar uma rota filha para ver a listagem dos usuários, para isso vamos adicionar a diretiva `children`.

```typescript
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ManagerComponent } from '../manager/manager.component';
import { authGuard } from '../auth.guard';
import { UsersListComponent } from './users-list/users-list.component';
import { UserComponent } from './user/user.component';

const routes: Routes = [
    {path: 'manager/users', component: ManagerComponent, canActivate: [authGuard], children: [
    {path: 'list', component: UsersListComponent},
    {path: 'user/:id', component: UserComponent}
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsersRoutingModule { }
```

Aproveitamos a deixa e adicionamos uma rota extra que retorna uma view de usuário pelo seu `id`. Não é nosso foco, mas consulte o código para entender seu comportamento depois de trabalhar nessa listagem, no serviço também ciramos os métodos `getUsersById(id: string)` e `getRolesByUserName(userName: string)`, vale muito a pena conferir depois.

Primeiramente vamos identificar qual role está relacionada ao nosso endpoint no projeto **API**. Navegue até ele, na camada *iVertion.WebApi*, no diretório `Controllers` e abra o arquivo `UserController.cs`, encontre o método que retorna os usuários e verifique a configuração de `[Authorize]`.

```csharp
/// <summary>
/// Returns a list of users.
/// </summary>
/// <returns></returns>
[HttpGet]
[Authorize(Roles = "GetUsers")]
public async Task<ActionResult> Get()
{
    var users = await _userService.GetUsersAsync();
    return Ok(users);
}
```
A role do método é `GetUsers` Abra o `users-list.component.ts`, vamos começar implementando a segurança da view. Vamos precisar das seguites bibliotecas, `OnInit`, `Router` e `AuthService`.

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {

  constructor(){}
  ngOnInit(): void {}

}
```
Inicialmente configuramos a classe `UsersListComponent` para implementar `OnInit`, com isso podemos usar o método `ngOnInit()`, nele colocaremos a lógica caso o usuário logado não tenha a permissão para receber os dados do endpoint. Agora vamos criar as váriáveis `roles` que receberá as roles do usuário logado e `role` que receberá `GetUsers`.
```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';

  constructor(){}
  ngOnInit(): void {}
  }

}
```
Por meio de `AuthService` vamos atribuir um *Array* de roles contidos no token do usuário autenticado. Isso será feito no `constructor` em duas etapas, a primeira será instanciando `AuthService` na variável privada `authService`, a segunda será atribuindo o valor do método `getRoles()` à variável `roles`.

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';

  constructor(private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {}

}
```
Agora vamos verificar se o usuário autenticado possui a permissão de `role` em `roles`. 

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';

  constructor(private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
        // Ação caso não houver permissão para o usuário logado.
    }
  }

}
```
Vamos configurar uma ação caso o usuário logado não tenha permissão de acesso. A resposta de proibição de acesso é `Forbidden - 403`, nosso projeto já tem uma rota para isso, então usaremos o `Router` para redirecionar o usuário a uma página 403. Intancie-o no `constructor` e configure a ação na linha comentada utilizando o método `navigate`.

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';

  constructor(private router: Router, private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }
  }

}
```

Apesar da rota estar protegida, sem um token válido ou usuário não ter permissão nesse endpoint, é impossível retornar os dados, mas isso gera erros que deixam o console cheio de alertas, além de deixarem a aplicação com *bugs*. Por isso é necessário verificar se o endpoint a ser consumído precisa de autenticação e se sim, configurar os passos acima.

Agora que nossa rota está segura, vamos ao que interessa, a lista de usuários! Vamos começar atualizando os imports com `UsersService`e `Users`.

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersService } from 'src/app/users.service';
import { User } from '../user';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';

  constructor(private router: Router, private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }
  }

}
```
Vamos criar uma variável chamada `users` do tipo *Array* de `User` (`User[]`).

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersService } from 'src/app/users.service';
import { User } from '../user';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';
  users: User[] = [];

  constructor(private router: Router, private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }
  }

}
```

Para atribuir a lista de usuários à `users`, instancie `UsersService` no `constructor` e no método `ngOnInit()` implemente `getUsers()` como mostrado abaixo.

```typescript
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth.service';
import { UsersService } from 'src/app/users.service';
import { User } from '../user';

@Component({
  selector: 'app-users-list',
  templateUrl: './users-list.component.html',
  styleUrls: ['./users-list.component.scss']
})
export class UsersListComponent implements OnInit {
  roles: Array<string>;
  role: string = 'GetUsers';
  users: User[] = [];

  constructor(private router: Router, private service: UsersService, private authService: AuthService){
    this.roles = authService.getRoles();
  }
  ngOnInit(): void {
    if (this.roles.indexOf(this.role) === -1) {
      this.router.navigate(['manager/403'])
    }

    this.service.getUsers()
      .subscribe(resposta => this.users = resposta)
  }

}
```

Com isso já temos dados para colocar no html, abra o arquivo `users-list.component.html` e implemente o código abaixo:

```html
<div class="content-header">
    <div class="container-fluid">
      <div class="row mb-2">
        <div class="col-sm-6">
          <h1 class="m-0">Users</h1>
        </div><!-- /.col -->
        <div class="col-sm-6">
          <ol class="breadcrumb float-sm-right">
            <li class="breadcrumb-item"><a href="#">Home</a></li>
            <li class="breadcrumb-item"><a href="#">Users</a></li>
            <li class="breadcrumb-item active">Users</li>
          </ol>
        </div><!-- /.col -->
      </div><!-- /.row -->
    </div><!-- /.container-fluid -->
  </div>
  <!-- /.content-header -->

  <section class="content">
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                <div class="card bg-dark">

                    <div class="card-header">
                        <h3>Users</h3>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table">
                                <thead>
                                    <tr>
                                        <th scope="col">User Name</th>
                                        <th scope="col">Full Name</th>
                                        <th scope="col">E-mail</th>
                                        <th scope="col">Phone Number</th>
                                        <th scope="col">Active</th>
                                        <th scope="col">Actions</th>
                                    </tr>
                                </thead>
                                <tbody *ngFor="let user of users">
                                    <tr>
                                        <td>{{user.userName}}</td>
                                        <td>{{user.fullName}}</td>
                                        <td>{{user.email}}</td>
                                        <td>{{user.phoneNumber}}</td>
                                        <td *ngIf="user.isEnabled"><i class="fa-solid fa-square-check text-success"></i></td>
                                        <td *ngIf="user.isEnabled === false"><i class="fa-solid fa-square-xmark text-danger"></i></td>
                                        <td><button class="btn btn-info" routerLink="/manager/users/user/{{user.id}}">View User</button></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
  </section>
```

Perceba como implementamos o `*ngFor` na linha *41* para replicar as linhas da nossa tabela, também utilizamos a **concatenação** para acessar os dados de `user`. e nas linhas *47* e *48* usamos o `*ngIf` para condicionar a impressão da informação. Com isso já é possível entender um pouco do funcionamento do projeto **Client** e como podemos contribuir com seu desenvolvimento.
## Deploy

#### Realizando um build com Docker
Para compilar as imagens execute o comando

```bash
docker-compose build --force-rm --no-cache 
```
Para subir os contêiners rode o comando

```bash
docker-compose up
```

