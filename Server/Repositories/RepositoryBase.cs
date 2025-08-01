using Server.Models;
namespace Server.Repositories
{
    public class RepositoryBase
    {
        public ModelsManager db;
        public RepositoryBase(ModelsManager context)
        {
            db = context;
        }
    }
}
