using EFGetStarted.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            using (var db = new BookContext())
            {

                List<Author> authorList = new List<Author> { new Author { Name = "Boston" }, new Author { Name = "Merdium" } };
                           
                // Create
                Console.WriteLine("Inserting a new blog");
                db.Add(new Book("Bananinhas", 10.00));
                db.SaveChanges();
                // Read
                Console.WriteLine("Querying for a blog");
                var book = db.Books;
                    

                
            }
        }
    }
}
