using Umr.BlogCraft.Model;

namespace Umr.BlogCraft.Data.Services;

public interface IUnitOfWork
{
    IEnumerable<Posts> GetPosts();
}