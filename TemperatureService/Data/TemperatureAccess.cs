using Microsoft.AspNetCore.Connections;
using Npgsql;
using Dapper;
using TemperatureService.Config;
using TemperatureService.Models;

namespace TemperatureService.Data {
    public class TemperatureAccess {
        private readonly Config.Config _config;

        public TemperatureAccess(Config.Config config) {
            _config = config;
        }

        public bool Create(Temperature temperature) {
            try {
                using var connection = new NpgsqlConnection(_config.Postgres_ConnectionString);

                const string sqlquery =
                    @"INSERT INTO temperature (timestamp, temp)
                    VALUES (@Date, @Temp);";

                int rowsAffected = connection.Execute(sqlquery, temperature);

                return rowsAffected > 0;
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public Temperature? Get() {
            try {
                using var connection = new NpgsqlConnection(_config.Postgres_ConnectionString);

                const string sqlquery =
                    @"SELECT timestamp AS date, temp
                    FROM temperature
                    ORDER BY id DESC LIMIT 1;";

                return connection.QuerySingleOrDefault<Temperature>(sqlquery);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
