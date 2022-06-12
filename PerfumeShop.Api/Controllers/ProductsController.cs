using Microsoft.AspNetCore.Mvc;
using PerfumeShop.Api.Core.DTO;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PerfumeShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public static IEnumerable<string> AllowedExtensions => new List<string> { ".jpg", ".png", ".jpeg" };
        private UseCaseHandler _handler;

       
        public ProductsController(UseCaseHandler handler)
        {
            _handler = handler;
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet]
        public IActionResult Get([FromQuery] BaseSearch search, [FromServices] IGetProductsQuery query)
        {
            return Ok(_handler.HandleQuery(query, search));
        }

        /// <summary>
        /// Get all products.
        /// </summary>
        /// <returns></returns>
        /// <response code="404">EntityNotFound.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneProductQuery query)
        {
            return Ok(_handler.HandleQuery(query, id));
        }

        /// <summary>
        /// Creates new product.
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        /// <response code="201">Successfull creation.</response>
        /// <response code="422">Validation failure.</response>
        /// <response code="500">Unexpected server error.</response>
        [HttpPost]
        public IActionResult Post([FromForm] CreateProductDtoWithImage dto,[FromServices] ICreateProductCommand command)
        {
            if (dto.Image != null)
            {
                var guid = Guid.NewGuid().ToString();

                var extension = Path.GetExtension(dto.Image.FileName);

                if (!AllowedExtensions.Contains(extension))
                {
                    throw new InvalidOperationException("Unsupported file type.");
                }

                var fileName = guid + extension;

                var filePath = Path.Combine("wwwroot", "images", fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                dto.Image.CopyTo(stream);


                dto.ImagePath = fileName;
            }

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
        public IActionResult Patch(int id, [FromRoute] ProductDto dto, [FromServices] ISoftDeleteProductCommand command)
        {
            dto.id = id;
            _handler.HandleCommand(command, dto);
            return NoContent();
        }

    }
}
