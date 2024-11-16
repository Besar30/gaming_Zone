namespace GameZone.ViewModels
{
    public class GameViewModel
    {
        public string Name { get; set; } = string.Empty;

        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Category")]
        public int CategoriesId { get; set; }
        public IEnumerable<SelectListItem> Categorys { get; set; } = Enumerable.Empty<SelectListItem>();
        [Display(Name = "Devices")]
        public List<int> SelectedDevices { set; get; } = default!;
        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
