using NvkInWay.Api.Persistence.Entities.Base;

namespace NvkInWay.Api.Persistence.Entities;

public class TripEntity : EntityBase
{
    public required string StartPlace { get; set; }
    
    public required string EndPlace { get; set; }
    
    public required DateTimeOffset StartTime { get; set; }
    
    public required DateTimeOffset EndTime { get; set; }
    
    public int SeatsCount { get; set; }
    
    public double SeatPrice { get; set; }
    
    public bool IsTaxi { get; set; }
    
    public string? Description { get; set; }

    public UserEntity Creator { get; set; } = null!;
    
    public long CreatorId { get; set; }
    
    public string? CarModel { get; set; }
    
    public string? CarNumber { get; set; }

    public bool IsClosed { get; set; }

    public bool IsDeleted { get; set; }
    
    public bool IsEnded { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    
    public DateTimeOffset UpdatedAt { get; set; }
}