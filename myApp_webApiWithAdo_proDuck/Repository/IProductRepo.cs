using myApp_webApiWithAdo_proDuck.Models;
using System;
using System.Collections;

namespace myApp_webApiWithAdo_proDuck.Repository {
  public interface IProductRepo {
    IEnumerable GetAllProducts();
    Product GetProductById(int id);
    Product SaveProduct(Product person);
    Product UpdateProduct(int id, Product person);
    void DeleteProduct(int id);
  }
}
