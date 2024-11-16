using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public class CategoriesServices : ICategoriesServices
	{
		private readonly ApplicationDbcontext _context;
		public CategoriesServices(ApplicationDbcontext context)
		{
			_context = context;
		}
		public IEnumerable<SelectListItem> Getselectlist()
		{
	       return _context.Categories.Select(e=>new SelectListItem { Value=e.Id.ToString(),Text=e.Name.ToString()})
				.OrderBy(e=>e.Text).ToList();
				
	    }
	}
}
