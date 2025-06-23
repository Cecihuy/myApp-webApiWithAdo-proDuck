using Microsoft.AspNetCore.Mvc;
using myApp_webApiWithAdo_proDuck.Models;
using myApp_webApiWithAdo_proDuck.Repository;
using System;
using System.Collections;

namespace myApp_webApiWithAdo_proDuck.Controllers {
  [Route("api/[controller]")]
  [ApiController]
  public class ProductController : ControllerBase {
    private readonly IProductRepo productRepo;

    public ProductController(IProductRepo productRepo) {
      this.productRepo=productRepo;
    }
    [HttpGet]
    public ObjectResult GetAllProducts() {
      IEnumerable enumerable = productRepo.GetAllProducts();
      return Ok(enumerable);
    }
    [HttpGet]
    [Route("{id}", Name = "urlStringWithId")]
    public ActionResult GetProductById(int id) {
      Product product = productRepo.GetProductById(id);
      if(product.Id != 0) { 
        return Ok(product);
      } else { 
        return NotFound(); 
      }
    }
    [HttpPost]
    public ActionResult SaveProduct(Product model) {
      if(ModelState.IsValid) { 
        Product product = productRepo.SaveProduct(model);
        return Created(new Uri(Url.Link("urlStringWithId", new {Id = model.Id})!),product);
      } else {
        return BadRequest("Something wrong with modelstate validation");
      }
    }
    [HttpPut]
    [Route("{id}")]
    public IActionResult UpdateProduct(int id, Product model) {
      if(ModelState.IsValid) { 
        Product getProduct = productRepo.GetProductById(id);
        if(getProduct.Id != 0) {
          Product product = productRepo.UpdateProduct(id, model);
          return Ok(product);
        } else {
          return NotFound($"Id with: {id}. Not found");
        }
      } else {
        return BadRequest("Something wrong with modelstate validation");
      }
    }
    [HttpDelete]
    [Route("{id}")]
    public ObjectResult DeleteProduct(int id) {
      Product product = productRepo.GetProductById(id);
      if(product.Id != 0) {
        productRepo.DeleteProduct(product.Id);
        return Ok($"Id with: {product.Id}. Deleted");
      } else {
        return NotFound($"Id with: {id}. Not found");
      }
    }
  }
}
