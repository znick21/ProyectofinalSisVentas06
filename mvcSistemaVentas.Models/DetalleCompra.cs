using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcSistemaVentas.Models
{
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el monto total")]
        [Display(Name = "Monto Total")]
        public decimal MontoTotal { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        // Relación con Producto
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        // Relación con Compra
        public int CompraId { get; set; }
        public Compra Compra { get; set; }
    }
}
