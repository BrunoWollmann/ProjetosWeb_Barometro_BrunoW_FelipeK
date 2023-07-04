using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BarometerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarometerController : ControllerBase
    {
        private readonly ILogger<BarometerController> _logger;

        public BarometerController(ILogger<BarometerController> logger)
        {
            _logger = logger;
        }

        // GET: api/<BarometerController>
        [HttpGet]
        public IEnumerable<BarometerData> Get()
        {
            // Aqui você pode adicionar o código para coletar os dados do sensor BME280.
            // Por enquanto, vamos retornar alguns dados de exemplo.
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new BarometerData
            {
                Date = DateTime.Now.AddDays(index),
                Temperature = rng.Next(-20, 55),
                Pressure = rng.Next(950, 1050),
                Altitude = rng.Next(-200, 2000),
                Humidity = rng.Next(0, 100)
            })
            .ToArray();
        }

        // As outras ações (POST, PUT, DELETE) não são necessárias para este projeto, então você pode removê-las.
    }

    public class BarometerData
    {
        public DateTime Date { get; set; }
        public float Temperature { get; set; }
        public float Pressure { get; set; }
        public float Altitude { get; set; }
        public float Humidity { get; set; }
    }
}
