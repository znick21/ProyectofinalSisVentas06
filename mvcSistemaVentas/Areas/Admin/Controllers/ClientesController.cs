using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;

namespace mvcSistemaVentas.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientesController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ClientesController(IContenedorTrabajo contenedorTrabajo)
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
        public IActionResult Create(Clientela cliente)
        {
            if (ModelState.IsValid)
            {
                //logica para guardar en bd
                _contenedorTrabajo.Cliente.Add(cliente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(cliente);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Clientela cliente = new Clientela();
            cliente = _contenedorTrabajo.Cliente.Get(id);
            if (cliente == null)
            {
                return NotFound();

            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Clientela cliente)
        {

            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Cliente.Update(cliente);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }
        #region llamadas a la api
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Cliente.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.Cliente.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando almacen" });
            }
            _contenedorTrabajo.Cliente.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Se borro la almacen" });
        }
        #endregion
    }
}
