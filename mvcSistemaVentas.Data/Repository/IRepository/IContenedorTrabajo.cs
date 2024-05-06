using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Data.Repository.IRepository
{
    public interface IContenedorTrabajo
    {
        IUsuarioRepository Usuario { get; }
        ISliderRepository Slider { get; }
        ICategoriaRepository Categoria { get; }
        IProductoRepository Producto { get; }
        IProveedorRepository Proveedor { get; }
        IClienteRepository Cliente { get; }
        ICompraRepository Compra { get; }
        IDetalleCompraRepository DetalleCompra { get; }
        IVentaRepository Venta { get; }
        IDetalleVentaRepository DetalleVenta { get; }

        
        void Save();
    }
}
