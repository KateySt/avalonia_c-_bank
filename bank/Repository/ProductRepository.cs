using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class ProductRepository(ApplicationContext db)
{
    public void AddProduct(Product product)
    {
        db.Products.Add(product);
        db.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        db.Products.Update(product);
        db.SaveChanges();
    }

    public bool ExistProduct(Product product)
    {
        return db.Products.Any(p => p.Name == product.Name);
    }

    public void DeleteProduct(long productId)
    {
        var product = db.Products.Find(productId);
        if (product != null)
        {
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
    
    public Product GetProductByName(string name)
    {
        return db.Products.FirstOrDefault(p => p.Name == name);
    }
    
    public Product GetProductById(long productId)
    {
        return db.Products.Find(productId);
    }

    public IEnumerable<Product> GetAllProducts()
    {
        return db.Products.ToList();
    }
}