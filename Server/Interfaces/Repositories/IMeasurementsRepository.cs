using Server.Models;

namespace Server.Interfaces.Repositories
{
    public interface IMeasurementsRepository
    {
        IEnumerable<Measurement> GetMeasurements();
        Measurement? GetMeasurementById(int id);
    }
}
