using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HairTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BarbersController : ControllerBase
    {
        
        private readonly ILogger<BarbersController> _logger;
        private readonly IBarberRepository barberRepository;

        public BarbersController(ILogger<BarbersController> logger, IBarberRepository _barberRepository)
        {
            _logger = logger;
            barberRepository = _barberRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var jsonResult = JsonConvert.SerializeObject(barberRepository.AllBarbers);
            return Content(jsonResult);
        }
        [HttpGet("{barberId}")]
        public IActionResult GetBarber(int barberId)
        {
            var barber = barberRepository.GetBarberById(barberId);
            if (barber == null)
                return NotFound();
            return Content(JsonConvert.SerializeObject(barber));
        }
    }
}
