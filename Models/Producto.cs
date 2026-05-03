namespace FormativaWeb.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Categoria { get; set; } = "";
        public decimal Precio { get; set; }
        public string Descripcion { get; set; } = "";
        public string Icono { get; set; } = "";
        public string Color { get; set; } = "";
    }

    public static class DatosProductos
    {
        public static List<Producto> ObtenerProductos() =>
            [
                new()
                {
                    Id = 1,
                    Nombre = "Laptop Dell XPS 15",
                    Categoria = "Tecnología",
                    Precio = 4500000,
                    Descripcion =
                        "Laptop de alta gama con procesador Intel i9 y 32GB RAM, ideal para desarrollo de software.",
                    Icono = "💻",
                    Color = "primary",
                },
                new()
                {
                    Id = 2,
                    Nombre = "Mouse Logitech MX Master",
                    Categoria = "Periféricos",
                    Precio = 185000,
                    Descripcion =
                        "Mouse ergonómico inalámbrico con conexión Bluetooth y hasta 3 dispositivos.",
                    Icono = "🖱️",
                    Color = "success",
                },
                new()
                {
                    Id = 3,
                    Nombre = "Teclado Mecánico RGB",
                    Categoria = "Periféricos",
                    Precio = 320000,
                    Descripcion =
                        "Teclado mecánico con switches Cherry MX Red e iluminación RGB personalizable.",
                    Icono = "⌨️",
                    Color = "warning",
                },
                new()
                {
                    Id = 4,
                    Nombre = "Monitor Samsung 27\"",
                    Categoria = "Tecnología",
                    Precio = 1200000,
                    Descripcion =
                        "Monitor IPS 4K 144Hz con soporte HDR, perfecto para gaming y diseño.",
                    Icono = "🖥️",
                    Color = "info",
                },
                new()
                {
                    Id = 5,
                    Nombre = "Audífonos Sony WH-1000XM5",
                    Categoria = "Audio",
                    Precio = 780000,
                    Descripcion =
                        "Audífonos inalámbricos con cancelación de ruido activa de última generación.",
                    Icono = "🎧",
                    Color = "danger",
                },
                new()
                {
                    Id = 6,
                    Nombre = "Webcam Logitech 4K Pro",
                    Categoria = "Periféricos",
                    Precio = 390000,
                    Descripcion =
                        "Cámara web 4K con HDR y corrección de luz automática, ideal para streaming.",
                    Icono = "📸",
                    Color = "secondary",
                },
            ];
    }
}
