using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using mvcSistemaVentas.Models.ViewModels;

namespace mvcSistemaVentas.Models
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        // Propiedad que representa el Id del usuario asociado a la venta
        public string IdUsuario { get; set; }

        // Propiedad de navegación que representa al usuario asociado a la venta
        [ForeignKey("IdUsuario")]
        public ApplicationUser Usuario { get; set; }

        public int ClientelaId { get; set; }


        [Required(ErrorMessage = "Ingrese el monto de pago")]
        [Display(Name = "Monto de Pago")]
        public decimal MontoPago { get; set; }

        [Required(ErrorMessage = "Ingrese el monto de cambio")]
        [Display(Name = "Monto de Cambio")]
        public decimal MontoCambio { get; set; }

        [Required(ErrorMessage = "Ingrese el monto total")]
        [Display(Name = "Monto Total")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        public Clientela Clientela { get; set; }

        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        public Venta()
        {
            DetalleVentas = new HashSet<DetalleVenta>();
        }
    }
}
