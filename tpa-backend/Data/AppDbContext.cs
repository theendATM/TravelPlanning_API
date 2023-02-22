using Microsoft.EntityFrameworkCore;
using tpa_backend.Models;

namespace tpa_backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /*public DbSet<City> Cities { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Landmark> Landmarks { get; set; }
        public DbSet<MovingType> MovingTypes { get; set; }
        public DbSet<PersonalLandmark> PersonalLandmarks { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<VisitCost> VisitCosts  { get; set; }*/


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<City>()
                .HasMany(x=>x.Landmarks)
                .WithOne(x => x.City)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<City>()
                .HasMany(x => x.Plans)
                .WithOne(x => x.City)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Day>()
                .HasMany(x => x.TimeSlots)
                .WithOne(x => x.Day)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Difficulty>()
                .HasMany(x => x.Landmarks)
                .WithOne(x => x.Difficulty)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Interest>()
                .HasMany(x => x.Landmarks)
                .WithMany(x => x.Interests);

            modelBuilder.Entity<Landmark>()
                .HasMany(x => x.WorkingDays)
                .WithOne(x => x.LandmarkWorkingHours )
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Landmark>()
                .HasMany(x => x.VisitCosts)
                .WithOne(x => x.Landmark)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<PersonalLandmark>()
                .HasOne(x => x.Plan)
                .WithMany(x=>x.PersonalLandmarks)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Plan>()
                .HasMany(x => x.MovingTypes)
                .WithMany(x => x.Plans);
            modelBuilder.Entity<Plan>()
                .HasOne(x => x.User)
                .WithMany(x => x.Plans)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tourist>()
                .HasOne(x => x.User)
                .WithMany(x => x.Tourists)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Tourist>()
                .HasMany(x => x.Interests)
                .WithMany(x => x.Tourists);
        
            modelBuilder.Entity<VisitCost>().HasKey(x => x.Id);
        }


       }
}
