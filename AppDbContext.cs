using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Boleto> Boletos { get; set; }
    public DbSet<Banco> Bancos { get; set; }
}