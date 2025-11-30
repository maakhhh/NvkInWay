namespace NvkInWay.Api.Domain;

public class TripPassenger
{
    public long Id { get; set; }
    
    public long TripId { get; set; }

    public Trip Trip { get; set; } = null!;
    
    public long PassengerId { get; set; }
    
    public User Passenger { get; set; } = null!;
    
    public bool IsApproved { get; set; }
}