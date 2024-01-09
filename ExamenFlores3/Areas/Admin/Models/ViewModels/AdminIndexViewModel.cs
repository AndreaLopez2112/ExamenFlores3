namespace ExamenFlores3.Areas.Admin.Models.ViewModels
{
    public class AdminIndexViewModel
    {
        public IEnumerable<AdminFlorModel> Flores { get; set; } = null!;
    }
    public class AdminFlorModel
    {
        public string Nombre { get; set; } = null!;
        public int Id { get; set; }
    }
}
