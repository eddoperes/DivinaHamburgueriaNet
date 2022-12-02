using DivinaHamburgueria.Application.Interfaces;

namespace DivinaHamburgueria.API.HostedServices
{
    public class InventoryEnterService : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;        

        public InventoryEnterService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(5));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IInventoryEnterService scopedProcessingService =
                            scope.ServiceProvider.GetRequiredService<IInventoryEnterService>();
                    await scopedProcessingService.Execute();
                };
            }
            //return Task.CompletedTask;
        }       

    }
}
