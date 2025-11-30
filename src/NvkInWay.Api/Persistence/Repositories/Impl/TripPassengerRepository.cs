using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NvkInWay.Api.Domain;
using NvkInWay.Api.Exceptions;
using NvkInWay.Api.Persistence.DbContext;
using NvkInWay.Api.Persistence.Entities;

namespace NvkInWay.Api.Persistence.Repositories.Impl;

internal sealed class TripPassengerRepository(ApplicationContext applicationContext, IMapper mapper) : ITripPassengerRepository
{
    public async Task DeleteTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default)
    {
        var entity = await applicationContext.TripPassengers
            .FirstOrDefaultAsync(t => t.Id == tripPassenger.Id, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip passenger with id: '{tripPassenger.Id}', not found");
        
        applicationContext.TripPassengers.Remove(entity);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TripPassenger> CreateTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default)
    {
        var entity = mapper.Map<TripPassengerEntity>(tripPassenger);
        
        await applicationContext.TripPassengers.AddAsync(entity, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<TripPassenger>(entity);
    }

    public async Task UpdateTripPassengerAsync(TripPassenger tripPassenger, CancellationToken cancellationToken = default)
    {
        var entity = await applicationContext.TripPassengers
            .FirstOrDefaultAsync(t => t.Id == tripPassenger.Id, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip passenger with id: '{tripPassenger.Id}', not found");
        
        mapper.Map(tripPassenger, entity);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<TripPassenger> GetTripPassengerByIdAsync(long tripPassengerId, CancellationToken cancellationToken = default)
    {
        var entity = await applicationContext.TripPassengers
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == tripPassengerId, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip passenger with id: '{tripPassengerId}', not found");
        
        return mapper.Map<TripPassenger>(entity);
    }

    public async Task<IEnumerable<TripPassenger>> GetAllTripPassengersAsync(CancellationToken cancellationToken = default)
    {
        var passengers = await applicationContext.TripPassengers.AsNoTracking().ToListAsync(cancellationToken);
        
        return mapper.Map<IEnumerable<TripPassenger>>(passengers);
    }
}