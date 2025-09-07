using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Umr.BlogCraft.Model;
public class Comments
{
    public int Id { get; set; }
    [ForeignKey("Posts")]
    public int PostId { get; set; }
    public string CommentText { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; } = null!;
    public DateTime ModifiedDate { get; set; }
    public string ModifiedBy { get; set; } = null!;
}
