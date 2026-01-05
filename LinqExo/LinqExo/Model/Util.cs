using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExo.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public decimal Amount { get; set; }
    }

    public static class OrderUtils
    {
        public static Dictionary<int, decimal> GetTotalAmountByCustomer(List<Order> orders)
        {
            if (orders == null) throw new ArgumentNullException(nameof(orders));

            if (!orders.Any()) return new Dictionary<int, decimal>();

            return orders
                .GroupBy(orders => orders.CustomerId)
                .Select(group => new
                {
                    CustomerId = group.Key,
                    TotalAmount = group.Sum(o => o.Amount),
                })
                .ToDictionary(x => x.CustomerId, x => x.TotalAmount);
        }
    }

    public static class EmailUtils
    {
        public static List<string> FindDuplicateEmails(List<string> emails)
        {
            if (emails == null) throw new ArgumentNullException(nameof(emails));

            if (!emails.Any()) return new List<string>();

            return emails
                .GroupBy(email => email)
                .Where(group => group.Count() > 1)
                .Select(group => group.Key)
                .ToList();
        }
    }

    public class ExternalService
    {
        public async Task<string> GetWeatherAsync()
        {
            await Task.Delay(1000); // Simule appel API
            return "Sunny";
        }

        public async Task<int> GetTemperatureAsync()
        {
            await Task.Delay(1000); // Simule appel API
            return 25;
        }

        public async Task<string> GetForecastAsync()
        {
            await Task.Delay(1000); // Simule appel API
            return "Clear skies";
        }
    }

    public class WeatherData
    {
        public string Weather { get; set; }
        public int Temperature { get; set; }
        public string Forecast { get; set; }
    }

    public static class WeatherUtils
    {
        public static async Task<WeatherData> GetWeatherDataAsync(ExternalService service)
        {
            if (service == null)
                   throw new ArgumentNullException(nameof(service));

            var weatherTask = service.GetWeatherAsync();
            var temperatureTask = service.GetTemperatureAsync();
            var forecastTask = service.GetForecastAsync();

            try
            {
                await Task.WhenAll(weatherTask, temperatureTask, forecastTask);

                return new WeatherData
                {
                    Weather = await weatherTask,      // ✅ await (plus explicite)
                    Temperature = await temperatureTask,
                    Forecast = await forecastTask
                };
            }
            catch(Exception ex)
            {
                /*Console.WriteLine($"Failed to fetch weather data: {ex.Message}");
                throw;*/
                // ✅ Récupérer TOUTES les exceptions
                var exceptions = new List<Exception>();

                if (weatherTask.IsFaulted) exceptions.Add(weatherTask.Exception.InnerException);
                if (temperatureTask.IsFaulted) exceptions.Add(temperatureTask.Exception.InnerException);
                if (forecastTask.IsFaulted) exceptions.Add(forecastTask.Exception.InnerException);

                throw new AggregateException("Multiple weather data fetch failures", exceptions);
            }

            
        }
    }

    public class UnstableApiService
    {
        private int _attemptCount = 0;

        public async Task<string> CallApiAsync()
        {
            _attemptCount++;
            await Task.Delay(100); // Simule appel API

            // Échoue les 2 premières fois, réussit la 3ème
            if (_attemptCount < 3)
            {
                throw new HttpRequestException($"API call failed (attempt {_attemptCount})");
            }

            return "Success! ";
        }
    }

    public static class ApiUtils
    {
        public static async Task<string> CallApiWithRetryAsync(UnstableApiService service, int maxRetries = 3)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            if (maxRetries < 1)
                throw new ArgumentException("maxRetries must be at least 1", nameof(maxRetries));

            int attempt = 0;
            while (true)
            {
                try
                {
                    return await service.CallApiAsync();
                }
                catch (HttpRequestException ex)
                {
                    attempt++;
                    if (attempt >= maxRetries)
                    {
                        Console.WriteLine($"Max retry attempts reached:  {ex.Message}");
                        throw;
                    }
                    // ✅ Exponential backoff
                    var delaySeconds = Math.Pow(2, attempt); // 2^1 = 2s, 2^2 = 4s, 2^3 = 8s
                    Console.WriteLine($"API call failed (attempt {attempt}/{maxRetries}). Retrying in {delaySeconds}s...");

                    await Task.Delay(TimeSpan.FromSeconds(delaySeconds));
                }
            }
        }
    }
}
