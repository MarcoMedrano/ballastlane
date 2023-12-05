using BallestLane.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BallastLane.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NftsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<NftsController> _logger;

        public NftsController(ILogger<NftsController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetNfts")]
        public IEnumerable<Nft> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Nft
            {
                Id = (ulong)index,
                Name = "Some " + index
            })
            .ToArray();
        }
    }
}
