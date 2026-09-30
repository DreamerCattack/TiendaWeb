using Microsoft.EntityFrameworkCore;
using TiendaWeb.Models;

namespace TiendaWeb.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = default!;
    }
}
