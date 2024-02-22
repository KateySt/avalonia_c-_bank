using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("Companies")]
public class Company
{
    [Column("company_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    public ICollection<User> Users { get; set; }
    public ICollection<ProductCompany> ProductCompanies { get; set; } 
    public Company(string name, string country)
    {
        Name = name;
        Country = country;
    }
}