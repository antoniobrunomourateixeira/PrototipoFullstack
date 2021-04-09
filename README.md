# Prototipo Fullstack (Angular, .NET Core)

Projeto de e-commerce, para inclusão de itens no carrinho atendendo aos criterios da promoção que o produto esta associado.


***Prototype => API BACKEND***

**Ultidade da aplicação**

Aplicação para inclusão de produtos ao carrinho.  

1- Cadastro de Promoções
 - Cadastro/Edição/Exclusão
 - No cadastro/edição existem 3 campo (Leve, Pague e Valor), onde o fluxo ficará da sequinte forma. Ex: Promoção leve 3 e pague 1 (Campos Leve = 3, Pague = 1, Valor = 0), se a promoção for, Leve 5 e pague R$ 10,00 (Campos Leve = 5, Pague = 0, Valor = 10)

2- Cadastro de Produtos
 - Cadastro/Edição/Exclusão
 - No cadastro/edição é informado nome, valor e se tem promoção, se tiver é habilitado um combo para informar qual promoção ficará vinculada ao produto.

3- Venda
 - Tela com listagem dos produtos e com o campo para informar a quantidade que deseja adicionar ao carrinho
 - Se o produto já estiver adicionado ao carrinho e você tentar incluir novamente, será feito apenas a inclusão da nova quantidade informada. Ex: Teclado já tem 3 no carrinho e você posteriormente informa mais 5, total irá ficar 8


**Tecnologias e  Padrões**

  1- Aplicação: em .NET CORE 3.1 
  
  2- Documentação de endpoints da API com swagger (http://localhost:5001/swagger/index.html)
  
  3- Padõres: Sevice Pattern, Repository Pattern, Command Pattern.
  
  4- ORM: Entity Framework 3.1.10. 
  
  5- Banco de Dados: PostgresSQL 


**Como executar**

1-Acessar a aplicação para geração do banco de dados via migrations:
  No **Console do Gernciador de Pacotes** escolher o projeto padrão **3-Infrastructure\Prototype.Infra.Data**
  Executar o comando: **Update-Database** para que o banco de dados da aplicação seja criado baseado nas migrations. 
  
**Deploy**
Para deploy windows: 

1-Instalar runtime. 
  https://download.visualstudio.microsoft.com/download/pr/c1ea0601-abe4-4c6d-96ed-131764bf5129/a1823d8ff605c30af412776e2e617a36/aspnetcore-runtime-3.1.10-win-x64.exe

2-Baixar e instalar o hosting
  https://download.visualstudio.microsoft.com/download/pr/7e35ac45-bb15-450a-946c-fe6ea287f854/a37cfb0987e21097c7969dda482cebd3/dotnet-hosting-3.1.10-win.exe

3-Acessar a aplicação para geração do banco de dados via migrations:
  No **Console do Gernciador de Pacotes** escolher o projeto padrão **3-Infrastructure\Prototype.Infra.Data**
  Executar o comando: **Update-Database** para que o banco de dados da aplicação seja criado.
  
4-No projeto Prototype.API, clicar com botão direito para geração dos aquivos de deploy.



#############################################################################################################

***FRONT => ANGULAR FRONTEND***

***EXECUÇÃO DA APLICAÇÃO ***

-Para execução plena das funções da aplicação se faz necessário o uso do ***backend*** e ***banco de sql server***.

-Para execução (via Visual Studio Code) se faz necessária a utilização de **Node**.

  1 - Após clonar o fonte, acessar pasta do projeto via terminal e executar o comando **npm install**.
  2 - Apontar o caminho da API na classe **src\shared\Utils.ts** no método **hostApi()**
  3 - Após todos os módulos instalados via node, rodar o comando **ng serve**.

-Para deploy da aplicação via IIS:

  1 - Após clonar o fonte, acessar pasta do projeto via terminal e executar o comando **npm install**.
  2 - Apontar o caminho da API na classe **src\shared\Utils.ts** no método **hostApi()**
  3 - Após todos os módulos instalados via node, rodar o comando **ng build --prod**. Dentro da pasta da aplicação será criada 
      uma subpasta com o nome **dist** seu conteúdo é o necessário para o deploy da aplicação.
      
**IMAGENS**
![Screenshot-1](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/1%20-%20Tela%20Cadastro%20Promoçao.jpg)
![Screenshot-2](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/2%20-%20Listagem%20das%20promoções.jpg)
![Screenshot-3](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/3%20-%20Edição%20Promoção.jpg)
![Screenshot-4](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/4%20-%20Cadastro%20de%20Produto.jpg)
![Screenshot-5](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/5%20-%20Listagem%20dos%20produtos.jpg)
![Screenshot-6](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/6%20-%20Tela%20de%20venda.jpg)
![Screenshot-7](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/7%20-%20Visualizar%20itens%20do%20Carrinho.jpg)
![Screenshot-8](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/8%20-%20Editar%20item%20do%20carrinho.jpg)
![Screenshot-9](https://github.com/antoniobrunomourateixeira/PrototipoFullstack/blob/main/FRONT/9%20-%20Lista%20carrinho%20apos%20atualizar.jpg)
