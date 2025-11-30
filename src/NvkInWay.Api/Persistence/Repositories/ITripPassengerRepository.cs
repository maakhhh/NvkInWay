using NvkInWay.Api.Domain;

namespace NvkInWay.Api.Persistence.Repositories;

public interface ITripPassengerRepository
{
    Task DeleteTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default);
    
    Task<TripPassenger> CreateTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default);
    
    Task UpdateTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default);
    
    Task<TripPassenger> GetTripPassengerByIdAsync(long tripPassengerId, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<TripPassenger>> GetAllTripPassengersAsync(CancellationToken cancellationToken = default);
}