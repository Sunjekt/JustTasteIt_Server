using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Intefaces.Services
{
    public interface IMeasurementsService
    {
        public IEnumerable<Measurement> GetMeasurements();
        public Measurement? GetMeasurementById(int id);
    }
}
