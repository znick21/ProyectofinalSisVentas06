using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Models
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        public int VentaId { get; set; } // Corregido: Agregar tipo de dato y nombre de la propiedad
        public int ProductoId { get; set; } // Corregido: Agregar tipo de dato y nombre de la propiedad

        [Required(ErrorMessage = "Ingrese el precio de venta")]
        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el subtotal")]
        [Display(Name = "Subtotal")]
        public decimal Subtotal { get; set; }  // Nueva propiedad para el subtotal

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; } // Corregido: Cambiado DateOnly a DateTime

        [ForeignKey("VentaId")] // Corregido: Agregado ForeignKey con nombre de la propiedad correspondiente
        public Venta Venta { get; set; } // Agregado: Propiedad de navegación para Venta

        [ForeignKey("ProductoId")] // Corregido: Agregado ForeignKey con nombre de la propiedad correspondiente
        public Producto Producto { get; set; } // Agregado: Propiedad de navegación para Producto
    }
}
