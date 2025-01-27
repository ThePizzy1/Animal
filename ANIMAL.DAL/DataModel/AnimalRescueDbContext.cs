using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ANIMAL.DAL.DataModel
{
    public partial class AnimalRescueDbContext : IdentityDbContext<ApplicationUser>
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
        //public virtual DbSet<FoundRecord> FoundRecord { get; set; }
        public virtual DbSet<SystemRecord> SystemRecord { get; set; }
       public virtual DbSet<AnimalRecord> AnimalRecord { get; set; }

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Adopted__AnimalI__4D94879B");
            });
      

            // Adopter entity configuration
            modelBuilder.Entity<Adopter>(entity =>
            {
                entity.Property(e => e.DateOfBirth).HasColumnType("date");

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

                entity.Property(e => e.NumAdoptedAnimals)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NumReturnedAnimals)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            // Amphibians entity configuration
            modelBuilder.Entity<Amphibians>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Humidity).HasColumnType("decimal(5, 2)");

                entity.Property(e => e.Temperature).HasColumnType("decimal(5, 2)");

                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Amphibian__Anima__5CD6CB2B");
            });

            // Animals entity configuration
            modelBuilder.Entity<Animals>(entity =>
            {
                entity.HasKey(e => e.IdAnimal)
                    .HasName("PK__Animals__951092F0A1868E05");

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

            // Birds entity configuration
            modelBuilder.Entity<Birds>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__Birds__A21A73070FA89F7C");

                entity.Property(e => e.AnimalId).ValueGeneratedNever();

                entity.Property(e => e.CageSize)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedToys)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Sociability)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Animal)
                    .WithOne(p => p.Birds)
                    .HasForeignKey<Birds>(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Birds__AnimalId__5812160E");
            });

            // Fish entity configuration
            modelBuilder.Entity<Fish>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CompatibleSpecies)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedItems)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TankSize)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Fish__AnimalId__5EBF139D");
            });

            // Mammals entity configuration
            modelBuilder.Entity<Mammals>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.CoatType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GroomingProducts)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Mammals__AnimalI__5535A963");
            });

            // Reptiles entity configuration
            modelBuilder.Entity<Reptiles>(entity =>
            {
                entity.HasKey(e => e.AnimalId)
                    .HasName("PK__Reptiles__A21A7307D28BF62E");

                entity.Property(e => e.AnimalId).ValueGeneratedNever();

                entity.Property(e => e.CompatibleSpecies)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.RecommendedItems)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Sociability)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TankSize)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Animal)
                    .WithOne(p => p.Reptiles)
                    .HasForeignKey<Reptiles>(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Reptiles__Animal__5AEE82B9");
            });

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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReturnedA__Anima__52593CB8");
            });

            modelBuilder.Entity<AnimalRecord>(entity =>
            {
                entity.HasKey(e => e.Id)
                 .HasName("PK__AnimalRecord");


                entity.HasOne(d => d.Animal)
                    .WithMany()
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AnimalRecord__Animal");
                entity.HasOne(d => d.Record)
                   .WithMany()
                   .HasForeignKey(d => d.RecordId)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK__AnimalRecord__Record");



            });










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

                entity.Property(e => e.RecordNumber)
                .HasColumnType("integer");

            });
         






            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}