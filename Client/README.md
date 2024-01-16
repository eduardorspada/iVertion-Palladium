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


