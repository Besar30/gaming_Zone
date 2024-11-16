using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Services
{
	public interface IDeviceServices
	{
		public IEnumerable<SelectListItem> GetDevices();
	}
}
