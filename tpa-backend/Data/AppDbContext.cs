using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tpa_backend.Models;

namespace tpa_backend.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureCreated();
        }

        public DbSet<City> Cities { get; set; }
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
        public DbSet<VisitCost> VisitCosts  { get; set; }


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

            /*modelBuilder.Entity<Landmark>()
                .HasMany(x => x.WorkingDays)
                .WithOne(x => x.LandmarkWorkingHours )
                .OnDelete(DeleteBehavior.Cascade);*/
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


            /*var user1 = new User()
            {
                Name = "Evgeniya",
                Id = Guid.NewGuid(),
                Email = "email",
                Phone = "8980",
                Plans = null,
                Tourists= null,
                Password = "12345678",
         
            };

            modelBuilder.Entity<User>().HasData(user1);*/



            var int1=new Interest()
                {
                    Id = 1,
                    Name = "Художественные музеи",
                };
            var int2 = (new Interest()
                {
                    Id = 2,
                    Name = "Исторические музеи",
                });
            var int3 = (new Interest()
                {
                    Id = 3,
                    Name = "Научные музеи",
                });
            var int4 = (new Interest()
                {
                    Id = 4,
                    Name = "Музеи естественной истории",
                });
            var int5 = (new Interest()
                {
                    Id = 5,
                    Name = "Технические музеи",
                });
            var int6 = (new Interest()
                {
                    Id = 6,
                    Name = "Музеи культуры",
                });
            var int7 = (new Interest()
               {
                   Id = 7,
                   Name = "Археологические места",
               });
            var int8 = (new Interest()
               {
                   Id = 8,
                   Name = "Крепости и замки",
               });
            var int9 = (new Interest()
               {
                   Id = 9,
                   Name = "Памятники архитектуры",
               });
            var int10 = (new Interest()
              {
                  Id = 10,
                  Name = "Памятники",
              });
            var int11 = (new Interest()
              {
                  Id = 11,
                  Name = "Религиозные места",
              });
            var int12 = (new Interest()
              {
                  Id = 12,
                  Name = "Памятники воинской и трудовой славы",
              });
            var int13 = (new Interest()
             {
                 Id = 13,
                 Name = "Национальные парки",
             });
            var int14 = (new Interest()
             {
                 Id = 14,
                 Name = "Заповедники",
             });
            var int15 = (new Interest()
             {
                 Id = 15,
                 Name = "Водопады",
             });
            var int16 = (new Interest()
            {
                Id = 16,
                Name = "Горы",
            });
            var int17 = (new Interest()
            {
                Id = 17,
                Name = "Водоемы",
            });
            var int18 = (new Interest()
            {
                Id = 18,
                Name = "Пляжи",
            });
            var int19 = (new Interest()
            {
                Id = 19,
                Name = "Парки развлечений",
            });
            var int20 = (new Interest()
            {
                Id = 20,
                Name = "Аквапарки",
            });
            var int21 = (new Interest()
            {
                Id = 21,
                Name = "Современные здания",
            });
            var int22 = (new Interest()
            {
                Id = 22,
                Name = "Экстремальные места",
            });
            var int23 = (new Interest()
            {
                Id = 23,
                Name = "Фестивали",
            });
            var int24 = (new Interest()
            {
                Id = 24,
                Name = "Театры",
            });
            var int25 = (new Interest()
            {
                Id = 25,
                Name = "Выставки",
            });

                modelBuilder.Entity<Interest>()
                           .HasData(int1, int2, int3, int4, int5, int6, int7, int8,
                           int9, int10, int11, int12, int13, int14, int15, int16, int17, int18,
                           int19, int20, int21, int22, int23, int24, int25);



            var mt1=(new MovingType()
           {
               Id = 1,
               Name = "Пешком",
           });
            var mt2 = (new MovingType()
          {
              Id = 2,
              Name = "Общественный транспорт",
          });
            var mt3 = (new MovingType()
          {
              Id = 3,
              Name = "Такси",
          });
            var mt4 = (new MovingType()
          {
              Id = 4,
              Name = "Личный автомобиль",
          });
            var mt5 = (new MovingType()
          {
              Id = 5,
              Name = "Самокат",
          });

            modelBuilder.Entity<MovingType>()
                           .HasData(mt1, mt2, mt3, mt4, mt5);


            var d1=(new Difficulty()
          {
              Id = 1,
              Name = "Очень низкий уровень сложности",
          });
            var d2=(new Difficulty()
         {
             Id = 2,
             Name = "Низкий уровень сложности",
         });
            var d3=(new Difficulty()
         {
             Id = 3,
             Name = "Средний уровень сложности",
         });
            var d4=(new Difficulty()
         {
             Id = 4,
             Name = "Высокий уровень сложности",
         });
            var d5=(new Difficulty()
         {
             Id = 5,
             Name = "Очень высокий уровень сложности",
         });

               modelBuilder.Entity<Difficulty>().HasData(d1, d2, d3, d4, d5);

            var city1 = new City()
            {
                Id = 1,
                Name = "Москва",
            };
            modelBuilder.Entity<City>().HasData(city1);

            /*var t1 = new Tourist()
            {
                Id = Guid.NewGuid(),
                Name = "Tourist",
                User = user1,
                Age = 15,
                Interests = new List<Interest>()
                {
                    int1,int2, int3
                },

            };
            var t2 = new Tourist()
            {
                Id = Guid.NewGuid(),
                Name = "Tourist2",
                User = user1,
                Age = 18,
                Interests = new List<Interest>()
                {
                    int1,int2, int3, int5, int6, int8
                },

            };
            Console.WriteLine( user1.Id);
            var t3 = new Tourist()
            {
                Id = Guid.NewGuid(),
                Name = "Tourist3",
                User = user1,
                Age = 20,
                Interests = new List<Interest>()
                {
                    int1,int2, int3, int5, int6, int8,int20,int21, int22, int23, int24, int25
                },

            };
            modelBuilder.Entity<Tourist>().HasData(t1,t2,t3);*/

        }


    }
}
