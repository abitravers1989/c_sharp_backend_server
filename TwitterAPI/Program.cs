﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace TwitterAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                  .UseStartup<Startup>()
                .Build();
        //           .UseKestrel(options =>
        //           {
        //           options.ConfigureEndpoints());
        //}
                 
    }
}

//{
//    // Configure the Url and ports to bind to
//    // This overrides calls to UseUrls and the ASPNETCORE_URLS environment variable, but will be 
//    // overridden if you call UseIisIntegration() and host behind IIS/IIS Express

//    options.Listen(IPAddress.Loopback, 5000, listenOptions =>
//    {
//        listenOptions.UseHttps("localhost.pfx", "PASSWORD");
//    });
//})