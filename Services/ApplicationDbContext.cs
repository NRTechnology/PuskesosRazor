using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PuskesosRazor.Services
{
  public class ApplicationDbContext : IdentityDbContext
  {
    public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      base.OnModelCreating(builder);

      var administrator = new IdentityRole("Administrator")
      {
        NormalizedName = "Administrator"
      };

      var bpjs = new IdentityRole("BPJS")
      {
        NormalizedName = "BPJS"
      };

      builder.Entity<IdentityRole>().HasData(administrator, bpjs);
    }
  }
}
