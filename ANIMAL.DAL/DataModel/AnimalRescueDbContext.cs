using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ANIMAL.DAL.DataModel
{
    public partial class AnimalRescueDbContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AnimalRescue;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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
            });

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
