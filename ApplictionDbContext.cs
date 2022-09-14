using copernicus_back.Entity;
using Microsoft.EntityFrameworkCore;

namespace copernicus_back
{
    public class ApplictionDbContext : DbContext
    {
        public ApplictionDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

    }
}
