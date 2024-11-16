using GameZone.Models;
using GameZone.Services;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

namespace GameZone.Controllers
{
	public class GamesController : Controller
	{
		private readonly ICategoriesServices _CategoriesServices;
		private readonly IDeviceServices _DeviceServices;
		private readonly IGameServices _GameServices;

        public GamesController(IDeviceServices deviceServices, ICategoriesServices categoriesServices, IGameServices gameServices)
		{
			_DeviceServices = deviceServices;
			_CategoriesServices = categoriesServices;
			_GameServices = gameServices;
        }
        public IActionResult Index()
		{
            var game = _GameServices.GetAll();
            return View(game);
        }
        [HttpGet]
        public IActionResult Create()
		{
			var viewModel = new CreateGameFormViewModel
			{
				Categorys = _CategoriesServices.Getselectlist(),
				Devices = _DeviceServices.GetDevices()
			};
			return View(viewModel);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CreateGameFormViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				await _GameServices.create(viewModel);
				return RedirectToAction("Index");
			}

			viewModel.Categorys = _CategoriesServices.Getselectlist();
			viewModel.Devices = _DeviceServices.GetDevices();
			return View("Create", viewModel);
		}
		public IActionResult Details(int id)
		{
			var game = _GameServices.GetById(id);
			if (game == null) {
				return NotFound();
			}
			return View(game);
		}
		public IActionResult Edit(int id)
		{
            var game = _GameServices.GetById(id);
            if (game == null)
            {
                return NotFound();
            }
			GameEditViewModel gameEditViewModel = new()
			{
				Name = game.Name,
				id = game.Id,
				Description = game.Description,
				CategoriesId = game.CategoriesId,
				SelectedDevices = game.Devices.Select(d => d.DevicesId).ToList(),
				Categorys = _CategoriesServices.Getselectlist(),
				Devices = _DeviceServices.GetDevices(),
				currentcover=game.Cover
			};
            return View(gameEditViewModel);
		}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(GameEditViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
               var game=  await _GameServices.Edit(viewModel);
				if (game == null) { return BadRequest();}
                return RedirectToAction("Index");
            }

            viewModel.Categorys = _CategoriesServices.Getselectlist();
            viewModel.Devices = _DeviceServices.GetDevices();
            return View("Edit", viewModel);
        }
		public IActionResult Delete(int id)
		{
		
			var x=_GameServices.delete(id);
			if (x == true) return RedirectToAction("index");
			else return NotFound();
		}
    }
}   