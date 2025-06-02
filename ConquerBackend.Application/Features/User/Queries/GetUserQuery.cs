using System.Data;
using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Domain.Constants;
using ConquerBackend.Domain.Respositories.ConquerBackenQuery;
using ConquerBackend.Infrastructure.Redis.Abtractions;
using ConquerBackend.Shared.Converts;
using Microsoft.Extensions.Caching.Distributed;

namespace ConquerBackend.Application.Features.User.Queries
{
    public class GetUserQuery(
    IUserQueryRepository userQueryRepository,
    IRedisService redisService
     ) :IGetUserQuery 
    {
        public async Task<List<UsersDTO>> GetAll(CancellationToken cancellation)
        {

            var rs = await userQueryRepository.GetAll(cancellation);

            var rsFinall = rs.Select(user =>  new UsersDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FullName,
                DateOfBirth = user.DateOfBirth,
                IsDirector = user.IsDirector,
                IsHeadOfDepartment = user.IsHeadOfDepartment,
                ManagerId = user.ManagerId,
                PositionId = user.PositionId
            });
            return rsFinall.ToList();
        }
        public async Task<List<UsersDTO>> GetAllSaveRedis(CancellationToken cancellation)
        {
            try
            {
                var data = await redisService.GetAsync<List<UsersDTO>>(RedisConst.Prefix.GetDataUser, RedisConst.GetData, cancellation);

                if (data != null)
                {
                    return data; // ✅ Return nếu có cache
                }

                var rs = await userQueryRepository.GetAll(cancellation);

                var rsFinall = rs.Select(user => new UsersDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    FullName = user.FullName,
                    DateOfBirth = user.DateOfBirth,
                    IsDirector = user.IsDirector,
                    IsHeadOfDepartment = user.IsHeadOfDepartment,
                    ManagerId = user.ManagerId,
                    PositionId = user.PositionId
                }).ToList();

                var options = new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(4),
                };

                await redisService.SetStringAsync(RedisConst.Prefix.GetDataUser, RedisConst.GetData, rsFinall.ToJsonString(), options, cancellation); // ✅ truyền object, không cần ToJsonString()

                return rsFinall;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while getting user list: {ex.Message}");
                throw;
            }
        }
    }
}
