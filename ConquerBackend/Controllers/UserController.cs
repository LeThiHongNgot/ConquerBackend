using ConquerBackend.Application.Common;
using ConquerBackend.Application.Features.User.DTOs;
using ConquerBackend.Application.Features.User.Interface;
using ConquerBackend.Application.Features.User.Queries;
using ConquerBackend.Domain.Paging;
using Hangfire;
using Microsoft.AspNetCore.Mvc;

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
        [HttpGet("GetByDapper")]
        public async Task<ActionResult<List<UsersDTO>>> GetAll(CancellationToken cancellationToken)
        {
            var users = await _getUserQuery.GetAllSaveRedis(cancellationToken);
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
        [HttpGet("error")]
        public IActionResult ThrowError()
        {
            throw new Exception("Lỗi test middleware!");
        }

        [HttpPost("BackgroundJob")]
        public IActionResult CreateBackgroundJob()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Background Job Trigger"));
            return Ok();
        }
        [HttpPost("ScheduleJob")]
        public IActionResult CreateScheduleJob()
        {
            var scheduleDateTime = DateTime.UtcNow.AddSeconds(10);
            var dateTimeOffset = new DateTimeOffset(scheduleDateTime);
            BackgroundJob.Schedule(() => Console.WriteLine("Schedule Job Triggered"), scheduleDateTime);
            return Ok();
        }
        [HttpPost("ContinueJob")]
        public IActionResult CreateContinueJob()
        {
            var scheduleDateTime = DateTime.UtcNow.AddSeconds(10);
            var dateTimeOffset = new DateTimeOffset(scheduleDateTime);
            var jobId = BackgroundJob.Schedule(() => Console.WriteLine("Schedule Job On Continue Triggered"), scheduleDateTime);
            var job2Id = BackgroundJob.ContinueJobWith(jobId, () => Console.WriteLine("Continue 1 Job Triggered"));
            var job3Id = BackgroundJob.ContinueJobWith(job2Id, () => Console.WriteLine("Continue 2 Job Triggered"));
            return Ok();
        }
        //Cron.Minutely       // Mỗi phút
        //Cron.Hourly         // Mỗi giờ
        //Cron.Daily          // Mỗi ngày
        //Cron.Weekly         // Mỗi tuần
        //"*/5 * * * *"       // Mỗi 5 phút
        //"0 8 * * 1-5"       // 8 giờ sáng từ thứ 2 đến thứ 6

        [HttpPost("RecurringJob")]
        public IActionResult CreateRecurringJob()
        {
            RecurringJob.AddOrUpdate(
               recurringJobId: "RecurringJob1",
               methodCall: () => Console.WriteLine($"[Recurring Job] Triggered at {DateTime.Now}"),
               cronExpression: Cron.Minutely); // chạy mỗi phút
            return Ok();
        }
    }
}
