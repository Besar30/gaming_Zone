using GameZone.Attributes;
using GameZone.Models;
using GameZone.Setings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameViewModel
	{
        [AllowedExtention(FileSettings.AllowedExtentions), MaxSizeFile(FileSettings.MaxFileSizeInBytes)]

        public IFormFile Cover { get; set; } = default!;
    }
}
