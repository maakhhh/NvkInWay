namespace NvkInWay.Api.V1.Models;

public class V1CreateTripDto
{
    public required string StartPlace { get; set; }
    
    public required string EndPlace { get; set; }
    
    public required DateTimeOffset StartTime { get; set; }
    
    public required DateTimeOffset EndTime { get; set; }
    
    public int SeatsCount { get; set; }
    
    public double SeatPrice { get; set; }
    
    public bool IsTaxi { get; set; }
    
    public string? Description { get; set; }
    
    public string? CarModel { get; set; }
    
    public string? CarNumber { get; set; }
}