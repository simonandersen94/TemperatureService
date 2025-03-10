using TemperatureService.Data;
using TemperatureService.Models;

namespace TemperatureService.BusinessLogic {
    public class TemperatureControl {
        private readonly TemperatureAccess _temperatureAccess;

        public TemperatureControl(TemperatureAccess temperatureAccess) {
            _temperatureAccess = temperatureAccess;
        }

        public bool Create(Temperature temperature) {
            return _temperatureAccess.Create(temperature);
        }

        public Temperature? Get() {
            return _temperatureAccess.Get();
        }
    }
}
