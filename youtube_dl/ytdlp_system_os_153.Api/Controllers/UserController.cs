using Microsoft.AspNetCore.Mvc;
using System.Net;
using ytdlp_system_os_153.Application.Common;
using ytdlp_system_os_153.Application.Services.Users.Interfaces;
using ytdlp_system_os_153.Application.Services.Users.Requests;
using ytdlp_system_os_153.Application.Services.Users.Responses;

namespace ytdlp_system_os_153.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("GetById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            var response = await _service.GetByIdAsync(id, cancellationToken);

            if (response == null)
                return NotFound(ApiResponse<UserResponse>.ErrorResponse("User not found"));

            return StatusCode((int)HttpStatusCode.Created, ApiResponse<UserResponse>.SuccessResponse(response));
        }

        [HttpGet("ListAll")]
        public async Task<IActionResult> List(CancellationToken cancellationToken)
        {
            var response = await _service.ListAsync(cancellationToken);

            return Ok(ApiResponse<IEnumerable<UserResponse>>.SuccessResponse(response));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Create([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _service.CreateAsync(request, cancellationToken);

            var response = ApiResponse<UserResponse>.SuccessResponse(user, "User created successfully");

            return StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var response = await _service.UpdateAsync(request, cancellationToken);

            if (response == null)
                return NotFound(ApiResponse<UserResponse>.ErrorResponse("User not found"));

            return Ok(ApiResponse<UserResponse>.SuccessResponse(response, "User updated"));
        }

        [HttpDelete("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            var response = await _service.DeleteAsync(id, cancellationToken);

            if (response == null)
                return NotFound(ApiResponse<UserResponse>.ErrorResponse("User not found"));

            return Ok(ApiResponse<UserResponse>.SuccessResponse(response, "User deleted"));
        }
    }
}
