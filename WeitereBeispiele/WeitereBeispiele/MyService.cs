namespace WeitereBeispiele
{
  public class MyService
  {
    public int Zähler { get; set; }
    private Timer Timer { get; set; }

    private CancellationToken stoppingToken;

    internal void Startup(CancellationToken stoppingToken)
    {
      Timer = new(TimerTick, null, 2000, 1000);
      this.stoppingToken = stoppingToken;
    }

    private void TimerTick(object? x)
    {
      stoppingToken.ThrowIfCancellationRequested();

      Zähler++;
    }

  }
}
