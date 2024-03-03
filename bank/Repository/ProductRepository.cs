using System.Collections.Generic;
using System.Linq;
using bank.Context;
using bank.Models;

namespace bank.Repository;

public class ProductRepository()
{
    public void AddProduct(Product product)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }

    public void UpdateProduct(Product product)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            db.Products.Update(product);
            db.SaveChanges();
        }
    }

    public bool ExistProduct(Product product)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products.Any(p => p.Name == product.Name);
        }
    }

    public void DeleteProduct(long productId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            var product = db.Products.Find(productId);
            if (product != null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
            }
        }
    }
    
    public Product GetProductByName(string name)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products.FirstOrDefault(p => p.Name == name);
        }
    }
    
    public Product GetProductById(long productId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products.Find(productId);
        }
    }

    public  List<Product> GetAllProducts()
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products.ToList();
        }
    }
    
    public  List<Product> GetAllProductsByStorageId(long storageId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products
                .Where(p => p.StorageProducts != null && p.StorageProducts.Any(s => s.StorageId == storageId)).ToList();
        }
    }
    
    public  List<Product> GetAllProductsByCompanyId(long companyId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products
                .Where(p => p.ProductCompanies != null && p.ProductCompanies.Any(c => c.CompanyId == companyId))
                .ToList();
        }
    }
    
    public  List<Product> GetAllProductsByUserId(long userId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products
                .Where(p => p.ProductCompanies.Any(c => c.Company.User.Id == userId))
                .ToList();
        }
    }

    public List<Product> GetAllProductsByUserIdAndCompanyId(long userId, long companyId)
    {
        using (ApplicationContext db = new ApplicationContext())
        {
            return db.Products
                .Where(p => p.ProductCompanies.Any(c => c.Company.User != null 
                                                        && c.Company.User.Id == userId)
                            && p.ProductCompanies.Any(c => c.CompanyId == companyId))
                .ToList();
        }
    }
}