using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using myApp_webApiWithAdo_proDuck.Repository;

namespace myApp_webApiWithAdo_proDuck{
  public class Program{
    public static void Main(string[] args){

      /* ============================== services ============================== */
      var builder = WebApplication.CreateBuilder(args);
      builder.Services.AddControllers();
      builder.Services.AddScoped<IProductRepo, ProductRepo>();
      builder.Services.Configure<ApiBehaviorOptions>(options => {
        options.SuppressModelStateInvalidFilter = true;
      });

      /* ============================== pipeline ============================== */
      var app = builder.Build();
      app.MapControllers();
      app.Run();
    }
  }
}
