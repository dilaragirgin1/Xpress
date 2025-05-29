using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BG.Express.API.Data.Entities
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? PlateNumber { get; set; } // Araç plakası

        public string? StartLocationCode { get; set; } // Başlangıç lokasyon kodu

        public string? EndLocationCode { get; set; } // Bitiş lokasyon kodu

        public string? CrossDockCode { get; set; } // CrossDock kodu

        public int? VolumeCapacity { get; set; } // Hacim kapasitesi

        public int? BoxCapacity { get; set; } // Kutu kapasitesi

        public bool IsActive { get; set; } // Aktiflik durumu

        public DateTime CreateTime { get; set; } = DateTime.UtcNow; // Oluşturulma zamanı

        public string CreateUserCode { get; set; } // Oluşturan kullanıcının kodu

        public DateTime? UpdateTime { get; set; } // Güncelleme zamanı

        public string? UpdateUserCode { get; set; } // Güncelleyen kullanıcının kodu

        public string? DriverCode { get; set; } // Sürücü kodu

        public decimal? FixedUsageCost { get; set; } // Sabit kullanım maliyeti

        public decimal? CostPerKm { get; set; } // Kilometre başına maliyet

        public DateTime? EarliestAvailableTime { get; set; } // En erken kullanılabilirlik zamanı

        public DateTime? LatestAvailableTime { get; set; } // En geç kullanılabilirlik zamanı

        public string? VehicleType { get; set; } // Araç tipi

        public decimal? SpeedMultiplier { get; set; } // Hız çarpanı

        public decimal? ServiceTimeMultiplier { get; set; } // Servis süresi çarpanı

        public bool? IsHostes { get; set; } // Hostes durumu
    }
}
