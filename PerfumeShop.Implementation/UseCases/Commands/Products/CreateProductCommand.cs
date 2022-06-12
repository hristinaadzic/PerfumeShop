using FluentValidation;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using PerfumeShop.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.Products
{
    public class CreateProductCommand : EfUseCase, ICreateProductCommand
    {
        CreateProductValidator _validator;
        public CreateProductCommand(Context context, CreateProductValidator validator) : base(context)
        {
            _validator = validator;
        }

        public int Id => 15;

        public string Name => "Create new product";

        public string Description => "Creating new product using EF";

        public void Execute(CreateProductDto request)
        {
            _validator.ValidateAndThrow(request);

            var product = new Product
            {
                Name = request.Name,
                Description = request.Description,
                GenderId = request.GenderId,
                BrandId = request.BrandId,
                ImagePath = request.ImagePath,

                ProductCategories = request.CategoryIds.Select(x => new ProductCategory
                {
                    CategoryId = x
                }).ToList(),
                ProductVolumes = request.VolumeIds.Select(x => new ProductVolume
                {
                    VolumeId = x
                }).ToList()
                
            };

            Context.Products.Add(product);
            Context.SaveChanges();
        }
    }
}
