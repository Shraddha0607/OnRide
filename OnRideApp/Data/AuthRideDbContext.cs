using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace OnRideApp.Data;

public class AuthRideDbContext : IdentityDbContext
{
    public AuthRideDbContext(DbContextOptions<AuthRideDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var userRoleId = "ed2c9038-d12d-4667-83d7-4ea043ffd8f4";
        var adminRoleId = "5ea78d9d-9080-4a2c-83d9-8d181c3621d8";

        var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp= adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            };

        builder.Entity<IdentityRole>().HasData(roles);
    }
}