using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Storage.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<BeeForumDbContext>
    {
        public BeeForumDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BeeForumDbContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=EcommerceDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BeeForumDbContext(optionsBuilder.Options);
        }
    }
}
