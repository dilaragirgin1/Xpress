namespace BG.Express.API.Model.Request
{
    public class VehicleUpdateRequest
    {
        public string? PlateNumber { get; set; }
        public string? StartLocationCode { get; set; }
        public string? EndLocationCode { get; set; }
        public int? VolumeCapacity { get; set; }
        public string? UpdateUserCode { get; set; }
        public bool IsActive { get; set; }
    }
}
