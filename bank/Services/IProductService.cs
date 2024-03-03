using System.Collections.Generic;
using bank.Models;

namespace bank.Services;

public interface IProductService
{
    Product Add(Product product);
    Product Update(Product product);
    void Delete(long productId);
    Product GetProductById(long productId);
    List<Product> GetAllProducts();
    List<Product> GetAllProductsByStorageId(long storageId);
    List<Product> GetAllProductsByCompanyId(long companyId);
    List<Product> GetAllProductsByUserId(long userId);
    List<Product> GetAllProductsByUserIdAndCompanyId(long userId, long companyId);
}