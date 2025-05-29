using Beymen.IT.Package.ExceptionHandling.Exceptions;

namespace BG.Express.API.Exceptions;

public static class ExpressExceptions
{
    public static class Messages
    {
        public static string AddressNotFound(int id) => $"Adres bilgisi bulunamadı. AddressId: {id}";
        public static string AddressAlreadyExist(string customerCode) => $"Bu müşteri koduna ait adres zaten mevcut. CustomerCode: {customerCode}";
        public static string GeocodeServiceError(string responseBody) => $"Geocode servisinden hata döndü: {responseBody}";
        public static string DriverNotFound(string id) => $"Sürücü bilgisi bulunamadı. DriverId: {id}";
    }

    // BusinessException Tanımları
    public static readonly BusinessException AddressCannotBeNullOrEmpty = new("Adres bilgisi boş olamaz.");
    public static readonly BusinessException CustomerCodeCannotBeNullOrEmpty = new("Müşteri kodu boş olamaz.");
    public static readonly BusinessException GeocodeServiceFailed = new("Geocode servisi hatalı sonuç döndü.");

    
    // NotFoundException Tanımları
    public static readonly NotFoundException DriverNotFoundException = new("Sürücü bilgisi bulunamadı.");
    public static readonly NotFoundException AddressNotFoundException = new("Adres bilgisi bulunamadı.");
}
