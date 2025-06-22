using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace myApp_webApiWithAdo_proDuck{
  public class Program{
    public static void Main(string[] args){

      /* ============================== services ============================== */
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllers();

      /* ============================== pipeline ============================== */
      var app = builder.Build();
      app.MapControllers();
      app.Run();
    }
  }
}
