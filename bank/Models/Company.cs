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
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    public string? Image { get; set; }
    [ForeignKey("user_id")]
    public User? User { get; set; }
    public ICollection<ProductCompany>? ProductCompanies { get; set; } 
    public ICollection<Storage>? Storages { get; set; } = new List<Storage>();

    public Company(string name, string country, string image)
    {
        Name = name;
        Country = country;
        Image = image;
    }
}