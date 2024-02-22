using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bank.Models;

[Table("Users")]
public class User
{
    [Column("user_id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { set; get; }
    [Required]
    public string Name { set; get; }
    [Required]
    public string Password { set; get; }
    public Company Company { get; set; }
}