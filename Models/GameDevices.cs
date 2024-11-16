namespace GameZone.Models
{
    public class GameDevices
    {
        public int GamesId { get; set; }
        public int DevicesId { get; set; }
        public Games Games { get; set; }
        public Devices Devices { get; set; }
    }
}
