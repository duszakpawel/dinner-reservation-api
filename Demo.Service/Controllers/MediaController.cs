using Demo.Contracts;
using Demo.Logic.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Service.Controllers
{
    /// <summary>
    /// Media controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class MediaController(ILogger<MediaController> logger) : ControllerBase
    {
        private readonly ILogger<MediaController> _logger = logger;

        /// <summary>
        /// Retrieves all media
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Media>), StatusCodes.Status200OK)]
        public async Task<IEnumerable<Media>> Get()
        {
            // TODO: dispatcher for handlers + entire DI

            var handlerResult = await _dispatcher.Execute<IEnumerable<Logic.Models.Entities.Media>>(new GetMediaQuery());
            
            return handlerResult.Result.Value.Select(q => q.ToContract()).ToList();
        }
    }
}
