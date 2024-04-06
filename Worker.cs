using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Vitals
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        System.Timers.Timer? shortTimer = null;
        System.Timers.Timer? intermediateTimer = null;
        System.Timers.Timer? longTimer = null;
        public int? HR { get; set; }
        public int? Sys { get; set; }
        public int? Dia { get; set; }
        public double? Temp { get; set; }
        public int? ETCO2 { get; set; }
        public int? Resp { get; set; }
        public int? SPO2 { get; set; }
        public int? Profile { get; set; }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int VitalShortIntervalSeconds = 40;
            int VitalIntermediateIntervalSeconds = 40;
            int VitalLongIntervalSeconds = 40;

            // Main execution loop
            while (!stoppingToken.IsCancellationRequested)
            {
                // Set default profile
                Profile = 0;

                // Define vital signs based on the selected profile
                if (Profile == 1) // Elevated blood pressure
                {
                    // Set elevated vital signs
                    HR = 95;
                    SPO2 = 97;
                    Sys = 125;
                    Dia = 80;
                    ETCO2 = 40;
                    Resp = 16;
                    Temp = 98.6;
                }
                else if (Profile == 2) // COVID-19
                {
                    // Set COVID-19 vital signs
                    HR = 102;
                    SPO2 = 87;
                    Sys = 120;
                    Dia = 70;
                    ETCO2 = 40;
                    Resp = 23;
                    Temp = 101;
                }
                else // Stable (default profile)
                {
                    // Set stable vital signs
                    HR = 85;
                    SPO2 = 97;
                    Sys = 120;
                    Dia = 80;
                    ETCO2 = 40;
                    Resp = 16;
                    Temp = 98.6;
                }

                // Create timers for different intervals
                shortTimer = new System.Timers.Timer(VitalShortIntervalSeconds * 1000);
                shortTimer.Elapsed += async (sender, e) => await CreateShortIntervalVital();
                shortTimer.Start();

                intermediateTimer = new System.Timers.Timer(VitalIntermediateIntervalSeconds * 1000);
                intermediateTimer.Elapsed += async (sender, e) => await CreateIntermediateIntervalVital();
                intermediateTimer.Start();

                longTimer = new System.Timers.Timer(VitalLongIntervalSeconds * 1000);
                longTimer.Elapsed += async (sender, e) => await CreateLongIntervalVital();
                longTimer.Start();

                // Delay before next iteration
                await Task.Delay(1000, stoppingToken);
            }
        }

        private async Task CreateShortIntervalVital()
        {
            // Simulate vital sign fluctuations
            Random rnd = new Random();
            HR += rnd.Next(-3, 3);
            SPO2 += rnd.Next(-2, 2);

            // Apply profile-specific adjustments
            if (Profile == 1) // Elevated blood pressure
            {
                if (HR < 70) HR += 7;
                if (HR > 140) HR -= 8;

                if (SPO2 < 95) SPO2 += 2;
                if (SPO2 > 100) SPO2 -= 1;
            }
            else if (Profile == 2) // COVID-19
            {
                if (HR < 77) HR += 7;
                if (HR > 147) HR -= 8;

                if (SPO2 < 93) SPO2 += 2;
                if (SPO2 > 97) SPO2 -= 1;
            }
            else // Stable
            {
                if (HR < 60) HR += 7;
                if (HR > 130) HR -= 8;

                if (SPO2 < 95) SPO2 += 2;
                if (SPO2 > 100) SPO2 -= 1;
            }

            _logger.LogInformation("{0} , {1} ", HR, SPO2);
        }

        private async Task CreateIntermediateIntervalVital()
        {
            // Simulate vital sign fluctuations
            Random rnd = new Random();
            Sys += rnd.Next(-3, 3);
            Dia += rnd.Next(-2, 2);
            ETCO2 += rnd.Next(-2, 3);
            Resp += rnd.Next(-2, 2);

            // Apply profile-specific adjustments
            if (Profile == 1) // Elevated blood pressure
            {
                if (Sys < 103) Sys += 7;
                if (Sys > 134) Sys -= 4;

                if (Dia < 51) Dia += 2;
                if (Dia > 99) Dia -= 2;

                if (ETCO2 < 33) ETCO2 += 2;
                if (ETCO2 > 47) ETCO2 -= 2;

                if (Resp < 12) Resp += 2;
                if (Resp > 23) Resp -= 2;
            }
            else if (Profile == 2) // COVID-19
            {
                if (Sys < 103) Sys += 7;
                if (Sys > 128) Sys -= 4;

                if (Dia < 51) Dia += 2;
                if (Dia > 99) Dia -= 2;

                if (ETCO2 < 33) ETCO2 += 2;
                if (ETCO2 > 47) ETCO2 -= 2;

                if (Resp < 12) Resp += 2;
                if (Resp > 30) Resp -= 2;
            }
            else // Stable
            {
                if (Sys < 103) Sys += 7;
                if (Sys > 128) Sys -= 4;

                if (Dia < 51) Dia += 2;
                if (Dia > 99) Dia -= 2;

                if (ETCO2 < 33) ETCO2 += 2;
                if (ETCO2 > 47) ETCO2 -= 2;

                if (Resp < 12) Resp += 2;
                if (Resp > 23) Resp -= 2;
            }

            _logger.LogInformation("{0} , {1}, {2}, {3} ", Sys, Dia, ETCO2, Resp);
        }

        private async Task CreateLongIntervalVital()
        {
            // Simulate temperature fluctuations
            Random rnd = new Random();
            int cond = rnd.Next(1, 5);
            if (cond == 1) Temp += 0.1;
            if (cond == 2) Temp -= 0.1;
            if (cond == 3) Temp += 0.2;
            if (cond == 4) Temp -= 0.2;

            // Apply profile-specific adjustments
            if (Profile == 2) // COVID-19
            {
                if (Temp < 97) Temp += 0.3;
                if (Temp > 105) Temp -= 0.3;
            }
            else // Stable
            {
                if (Temp < 97) Temp += 0.3;
                if (Temp > 101) Temp -= 0.3;
            }

            // Log the temperature
            String tempDis = String.Format("{0:0.0}", Temp);
            _logger.LogInformation("{0}", tempDis);
        }
    }
}
