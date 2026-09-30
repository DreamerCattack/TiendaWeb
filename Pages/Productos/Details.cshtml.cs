using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Models;
using TiendaWeb.Data;

namespace TiendaWeb.Pages.Productos;

public class DetailsModel : PageModel
{
    private readonly TiendaContext _context;
    public DetailsModel(TiendaContext context)
    {
        _context = context;
    }

    public Producto Producto { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var producto = await _context.Productos.FirstOrDefaultAsync(m => m.Id == id);
        if (producto is null)
        {
            return NotFound();
        }
        else
        {
            Producto = producto;
        }

        return Page();
    }
}
