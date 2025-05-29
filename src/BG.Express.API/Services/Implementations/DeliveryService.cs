using BG.Express.API.Data.Entity;
using BG.Express.API.Data.Enums;
using BG.Express.API.Model.Request;
using BG.Express.API.Model.Response;
using Beymen.IT.Package.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BG.Express.API.Services.Implementations
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeliveryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<int> CreateDeliveryAsync(DeliveryCreateRequest request)
        {
            // Adres kontrolü
            var address = await _unitOfWork.Repository<Address, int>().GetAsync(request.AddressId)
                ?? throw new Exception("Address not found.");

            // Teslimat kaydı oluşturma
            var delivery = new Delivery
            {
                AddressId = request.AddressId,
                TrackingNumber = Guid.NewGuid().ToString(),
                DeliveryDate = request.DeliveryDate ?? DateTime.UtcNow.AddDays(3), // Varsayılan: 3 gün sonrası
                Status = DeliveryStatus.Pending,
                CreateTime = DateTime.UtcNow
            };

            await _unitOfWork.Repository<Delivery, int>().InsertAsync(delivery);
            await _unitOfWork.SaveChangesAsync();

            return delivery.Id;
        }

    }
}
