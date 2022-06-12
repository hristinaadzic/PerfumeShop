using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.UseCases.Queries
{
    public interface IGetOrdersQuery : IQuery<BaseSearch, IEnumerable<OrderDto>>
    {
    }
}
