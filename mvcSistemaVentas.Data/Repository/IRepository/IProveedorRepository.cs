using mvcSistemaVentas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvcSistemaVentas.Data.Repository.IRepository
{
    public interface IProveedorRepository : IRepository<Proveedor>
    {
        void Update(Proveedor proveedor);
    }
}
