using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProveedoresController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProveedoresController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Proveedor.Add(proveedor);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Proveedor proveedor = _contenedorTrabajo.Proveedor.Get(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return View(proveedor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Proveedor.Update(proveedor);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(proveedor);
        }

        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Proveedor.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Proveedor.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando proveedor" });
            }
            _contenedorTrabajo.Proveedor.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borró el proveedor" });
        }
        #endregion
    }
}
