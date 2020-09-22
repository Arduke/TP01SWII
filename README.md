# 🚧  Em construção 🚧

- [ ]  Rotas
    - [x]  Apresentar um Livro.
    - [x]  Apresentar um Livro com descrição completa.[
    - [x]  Apresentar lista de livros com descrição completa.
    - [ ]  Cadastrar livro.
    - [ ]  Atualizar livro.
    - [ ]  Deletar livro.
- [ ]  Views
    - [ ]  Cadastrar livro.
    - [ ]  Atualizar livro.
    - [ ]  Deletar livro.
    - [ ]  Lista de livros.

# Pacotes utilizados

- Microsoft.AspNetCore
- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.EntityFrameworkCore.Tools

# **Descrição**

Projeto simples de CRUD ( create, read, update, delete) de Livros com seus autores vinculados através de requisições na web.

# Pré-requisitos e como rodar a aplicação

Requisitos:

Visual Studio 2019 qualquer versão.

Como rodar:

Apenas abra o projeto e compile.

Arquivo teste.cs é parte do projeto em prompt.

Rotas:

- Apresentar descrição completa de um livro passando o ID:
    - http://localhost:5000/BooksDescriptionById/<id do livro>
- Apresentar somente o nome de um livro passando o ID:
    - http://localhost:5000/ShowNameOfBookById/<id do livro>
- Apresentar os autores de um livro passando o ID:
    - http://localhost:5000/BookAuthorsById/<id do livro>
- Apresentar pagina HTML com dados de um livro passando o ID:
    - http://localhost:5000/Book/ShowLivro/<id do livro>

