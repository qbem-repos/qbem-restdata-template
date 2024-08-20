# Template do Visual Studio para otimizar o desenvolvimento de RestData

Este template gera uma solution com os projetos para criar uma WebApi de RestData. <br />
O template já inclui um docker compose com MongoDB e MongoExpress<br />
Já possui testes unitários de todos os Use Cases.

## Instalando o template
Para que o template fique disponivel no visual studio, baixe o arquivo .zip da pasta <b>/published</b> deste repo.<br />
Mova o arquivo .zip no diretório do modelo de projeto do usuário. <br />
Por padrão, esse diretório é %USERPROFILE%\Documents\Visual Studio <versão>\Templates\ProjectTemplates.

## Usando o template
Crie um novo projeto no visual studio.<br />
Selecione o template "Qbem RestData"<br />
No campo "Project name" insira o nome da **entidade de negócio**, no **singular** e usando padrão **Camelcase**.

## Ajustes após a criação da solution
Ajuste o nome da solution<br />
Confira se o nome da controller está no padrão esperado (plural), no projeto WebApi/Controllers<br />
Na pasta develop, no docker-compose confira o nome do banco de dados (DATABASE_NAME) e o nome da collection (COLLECTION_NAME)<br />
No projeto Domain, na pasta Entities crie as propriedades da sua entidade de negócio. Adote o padrão DataAnnotations para decorar as regras necessárias.<br />

<br />
<br />
