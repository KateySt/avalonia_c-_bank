using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IProductService
{
    Product Add(Product product);
    Product Update(Product product);
    void Delete(long productId);
    Product GetProductById(long productId);
    IEnumerable<Product> GetAllProducts();
}