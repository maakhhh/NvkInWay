using NvkInWay.Api.Domain;
using NvkInWay.Api.Persistence.Repositories;

namespace NvkInWay.Api.Services.Impl;

internal sealed class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<User> GetUserById(long userId)
    {
        return await userRepository.GetUserByIdAsync(userId);
    }
}