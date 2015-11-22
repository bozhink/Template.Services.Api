namespace Application.Data
{
    using Models;
    using Repositories;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            ////modelBuilder
            ////    .Entity<ApplicationUser>()
            ////    .HasMany

            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}