using ExamenFlores3.Models.Entities;

namespace ExamenFlores3.Repositories
{
    public class FloresRepository : Repository<Datos>
    {
        public FloresRepository(FloresContext context):base(context)
        { 

        }
        public IEnumerable<string> GetFloresNombres()
        {
            return Context.Datos.OrderBy(x=>x.NombreFlor).Select(x=>x.NombreFlor);
        }
        public Datos? GetFlor(string nombreFlor)
        {
            return Context.Datos.Where(x=>x.NombreFlor == nombreFlor).FirstOrDefault();
        }
    }
}
