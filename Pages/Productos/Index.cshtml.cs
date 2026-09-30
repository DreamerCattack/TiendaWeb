using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Models;
using TiendaWeb.Data;

namespace TiendaWeb.Pages.Productos;

public class IndexModel : PageModel
{
    private readonly TiendaContext _context;

    public IndexModel(TiendaContext context)
    {
        _context = context;
    }

    public IList<Producto> Producto { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Producto = await _context.Productos.ToListAsync();
    }
}
