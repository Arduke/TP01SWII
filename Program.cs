using EFGetStarted.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFGetStarted
{
    class Program
    {
        static void Main()
        {
            /* codigo para prompt
            teste a1 = new teste();
            a1.testexecutar();
            */

            
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();
            host.Run();
            
        }
    }
}
