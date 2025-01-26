using Microsoft.EntityFrameworkCore;

namespace casaWinOS.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<SelectableApp> MyApps { get; set; }
    }
}
