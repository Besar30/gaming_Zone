namespace GameZone.Models
{
    public class Categories:BaseEntity
    {
      
        public ICollection<Games> Games { get; set; }=new List<Games>();
    }
}
