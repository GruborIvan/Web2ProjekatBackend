using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Web2ProjekatBackend.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Ekipa> Ekipe { get; set; }
        public DbSet<Element> Elementi { get; set; }
        public DbSet<NalogRada> NaloziRada { get; set; }
        public DbSet<PlanRada> PlanoviRada { get; set; }
        public DbSet<Poruka> Poruke { get; set; }
        public DbSet<Potrosac> Potrosaci { get; set; }
        public DbSet<Poziv> Pozivi { get; set; }
        public DbSet<Resolution> Resolutions { get; set; }
        public DbSet<SafetyDocument> SafetyDocuments { get; set; }
        public DbSet<UserInfo> UserInfos { get; set; }
        public DbSet<Oprema> Oprema { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}