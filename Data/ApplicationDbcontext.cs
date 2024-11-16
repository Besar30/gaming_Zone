using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class ApplicationDbcontext:DbContext
    {
		public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options)
		   : base(options) // تمرير الخيارات إلى المُنشئ الأساسي
		{
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameZone;Integrated Security=True;Trusted_Connection=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameDevices>().HasKey(e => new { e.DevicesId, e.GamesId });
            modelBuilder.Entity<Categories>().HasData(
                new Categories[]
                {
                    new Categories { Id = 1, Name="Sports"},
                    new Categories { Id = 2, Name="Action"},
                    new Categories { Id = 3, Name="Adventure"},
                    new Categories { Id = 4, Name="Racing"},
                    new Categories { Id = 5, Name="Fighting"},
                    new Categories { Id = 6, Name="Film"}
                });
            modelBuilder.Entity<Devices>().HasData(
               new Devices[]
               {
                    new Devices { Id = 1, Name="PlayStation" ,Icone="bi bi-playstation"},
                    new Devices { Id = 2, Name="xbox",Icone="bi bi-xbox"},
                    new Devices { Id = 3, Name="Nintendo Switch",Icone="bi bi-nintendo-switch"},
                    new Devices { Id = 4, Name="PC",Icone="bi bi-pc-display"}
               });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Games> Games { get; set; }
        public DbSet<Devices> Devices { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<GameDevices> GameDevices { get; set; }
    }
}
