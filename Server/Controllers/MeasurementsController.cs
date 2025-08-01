using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Intefaces.Services;
using Server.Models;
using Server.Servieces;
using System.Diagnostics.Metrics;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementsController : ControllerBase //Контроллер для единиц измерения
    {
        private readonly IMeasurementsService measurementsService;
        public MeasurementsController(IMeasurementsService _measurementsService)
        {
            measurementsService = _measurementsService;
        }


        // GET: api/Measurements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetMeasurement() // метод получения всех единиц измерения
        {
            var measurements = measurementsService.GetMeasurements();
            return Ok(measurements);
        }

        // GET: api/Measurements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Measurement>> GetMeasurement(int id) // метод получения одной единицы измерения по id
        {
            var measurement = measurementsService.GetMeasurementById(id);
            if (measurement == null)
            {
                return NotFound();
            }
            return Ok(measurement);
        }
    }
}
