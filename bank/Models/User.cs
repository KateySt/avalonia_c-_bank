namespace bank.Models;

public class User
{
    public long Id { set; get; }
    public string Name { set; get; }
    public string Password { set; get; }
    public Company? Company { get; set; }
}