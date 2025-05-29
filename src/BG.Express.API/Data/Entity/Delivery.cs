namespace BG.Express.API.Data.Entity
{
    public class Delivery
    {
        public int Id { get; set; }
        public int AddressId { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public BG.Express.API.Data.Enums.DeliveryStatus Status { get; set; } // Enums'tan çağırıyoruz
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}
