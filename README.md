<h1 align="left">System API </h1>

###

<p align="left">Esta é uma API (Application Programming Interface) de um sistema de cadastro de usuários. Acesse também o front-end da aplicação em https://github.com/brunnaserafina/system </p>

###

</br>

### Funcionalidades

- Login - POST ("/auth/login")
- Cadastro de usuários - POST ("/customers/register")

</br>


### Pré-requisitos
##### Antes de começar, verifique se você tem os seguintes pré-requisitos instalados em sua máquina:
- .NET Core SDK - O SDK do .NET Core é necessário para compilar e executar o projeto.
- Editor de código (opcional) - Um editor de código como o Visual Studio Code, Visual Studio ou qualquer outro de sua preferência.
- PostgreSQL - O PostgreSQL é um banco de dados relacional necessário para armazenar os dados do aplicativo. Verifique se você tem o PostgreSQL instalado em sua máquina.

</br>


### Rodando a aplicação

1. Clone este repositório em uma pasta de sua preferência:

```bash
 $ git clone https://github.com/brunnaserafina/system-api.git
```

2. Crie um novo banco de dados: Abra um cliente PostgreSQL (por exemplo, pgAdmin, psql) e crie um novo banco de dados com o nome desejado para o seu projeto.

3. Execute os Scripts do Banco de Dados: No diretório do projeto, você encontrará um arquivo chamado `DatabaseScripts.sql`. Esse arquivo contém os scripts SQL necessários para configurar o esquema do banco de dados e inserir os dados iniciais. Execute o script `DatabaseScripts.sql` em seu banco de dados recém-criado para criar as tabelas necessárias e inserir os dados iniciais. 

4. Atualize a String de Conexão: Abra o arquivo appsettings.json e atualize a string de conexão ConnectionDb com os valores corretos para o seu banco de dados PostgreSQL. Certifique-se de substituir os marcadores de posição (<host>, <porta>, <nome_do_banco_de_dados>, <nome_do_usuario>, <senha>) pelas informações do banco que você criou no item anterior.

```bash
"ConnectionStrings": {
  "ConnectionDb": "Host=<host>;Port=<porta>;Database=<nome_do_banco_de_dados>;Username=<nome_do_usuario>;Password=<senha>;"
}
```

5. Abra um terminal ou promp de comando na raíz do projeto para compilar e executar o projeto, executando os seguintes comandos:

```bash
# Restaurar as dependências do projeto
$ dotnet restore 
```

```bash
# Compilar o projeto
$ dotnet build
```

```bash
# Executar o projeto
$ dotnet run 
```

6. O projeto estará rodando na porta http://localhost:5224 

</br>

### Database
 <img  alt="database" src="https://github.com/brunnaserafina/system-api/assets/106851605/3c5ac290-a88b-4d6b-9425-996e09cd18de" />

</br>

### Tecnologias utilizadas


 <img align="left" alt="csharp" height="30px" src="https://github.com/brunnaserafina/to-do-list-api/assets/106851605/94e0b12c-442e-4e59-b097-fad3d500c96e" />
 <img align="left" alt="dotnet" height="30px" src="https://github.com/brunnaserafina/to-do-list-api/assets/106851605/4ee9f23c-09c3-48df-8271-052d30252f53" />
 <img align="left" alt="jwt" height="30px" src="https://ps.w.org/jwt-auth/assets/icon-256x256.png?rev=2298869" />
</br>
</br>

### Autora

- [@brunnaserafina](https://www.github.com/brunnaserafina)