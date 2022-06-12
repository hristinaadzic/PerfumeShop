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
    public class SoftDeleteCategoryCommand : EfUseCase, ISoftDeleteCategoryCommand
    {
        public SoftDeleteCategoryCommand(Context context) : base(context)
        {
        }

        public int Id => 9;

        public string Name => "Soft delete category";

        public string Description => "Updating isDelete column";

        public void Execute(CategoryDto request)
        {
            var id = request.id;

            var category = Context.Categories.FirstOrDefault(x => x.Id == id);

            if(category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            category.IsDeleted = true;
            category.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
