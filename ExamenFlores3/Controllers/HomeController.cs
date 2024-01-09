using ExamenFlores3.Models.ViewModels;
using ExamenFlores3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFlores3.Controllers
{
    public class HomeController : Controller
    {
        private readonly FloresRepository floresRepo;
        public HomeController(FloresRepository floresRepository)
        {

            floresRepo = floresRepository;

        }
        public IActionResult Index()
        {
            IndexViewModel vm = new IndexViewModel();
            vm.FloresNombres = floresRepo.GetFloresNombres();
            return View(vm);
        }
        [Route("Detalles/{Id}")]
        public IActionResult Detalles(string Id)
        {
            DetallesViewModel vm = new DetallesViewModel();
            if(string.IsNullOrEmpty(Id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                var datos = floresRepo.GetFlor(Id.Replace("-"," "));
                if(datos == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Flor = datos;
                    return View(vm);
                }   
            }
        }
    }
}
