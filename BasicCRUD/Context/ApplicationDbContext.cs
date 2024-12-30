using BasicCRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicCRUD.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)  { }

    public DbSet<Pessoa> Pessoa { get; set; }
}
