using ExamenFlores3.Models.Entities;

namespace ExamenFlores3.Repositories
{
    public class AdminRepository:Repository<Datos>
    {
        public AdminRepository(FloresContext context):base(context)
        {

        }
    }
}
