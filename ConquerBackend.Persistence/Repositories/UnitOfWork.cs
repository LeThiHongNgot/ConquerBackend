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
        private IDbContextTransaction _dbTransaction;

        public UnitOfWork(ConquerBackendContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _dbTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbTransaction != null)
            {
                await _dbTransaction.CommitAsync(cancellationToken);
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_dbTransaction != null)
            {
                await _dbTransaction.RollbackAsync(cancellationToken);
                await _dbTransaction.DisposeAsync();
                _dbTransaction = null;
            }
        }

        public void Dispose()
        {
            _dbTransaction?.Dispose();
            _dbContext?.Dispose();
        }
    }

}
