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
    public class BrandsController : ControllerBase
    {

        private UseCaseHandler _handler;

        public BrandsController(UseCaseHandler handler)
        {
            _handler = handler;
        }
        /// <summary>
        /// Get all brands.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetBrandsQuery query)
        {

            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Get all categories.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneBrandQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        /// <summary>
        /// Creates new brand.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Brands
        ///     {
        ///        "name": "New Brand"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromBody] BrandDto dto, [FromServices] ICreateBrandCommand command)
        {
            _handler.HandleCommand(command, dto);
            return StatusCode(201);
        }

        /// <summary>
        /// Updates brand.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Brands
        ///     {
        ///        "name": "New Brand"
        ///     }
        ///
        /// </remarks>
        /// <response code="204">No content.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BrandDto dto, [FromServices] IUpdateBrandCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

        /// <summary>
        /// Soft delete category.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="204">No contet.</response>
        /// <response code="404">Entity not found</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromRoute] BrandDto dto, [FromServices] ISoftDeleteBrandCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

    }
}
