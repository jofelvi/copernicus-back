using copernicus_back.Entity;
using copernicus_back.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace copernicus_back.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly ILogger<UsersController> _logger;
        private readonly IRepository _repositorio;
        private readonly ApplictionDbContext _dbContext;

        public UsersController(ILogger<UsersController> logger, IRepository repositorio, ApplictionDbContext dbContext)
        {
            _logger = logger;
            _repositorio = repositorio;
            _dbContext = dbContext;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<List<User>>> Get()
        {
            return Ok(await _dbContext.Users.ToListAsync());
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = _dbContext.Users.FindAsync(id);
            if (user.Result == null)
            {
                return NotFound();
            }
            return Ok(user.Result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            
            try
            {
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex); 
            }
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User userbody)
        {
            var id = userbody.Id;
            var userDb = _dbContext.Users.FindAsync(id);
            if (userDb.Result == null)
            {
                return NotFound();
            }
            userDb.Result.email = userbody.email;
            userDb.Result.company = userbody.company;
            userDb.Result.first = userbody.first;
            userDb.Result.last = userbody.last;
            userDb.Result.country = userbody.country;
            await _dbContext.SaveChangesAsync();
            return Ok(userDb.Result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userDb = _dbContext.Users.FindAsync(id);
            if (userDb.Result == null)
            {
                return NotFound();
            }
            _dbContext.Remove(userDb.Result);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
