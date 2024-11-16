using GameZone.Data;
using GameZone.Models;
using GameZone.Setings;
using GameZone.ViewModels;

namespace GameZone.Services
{
	public class GameServices : IGameServices
	{
		private readonly ApplicationDbcontext _context;
		private readonly IWebHostEnvironment _IwebHostEnvironment;
		private readonly string _imagespath;
     
        public GameServices(ApplicationDbcontext context ,IWebHostEnvironment IWebHostEnvironment)
		{
			_context = context;
			_IwebHostEnvironment = IWebHostEnvironment;
			_imagespath = $"{_IwebHostEnvironment.WebRootPath}{FileSettings.ImagePath}";
		}
        IEnumerable<Games> IGameServices.GetAll()
        {
           return _context.Games.Include(e=>e.Categories).Include(e=>e.Devices).ThenInclude(e=>e.Devices).AsNoTracking().ToList();
        }
        public async Task create(CreateGameFormViewModel Game)
		{
			var covername = await savecover(Game.Cover);
			
			Games game = new Games()
			{
				Name= Game.Name,
				Description= Game.Description,
				CategoriesId= Game.CategoriesId,
				Cover =covername,
				Devices=Game.SelectedDevices.Select(d=>new GameDevices { DevicesId=d}).ToList()
			};
			_context.Games.Add(game);
            await _context.SaveChangesAsync();
        }
        public async Task<Games?> Edit(GameEditViewModel Game)
        {
			var game = _context.Games.Include(d => d.Devices).SingleOrDefault(d => d.Id == Game.id);
			
			if(game == null)
			{
				return null;
			}
			string covername1 = game.Cover;

            var hascover=Game.Cover != null;
			game.Name= Game.Name;
			game.Description= Game.Description;
			game.CategoriesId= Game.CategoriesId;
			game.Devices=Game.SelectedDevices.Select(d=>new GameDevices { DevicesId=d}).ToList();
			if (hascover)
			{
                var covername = await savecover(Game.Cover!); 
				game.Cover= covername;
            }
			var effectedrow=_context.SaveChanges();
			if (effectedrow > 0)
			{
				if (hascover)
				{
					var cover=Path.Combine(_imagespath,covername1);
					File.Delete(cover);
				}
				return game;
			}
			else
			{
                var cover = Path.Combine(_imagespath, game.Cover);
                File.Delete(cover);
                return null;
			}

        }
		private async Task<string> savecover(IFormFile cover)
		{
            var covername = $"{Guid.NewGuid()}{Path.GetExtension(cover.FileName)}";
            var path = Path.Combine(_imagespath, covername);
            using var stream = File.Create(path);
            await cover.CopyToAsync(stream);
			return covername;	
        }

        public Games? GetById(int id)
        {
			Games? game=_context.Games.Include(e=>e.Categories).Include(e=>e.Devices).ThenInclude(e=>e.Devices).SingleOrDefault(e=>e.Id==id);
			return game;
        }
        public bool delete(int id)
        {
            var game = _context.Games.Include(e => e.Categories).Include(e => e.Devices).ThenInclude(e => e.Devices).SingleOrDefault(e => e.Id == id);
            if (game == null)
            {
                return false; 
            }

            var coverPath = Path.Combine(_imagespath, game.Cover ?? string.Empty);

            _context.Remove(game);
            _context.SaveChanges();

            if (File.Exists(coverPath))
            {
                File.Delete(coverPath);
            }

            return true;
        }


    }
}
