using NvkInWay.Api.Domain;

namespace NvkInWay.Api.Services;

public interface IUserService
{
    Task<User> GetUserById(long userId);
}