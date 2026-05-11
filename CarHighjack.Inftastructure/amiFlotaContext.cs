using CarHighjack.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarHighjack.Inftastructure
{
    public class AmiFlotaContext : IdentityDbContext<IdentityUser>
    {
        public AmiFlotaContext(DbContextOptions<AmiFlotaContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}