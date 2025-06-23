using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using myApp_webApiWithAdo_proDuck.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace myApp_webApiWithAdo_proDuck.Repository {
  public class ProductRepo : IProductRepo {
    private readonly string conn;

    public ProductRepo(IConfiguration configuration) {
      this.conn = configuration.GetConnectionString("konek")!;
    }
    public IEnumerable GetAllProducts() {
      List<Product> products = new List<Product>();
      using(SqlConnection sqlConnection = new SqlConnection(conn)) {
        SqlCommand sqlCommand = new SqlCommand("select * from product ", sqlConnection);
        sqlConnection.Open();
        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
        while(sqlDataReader.Read()) {
          Product product = new Product() {
            Id = sqlDataReader.GetInt32(0),
            Name = sqlDataReader.GetString(1),
            Price = sqlDataReader.GetInt64(2)
          };
          products.Add(product);
        }
      }
      return products;
    }
    public Product GetProductById(int id) {
      Product product = new Product();
      try {
        using(SqlConnection sqlConnection = new SqlConnection(conn)) {
          SqlCommand sqlCommand = new SqlCommand($"select * from product where id = {id}", sqlConnection);
          sqlConnection.Open();
          SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
          sqlDataReader.Read();
          product.Id = sqlDataReader.GetInt32(0);
          product.Name = sqlDataReader.GetString(1);
          product.Price = sqlDataReader.GetInt64(2);
        }
      } catch(Exception ex) {
        string errorMessage = ex.Message;
      }
      return product;
    }
    public Product SaveProduct(Product product) {
      using(SqlConnection sqlConnection = new SqlConnection(conn)) {
        SqlCommand sqlCommand = new SqlCommand(
          $"insert into product(id, name, price) values({product.Id},'{product.Name}',{product.Price})"
          , sqlConnection
        );
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
      }
      return product;
    }
    public Product UpdateProduct(int id, Product product) {
      using(SqlConnection sqlConnection = new SqlConnection(conn)) {
        SqlCommand sqlCommand = new SqlCommand(
          $"update product set name = '{product.Name}', price = {product.Price} where id = {id}"
          , sqlConnection
        );
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
      }
      return product;
    }
    public void DeleteProduct(int id) {
      using(SqlConnection sqlConnection = new SqlConnection(conn)) {
        SqlCommand sqlCommand = new SqlCommand(
          $"delete from product where id = {id}", sqlConnection
        );
        sqlConnection.Open();
        sqlCommand.ExecuteNonQuery();
      }
    }
  }
}
