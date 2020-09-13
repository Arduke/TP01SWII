using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFGetStarted.Model
{
    public class Book
    {
        public int bookId { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public int qty { get; set; }
        public List<Author> authors { get; } = new List<Author>();

        public Book (string name, double price)
        {
            this.name = name;
            this.authors = authors.ToList();
            this.price = price;
        }
        public Book (string name, double price, int qty)
        {
            this.name = name;
            this.authors = authors.ToList();
            this.price = price;
            this.qty = qty;
        }

        public override string ToString()
        {
            string aux = "";

            foreach (Author author in authors)
            {
                return "name = " + author.Name + "email = " + author.email + "gender = " + author.gender + ',';
            }


            string apresentation = $"Book [{this.name}, authors = {aux}, price = {price}, qty = {qty}] \n";
            
            return apresentation;
        } 

        public string getAuthorNames ()
        {
            foreach (Author author in authors)
            {
                return "name = " + author.Name + ',';
            }

            return "";
        }
    }
}
