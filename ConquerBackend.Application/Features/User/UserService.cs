using AutoMapper;
using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Domain.Entities.ConquerBackend;
using ConquerBackend.Domain.Paging;
using ConquerBackend.Domain.Respositories.ConquerBackend;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConquerBackend.Application.Features.User
{
    public class UserService : IUserService 
    {
        private readonly IUserRepository _userRepository;
        public  UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<UsersDTO>> GetAllAsync(CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetAsync(cancellationToken);
            return users.Select(user => new UsersDTO
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
            
        }
        public async Task<PagedResult<UsersModel>> GetAsync(
    UsersDTO search,
    PageParam param,
    CancellationToken cancellationToken = default)
        {
            Expression<Func<UsersModel, bool>> predicate = e =>
            (string.IsNullOrEmpty(search.FirstName) || e.FirstName.Contains(search.FirstName)) &&
            (string.IsNullOrEmpty(search.LastName) || e.LastName.Contains(search.LastName)) &&
            (string.IsNullOrEmpty(search.FullName) || e.FullName.Contains(search.FullName)) &&
            (!search.DateOfBirth.HasValue || e.DateOfBirth.Value.Date == search.DateOfBirth.Value.Date) &&
            (!search.IsDirector.HasValue || e.IsDirector == search.IsDirector) &&
            (!search.IsHeadOfDepartment.HasValue || e.IsHeadOfDepartment == search.IsHeadOfDepartment);

            var items = await _userRepository.GetAsync(predicate, param.PageNumber, param.PageSize, cancellationToken);
            var totalItems =await _userRepository.GetTotalItemsAsync(predicate, cancellationToken);
            var result = new PagedResult<UsersModel>
            {
                Items = items.ToList(),
                TotalItems = totalItems,
                PageNumber = param.PageNumber,
                PageSize = param.PageSize
            };

            return result;
        }


        public async Task<UsersDTO?> GetByIdAsync(Guid id)
        {
            var user = await _userRepository.GetSingleAsync(id);
            if (user == null) return null;

            return new UsersDTO
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
            };
        }

        public async Task<UsersDTO> CreateAsync(UpdateUser input, CancellationToken cancellation)
        {
            // Create a new UsersModel entity from the input
            var entity = new UsersModel
            {
                Id = Guid.NewGuid(),
                FirstName = input.FirstName,
                LastName = input.LastName,
                FullName = $"{input.FirstName} {input.LastName}",
                DateOfBirth = input.DateOfBirth,
                IsDirector = input.IsDirector,
                IsHeadOfDepartment = input.IsHeadOfDepartment,
                ManagerId = input.ManagerId,
                PositionId = input.PositionId
            };

            // Insert the entity into the repository
            await _userRepository.InsertAsync(entity, cancellation);

            // Commit the changes (this saves the data in the database)
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellation);

            // Create a DTO to return the created user data
            var data = new UsersDTO
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                FullName = entity.FullName,
                DateOfBirth = entity.DateOfBirth,
                IsDirector = entity.IsDirector,
                IsHeadOfDepartment = entity.IsHeadOfDepartment,
                ManagerId = entity.ManagerId,
                PositionId = entity.PositionId
            };

            // Return the created DTO
            return data;
        }


        public async Task<UsersDTO> UpdateAsync(Guid id, UpdateUser input)
        {
            var user = await _userRepository.GetSingleAsync(id)
                       ?? throw new Exception("User not found");

            user.FirstName = input.FirstName;
            user.LastName = input.LastName;
            user.FullName = $"{input.FirstName} {input.LastName}";
            user.DateOfBirth = input.DateOfBirth;
            user.IsDirector = input.IsDirector;
            user.IsHeadOfDepartment = input.IsHeadOfDepartment;
            user.ManagerId = input.ManagerId;
            user.PositionId = input.PositionId;

            _userRepository.Update(user);

            return new UsersDTO
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
            };
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            await _userRepository.DeleteAsync(id);
            return true;
        }
    }

}
