using ConquerBackend.Application.Common;
using ConquerBackend.Domain.Dapper;
using ConquerBackend.Persistence.Context;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Diagnostics;
using Dapper.Oracle;
namespace ConquerBackend.Persistence.Dapper
{
    public class DapperRepository(ConquerBackendContext dbContext, ILogger<DapperRepository> logger) :IDapperRepository
    {
        private readonly IDbConnection connection = dbContext.Database.GetDbConnection();
        private readonly ILogger<DapperRepository> _logger = logger;
        public async Task<List<T>> QueryAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var validParams = await GetValueParams(sql, commandType, transaction, param);
            sql = GetNameStoredProcedure(sql, commandType);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = (await connection.QueryAsync<T>(sql, validParams, transaction, commandType: commandType)).AsList();
            stopwatch.Stop();
            _logger.LogInformation($"Dapper Executed DbCommand ({stopwatch.ElapsedMilliseconds}ms) Stored Procedure/SQL: {sql}");
            return result;
        }
        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.StoredProcedure, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            var validParams = await GetValueParams(sql, commandType, transaction, param);
            sql = GetNameStoredProcedure(sql, commandType);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var result = await connection.ExecuteAsync(sql, validParams, transaction, commandType: commandType);
            stopwatch.Stop();
            _logger.LogInformation($"Dapper Executed DbCommand ({stopwatch.ElapsedMilliseconds}ms) Stored Procedure/SQL: {sql}");
            return result;
        }
        private static string GetNameStoredProcedure(string sql, CommandType commandType)
        {
            if (commandType == CommandType.StoredProcedure && !string.IsNullOrEmpty(AppConstants.DbSchema))
            {
                return $"{AppConstants.DbSchema}.{sql}";
            }

            return sql;
        }
        private async Task<object> GetValueParams(string sql, CommandType commandType, IDbTransaction transaction, object? param)
        {
            if (commandType != CommandType.StoredProcedure) return param;

            var validParams = await GetParamsOfProcedure(sql, transaction);
            var dynamicParameters = MapParameters(param, validParams);
            return dynamicParameters;
        }
        private static OracleDynamicParameters MapParameters(object? param, List<string> validParams)
        {
            if (param is OracleDynamicParameters oracleDynamic)
            {
                var result = new OracleDynamicParameters();
                foreach (var item in validParams)
                {
                    var getParamName = oracleDynamic.ParameterNames.FirstOrDefault(x => x.Equals(item, StringComparison.OrdinalIgnoreCase));

                    if (getParamName != null)
                    {
                        var paramInfo = oracleDynamic.GetParameter(getParamName);
                        result.Add(paramInfo.Name, paramInfo.Value, paramInfo.DbType, paramInfo.ParameterDirection);
                    }
                }

                return result;
            }

            return new OracleDynamicParameters();
        }

        private async Task<List<string>> GetParamsOfProcedure(string sql, IDbTransaction transaction)
        {
            string procedureName = sql.Split('.').LastOrDefault() ?? "";
            string query = $"SELECT ARGUMENT_NAME, DATA_TYPE, IN_OUT FROM ALL_ARGUMENTS WHERE OBJECT_NAME = '{procedureName}'   AND OWNER = '{AppConstants.DbSchema}'  ORDER BY POSITION";

            var paramNames = (await connection.QueryAsync<string>(query, null, transaction, commandType: CommandType.Text)).AsList();

            return paramNames;
        }
    }
}
