using Lab1;
using Microsoft.EntityFrameworkCore;
namespace Lab1.Data
{
    public class AplicationDBContext : DbContext
    {
        public AplicationDBContext(DbContextOptions<AplicationDBContext> option): base(option)
        {
        
        }

        public DbSet<Paint> Gallery { get; set; }
    }
}
