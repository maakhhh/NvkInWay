using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NvkInWay.Api.Domain;
using NvkInWay.Api.Exceptions;
using NvkInWay.Api.Persistence.DbContext;
using NvkInWay.Api.Persistence.Entities;

namespace NvkInWay.Api.Persistence.Repositories.Impl;

internal sealed class TripRepository(ApplicationContext applicationContext, IMapper mapper) : ITripRepository
{
    public async Task<Trip> CreateTripAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        var entity = mapper.Map<TripEntity>(trip);
        
        await applicationContext.Trips.AddAsync(entity, cancellationToken);
        await applicationContext.SaveChangesAsync(cancellationToken);
        
        return mapper.Map<Trip>(entity);
    }

    public async Task DeleteTripAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        var entity = applicationContext.Trips
            .FirstOrDefaultAsync(t => t.Id == trip.Id, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip with id: '{trip.Id}', not found");
        
        applicationContext.Remove(entity);
        await applicationContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Trip> GetTripByIdAsync(long tripId, CancellationToken cancellationToken = default)
    {
        var entity = await applicationContext.Trips
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.Id == tripId, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip with id: '{tripId}' not found");
        
        return mapper.Map<Trip>(entity);
    }

    public async Task<Trip> UpdateTripAsync(Trip trip, CancellationToken cancellationToken = default)
    {
        var entity = await applicationContext.Trips
            .FirstOrDefaultAsync(t => t.Id == trip.Id, cancellationToken);
        
        if (entity is null)
            throw new NotFoundException($"Trip with id: '{trip.Id}' not found");
        
        mapper.Map(trip, entity);
        await applicationContext.SaveChangesAsync(cancellationToken);
        return trip;
    }

    public async Task<IEnumerable<Trip>> GetAllTripsAsync(CancellationToken cancellationToken = default)
    {
        var trips = await applicationContext.Trips.AsNoTracking().ToListAsync(cancellationToken);
        
        return mapper.Map<IEnumerable<Trip>>(trips);
    }
}