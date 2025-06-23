using myApp_webApiWithAdo_proDuck.Models;
using System;
using System.Collections;

namespace myApp_webApiWithAdo_proDuck.Repository {
  public interface IProductRepo {
    IEnumerable GetAllProducts();
    Product GetProductById(int id);
    Product SaveProduct(Product product);
    Product UpdateProduct(int id, Product product);
    void DeleteProduct(int id);
  }
}
