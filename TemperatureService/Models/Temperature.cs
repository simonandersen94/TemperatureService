using System.ComponentModel.DataAnnotations.Schema;

namespace TemperatureService.Models {
    public class Temperature {
        public string Date { get; set; }
        public double Temp { get; set; }

        public Temperature() {
            
        }

        public Temperature(string date, double temp) {
            Date = date;
            Temp = temp;
        }
    }
}
