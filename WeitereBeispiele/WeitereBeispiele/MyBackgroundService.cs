namespace WeitereBeispiele
{
  public class MyBackgroundService : BackgroundService
  {
    private readonly MyService myService;

    public MyBackgroundService(MyService myService)
    {
      this.myService = myService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
      myService.Startup(stoppingToken);

      return Task.CompletedTask;
    }

  }
}
