using ArBackend.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ArBackend.Api.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Model3d> Model3Ds { get; set; } = null!;
}
