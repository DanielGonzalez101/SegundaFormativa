# Segunda Formativa — ASP.NET Repeater
**Universidad Autónoma del Caribe · Sesión Abril 26 de 2026**

---

## ¿Qué se hizo?

Se creó un aplicativo web en **ASP.NET Core Razor Pages** (`.NET 10`) que demuestra el concepto del control **Repeater** de ASP.NET Web Forms, simulando sus 4 plantillas mediante la sintaxis Razor (`@foreach` + `if/else`).

> **¿Por qué Razor Pages y no Web Forms puro?**
> ASP.NET Web Forms (`System.Web`) solo corre en Windows con .NET Framework 4.x.
> El proyecto fue desarrollado en macOS, por lo que se usó Razor Pages como equivalente moderno y ejecutable en Mac.
> El proyecto Web Forms con el Repeater real también fue creado en `../FormativaRepeater/`.

---

## Comando para crear el proyecto

```bash
dotnet new webapp -n FormativaWeb --no-https
```

---

## Estructura del proyecto

```
FormativaWeb/
├── Models/
│   └── Producto.cs          # Modelo de datos + lista hardcodeada
├── Pages/
│   ├── Shared/
│   │   └── _Layout.cshtml   # Layout compartido con navbar y footer
│   ├── Index.cshtml          # Página de inicio — explicación del Repeater
│   ├── Index.cshtml.cs
│   ├── Repeater.cshtml       # ★ Punto 3: todas las plantillas en una tabla
│   ├── Repeater.cshtml.cs
│   ├── Cards.cshtml          # ★ Punto 2: cards con el patrón Repeater
│   ├── Cards.cshtml.cs
│   ├── Comparativa.cshtml    # ★ Punto 4: comparativa GridView vs ListView vs Repeater
│   └── Comparativa.cshtml.cs
├── wwwroot/                  # Bootstrap y archivos estáticos
├── Program.cs
└── DOCUMENTACION.md          # Este archivo
```

---

## Cómo correr el proyecto

```bash
cd "/ruta/a/Formativa 2/FormativaWeb"
dotnet run
```

Luego abrir en el navegador: **http://localhost:5098**

---

## Páginas y qué hace cada una

### 1. `/` — Index (Inicio)
Explica teóricamente qué es el Repeater, sus 4 plantillas y cuándo usarlo.
Incluye una tabla comparativa de plantillas y botones de navegación a las demás secciones.

### 2. `/Repeater` — Plantillas en acción ★ Punto 3
Demuestra visualmente el uso de las 4 plantillas del Repeater sobre una tabla de productos.

| Plantilla | Color en pantalla | Cuándo aparece |
|-----------|-------------------|----------------|
| `HeaderTemplate` | Fondo negro `#212529` | Una vez — encabezados de la tabla |
| `ItemTemplate` | Fondo blanco | Registros en posición impar (1°, 3°, 5°...) |
| `AlternatingItemTemplate` | Fondo azul claro `#cfe2ff` | Registros en posición par (2°, 4°, 6°...) |
| `FooterTemplate` | Fondo verde `#198754` | Una vez — fila de resumen con total de productos |

Cada fila lleva un badge pequeño indicando qué plantilla la generó.

### 3. `/Cards` — Cards con Repeater ★ Punto 2
Muestra los mismos productos en formato de **tarjetas Bootstrap** (cards).

- `HeaderTemplate` → barra azul de título que abre el contenedor de tarjetas
- `ItemTemplate` → card con fondo blanco (registros impares)
- `AlternatingItemTemplate` → card con degradado azul-morado (registros pares)
- `FooterTemplate` → barra verde de cierre con el total de productos

### 4. `/Comparativa` — Comparativa ★ Punto 4
Tabla detallada comparando los tres controles:

| Característica | GridView | ListView | Repeater |
|----------------|----------|----------|----------|
| Control del HTML | ✗ automático | ◑ plantillas | ✓ total |
| Paginación | ✓ automática | ✓ DataPager | ✗ manual |
| Ordenamiento | ✓ automático | ✗ | ✗ |
| Edición/Eliminación | ✓ | ✓ | ✗ |
| Rendimiento | ✗ pesado | ◑ medio | ✓ ligero |
| Diseño libre | ✗ | ◑ | ✓ ideal |
| Caso de uso | CRUD rápido | Listas paginadas | Cards, catálogos |

La tabla inferior de la página **usa el propio patrón Repeater** para renderizarse.

---

## Equivalencia entre Web Forms y Razor Pages

### En Web Forms (`.aspx`) — Repeater real

```aspx
<asp:Repeater ID="rptProductos" runat="server">

    <HeaderTemplate>
        <table><thead><tr><th>Nombre</th></tr></thead><tbody>
    </HeaderTemplate>

    <ItemTemplate>
        <tr style="background:white">
            <td><%# Eval("Nombre") %></td>
        </tr>
    </ItemTemplate>

    <AlternatingItemTemplate>
        <tr style="background:#cfe2ff">
            <td><%# Eval("Nombre") %></td>
        </tr>
    </AlternatingItemTemplate>

    <FooterTemplate>
        </tbody></table>
    </FooterTemplate>

</asp:Repeater>
```

**Code-behind (`.aspx.cs`):**
```csharp
protected void Page_Load(object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        rptProductos.DataSource = DatosProductos.ObtenerProductos();
        rptProductos.DataBind(); // ← OBLIGATORIO
    }
}
```

---

### En Razor Pages (`.cshtml`) — Equivalente usado en este proyecto

```cshtml
@{
    int i = 0;
}

@* === HeaderTemplate === *@
<table>
    <thead>...</thead>
    <tbody>

        @foreach (var producto in Model.Productos)
        {
            if (i % 2 == 0)
            {
                @* === ItemTemplate (registros impares) === *@
                <tr style="background:white">
                    <td>@producto.Nombre</td>
                </tr>
            }
            else
            {
                @* === AlternatingItemTemplate (registros pares) === *@
                <tr style="background:#cfe2ff">
                    <td>@producto.Nombre</td>
                </tr>
            }
            i++;
        }

    </tbody>

    @* === FooterTemplate === *@
    <tfoot>
        <tr><td>Total: @Model.Productos.Count</td></tr>
    </tfoot>
</table>
```

**PageModel (`.cshtml.cs`):**
```csharp
public class RepeaterModel : PageModel
{
    public List<Producto> Productos { get; set; } = [];

    public void OnGet()
    {
        // Equivale a DataSource + DataBind() del Repeater
        Productos = DatosProductos.ObtenerProductos();
    }
}
```

---

## Modelo de datos (`Models/Producto.cs`)

```csharp
public class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Categoria { get; set; }
    public decimal Precio { get; set; }
    public string Descripcion { get; set; }
    public string Icono { get; set; }
    public string Color { get; set; }
}
```

Los datos son una lista hardcodeada de 6 productos tecnológicos definida en `DatosProductos.ObtenerProductos()`.

---

## Puntos de la tarea cubiertos

| # | Punto | Dónde se evidencia |
|---|-------|--------------------|
| 1 | Investigar Repeater | `Index.cshtml` — definición, plantillas, cuándo usarlo |
| 2 | ¿Qué son las Cards y cómo se acopla con Repeater? | `Cards.cshtml` — explicación + demo visual |
| 3 | Aplicativo con uso de cada plantilla | `Repeater.cshtml` — tabla con las 4 plantillas diferenciadas por color |
| 4 | Comparativa GridView vs ListView vs Repeater | `Comparativa.cshtml` — tarjetas resumen + tabla detallada |
