using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcSistemaVentas.Models
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Ingrese un código para el producto")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para el producto")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Ingrese la cantidad de stock del producto")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "Ingrese el precio de compra del producto")]
        [Display(Name = "Precio de Compra")]
        public decimal PrecioCompra { get; set; }

        [Required(ErrorMessage = "Ingrese el precio de venta del producto")]
        [Display(Name = "Precio de Venta")]
        public decimal PrecioVenta { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; }

        [Display(Name = "Fecha de Caducidad")]
        [DataType(DataType.Date)]
        public DateTime FechaCaducidad { get; set; }

        // Relación con Categoria
        public Categoria Categoria { get; set; }

        // Colección de detalles de venta
        public ICollection<DetalleVenta> DetalleVentas { get; set; }

        // Colección de detalles de compra
        public ICollection<DetalleCompra> DetalleCompras { get; set; }

        // Constructor
        public Producto()
        {
            DetalleVentas = new HashSet<DetalleVenta>();
            DetalleCompras = new HashSet<DetalleCompra>();
        }
    }
}
