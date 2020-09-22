using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    class Startup
    {


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("BooksDescriptionById/{bookId}", ShowBookById);
            builder.MapRoute("ShowNameOfBookById/{bookId}", ShowNameOfBookById);
            builder.MapRoute("BookAuthorsById/{bookId}", ShowBookAuthorsByIdBook);
            builder.MapRoute("Book/ShowLivro/{bookId}", ShowBookHtml);

            //criar rota home
            builder.MapRoute("", Home); 

            var rotas = builder.Build();
            app.UseRouter(rotas);
        }

        public Task  Home (HttpContext context)
        {
            return context.Response.WriteAsync("Funcionando");
        }


        public Task ShowBookAuthorsByIdBook(HttpContext context)
        {
            using (var db = new BookContext())
            {
                var books = db.Books
                    .Include(book => book.authors)
                    .ToList();

                int bookId = Convert.ToInt32(context.GetRouteValue("bookId").ToString()) - 1;
                var book = books[bookId];

                return context.Response.WriteAsync(book.getAuthorNames());
            }
        }

        public Task ShowNameOfBookById(HttpContext context)
        {
            using ( var db = new BookContext())
            {
                var books = db.Books
                    .Include(book => book.authors)
                    .ToList();

                int bookId = Convert.ToInt32(context.GetRouteValue("bookId").ToString()) - 1;
                var book = books[bookId];

                return context.Response.WriteAsync(book.name);
            }
        }


        public Task ShowBookById(HttpContext context)
        {
            using ( var db = new BookContext())
            {
                var books = db.Books
                    .Include(book => book.authors)
                    .ToList();

                int bookId = Convert.ToInt32(context.GetRouteValue("bookId").ToString()) - 1;
                var book = books[bookId];

                return context.Response.WriteAsync(book.ToString());
            } 
        }


        //teste
        /*
        public Task ShowBook(HttpContext context)
        {
            using (var db = new BookContext())
            {
                var book = db.Books
                    .Include(book => book.authors)
                    .First();

                return context.Response.WriteAsync(book.ToString());
            }
        }
        */

        public Task ShowBookHtml(HttpContext context)
        {
            using (var db = new BookContext())
            {
                var books = db.Books
                    .Include(book => book.authors)
                    .ToList();

                int bookId = Convert.ToInt32(context.GetRouteValue("bookId").ToString()) - 1;
                var book = books[bookId];

                var conteudoArquivo = CarregaArquivoHTML("ShowBook");

                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM#", $"<h4>{book.ToString()}<h4>");

                return context.Response.WriteAsync(conteudoArquivo);
            }
        }

        private string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"View/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
