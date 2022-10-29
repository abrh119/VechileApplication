using Microsoft.EntityFrameworkCore;

namespace VechileApplication.Models
{
    public class vehicleDbContext : DbContext
    {
        public vehicleDbContext(DbContextOptions<vehicleDbContext> options)
            : base(options)
        {
        }
        public DbSet<Make> Make { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Price> Price { get; set; }
        public DbSet<Vehicles> Vehicles { get; set; }

    }
}

//public class vehicleDbContext : DbContext
//{
//    public vehicleDbContext(DbContextOptions options) : base(options)
//    {
//    }
//    public DbSet<Make> Make { get; set; }
//    public DbSet<Model> Models { get; set; }
//    public DbSet<Price> Price { get; set; }
//    public DbSet<Vehicles> Vehicles { get; set; }
//}
//}