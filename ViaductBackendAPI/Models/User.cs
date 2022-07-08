namespace ViaductBackendAPI.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int Permission { get; set; }
        public int BarRate { get; set; }
        public int KitchenRate { get; set; }
        public int DeliveryRate { get; set; }
    }
}
