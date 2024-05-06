using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using System;
using System.Linq;

namespace mvcSistemaVentas.Data.Repository
{
    public class ClienteRepository : Repository<Clientela>, IClienteRepository
    {
        private readonly ApplicationDbContext _db;

        public ClienteRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Clientela cliente)
        {
            var objDesdeDb = _db.Cliente.FirstOrDefault(c => c.Id == cliente.Id);
            if (objDesdeDb != null)
            {
                objDesdeDb.NombreCompleto = cliente.NombreCompleto;
                objDesdeDb.Documento = cliente.Documento;
                objDesdeDb.Correo = cliente.Correo;
                objDesdeDb.Telefono = cliente.Telefono;
                objDesdeDb.FechaRegistro = cliente.FechaRegistro;
                objDesdeDb.Estado = cliente.Estado;
                // Actualizar otros campos si es necesario
            }
        }
    }
}
