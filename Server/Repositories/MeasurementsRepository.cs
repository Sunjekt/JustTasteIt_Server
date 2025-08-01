using Server.Interfaces.Repositories;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Repositories
{
    public class MeasurementsRepository : RepositoryBase, IMeasurementsRepository
    {
        public MeasurementsRepository(ModelsManager context) : base(context)
        {
        }

        public IEnumerable<Measurement> GetMeasurements()
        {
            return db.Measurement.ToList();
        }
        public Measurement? GetMeasurementById(int id)
        {
            var measurement = db.Measurement.FirstOrDefault(p => p.Id == id);
            return measurement;
        }
    }
}
