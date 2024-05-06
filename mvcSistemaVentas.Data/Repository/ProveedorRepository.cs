using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System.Linq;

namespace mvcSistemaVentas.Data.Repository
{
    public class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        private readonly ApplicationDbContext _db;

        public ProveedorRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Proveedor proveedor)
        {
            var objDesdeDb = _db.Proveedor.FirstOrDefault(p => p.Id == proveedor.Id);
            if (objDesdeDb != null)
            {
                objDesdeDb.RazonSocial = proveedor.RazonSocial;
                objDesdeDb.DocumentoNit = proveedor.DocumentoNit;
                objDesdeDb.Correo = proveedor.Correo;
                objDesdeDb.Telefono = proveedor.Telefono;
                objDesdeDb.Estado = proveedor.Estado;
                objDesdeDb.FechaRegistro = proveedor.FechaRegistro;
            }
        }
    }
}
