using Microsoft.AspNetCore.Mvc;
using mvcSistemaVentas.Data.Repository;
using mvcSistemaVentas.Data.Repository.IRepository;
using mvcSistemaVentas.Models;
using mvcSistemaVentas.Models.ViewModels;
using System.Diagnostics;

namespace mvcSistemaVentas.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController1 : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;
        public HomeController1(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 6)
        {

            var categorias = _contenedorTrabajo.Categoria.AsQueryable();

            // Paginar los resultados
            var paginatedEntries = categorias.Skip((page - 1) * pageSize).Take(pageSize);


            

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.Slider.GetAll(),
                ListCategorias = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPages = (int)Math.Ceiling(categorias.Count() / (double)pageSize)

            };

            //Esta línea es para poder saber si estamos en el home o no
            ViewBag.IsHome = true;

            return View(homeVM);
        }
              //Para buscador categoria
        [HttpGet]
        public IActionResult ResultadoBusqueda1(string searchString, int page = 1, int pageSize = 3)
        {
            var categorias = _contenedorTrabajo.Categoria.AsQueryable();

            // Filtrar por título si hay un término de búsqueda
            if (!string.IsNullOrEmpty(searchString))
            {
                categorias = categorias.Where(e => e.Nombre.Contains(searchString));
            }

            // Paginar los resultados
            var paginatedEntries = categorias.Skip((page - 1) * pageSize).Take(pageSize);

            // Crear el modelo para la vista
            var model = new ListaPaginada<Categoria>(paginatedEntries.ToList(), categorias.Count(), page, pageSize, searchString);
            return View(model);
        }
        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var categoriaDesdeBd = _contenedorTrabajo.Categoria.Get(id);
            return View(categoriaDesdeBd);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
