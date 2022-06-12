using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private UseCaseHandler _handler;

        public PricesController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Get all prices.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        /// <summary>
        /// Get one price.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Creates new price for product volume.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Prices
        ///     {
        ///        "ProductVolumeId":1,
        ///        "Price": 99
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] PriceDto dto, [FromServices] ICreatePriceCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        /// <summary>
        /// Soft delete volume.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="204">No contet.</response>
        /// <response code="404">Entity not found</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromRoute] PriceDto dto, [FromServices] ISoftDeletePriceCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

    }
}
