using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FormativaWeb.Pages;

public class FilaComparativa
{
    public string Caracteristica { get; set; } = "";
    public string Valor { get; set; } = "";
    public string Control { get; set; } = "";
    public string ColorBadge { get; set; } = "";
}

public class ComparativaModel : PageModel
{
    public List<FilaComparativa> FilasComparativa { get; set; } = [];

    public void OnGet()
    {
        FilasComparativa =
        [
            new()
            {
                Caracteristica = "Máximo control del HTML",
                Valor = "Control total del diseño",
                Control = "Repeater",
                ColorBadge = "success",
            },
            new()
            {
                Caracteristica = "Paginación automática",
                Valor = "Sin necesidad de código extra",
                Control = "GridView",
                ColorBadge = "primary",
            },
            new()
            {
                Caracteristica = "CRUD rápido (editar/borrar)",
                Valor = "Botones integrados automáticos",
                Control = "GridView",
                ColorBadge = "primary",
            },
            new()
            {
                Caracteristica = "Diseño en Cards / Catálogo",
                Valor = "HTML libre por registro",
                Control = "Repeater",
                ColorBadge = "success",
            },
            new()
            {
                Caracteristica = "Mejor rendimiento",
                Valor = "Mínimo ViewState generado",
                Control = "Repeater",
                ColorBadge = "success",
            },
            new()
            {
                Caracteristica = "Paginación + diseño propio",
                Valor = "DataPager + plantillas",
                Control = "ListView",
                ColorBadge = "warning",
            },
            new()
            {
                Caracteristica = "Proyectos académicos rápidos",
                Valor = "Implementación inmediata",
                Control = "GridView",
                ColorBadge = "primary",
            },
            new()
            {
                Caracteristica = "Proyectos reales con diseño",
                Valor = "Interfaz visualmente rica",
                Control = "Repeater",
                ColorBadge = "success",
            },
        ];
    }
}
