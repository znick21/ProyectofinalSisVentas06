using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcSistemaVentas.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        // Propiedad que representa el Id del usuario asociado a la venta
        public string IdUsuario { get; set; }

        // Propiedad de navegación que representa al usuario asociado a la venta
        [ForeignKey("IdUsuario")]
        public ApplicationUser Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese el monto total")]
        [Display(Name = "Monto Total")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        // Relación con Proveedor
        [Required(ErrorMessage = "Seleccione un proveedor")]
        [Display(Name = "Proveedor")]
        public int ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }

        // Colección de detalles de compra
        public ICollection<DetalleCompra> DetalleCompras { get; set; }
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }
    }
}
