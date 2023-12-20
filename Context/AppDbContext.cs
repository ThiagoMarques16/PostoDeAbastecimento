using Microsoft.EntityFrameworkCore;
using ListaDePostos.Models;

namespace ListaDePostos.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<PostoDeAbastecimento> PostosDeAbastecimento { get; set; }
    }
}
