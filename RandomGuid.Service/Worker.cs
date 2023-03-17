using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SampleWorkerService.Models;
using SampleWorkerService.Services;

namespace WorkerServiceApp1
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly DbHelper dbHelper;
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
            dbHelper = new DbHelper();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
               
               
                dbHelper.SeedData();
                RandomGuid data = dbHelper.GetData();
                PrintGuidInfo(data);

                await Task.Delay(TimeSpan.FromMinutes(5), stoppingToken);
            }
        }

        private void PrintGuidInfo(RandomGuid data)
        {
            
            _logger.LogInformation($"Data Info: Id: {data.Id} and Status: {data.StatusId} Create date:{data.CreationDate}");

        }
    }
}
