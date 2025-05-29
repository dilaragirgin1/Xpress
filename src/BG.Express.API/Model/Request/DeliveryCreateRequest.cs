namespace BG.Express.API.Model.Request
{
    public class DeliveryCreateRequest
    {
        public int AddressId { get; set; } // Teslimatın yapılacağı adresin ID'si
        public DateTime? DeliveryDate { get; set; } // Opsiyonel: Planlanan teslimat tarihi
    }
}
