public interface IGameManagerWeather
{
    ManagerStatusWeather status { get; }

    void Startup(NetworkService service);
}

public enum ManagerStatusWeather
{
    Shutdown,
    Initializing,
    Started
}
