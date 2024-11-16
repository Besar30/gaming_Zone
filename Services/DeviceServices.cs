using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
	public class DeviceServices : IDeviceServices
	{
		private readonly ApplicationDbcontext _context;
		public DeviceServices(ApplicationDbcontext context)
		{
			_context = context;
		}
		public IEnumerable<SelectListItem> GetDevices()
		{
			return _context.Devices.Select(e => new SelectListItem { Value=e.Id.ToString(),Text=e.Name}).OrderBy(e=>e.Text).AsNoTracking().ToList();
		}
	}
}
