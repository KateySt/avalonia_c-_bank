using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("users")]
public class User
{
    [Key]
    [Column("user_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    [Required] 
    [Column("name")]
    public string Name { set; get; }
    [Required]
    [Column("password")]
    public string Password { set; get; }

    public List<Company> Companies { get; set; } = new();
}