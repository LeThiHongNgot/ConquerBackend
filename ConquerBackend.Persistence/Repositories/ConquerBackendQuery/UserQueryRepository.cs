using ConquerBackend.Application.Features.User.DTOs;
using System.Data;
using ConquerBackend.Domain.Dapper;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Respositories.ConquerBackenQuery;
using ConquerBackend.Persistence.Dapper;

namespace ConquerBackend.Persistence.Repositories.ConquerBackendQuery
{
    public class UserQueryRepository(IDapperRepository dapperRepository) : IUserQueryRepository
    {
        public async Task<List<UsersModel>> GetAll(CancellationToken cancellation)
        {
            var sql = @"SELECT * FROM CONQUERBACKEND.Users";
            var result = await dapperRepository.QueryAsync<UsersModel>(sql, null, CommandType.Text, null, cancellation);
            return result.ToList();
        }

    }
}
