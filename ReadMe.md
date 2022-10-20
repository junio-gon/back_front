
# EXEMPLO DE APLICAÇÃO COM ASP CORE E REACT:

## TECNOLOGIAS UTILIZADAS/:<br/>
Abordagem DDD<br/>
API REST<br/>
ASP Net Core com Entity Framework<br/>
React com Axios<br/>
Node JS<br/>
Yarn<br/>
Typescript (TSX)<br/>
JavaScript com Ajax (JSX)<br/>
Autenticação básica (user e senha)<br/>
Autorização com JWT (user e senha)<br/>
Swagger (com autorização e autenticação)<br/>
Estilização CSS<br/>
Estilização com SASS<br/>
Componentização<br/>
Visual Studio 2019<br/>
Visual Studio Code<br/>

**INSTRUÇÕES:**

1) Este projeto possui dados local (LocalDB) no diretório /prj_teste/LocalDB por favor atulizar o endereço do banco com o prefix da máquina onde será executata, para setar outra base de dados, insira a string de conexão e set a propriedade "Environment" no arquivo appsettings.json (/prj_teste/ASP_Core/RESTAPIDDD/RestDDD.API/appsettings.json)

 --> Para nova base de dados, executar as migrations (no project: Infraestructure\RestDDD.Infraestructure), para evitar erros, remova a propriedade 'AttachDbFilename', do campo "DevConection" no arquivo appsettings.json (/prj_teste/ASP_Core/RESTAPIDDD/RestDDD.API/appsettings.json)

COMANDOS PARA EXECUÇÃO DAS MIGRATIONS:
com o console do gerenciador de pacotes:
>update-database

com outros consoles (git-bash, Power Shell, Shell, CMD entre outros):
>dotnet ef database update

2) Caso a API seja executada em porta diferente, deve-se, alterar o arquivo api.ts (\prj_teste\frontend\src\services\api.ts) com o endereço correto

3) Caso seja necessário, atualize a url do front, para não ser barrado pela política de CORS.

## FRONTEND:
**INFORMAÇÕES:**
* Criação de Páginas:
Deve-se criar um diretório em /src/pages/ refente ao elemento a ser trabalhando na página, e dentro deste diretório as referidas páginas, exemplo, o diretório User contém as páginas CreateUser.tsx e Login.tsx.<br/><br/>

* Estilização:
A estilização com CSS deve ser inserida no diretório /src/styles/components/ para componentes ou /src/styles/pages para páginas, ou para o caso de se utilizar SCSS, a estilização é feita no diretório do próprio componente exemplo /src/componentes/input. *OBS: usei CSS e SCSS no desenvolvimento do exemplo para utilizar ambas as abordagem, na palicação real, usaria o que já foi definido*.<br/><br/>

* Interfaces:
Iserir as interfaces no diretório src/interfaces (poderá ser criado diretórios internos para melhorar a ornganização).<br/><br/>

* src/logs:
Diretório para armezar logs da aplicação (a ser implementado).<br/><br/>

## BACKEND:
**INFORMAÇÕES:**

* API desenvolvido com a arquitetura DDD, onde:<br/><br/>
***DOMAIN***<br/>
=> Domain \ project.Domain \ Entities : (class) entidade<br/>
=> Domain \ project.Domain.Core \ Interfaces \ Repositories : (Interface) IRepository<br/>
=> Domain \ project.Domain.Core \ Interfaces \ Services : (Interface) IService<br/>
=> Domain \ project.Domain.Services : (class) Service<br/>

***INFRAESTRUCTURE***<br/>
=> Infraestructure \ project.Infraestructure \ Data \ SqlContext -> Deve-se Adicionar o Contexto do OBJ<br/>
=> Infraestructure \ project.Infraestructure \ Data \ Repositories : (Class) Repository <br/>
=> Infraestructure \ project.Infraestructure \ CrossCutting \ IOC \ ConfigurationIOC -> Deve-se registrar os Builders<br/>

***APLICATION***<br/>
=> Application \ projetc.Application \ DTOS : (class) DTO <br/>
=> Application \ projetc.Application \ Interfaces \ Mappers : (Interface) IMapper<br/>
=> Application \ projetc.Application \ Interfaces : (Interface) IApplicationService<br/>
=> Application \ projetc.Application \ Mappers : (class) Mapper<br/>
=> Application \ projetc.Application : (class) ApplicationService<br/>

## BANCO DE DADOS:
**INFORMAÇÕES:**

* Para a construção desta aplicação foi utilizado o ORM do Entity Code First, com seu Scafold e migrations.<br/><br/>

* A tabela do Usuário é a do EF.<br/><br/>

* A tabela Contatos possui o seguintes atributos:<br/>
Id int Identity AutoIncrement primary key not null,<br/>
Nome nvarchar(50) not null,<br/>
Nascimento DateTime not null,<br/>
Email varchar(80) nullable,<br/>
DataCadastro DateTime not null,<br/>
DataAlteracao DateTime not null,<br/>
IsActive bit" not null<br/>
