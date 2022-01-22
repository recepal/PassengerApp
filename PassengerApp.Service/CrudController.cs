using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using PassengerApp.Model;
using PassengerApp.Storage;

namespace PassengerApp.Service
{
    [Route("[controller]")]
    [ApiController]
    public class CrudController:ControllerBase
    {
        private CrudRepository<Passenger> repo;
        private readonly IMemoryCache _memoryCache;

        public CrudController(IMemoryCache memoryCache)
        {
            repo = new CrudRepository<Passenger>();
            _memoryCache = memoryCache;
        }

        [HttpGet("test")]
        public ActionResult Test()
        {
            return Ok("test");
        }

        [HttpPost("passenger")]
        public async Task<ActionResult> Passenger(Passenger passenger)
        {
           // _memoryCache.CreateEntry(passenger);

            bool result = await repo.Insert(passenger);
            string message = result ? "Kayıt tamamlandı" : "Kayıt tamamlanmadı..";
            return Ok(message);
        }

        [HttpPut("Passenger")]
        public async Task<ActionResult> UpdatePassenger(Passenger passenger)
        {
            //_memoryCache.

            bool result = await repo.Update(passenger);
            string message = result ? "Kayıt tamamlandı" : "Kayıt tamamlanmadı..";
            return Ok(message);
        }
    }
}

