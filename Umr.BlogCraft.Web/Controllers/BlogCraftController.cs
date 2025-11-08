using Microsoft.AspNetCore.Mvc;
using Umr.BlogCraft.Data.Services;
using Umr.BlogCraft.Model;

namespace Umr.BlogCraft.Web.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BlogCraftController : ControllerBase
{
    public readonly UnitOfWork _uow;

    public BlogCraftController(UnitOfWork uow)
    {
        this._uow = uow;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Posts>> GetPosts()
    {
        var posts = _uow.GetPosts();
        return Ok(posts);
    }
}
