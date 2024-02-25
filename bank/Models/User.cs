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
    public string Name { set; get; }
    [Required]
    public string Password { set; get; }
    public ICollection<Company>? Company { get; set; }
}