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
    
}