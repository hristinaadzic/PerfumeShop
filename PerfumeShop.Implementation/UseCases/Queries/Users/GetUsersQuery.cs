using Microsoft.EntityFrameworkCore;
using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Users
{
    public class GetUsersQuery : EfUseCase, IGetUsersQuery
    {
        public GetUsersQuery(Context context) : base(context)
        {
        }

        public int Id => 4;

        public string Name => "Search users";

        public string Description => "Searching users using EF";

        public IEnumerable<UserDto> Execute(BaseSearch request)
        {
            var query = Context.Users.Where(x => !x.IsDeleted).Include(x => x.Role).AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.FirstName.Contains(request.Keyword) ||
                                         x.LastName.Contains(request.Keyword));
            }

            return query.Select(x => new UserDto
            {
                id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                Email = x.Email,
                Role = x.Role.Name
            }).ToList();
        }
    }
}
