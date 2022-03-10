using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace VeriketService
{
    public class TimedHostedService : IHostedService, IDisposable
    {
        private int executionCount = 0;

        private readonly ILogger<TimedHostedService> _logger;

        private Timer _timer ;

        private readonly string CommonAppData = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);//AppData klasor yolu

        private readonly string FolderName = "VeriketApp";//oluşturulacak klasor adi

        private readonly string FileName = "VeriketAppTest.txt";//oluşturulacak dosya adi

        public TimedHostedService(ILogger<TimedHostedService> logger)
        {
            _logger = logger;
        }


        public Task StartAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service running.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            var count = Interlocked.Increment(ref executionCount);

            _logger.LogInformation("Timed Hosted Service is working. Count: {Count}", count);

            string fullPath = Path.Combine(CommonAppData, FolderName);

            if (!Directory.Exists(fullPath))//eğer AppData klasorunde -FolderName- adındaki klasoru yoksa oluştur
            {
                Directory.CreateDirectory(fullPath);
            }

            fullPath = Path.Combine(fullPath, FileName);

            if (!File.Exists(fullPath))//-FolderName- adındaki klasorun içinde -FileName- adında dosya yoksa oluştur
            {
                using var fileStream = File.Create(fullPath);
                fileStream.Dispose();
            }

            //Dosyayı aç ve içine yazı ekle
            using StreamWriter writer = new(fullPath, append: true);
            writer.WriteLine($"{DateTime.Now} {Environment.MachineName}/{Environment.UserName}");
            writer.Dispose();

        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Timed Hosted Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

    }
}
