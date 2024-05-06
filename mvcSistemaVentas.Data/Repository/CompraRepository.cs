using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Data.Repository
{
    class CompraRepository : Repository<Compra>, ICompraRepository
    {
        private readonly ApplicationDbContext _db;

        public CompraRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Compra compra)
        {
            var objDesdeDb = _db.Compra.FirstOrDefault(c => c.Id == compra.Id);
            if (objDesdeDb != null)
            {
             
                objDesdeDb.MontoTotal = compra.MontoTotal;
                objDesdeDb.FechaRegistro = compra.FechaRegistro;
                // Actualizar otros campos si es necesario
            }
        }
    }
}
