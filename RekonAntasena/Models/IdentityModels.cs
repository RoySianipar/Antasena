using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RekonAntasena.Models.Master;
using RekonAntasena.Models.Transaksi;

namespace RekonAntasena.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<DataAntasena> DataAntasena { get; set; }
        public DbSet<LHBU> LHBU { get; set; }
        public DbSet<Transaksis> Transaksi { get; set; }
        public DbSet<TrDataLHBU> TrDataLHBU { get; set; }
        public DbSet<TrDataAntasena> TrDataAntasena { get; set; }
        public DbSet<Status> Status { get; set; }
        public ApplicationDbContext()
            : base("RekonAntasena", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        internal object entry(object entity)
        {
            throw new NotImplementedException();
        }
    }
}