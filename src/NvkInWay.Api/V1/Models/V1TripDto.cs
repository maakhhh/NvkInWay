namespace NvkInWay.Api.V1.Models;

public class V1TripDto
{
    public long Id { get; set; }
    
    public required string StartPlace { get; set; }
    
    public required string EndPlace { get; set; }
    
    public required DateTimeOffset StartTime { get; set; }
    
    public required DateTimeOffset EndTime { get; set; }
    
    public int SeatsCount { get; set; }
    
    public double SeatPrice { get; set; }
    
    public bool IsTaxi { get; set; }
    
    public string? Description { get; set; }

    public V1UserDto Creator { get; set; } = null!;
    
    public long CreatorId { get; set; }
    
    public string? CarModel { get; set; }
    
    public string? CarNumber { get; set; }

    public bool IsClosed { get; set; }

    public bool IsDeleted { get; set; }
    
    public bool IsEnded { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }
}