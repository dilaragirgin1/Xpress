namespace BG.Express.API.Model.Response
{
    public class DeliveryResponse
    {
        public int Id { get; set; } // Teslimat ID'si
        public int AddressId { get; set; } // Adres ID'si
        public string TrackingNumber { get; set; } // Benzersiz takip numarası
        public DateTime DeliveryDate { get; set; } // Planlanan teslimat tarihi
        public string Status { get; set; } // Teslimat durumu
    }
}
