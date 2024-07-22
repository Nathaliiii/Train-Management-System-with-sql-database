using Microsoft.EntityFrameworkCore;
using TrainAPI.Model;
using TrainAPI.Model;
using TrainAPI.Models;
namespace TrainAPI.Data
{
    public class AppDBContext : DbContext
    {
        internal object Ticket;
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }
        //Define tables
        public DbSet<Ticket> tickets { get; set; }
        public DbSet<Train>trains{ get; set; }
        public DbSet<Passenger> passengers { get; set; }
        public DbSet<Seat> seats { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ticket>()
                .Property(t => t.Price)
                .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Train>();
            modelBuilder.Entity<Passenger>();
            modelBuilder.Entity<Seat>();


            // Other entity configurations may go here

            base.OnModelCreating(modelBuilder);
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conn = "Data Source=LAPTOP-5ETVI718;Initial Catalog=SOC;User ID=sa;Password=sql;Trust Server Certificate=True";
            optionsBuilder.UseSqlServer(conn);
        }
    }
}
