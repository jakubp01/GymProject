using GymProject.Areas.Identity.Data;
using GymProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GymProject.Areas.Identity.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new AppUserEntityConfig());

    }

    public DbSet<Client> Clients { get; set; }

    public DbSet<SingleEntry> SingleEntries { get; set; }

    public DbSet<Carnet> Carnets { get; set; }

}
