using System.ComponentModel.DataAnnotations;

namespace GameZone.Models
{
    public class Games:BaseEntity
    {
       
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        public string Cover { get; set; } = string.Empty;
        public int CategoriesId { get; set; }
        public Categories Categories { get; set; } = default!;
        public ICollection<GameDevices> Devices { get; set; }= new List<GameDevices>();
    }
}
