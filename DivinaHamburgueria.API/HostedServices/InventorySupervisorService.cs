using DivinaHamburgueria.Application.Interfaces;

namespace DivinaHamburgueria.API.HostedServices
{
    public class InventorySupervisorService : BackgroundService
    {

        private readonly IServiceProvider _serviceProvider;

        public InventorySupervisorService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                using (IServiceScope scope = _serviceProvider.CreateScope())
                {
                    IInventorySupervisorService scopedProcessingService =
                            scope.ServiceProvider.GetRequiredService<IInventorySupervisorService>();
                    await scopedProcessingService.Execute();
                };
            }
            //return Task.CompletedTask;
        }

    }
}
