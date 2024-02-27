using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("companies")]
public class Company
{
    [Key]
    [Column("company_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Required]
    [Column("name")]
    public string Name { get; set; }
    [Required]
    [Column("country")]
    public string Country { get; set; }
    [Column("image")]
    public string? Image { get; set; }
    [ForeignKey("user_id")]
    public User? User { get; set; }
    public List<ProductCompany>? ProductCompanies { get; set; } = new(); 
    public List<Storage> Storages { get; set; } = new(); 

    public Company(string name, string country, string image)
    {
        Name = name;
        Country = country;
        Image = image;
    }
}