using FormativaWeb.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormativaWeb.Pages;

public class RepeaterModel : PageModel
{
    public List<Producto> Productos { get; set; } = [];

    public void OnGet()
    {
        Productos = DatosProductos.ObtenerProductos();
    }
}
