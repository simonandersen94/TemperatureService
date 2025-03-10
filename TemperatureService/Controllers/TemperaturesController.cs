using Microsoft.AspNetCore.Mvc;
using TemperatureService.BusinessLogic;
using TemperatureService.Models;

namespace TemperatureService.Controllers {
    [Route("api/[controller]")]
    public class TemperaturesController : ControllerBase {
        private readonly TemperatureControl _temperatureControl;

        public TemperaturesController(TemperatureControl temperatureControl) {
            _temperatureControl = temperatureControl;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Temperature temperature) {
            if (temperature == null) {
                return StatusCode(400);
            }

            bool success = _temperatureControl.Create(temperature);

            if (success) {
                return StatusCode(201);
            } else {
                return StatusCode(500);
            }
        }

        [HttpGet("newest")]
        public ActionResult<Temperature> Get() {
            Temperature? temp = _temperatureControl.Get();
            
            if (temp != null) {
                return Ok(temp);
            } else {
                return StatusCode(500);
            }
        }
    }
}
