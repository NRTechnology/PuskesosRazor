using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PuskesosRazor.Models;

namespace PuskesosRazor.Services
{
  public class ApplicationDbContext : IdentityDbContext
  {

    public DbSet<Kecamatan> Kecamatan { get; set; }

    public DbSet<Desa> Desa { get; set; }

    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      const string useradminId = "a18be9c0-aa65-4af8-bd17-00bd9344e575";
      const string adminroleId = "f815e476-8b49-405e-80c9-9663ec76420e";

      var administrator = new IdentityRole("Administrator")
      {
        Id = adminroleId,
        NormalizedName = "Administrator"
      };

      var bpjs = new IdentityRole("BPJS")
      {
        NormalizedName = "BPJS"
      };

      builder.Entity<IdentityRole>().HasData(administrator, bpjs);

      var hasher = new PasswordHasher<IdentityUser>();
      builder.Entity<IdentityUser>().HasData(new IdentityUser
      {
        Id = useradminId,
        UserName = "admin",
        NormalizedUserName = "admin",
        Email = "admin@gmail.com",
        NormalizedEmail = "admin@gmail.com",
        EmailConfirmed = true,
        PasswordHash = hasher.HashPassword(null!, "Admin123#"),
        SecurityStamp = string.Empty
      });

      builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
      {
        RoleId = adminroleId,
        UserId = useradminId
      });
    }
  }
}
