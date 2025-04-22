using Microsoft.EntityFrameworkCore;

namespace test_db_cn
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options): base(options) { }

        
        public DbSet<Users> Users { get; set; }
    }
}
                    