using Microsoft.EntityFrameworkCore;

namespace BelajarPostGre.Entity
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id)
                .HasName("user_pkey");
                entity.HasMany<Address>(e => e.Addresses)
                .WithOne(e => e.User).HasConstraintName("t__Adress_fkey").IsRequired();
            });

        }
    }
}
