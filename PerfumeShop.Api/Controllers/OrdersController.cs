using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.Implementation;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private UseCaseHandler _handler;

        public OrdersController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Get all orders.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetOrdersQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Get one order.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneOrderQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        /// <summary>
        /// Creates new order.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Orders
        ///     {
        ///        "UserId":1,
        ///        "OrderLines":[
        ///             {
        ///                 ProductVolumeId = 1,
        ///                 Quantity = 1
        ///             },
        ///             {
        ///                 ProductVolumeId = 2,
        ///                 Quantity = 1
        ///             }
        ///         ]
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] CreateOrderDto dto, [FromServices] ICreateOrderCommand command)
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
        public IActionResult Patch(int id, [FromRoute] OrderDto dto, [FromServices] ISoftDeleteOrderCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }
    }
}
