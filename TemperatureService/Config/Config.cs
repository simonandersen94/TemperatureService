using System.Text.Json;

namespace TemperatureService.Config {
    public class Config {
        public string Postgres_ConnectionString { get; set; }

        private static readonly String ConfigPath = Path.Combine(Directory.GetCurrentDirectory(), "Config/Config.json");

        public static Config LoadConfig() {
            if (!File.Exists(ConfigPath)) {
                throw new FileNotFoundException($"Config.json file not found at: {ConfigPath}");
            }
            var json = File.ReadAllText(ConfigPath);
            return JsonSerializer.Deserialize<Config>(json)
                ?? throw new InvalidOperationException("Failed to deserialize config file");
        }
    }
}
