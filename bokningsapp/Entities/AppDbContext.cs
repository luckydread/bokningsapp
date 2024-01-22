using System.Reflection.Metadata;
using bokningsapp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace bokningsapp.Entities
{

    // public class AppDbContext: IdentityDbContext<User>
    public class AppDbContext: IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           

        }
     
        /*
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
                .HasKey(b => b.SlotId);

            modelBuilder.Entity<Slot>()
                .HasOne<Booking> (s => s.Booking)
                .WithOne(b => b.Slot);
             
            
        }*/
        public DbSet<Slot> Slots { get; set; }
       public DbSet<Booking> Bookings { get; set; }
        public DbSet<Backpack> Backpacks { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
    }
}
