using EFGetStarted.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFGetStarted
{
    public class teste
    {
        public void testexecutar()
        {
            using (var db = new BookContext())
            {
                //Create (Cria um livro e cadastrar na tabela

                Console.WriteLine("Inserting a new book");
                db.Add(new Book("Sentido da vida e tudo mais", 10.00));
                db.SaveChanges();

                // Read (busca um livro no banco de dados e inclue seus autores
                Console.WriteLine("Querying for a book");
                var books = db.Books
                    .Include(book => book.authors)
                    .ToList();

                //Update (atualiza um author dentro do primeiro book da tabela)
                Console.WriteLine("Updating");
                books[0].authors.Add(
                    new Author
                    {
                        Name = "Mc Gurila",
                        gender = 'M',
                        email = "gurilinha@hotmail.com"
                    });

                books[0].authors.Add(
                    new Author
                    {
                        Name = "Mc Bananinha",
                        gender = 'M',
                        email = "bananinha@hotmail.com"
                    });

                db.SaveChanges();
                
                var book = db.Books
                    .Include(book => book.authors)
                    .First();

                Console.WriteLine("simplismente pegando o primeiro author do book: " + book.authors[0].Name);
                //utilizando o toString
                Console.WriteLine("metodo tostring: " + book.ToString());
                //utilizando o getAuthorName
                Console.WriteLine("metodo getAuthorName: " + book.getAuthorNames());

            }
        }
    }
}
