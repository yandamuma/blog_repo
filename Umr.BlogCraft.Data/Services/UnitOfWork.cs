using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umr.BlogCraft.Model;

namespace Umr.BlogCraft.Data.Services;
public class UnitOfWork : IUnitOfWork
{
    public readonly BlogCraftDbContext _dbContext;

    public UnitOfWork(BlogCraftDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public int Complete()
    {
        return _dbContext.SaveChanges();
    }

    public void Dispose()
    { 
        _dbContext.Dispose();
    }

    public IEnumerable<Posts> GetPosts()
    {
        return _dbContext.Posts;
    }
}
