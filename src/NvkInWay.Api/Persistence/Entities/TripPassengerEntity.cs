using NvkInWay.Api.Persistence.Entities.Base;

namespace NvkInWay.Api.Persistence.Entities;

public class TripPassengerEntity : EntityBase
{
    public long TripId { get; set; }

    public TripEntity Trip { get; set; } = null!;
    
    public long PassengerId { get; set; }
    
    public UserEntity Passenger { get; set; } = null!;
    
    public bool IsApproved { get; set; }
}