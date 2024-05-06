using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System.Linq;

namespace mvcSistemaVentas.Data.Repository
{
    public class VentaRepository : Repository<Venta>, IVentaRepository
    {
        private readonly ApplicationDbContext _db;

        public VentaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Venta venta)
        {
            var objDesdeDb = _db.Venta.FirstOrDefault(v => v.Id == venta.Id);
            if (objDesdeDb != null)
            {
         
                objDesdeDb.MontoPago = venta.MontoPago;
                objDesdeDb.MontoCambio = venta.MontoCambio;
                objDesdeDb.MontoTotal = venta.MontoTotal;
                objDesdeDb.FechaRegistro = venta.FechaRegistro;
                // Actualizar otros campos si es necesario
            }
        }
    }
}
