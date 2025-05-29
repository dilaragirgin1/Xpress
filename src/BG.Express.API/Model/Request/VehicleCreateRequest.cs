public class VehicleCreateRequest
{
    public string? PlateNumber { get; set; }
    public string? StartLocationCode { get; set; }
    public string? EndLocationCode { get; set; }
    public int? VolumeCapacity { get; set; }
    public string CreateUserCode { get; set; }
    public string? CrossDockCode { get; set; }
    public bool IsActive { get; set; }
}
