using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DetalleComprasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public DetalleComprasController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(DetalleCompra detallecompra)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.DetalleCompra.Add(detallecompra);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(detallecompra);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            DetalleCompra detallecompra = new DetalleCompra();
            detallecompra = _contenedorTrabajo.DetalleCompra.Get(id);
            if (detallecompra == null)
            {
                return NotFound();

            }
            return View(detallecompra);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DetalleCompra detallecompra)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.DetalleCompra.Update(detallecompra);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(detallecompra);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.DetalleCompra.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.DetalleCompra.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando almacen" });
            }
            _contenedorTrabajo.DetalleCompra.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la almacen" });
        }
        #endregion
    }
}
