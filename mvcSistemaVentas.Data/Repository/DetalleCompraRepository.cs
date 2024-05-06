using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System.Linq;

namespace mvcSistemaVentas.Data.Repository
{
    public class DetalleCompraRepository : Repository<DetalleCompra>, IDetalleCompraRepository
    {
        private readonly ApplicationDbContext _db;

        public DetalleCompraRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(DetalleCompra detalleCompra)
        {
            var objDesdeDb = _db.DetalleCompra.FirstOrDefault(d => d.Id == detalleCompra.Id);
            if (objDesdeDb != null)
            {
               objDesdeDb.Cantidad = detalleCompra.Cantidad;
                objDesdeDb.MontoTotal = detalleCompra.MontoTotal;
                objDesdeDb.FechaRegistro = detalleCompra.FechaRegistro;
                // Actualizar otros campos si es necesario
            }
        }
    }
}
