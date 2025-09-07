namespace Umr.BlogCraft.Model;

public class Users
{
    public int Id { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; } = null!;

}
