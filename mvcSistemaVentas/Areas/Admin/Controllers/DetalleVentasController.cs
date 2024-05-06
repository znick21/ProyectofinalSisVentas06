using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetalleVentasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public DetalleVentasController(IContenedorTrabajo contenedorTrabajo)
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
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DetalleVenta detalleventa)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.DetalleVenta.Add(detalleventa);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(detalleventa);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DetalleVenta detalleventa = new DetalleVenta();
            detalleventa = _contenedorTrabajo.DetalleVenta.Get(id);
            if (detalleventa == null)
            {
                return NotFound();

            }
            return View(detalleventa);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DetalleVenta detalleventa)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.DetalleVenta.Update(detalleventa);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(detalleventa);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.DetalleVenta.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.DetalleVenta.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando almacen" });
            }
            _contenedorTrabajo.DetalleVenta.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la almacen" });
        }
        #endregion
    }
}
