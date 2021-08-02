using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace application
{
  public class Program
  {

    public static void Main(string[] args)
    {
      var connectionString = Environment.GetEnvironmentVariable("CONNECTION_lOG");
      var tableName = Environment.GetEnvironmentVariable("LOG_TABLE_NAME");
      Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Warning()
      .WriteTo.PostgreSQL(connectionString, tableName, needAutoCreateTable: true, batchSizeLimit: 1)
      .CreateLogger();

      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            /*.ConfigureLogging((_, builder) =>
            {
              builder.AddFile("logs/app-{Date}.json", isJson: true);
            })*/
            .ConfigureWebHostDefaults(webBuilder =>
            {
              webBuilder.UseStartup<Startup>();
              webBuilder.UseUrls("http://localhost:8585");
            });
  }
}
