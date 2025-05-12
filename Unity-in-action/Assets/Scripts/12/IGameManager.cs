namespace _12
{
	public interface IGameManager
	{
		ManagerStatus status { get; }

		void Startup(NetworkService service);
	}
}
