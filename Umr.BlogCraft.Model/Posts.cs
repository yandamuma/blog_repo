using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umr.BlogCraft.Model;
public class Posts
{
    public int Id { get; set; }
    [ForeignKey("Users")]
    public int UserId { get; set; }
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;    
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public virtual ICollection<Tags> Tags { get; set; } = new List<Tags>();
}
