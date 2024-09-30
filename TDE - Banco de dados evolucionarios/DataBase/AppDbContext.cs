using Microsoft.EntityFrameworkCore;
using TDE___Banco_de_dados_evolucionarios.Entities;

namespace TDE___Banco_de_dados_evolucionarios.DataBase;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
}
