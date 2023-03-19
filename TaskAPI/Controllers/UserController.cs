using AutoMapper;
using core;
using Microsoft.AspNetCore.Mvc;
using Services;
using TaskAPI.Dto;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaskAPI.Controllers
{
    /// <summary>
    /// The user controller.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IMapper mapper, IUserService userService)
        {
            this.mapper = mapper;
            this.userService = userService;
        }


        /// <summary>
        /// Gets the.
        /// </summary>
        /// <returns>A list of UserDtos.</returns>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            IEnumerable<User> result = userService.GetAll();

            return this.mapper.Map<IEnumerable<UserDto>>(result);
        }


        /// <summary>
        /// Gets the.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>An UserDto.</returns>
        [HttpGet("{id}")]
        public UserDto Get(Guid id)
        {
            UserDto user = this.mapper.Map<UserDto>(userService.Get(id));
            if (user == null)
            {
                this.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
            }
            return user;
        }

        /// <summary>
        /// Posts the.
        /// </summary>
        /// <param name="userDto">The user dto.</param>
        /// <returns>An UserDto.</returns>
        [HttpPost]
        public UserDto Post([FromBody] UserDto userDto)
        {
            User user = this.mapper.Map<User>(userDto);
            return this.mapper.Map<UserDto>(this.userService.Create(user));
        }

        
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] UserDto value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            this.userService.Delete(id);
            this.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        }
    }
}
