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

    public IEnumerable<Product> GetAllProducts()
    {
        return productRepository.GetAllProducts();
    }
}