# Template do Visual Studio para otimizar o desenvolvimento de RestData

Este template gera uma solution com os projetos para criar uma WebApi de RestData. <br />
O template já inclui um docker compose com MongoDB e MongoExpress<br />
Já possui testes unitários de todos os Use Cases.

## Instalando o template
Para que o template fique disponivel no visual studio. execute o comando no seu terminal:

```dotnet new install Qbem.RestData.WebApi --nuget-source Github```

## Usando o template
Crie um novo projeto no visual studio.<br />
Selecione o template "Qbem RestData WebApi"<br />
No campo "Project name" insira o nome da **entidade de negócio**, no **singular** e usando padrão **Camelcase**.

![image](https://github.com/user-attachments/assets/77271811-3cf0-4e18-afb5-b713de440890)
![image](https://github.com/user-attachments/assets/6e2b9667-7233-4f25-bfdf-3f54a7ee9325)
![image](https://github.com/user-attachments/assets/c2dc62ee-c5af-4e3a-bfaf-d0b4ba3da1b2)


## Ajustes após a criação da solution
Ajuste o nome da solution<br />
Confira se o nome da controller está no padrão esperado (plural), no projeto WebApi/Controllers<br />
Na pasta develop, no docker-compose confira o nome do banco de dados (DATABASE_NAME) e o nome da collection (COLLECTION_NAME)<br />
No projeto Domain, na pasta Entities crie as propriedades da sua entidade de negócio. Adote o padrão DataAnnotations para decorar as regras necessárias.<br />

![image](https://github.com/user-attachments/assets/cffeb840-668f-4b0e-bb93-b0c84107cdeb)
![image](https://github.com/user-attachments/assets/1307a5fb-c9ec-4ff3-ad4d-69b7552c5a53)
![image](https://github.com/user-attachments/assets/8618f3c0-d01b-4d8c-bfd3-e768232efed6)

<br />
<br />
