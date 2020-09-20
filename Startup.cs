using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
            builder.MapRoute("BookNameById/{bookId}", ShowNameOfBookById);
            builder.MapRoute("BookAuthorsById/{bookId}", ShowNameOfBookById);

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
    }
}
