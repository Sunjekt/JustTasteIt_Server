using Server.Intefaces.Services;
using Server.Interfaces.Repositories;
using Server.Models;
using Server.Repositories;
using Server.Models.DTO;

namespace Server.Servieces
{
    public class MeasurementsService : IMeasurementsService
    {

        private IMeasurementsRepository measurementsRepository;

        public MeasurementsService(IMeasurementsRepository _measurementsRepository)
        {
            measurementsRepository = _measurementsRepository;
        }
        public IEnumerable<Measurement> GetMeasurements()
        {
            return measurementsRepository.GetMeasurements();
        }
        public Measurement? GetMeasurementById(int id)
        {
            return measurementsRepository.GetMeasurementById(id);
        }
    }
}
