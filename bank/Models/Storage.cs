using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("storages")]
public class Storage
{
    [Key]
    [Column("storage_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    [Column("name")]
    [Required]
    public string Name { get; set; }
    [Column("country")]
    [Required]
    public string Country { get; set; }
    
    [Column("size")]
    [Required]
    public string Size { get; set; }
    [ForeignKey("company_id")]
    public Company? Company { get; set; }
    public List<StorageProduct>? StorageProducts { get; set; } = new();
    
    public Storage(string name, string country, string size)
    {
        Name = name;
        Country = country;
        Size = size;
    }
}