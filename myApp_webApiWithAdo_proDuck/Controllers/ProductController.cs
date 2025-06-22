using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using myApp_webApiWithAdo_proDuck.Repository;

namespace myApp_webApiWithAdo_proDuck.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase {
    private readonly IProductRepo productRepo;

    public ProductController(IProductRepo productRepo) {
      this.productRepo=productRepo;
    }
  }
}
