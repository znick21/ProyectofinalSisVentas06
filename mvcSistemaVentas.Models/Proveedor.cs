using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcSistemaVentas.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese una razón social para el proveedor")]
        [Display(Name = "Razón Social")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "Ingrese un documento o NIT para el proveedor")]
        [Display(Name = "Documento o NIT")]
        public string TipoDocumento { get; set; }

        [Required(ErrorMessage = "Ingrese un documento o NIT para el proveedor")]
        [Display(Name = "Documento o NIT")]
        public string DocumentoNit { get; set; }

        [Required(ErrorMessage = "Ingrese un correo electrónico para el proveedor")]
        [Display(Name = "Correo Electrónico")]
        [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "Ingrese un número de teléfono para el proveedor")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Display(Name = "Fecha de Registro")]
        [DataType(DataType.DateTime)]
        public DateOnly FechaRegistro { get; set; }
        public ICollection<Compra> Compras { get; set; }

        // Constructor para inicializar la colección de Productos
        public Proveedor()
        {
            Compras = new HashSet<Compra>();
        }
    }
}
