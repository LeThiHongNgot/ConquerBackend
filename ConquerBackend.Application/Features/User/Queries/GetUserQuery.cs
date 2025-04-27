using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Domain.Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Application.Features.User.Queries
{
    public class GetUserQuery:IGetUserQuery 
    {
        private IDapperRepository _dapperRepository;
        public GetUserQuery(IDapperRepository dapperRepository) {
            _dapperRepository = dapperRepository;
        }
        public async Task<List<UsersDTO>> GetAll(CancellationToken cancellation)
        {
            var sql = @"Select *
                    From CONQUERBACKEND.Users
                    ";
            return await _dapperRepository.QueryAsync<UsersDTO>(sql, null, CommandType.Text, null, cancellation);
        }
    }
}
