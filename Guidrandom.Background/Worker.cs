
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Guidrandom.Background
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly TaskDbHelper dbHelper;

        int counter = 1;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            dbHelper = new TaskDbHelper();


        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {

                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
               
                
                dbHelper.ReadDataAndWriteIntoFile();
              

                //counter++;

                dbHelper.AddDocument();
                dbHelper.UpdateData();
                dbHelper.UpdateStatusToRejected();



                stoppingToken.ThrowIfCancellationRequested();
                await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken);

            }

        }
    }
}
