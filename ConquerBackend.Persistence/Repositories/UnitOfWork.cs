using AutoMapper;
using ConquerBackend.Domain.Respositories;
using ConquerBackend.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Persistence.Repositories
{
     public class UnitOfWork : IUnitOfWork
     {
        private readonly ConquerBackendContext _dbContext;
        private readonly IDbContextTransaction _dbTransaction;

        public UnitOfWork(ConquerBackendContext dbContext, IMapper mapper, IDbContextTransaction dbTransaction)
        {
            _dbContext = dbContext; 
            _dbTransaction = dbTransaction;
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbTransaction.CommitAsync(cancellationToken);
        }

    }
}
