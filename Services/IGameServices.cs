using GameZone.ViewModels;

namespace GameZone.Services
{
	public interface IGameServices
	{
		public IEnumerable<Games> GetAll();
		public Games? GetById(int id);
		Task create(CreateGameFormViewModel Game);
        Task<Games?> Edit(GameEditViewModel Game);
		bool delete(int id);

    }
}
