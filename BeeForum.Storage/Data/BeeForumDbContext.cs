using BeeForum.Storage.Models;
using Microsoft.EntityFrameworkCore;

namespace BeeForum.Storage.Data
{
    public class BeeForumDbContext : DbContext
    {
        public BeeForumDbContext(DbContextOptions<BeeForumDbContext> options) : base(options) { }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
