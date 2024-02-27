using System.Collections.Generic;
using bank.Models;
using bank.Repository;

namespace bank.Services.Impl;

public class ProductService(ProductRepository productRepository) : IProductService
{
    public Product Add(Product product)
    {
        productRepository.AddProduct(product);
        return product;
    }

    public Product Update(Product product)
    {
        productRepository.UpdateProduct(product);
        return product;
    }

    public void Delete(long productId)
    {
        productRepository.DeleteProduct(productId);
    }

    public Product GetProductById(long productId)
    {
        return productRepository.GetProductById(productId);
    }

    public  List<Product> GetAllProducts()
    {
        return productRepository.GetAllProducts();
    }
    
    public  List<Product> GetAllProductsByStorageId(long storageId)
    {
        return productRepository.GetAllProductsByStorageId(storageId);
    }
    
    public  List<Product> GetAllProductsByCompanyId(long companyId)
    {
        return productRepository.GetAllProductsByCompanyId(companyId);
    }
}