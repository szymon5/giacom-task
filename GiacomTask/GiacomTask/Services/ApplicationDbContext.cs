using GiacomTask.Models;
using Microsoft.EntityFrameworkCore;

namespace GiacomTask.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions) { }

        public DbSet<CallDetail> CallDetails { get; set; }
    }
}
