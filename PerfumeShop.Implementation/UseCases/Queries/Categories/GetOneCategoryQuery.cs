using PerfumeShop.Application.Exceptions;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Categories
{
    public class GetOneCategoryQuery : EfUseCase, IGetOneCategoryQuery
    {
        public GetOneCategoryQuery(Context context) : base(context)
        {
        }

        public int Id => 23;

        public string Name => "Get one category";

        public string Description => "Get category by id";

        public CategoryDto Execute(int request)
        {
            var category = Context.Categories.Where(x => !x.IsDeleted).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (category == null)
            {
                throw new EntityNotFoundException(nameof(Category), request);
            }

            return new CategoryDto
            {
                id = category.Id, 
                Name = category.Name
            };
        }
    }
}
