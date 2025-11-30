using NvkInWay.Api.Domain;

namespace NvkInWay.Api.Persistence.Repositories;

public interface ITripRepository
{
    Task<Trip> CreateTripAsync(Trip trip, CancellationToken cancellationToken = default);
    
    Task DeleteTripAsync(Trip trip, CancellationToken cancellationToken = default);
    
    Task<Trip> GetTripByIdAsync(long tripId, CancellationToken cancellationToken = default);
    
    Task<Trip> UpdateTripAsync(Trip trip, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<Trip>> GetAllTripsAsync(CancellationToken cancellationToken = default);
}