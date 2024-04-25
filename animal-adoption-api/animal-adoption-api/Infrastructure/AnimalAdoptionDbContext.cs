using animal.adoption.api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace animal.adoption.api.Infrastructure
{
    public class AnimalAdoptionDbContext: IdentityDbContext<USER, USER_ROLE, int>
    {
        public AnimalAdoptionDbContext()
        {
        }

        public AnimalAdoptionDbContext(DbContextOptions<AnimalAdoptionDbContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<USER>(b =>
            {
                b.ToTable("user");
            });

            builder.Entity<USER_ROLE>(b =>
            {
                b.ToTable("user_role");
            });
        }

        public DbSet<USER> user { get; set; }
        public DbSet<USER_ROLE> user_role { get; set; }
        public DbSet<STATIC_DATA> static_data { get; set; }
        public DbSet<POST> post { get; set; }
        public DbSet<PET> pet { get; set; }
        public DbSet<EmailRequest>  email_request { get; set; }
        public DbSet<OTPVerification> otp_verification { get; set; }
       

    }
}
