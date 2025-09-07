using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umr.BlogCraft.Model;
public class Tags
{
    public int Id { get; set; }
    public string TagName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public virtual ICollection<Posts> Posts { get; set; } = new List<Posts>();

}
