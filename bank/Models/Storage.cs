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
    [Required]
    public string Name { get; set; }
    [Required]
    public string Country { get; set; }
    [Required]
    public string Size { get; set; }
    [ForeignKey("company_id")]
    public Company? Company { get; set; }

    public Storage(string name, string country, string size)
    {
        Name = name;
        Country = country;
        Size = size;
    }
}