using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
namespace Api.Data.Context
{
  public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
  {
    public MyContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
      //var connectionString = "Server=localhost;Port=5433;Database=SolidBase;User Id=kako;Password=kako123456;";
      //optionsBuilder.UseNpgsql(connectionString);
      if (Environment.GetEnvironmentVariable("DATABASE").ToLower() == "MYSQL".ToLower())
      {
          optionsBuilder.UseMySql(Environment.GetEnvironmentVariable("MYSQL_DB_CONNECTION"));
          //optionsBuilder.UseMySql("Server=localhost;Port=3306;Database=SolidBase;Uid=kako;Pwd=kako123456;");
      }
      else
      {
          optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("POSTGRE_DB_CONNECTION"));
          //optionsBuilder.UseNpgsql("Server=localhost;Port=5433;Database=SolidBase;User Id=kako;Password=kako123456;");
      }
      return new MyContext(optionsBuilder.Options);

    }
  }
}