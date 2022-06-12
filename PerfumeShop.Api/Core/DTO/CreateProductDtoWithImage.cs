using Microsoft.AspNetCore.Http;
using PerfumeShop.Application.UseCases.DTO;

namespace PerfumeShop.Api.Core.DTO
{
    public class CreateProductDtoWithImage : CreateProductDto
    {
        public IFormFile Image { get; set; }
    }
}
