using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace application.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Product> Products { get; set; }

        public Task<int> SaveChangesAsync();
    }
}
