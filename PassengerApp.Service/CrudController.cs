using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PassengerApp.Model;
using PassengerApp.Storage;

namespace PassengerApp.Service
{
    [Route("[controller]")]
    [ApiController]
    public class CrudController : ControllerBase
    {
        private CrudRepository<Passenger> repo;
        private readonly IMemoryCache _memoryCache;

        public CrudController(IMemoryCache memoryCache)
        {
            repo = new CrudRepository<Passenger>();
            _memoryCache = memoryCache;
        }

        [HttpGet("passenger/{id}")]
        public async Task<Passenger> Passenger(Guid id)
        {
            return await repo.Get(id);
        }

        [HttpPost("passenger")]
        public async Task<ActionResult<bool>> Passenger(Passenger passenger)
        {
            bool result = await repo.Insert(passenger);
            return result;
        }

        [HttpPut("Passenger")]
        public async Task<ActionResult<bool>> UpdatePassenger(Passenger passenger)
        {
            bool result = await repo.Update(passenger);
            return result;
        }

        [HttpGet("deletePassenger/{id}")]
        public async Task<bool> DeletePassenger(Guid id)
        {
            var passenger = await repo.Get(id);
            passenger.IsDeleted = true;
            bool result = await repo.Update(passenger);
            return result;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("test");
        }
    }
}

