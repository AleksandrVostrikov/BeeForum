using Microsoft.EntityFrameworkCore;

namespace BeeForum.Storage
{
    public class BeeForumDbContext : DbContext
    {
        public BeeForumDbContext(DbContextOptions<BeeForumDbContext> options) : base(options) { }

        DbSet<Forum> Forums { get; set; }
        DbSet<Topic> Topics { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<User> Users { get; set; }

    }
}
