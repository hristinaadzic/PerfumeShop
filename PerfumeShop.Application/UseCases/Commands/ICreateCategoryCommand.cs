using PerfumeShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.Commands
{
    public interface ICreateCategoryCommand : ICommand<CategoryDto>
    {
    }
}
