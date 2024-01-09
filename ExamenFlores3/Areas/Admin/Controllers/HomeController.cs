using ExamenFlores3.Areas.Admin.Models.ViewModels;
using ExamenFlores3.Models.Entities;
using ExamenFlores3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ExamenFlores3.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly AdminRepository adminRepo;
        public HomeController( AdminRepository adminRepository)
        {
            adminRepo = adminRepository;
        }
        public IActionResult Index()
        {
            AdminIndexViewModel vm = new AdminIndexViewModel();
            vm.Flores = adminRepo.GetAll().Select(x=> new AdminFlorModel 
            {
                Id = (int)x.Id,
                Nombre = x.NombreFlor
            });
            return View(vm);
        }
        [Route("Admin/Agregar")]
        public IActionResult Agregar() 
        {
            return View();
        }
        [Route("Admin/Agregar")]
        [HttpPost]
        public IActionResult Agregar(AgregarViewModel vm)
        {
            if(string.IsNullOrEmpty(vm.Flor.NombreFlor))
            {
                ModelState.AddModelError("Flor.NombreFlor","El nombre de la flor es requerido");
            }
            if(string.IsNullOrEmpty(vm.Flor.Descripcion))
            {
                ModelState.AddModelError("Flor.Descripcion","La descripción de la flor es requerida");
            }
            if(string.IsNullOrEmpty(vm.Flor.Origen))
            {
                ModelState.AddModelError("Flor.Origen","El origen de la flor es requerido");
            }
            if(vm.Foto == null)
            {
                ModelState.AddModelError("Foto","La foto de la flor es requerida");
            }
            else
            {
                if(vm.Foto.ContentType != "image/jpeg" && vm.Foto.ContentType != "image/png")
                {
                    ModelState.AddModelError("Foto","La foto debe ser de tipo jpg o png");
                }
            }
            if (ModelState.IsValid)
            {
                Datos datos = new Datos();
                datos.NombreFlor = vm.Flor.NombreFlor;
                datos.Descripcion = vm.Flor.Descripcion;
                datos.Origen = vm.Flor.Origen;
                datos.Id = 0;
                adminRepo.Insert(datos);
                System.IO.FileStream fs = System.IO.File.Create($"wwwroot/images/{datos.Id}.png");
                if (vm.Foto != null) 
                { 
                    vm.Foto.CopyTo(fs); 
                }

                return RedirectToAction("Index");
            }
            return View(vm);
        }
        [Route("Admin/Editar/{Id}")]
        public IActionResult Editar() 
        {
            return View();
        }
        [Route("Admin/Editar/{Id}")]
        [HttpPost]
        public IActionResult Editar(EditarViewModel vm)
        {
            return RedirectToAction("Index");
        }
        [Route("Admin/Eliminar/{Id}")]
        public IActionResult Eliminar()
        {
            return View();
        }
        [Route("Admin/Eliminar/{Id}")]
        [HttpPost]
        public IActionResult Eliminar(EliminarViewModel vm)
        {
            return RedirectToAction("Index");
        }

    }
}
