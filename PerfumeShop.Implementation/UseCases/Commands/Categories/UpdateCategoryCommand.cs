using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.Commands;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands.Categories
{
    public class UpdateCategoryCommand : EfUseCase, IUpdateCategoryCommand
    {
        public UpdateCategoryCommand(Context context) : base(context)
        {
        }

        public int Id => 8;

        public string Name => "Update category";

        public string Description => "Updating specific category using EF";

        public void Execute(CategoryDto request)
        {
            var id = request.id;
            var name = request.Name;

            var category = Context.Categories.FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            if (string.IsNullOrEmpty(name))
            {
                throw new Exception();
            }

            category.Name = name;
            Context.SaveChanges();
        }
    }
}
