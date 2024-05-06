using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

    namespace mvcSistemaVentas.Models
    {
        public class Clientela
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Ingrese el nombre completo")]
            [Display(Name = "Nombre Completo")]
            public string NombreCompleto { get; set; }

            [Required(ErrorMessage = "Ingrese un documento o NIT para el proveedor")]
            [Display(Name = "Documento o NIT")]
            public string TipoDocumento { get; set; }
            [Required(ErrorMessage = "Ingrese el documento")]
            [Display(Name = "Documento")]
            public string Documento { get; set; }

            [Required(ErrorMessage = "Ingrese el correo")]
            [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
            [Display(Name = "Correo")]
            public string Correo { get; set; }

            [Required(ErrorMessage = "Ingrese el número de teléfono")]
            [Display(Name = "Teléfono")]
            public string Telefono { get; set; }

            [Display(Name = "Fecha de Registro")]
            [DataType(DataType.DateTime)]
            public DateTime FechaRegistro { get; set; }

            [Required(ErrorMessage = "Ingrese el estado")]
            [Display(Name = "Estado")]
        public bool Estado { get; set; }
        // Relación con Productos
        public ICollection<Venta> Ventas { get; set; }

            // Constructor para inicializar la colección de Productos
            public Clientela()
            {
                Ventas = new HashSet<Venta>();
            }

    }
    }


