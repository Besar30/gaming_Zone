using GameZone.Attributes;

namespace GameZone.ViewModels
{
    public class GameEditViewModel : GameViewModel
    {
        public int id {  get; set; }
        [AllowedExtention(FileSettings.AllowedExtentions), MaxSizeFile(FileSettings.MaxFileSizeInBytes)]
        public string? currentcover {  get; set; }
        public IFormFile? Cover { get; set; } = default!;
    }
}
