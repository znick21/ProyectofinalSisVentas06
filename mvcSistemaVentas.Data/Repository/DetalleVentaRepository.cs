using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System.Linq;

namespace mvcSistemaVentas.Data.Repository
{
    public class DetalleVentaRepository : Repository<DetalleVenta>, IDetalleVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleVentaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetalleVenta detalleVenta)
        {
            var objDesdeDb = _db.DetalleVenta.FirstOrDefault(d => d.Id == detalleVenta.Id);
            if (objDesdeDb != null)
            {

                objDesdeDb.PrecioVenta = detalleVenta.PrecioVenta;
                objDesdeDb.Cantidad = detalleVenta.Cantidad;
                objDesdeDb.Subtotal = detalleVenta.Subtotal;
                objDesdeDb.FechaRegistro = detalleVenta.FechaRegistro;
                // Actualizar otros campos si es necesario
            }
        }
    }
}
