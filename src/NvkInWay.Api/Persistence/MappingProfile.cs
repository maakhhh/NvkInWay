using AutoMapper;
using NvkInWay.Api.Domain;
using NvkInWay.Api.Persistence.Entities;

namespace NvkInWay.Api.Persistence;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();
        CreateMap<RefreshToken, RefreshTokenEntity>();
        CreateMap<RefreshTokenEntity, RefreshToken>();
        CreateMap<UserSession, UserSessionsEntity>();
        CreateMap<UserSessionsEntity, UserSession>();
        CreateMap<Trip, TripEntity>();
        CreateMap<TripEntity, Trip>();
        CreateMap<TripPassenger, TripPassengerEntity>();
        CreateMap<TripPassengerEntity, TripPassenger>();
    }
}