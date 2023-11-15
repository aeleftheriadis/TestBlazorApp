using Duende.IdentityServer.EntityFramework.Options;

using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

using TestBlazorApp.Server.Models;

namespace TestBlazorApp.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasData
                (
                 new Employee
                 {
                     Id = Guid.NewGuid(),
                     Name = "Mark",
                     AccountNumber = "123-3452134543-32",
                     Age = 30
                 },
                 new Employee
                 {
                     Id = Guid.NewGuid(),
                     Name = "Evelin",
                     AccountNumber = "123-9384613085-55",
                     Age = 28
                 }
                );
        }
        public DbSet<Employee>? Employees { get; set; }
    }
}