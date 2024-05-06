using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VentasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public VentasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            ViewBag.Usuario = new SelectList(_contenedorTrabajo.Usuario.GetAll(), "Id", "Nombre");

            // Obtener la lista de productos y asignarla a ViewBag.Productos
            ViewBag.Productos = _contenedorTrabajo.Producto.GetAll();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Venta.Add(venta);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            ViewBag.Usuario = new SelectList(_contenedorTrabajo.Usuario.GetAll(), "Id", "Nombre");
            return View(venta);
        }
        /////////
        ////////////////
        ///[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Venta venta, List<DetalleVenta> productos)
        {
            if (ModelState.IsValid)
            {
                // Calcular el monto total de la venta
                decimal montoTotal = 0;
                foreach (var detalle in productos)
                {
                    // Obtener el producto asociado al detalle
                    var producto = _contenedorTrabajo.Producto.GetFirstOrDefault(p => p.Id == detalle.ProductoId);
                    if (producto != null)
                    {
                        // Calcular el subtotal del detalle y sumarlo al monto total
                        detalle.PrecioVenta = producto.PrecioVenta;
                        detalle.Subtotal = detalle.Cantidad * producto.PrecioVenta;
                        montoTotal += detalle.Subtotal;
                    }
                }

                // Establecer el monto total en la venta
                venta.MontoTotal = montoTotal;

                // Guardar la venta y sus detalles en la base de datos
                venta.FechaRegistro = DateTime.Now;
                _contenedorTrabajo.Venta.Add(venta);
                foreach (var detalle in productos)
                {
                    detalle.VentaId = venta.Id;
                    _contenedorTrabajo.DetalleVenta.Add(detalle);
                }
                _contenedorTrabajo.Save();

                return RedirectToAction(nameof(Index));
            }

            // Recargar las listas desplegables en caso de error de validación
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto", venta.ClientelaId);
            ViewBag.Usuario = new SelectList(_contenedorTrabajo.Usuario.GetAll(), "Id", "Nombre", venta.IdUsuario);
            return View(venta);
        }

        //////////
        ////////////

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Venta venta = _contenedorTrabajo.Venta.Get(id);
            if (venta == null)
            {
                return NotFound();
            }
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            ViewBag.Usuario = new SelectList(_contenedorTrabajo.Usuario.GetAll(), "Id", "Nombre");
            return View(venta);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Venta venta)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Venta.Update(venta);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Clientes = new SelectList(_contenedorTrabajo.Cliente.GetAll(), "Id", "NombreCompleto");
            ViewBag.Usuario = new SelectList(_contenedorTrabajo.Usuario.GetAll(), "Id", "Nombre");
            return View(venta);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Venta.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Venta.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando almacen" });
            }
            _contenedorTrabajo.Venta.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la almacen" });
        }
        #endregion
    }
}
