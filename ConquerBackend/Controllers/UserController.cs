using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using System.Threading;
using ConquerBackend.Domain.Entities.ConquerBackend;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConquerBackend.Domain.Paging;
using Microsoft.IdentityModel.Tokens;
using MediatR;
using ConquerBackend.Application.Features.User.Queries;
using ConquerBackend.Application.Common;
using Microsoft.AspNetCore.Components;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ConquerBackend.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService, IGetUserQuery _getUserQuery, IDispatch _dispatch) : ControllerBase
    {
        [HttpGet("MediatR")]
        public async Task<IActionResult> GetUserMediar(CancellationToken cancellationToken)
        {
            var users = await _dispatch.DispatchAsync(new GetUserListQuery(), cancellationToken);
            return Ok(users);
        }

        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<List<UsersDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var users = await _getUserQuery.GetAll(cancellationToken);
            return Ok(users);
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search([FromQuery] UsersDTO search , [FromQuery] PageParam param,CancellationToken cancellationToken)
        {
            
            var users = await _userService.GetAsync(search, param, cancellationToken);
            return Ok(users);
        }
        // GET: api/user/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersDTO>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        // POST: api/user
        [HttpPost]
        public async Task<ActionResult<UsersDTO>> Create([FromBody] UpdateUser input,CancellationToken cancellation)
        {
            var createdUser = await _userService.CreateAsync(input, cancellation);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        // PUT: api/user/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<UsersDTO>> Update(Guid id, [FromBody] UpdateUser input)
        {
            try
            {
                var updatedUser = await _userService.UpdateAsync(id, input);
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/user/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _userService.DeleteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
