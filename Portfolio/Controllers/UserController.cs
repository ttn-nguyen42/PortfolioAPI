using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Entities;
using Portfolio.Models.Gets;
using Portfolio.Repositories.Interfaces;

namespace Portfolio.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        private readonly IMapper _mapper;

        public UserController(IUserRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<UserDto>> GetUsers()
        {
            IEnumerable<User> entity = await _repository.GetUsersAsync();
            return Ok(entity);
        }
    }
}
