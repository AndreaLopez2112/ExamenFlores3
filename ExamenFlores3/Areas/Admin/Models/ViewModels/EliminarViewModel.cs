using ExamenFlores3.Models.Entities;

namespace ExamenFlores3.Areas.Admin.Models.ViewModels
{
    public class EliminarViewModel
    {
        public Datos Flor { get; set; } = null!;
        public IFormFile Foto { get; set; } = null!;
    }
}
