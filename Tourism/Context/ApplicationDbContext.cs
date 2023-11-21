using Microsoft.EntityFrameworkCore;
using Tourism.Model;

namespace Tourism.Context
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<UserProfile>? UserProfiles { get; set; }
    }
}
