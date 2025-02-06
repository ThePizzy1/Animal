using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ANIMAL.DAL.DataModel
{
    public partial class AnimalRescueDbContext : IdentityDbContext<ApplicationUser>
    {  
        public AnimalRescueDbContext(DbContextOptions<AnimalRescueDbContext> options)
            : base(options)
        {
        }

        public AnimalRescueDbContext()
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



            modelBuilder.Entity<Balans>(entity =>
            {
                entity.HasKey(b => b.Id);
                entity.Property(b => b.Balance)
               .HasColumnType("decimal(18,2)");
            });



            modelBuilder.Entity<Funds>(entity => {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.Amount)
                .HasColumnType("decimal(18,2)");

                entity.HasOne(f => f.Adopter)
                   .WithMany()
                   .HasForeignKey(f => f.AdopterId);
            });


            modelBuilder.Entity<Food>(entity => {
                entity.HasKey(f => f.Id);

                entity.Property(f => f.FatContent)
                .HasColumnType("decimal(5,2)");

                entity.Property(f => f.FiberContent)
                  .HasColumnType("decimal(5,2)");

                entity.Property(f => f.CaloriesPerServing)
                 .HasColumnType("decimal(6,2)");
            });


            modelBuilder.Entity<FoundRecord>(entity => {
                entity.HasKey(fr => fr.Id);

                entity.Property(fr => fr.OwnerOIB)
                  .HasMaxLength(11)
                  .IsFixedLength();

                entity.HasOne(fr => fr.Animal)
                   .WithMany()
                   .HasForeignKey(fr => fr.AnimalId);
            });


            modelBuilder.Entity<Toys>(entity => {
                entity.HasKey(t => t.Id);

                entity.Property(t => t.Hight)
                 .HasColumnType("decimal(5,2)");

                entity.Property(t => t.Width)
                 .HasColumnType("decimal(5,2)");

            });


            modelBuilder.Entity<VetVisits>(entity =>
            {
                entity.HasKey(vv => vv.Id);

                entity.HasOne(d => d.Animals)
                     .WithMany()
                     .HasForeignKey(d => d.AnimalId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK__VetVisits__AnimalI");



            });

            modelBuilder.Entity<Contact>(entity => {
                entity.HasKey(c => c.Id);

                entity.HasOne(c => c.Adopter)
                    .WithMany()
                    .HasForeignKey(c => c.AdopterId);

            });

            modelBuilder.Entity<ContageusAnimals>(entity => {
                entity.HasKey(ca => ca.Id);

                entity.HasOne(d => d.Animals)
                        .WithMany()
                        .HasForeignKey(d => d.AnimalId)
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContageusAnimals__AnimalI");

            });


            modelBuilder.Entity<Euthanasia>(entity => {
                entity.HasKey(e => e.Id);

                entity.HasOne(d => d.Animals)
                     .WithMany()
                     .HasForeignKey(d => d.AnimalId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK__Euthanasia__AnimalI");

            });


            modelBuilder.Entity<Labs>(entity => {
                entity.HasKey(l => l.Id);

                entity.HasOne(d => d.Animals)
                     .WithMany()
                     .HasForeignKey(d => d.AnimalId)
                     .OnDelete(DeleteBehavior.ClientSetNull)
                     .HasConstraintName("FK__Labs__AnimalI");

            });


            modelBuilder.Entity<Medicines>(entity => {
                entity.HasKey(m => m.Id);

                entity.HasOne(d => d.Animal)
                       .WithMany()
                       .HasForeignKey(d => d.AnimalId)
                       .OnDelete(DeleteBehavior.ClientSetNull)
                       .HasConstraintName("FK__Medicines__AnimalI");
            });


            modelBuilder.Entity<Parameter>(entity => {
                entity.HasKey(p => p.Id);

                entity.HasOne<Labs>()
                  .WithMany(l => l.Parameters)
                  .HasForeignKey(p => p.LabId);
            });














            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}