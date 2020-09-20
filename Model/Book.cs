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
            this.price = price;
        }
        public Book (string name, double price, int qty)
        {
            this.name = name;
            this.price = price;
            this.qty = qty;
        }

        public override string ToString()
        {
            string aux = "";

            foreach (Author author in this.authors)
            {
                aux =  "\n name = " + author.Name + "\n email = " + author.email + "\n gender = " + author.gender + "\n";
            }

            string apresentation = $"Book {this.name}\n [\n author(s) = \n {aux}\n ]\nprice = {price}\nqty = {qty}\n";
            
            return apresentation;
        } 

        public string getAuthorNames ()
        {
            string aux = "";

            foreach (Author author in this.authors)
            {
                aux = aux + author.Name + ',';
            }

            return "name = " + aux;
        }
    }
}
