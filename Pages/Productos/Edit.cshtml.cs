using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TiendaWeb.Models;
using TiendaWeb.Data;

namespace TiendaWeb.Pages.Productos;

public class EditModel : PageModel
{
    private readonly TiendaContext _context;

    public EditModel(TiendaContext context)
    {
        _context = context;
    }

    [BindProperty]
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
        Producto = producto;
        return Page();
    }

    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Attach(Producto).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProductoExists(Producto.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("./Index");
    }

    private bool ProductoExists(int id)
    {
        return _context.Productos.Any(e => e.Id == id);
    }
}
