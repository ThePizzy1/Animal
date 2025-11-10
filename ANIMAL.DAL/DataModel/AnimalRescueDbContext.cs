using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ANIMAL.DAL.DataModel
{
    public partial class AnimalRescueDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>

    {
        public AnimalRescueDbContext()
        {
        }

        public AnimalRescueDbContext(DbContextOptions<AnimalRescueDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adopted> Adopted { get; set; }
        public virtual DbSet<Adopter> Adopter { get; set; }
        public virtual DbSet<Amphibians> Amphibians { get; set; }
        public virtual DbSet<Animals> Animals { get; set; }
        public virtual DbSet<Birds> Birds { get; set; }
        public virtual DbSet<Fish> Fish { get; set; }
        public virtual DbSet<Mammals> Mammals { get; set; }
        public virtual DbSet<Reptiles> Reptiles { get; set; }
        public virtual DbSet<ReturnedAnimal> ReturnedAnimal { get; set; }
        public virtual DbSet<FoundRecord> FoundRecord { get; set; }
        public virtual DbSet<SystemRecord> SystemRecord { get; set; }
       public virtual DbSet<AnimalRecord> AnimalRecord { get; set; }
        public virtual DbSet<Balans> Balans { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<ContageusAnimals> ContageusAnimals { get; set; }
        public virtual DbSet<Euthanasia> Euthanasia { get; set; }
        public virtual DbSet<Food> Food { get; set; }
        public virtual DbSet<Funds> Funds { get; set; }
        public virtual DbSet<Labs> Labs { get; set; }
        public virtual DbSet<Medicines> Medicines { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Parameter> Parameter { get; set; }
        public virtual DbSet<Toys> Toys { get; set; }
        public virtual DbSet<VetVisits> VetVisits { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Identity configurations
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(l => new { l.LoginProvider, l.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
            modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("AspNetRoleClaims");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("AspNetUserTokens");




            // Adopted entity configuration
            modelBuilder.Entity<Adopted>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK__Adopted__A25C5AA69BF7B47B");

                entity.Property(e => e.AdoptionDate).HasColumnType("date");

                entity.HasOne(d => d.Adopter)
                    .WithMany(p => p.Adopted)
                    .HasForeignKey(d => d.AdopterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Adopted__Adopter__4E88ABD4");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.AdoptedNavigation)
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Adopted__AnimalI__4D94879B");
            });


            // Adopter entity configuration
            modelBuilder.Entity<Adopter>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__Adopter");

                // 🔸 Generira random broj 6 znamenki između 100000 i 999999 automatski u bazi
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("((ABS(CHECKSUM(NEWID())) % 900000) + 100000)")
                      .ValueGeneratedOnAdd(); // ✅ EF zna da ga generira baza

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Residence)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });


            // Animals entity configuration
            modelBuilder.Entity<Animals>(entity =>
            {
                entity.HasKey(e => e.AnimalCode);

                entity.Property(e => e.AnimalCode)
                    .IsRequired()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("NEWID()");

                // 🔹 IdAnimal — ručno unosiš, ali mora biti jedinstven
                entity.Property(e => e.IdAnimal)
                    .ValueGeneratedNever(); // ne generira se automatski
                entity.HasIndex(e => e.IdAnimal)
                    .IsUnique()
                    .HasName("UQ_Animals_IdAnimal");




                entity.Property(e => e.Family)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HealthIssues)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Length).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Picture)
                    .IsRequired()
                    .HasColumnType("varbinary(max)")
                    .IsUnicode(false);

                entity.Property(e => e.PersonalityDescription)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Species)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Subspecies)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");
            });

            //Birds
            modelBuilder.Entity<Birds>()
                    .HasKey(e => e.AnimalId)
                    .HasName("PK__Birds__A21A73070FA89F7C");  
            
            modelBuilder.Entity<Birds>()
                    .HasOne(d => d.Animal)
                    .WithOne(p => p.Birds)
                    .HasForeignKey<Birds>(d => d.AnimalId)
                    .HasPrincipalKey<Animals>(a => a.IdAnimal)

                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Birds__AnimalId__5812160E");
       
            modelBuilder.Entity<Amphibians>()
                     .HasKey(e => e.AnimalId)
                     .HasName("PK__Amphibians__A21A73070FA89F7C");

            modelBuilder.Entity<Amphibians>()
                    .HasOne(d => d.Animal)
                    .WithOne(d=>d.Amphibians)
                    .HasForeignKey<Amphibians>(d => d.AnimalId)
                    .HasPrincipalKey<Animals>(a => a.IdAnimal)
                    .HasConstraintName("FK__Amphibian__Anima__5CD6CB2B");

                // Fish 

                modelBuilder.Entity<Fish>()
                    .HasKey(e => e.AnimalId)
                    .HasName("PK__Fish__A21A73070FA89F7C");

                modelBuilder.Entity<Fish>()
                        .HasOne(d => d.Animal)
                        .WithOne(d=>d.Fish)
                        .HasForeignKey<Fish>(d => d.AnimalId)
                        .HasPrincipalKey<Animals>(a => a.IdAnimal)
                        .HasConstraintName("FK__Fish__AnimalId__5EBF139D");
                //Mammel

                modelBuilder.Entity<Mammals>()
                     .HasKey(e => e.AnimalId)
                     .HasName("PK__Mammals__A21A73070FA89F7C");

                modelBuilder.Entity<Mammals>()
                        .HasOne(d => d.Animal)
                        .WithOne(d=> d.Mammals)
                        .HasForeignKey<Mammals>(d => d.AnimalId)
                        .HasPrincipalKey<Animals>(a => a.IdAnimal)
                        .HasConstraintName("FK__Mammals__AnimalId__5EBF139D");


            //Reptile

                modelBuilder.Entity<Reptiles>()
                   .HasKey(e => e.AnimalId)
                   .HasName("PK__Reptiles__A21A73070FA89F7C");

                modelBuilder.Entity<Reptiles>()
                        .HasOne(d => d.Animal)
                        .WithOne(d=> d.Reptiles)
                        .HasForeignKey<Reptiles>(d => d.AnimalId)
                        .HasPrincipalKey<Animals>(a => a.IdAnimal)
                        .HasConstraintName("FK__Reptiles__AnimalId__5EBF139D");



            // ReturnedAnimal entity configuration
            modelBuilder.Entity<ReturnedAnimal>(entity =>
            {
                entity.HasKey(e => e.ReturnCode)
                    .HasName("PK__Returned__4CF726C86410F49F");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.ReturnReason)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Adopter)
                    .WithMany(p => p.ReturnedAnimal)
                    .HasForeignKey(d => d.AdopterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReturnedA__Adopt__534D60F1");

                entity.HasOne(d => d.AdoptionCodeNavigation)
                    .WithMany(p => p.ReturnedAnimal)
                    .HasForeignKey(d => d.AdoptionCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReturnedA__Adopt__5165187F");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.ReturnedAnimal)
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReturnedA__Anima__52593CB8");
            });
            //novo
            //

           modelBuilder.Entity<AnimalRecord>()
                  .HasKey(e => e.AnimalId)
                  .HasName("PK__AnimalRecord");

            modelBuilder.Entity<AnimalRecord>()
                .HasOne(r => r.Animal)
                .WithOne(a => a.AnimalRecord)
                .HasForeignKey<AnimalRecord>(a => a.AnimalId)
                .HasPrincipalKey<Animals>(a => a.IdAnimal)
                .HasConstraintName("FK__AnimalRecord__Animals__AnimalId");
 

            modelBuilder.Entity<AnimalRecord>()
                   .HasOne(d => d.Record)
                   .WithMany()
                   .HasForeignKey(d => d.RecordId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__AnimalRecord__SystemRecord__RecordId");
      

            modelBuilder.Entity<SystemRecord>(entity =>
               {
                  entity.HasKey(e => e.Id)
                        .HasName("PK__SystemRecord");


                  entity.Property(e => e.RecordName)
                        .IsRequired()
                        .HasMaxLength(255)
                        .IsUnicode(false);


                   entity.Property(e => e.RecordDescription)
                          .IsRequired()
                          .HasMaxLength(255)
                          .IsUnicode(false);


               });
            modelBuilder.Entity<SystemRecord>()
                .HasData(
                new SystemRecord {Id=1, RecordName="Arivall", RecordDescription= "Arivall"},
                new SystemRecord { Id = 2, RecordName = "First Vet Visit", RecordDescription = "First Vet Visit" },
                new SystemRecord { Id = 3, RecordName = "Quarantine", RecordDescription = "Quarantine" },
                new SystemRecord { Id = 4, RecordName = "Shelter", RecordDescription = "Shelter" },
                new SystemRecord { Id = 5, RecordName = "Socialized", RecordDescription = "Socialized" },
                new SystemRecord { Id = 6, RecordName = "Approve for Adoption", RecordDescription = "Approve for Adoption" },
                new SystemRecord { Id = 7, RecordName = "Adopted", RecordDescription = "Adopted" },
                new SystemRecord { Id = 8, RecordName = "Euthanasia", RecordDescription = "Euthanasia" },
                new SystemRecord { Id = 9, RecordName = "Returnd", RecordDescription = "Returnd" }
                );

            modelBuilder.Entity<Balans>(entity =>
            {//.IsUnique();
                entity.HasKey(e => e.Id)
                 .HasName("PK__Balans");

                entity.Property(e => e.Iban)
                .IsRequired()
                .HasMaxLength(21)
                .IsUnicode(false);

                entity.Property(e => e.Balance).HasColumnType("decimal(20, 2)");

                entity.HasIndex(e => e.Iban)
                   .IsUnique();

                entity.Property(e=>e.Iban)
                .IsRequired()
                .HasMaxLength(21)
                .IsUnicode(false);

                entity.Property(e => e.LastUpdated)
                .HasDefaultValue()
                .IsRequired();
            });


            modelBuilder.Entity<Transactions>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("Pk__Transactions");
            });

            // 🔹 Balans veza – ostaje obavezna (uvijek postoji shelter račun)
            modelBuilder.Entity<Transactions>()
                .HasOne(b => b.Balans)
                .WithMany()
                .HasForeignKey(i => i.IbanAnimalShelter)
                .HasPrincipalKey(i => i.Iban)
                .IsRequired(true);

            // 🔹 Funds veza – postaje neobavezna (donacije ili vanjske uplate)
            modelBuilder.Entity<Transactions>()
               .HasOne(b => b.Funds)
               .WithMany()
               .HasForeignKey(i => i.Iban)
               .HasPrincipalKey(i => i.Iban)
               .IsRequired(false); // ❗ OVO DODAŠ


            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Contact");

                entity.HasOne(d => d.Adopter)
                    .WithMany()
                    .HasForeignKey(d => d.AdopterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contact__Adopter");

                entity.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.Description)
                  .IsRequired()
                  .HasMaxLength(255)
                  .IsUnicode(false);

                entity.Property(e => e.Email)
                  .IsRequired()
                  .HasMaxLength(50)
                  .IsUnicode(false);

            });


            modelBuilder.Entity<ContageusAnimals>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__ContageusAnimals");

                entity.HasOne(d => d.Animals)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ContageusAnimals__Animal");

                entity.Property(e => e.DesisseName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);


            });


            modelBuilder.Entity<Euthanasia>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Euthanasia");

                entity.HasOne(d => d.Animals)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)

                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Euthanasia__Animal");

                entity.Property(e => e.NameOfDesissse)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);


            });
            modelBuilder.Entity<Food>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Food");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.BrandName)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

                entity.Property(e => e.FoodType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.AnimalType)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.AgeGroup)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CaloriesPerServing).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.WeightPerServing).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FatContent).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.FiberContent).HasColumnType("decimal(10, 4)");

                entity.Property(e => e.MeasurementPerServing)
                 .IsRequired()
                 .HasMaxLength(5)
                 .IsUnicode(false);

                entity.Property(e => e.MeasurementWeight)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

                entity.Property(e => e.Notes)
                .IsRequired()
                .HasMaxLength(1000)
                .IsUnicode(false);
            });

            modelBuilder.Entity<FoundRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__FoundRecord");


                entity.HasOne(d => d.Animal)
                    .WithMany(d=>d.FoundRecord)
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)

                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FoundRecord__Animal");

                entity.HasOne(d => d.User)
                   .WithMany()
                   .HasForeignKey(d => d.RegisterId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__FoundRecord__User");

                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.Adress)
                   .IsRequired()
                   .HasMaxLength(150)
                   .IsUnicode(false);

                entity.Property(e => e.OwnerName)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.OwnerSurname)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.OwnerPhoneNumber)
                   .IsRequired()
                   .HasMaxLength(13)
                   .IsUnicode(false);

                entity.Property(e => e.OwnerOIB)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

            });


            modelBuilder.Entity<Funds>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Funds");
                entity.Property(e => e.Iban)
                 .IsRequired()
                 .HasMaxLength(21)
                 .IsUnicode(false);

                entity.HasOne(d => d.Adopter)
                 .WithMany()
                 .HasForeignKey(d => d.AdopterId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK__Funds__Adopter");

                entity.Property(e => e.Purpose)
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.Amount).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.DateTimed)
                 .HasDefaultValue()
                 .IsRequired();
            });

            modelBuilder.Entity<Labs>(entity =>
            {
                entity.HasKey(e => e.Id)
                      .HasName("PK__Labs");

                // 🔸 Random 6-znamenkasti ID generiran na SQL strani
                entity.Property(e => e.Id)
                      .HasDefaultValueSql("((ABS(CHECKSUM(NEWID())) % 900000) + 100000)")
                      .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Animal)
                      .WithMany()
                      .HasForeignKey(d => d.AnimalId)
                      .HasPrincipalKey(a => a.IdAnimal)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Labs__Animals");
            });


            modelBuilder.Entity<Medicines>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Medicines");

                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)

                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Medicines__Animal");

                entity.Property(e => e.NameOfMedicines)
                 .IsRequired()
                 .HasMaxLength(50)
                 .IsUnicode(false);

                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);

                entity.Property(e => e.VetUsername)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.MesurmentUnit)
                   .IsRequired()
                   .HasMaxLength(10)
                   .IsUnicode(false);

                entity.Property(e => e.FrequencyOfMedicationUse)
                   .IsRequired()
                   .HasMaxLength(50)
                   .IsUnicode(false);

                entity.Property(e => e.AmountOfMedicine).HasColumnType("decimal(20, 6)");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__News");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                   .IsRequired()
                   .HasMaxLength(50000)
                   .IsUnicode(false);


            });
              modelBuilder.Entity<Parameter>(entity =>
                        {
                            entity.HasKey(e => e.Id)
                             .HasName("PK__Parameter");
             
              modelBuilder.Entity<Parameter>()
                 .HasOne(a => a.Labs)
                 .WithMany()
                 .HasForeignKey(a => a.LabId)
                 .HasConstraintName("FK__Parameter__Lab")
                 .OnDelete(DeleteBehavior.ClientSetNull);

                entity.Property(e => e.ParameterName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.MeasurementUnits)
               .IsRequired()
               .HasMaxLength(10)
               .IsUnicode(false);

                entity.Property(e => e.Remarks)
               .IsRequired()
               .HasMaxLength(100)
               .IsUnicode(false);

                entity.Property(e => e.ParameterValue).HasColumnType("decimal(10, 4)");
            });



            modelBuilder.Entity<Toys>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__Toys");

                entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

                entity.Property(e => e.BrandName)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.AnimalType)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.ToyType)
               .IsRequired()
               .HasMaxLength(50)
               .IsUnicode(false);

                entity.Property(e => e.AgeGroup)
                .IsRequired()
                .HasMaxLength(10)
                .IsUnicode(false);

                entity.Property(e => e.Notes)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(20, 2)");
                entity.Property(e => e.Hight).HasColumnType("decimal(10,2 )");
                entity.Property(e => e.Width).HasColumnType("decimal(10,2 )");
            });


            modelBuilder.Entity<VetVisits>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__VetVisits");

                entity.HasOne(d => d.Animals)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .HasPrincipalKey(a => a.IdAnimal)

                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VetVisits__Animal");

                entity.Property(e => e.TypeOfVisit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Notes)
                   .IsRequired()
                   .HasMaxLength(255)
                   .IsUnicode(false);


           
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}