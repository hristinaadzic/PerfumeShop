using Microsoft.EntityFrameworkCore;
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

namespace PerfumeShop.Implementation.UseCases.Queries.Users
{
    public class GetOneUsersQuery : EfUseCase, IGetOneUserQuery
    {
        public GetOneUsersQuery(Context context) : base(context)
        {
        }

        public int Id => 26;

        public string Name => "Get one user";

        public string Description => "Get user by id";

        public UserDto Execute(int request)
        {
            var user = Context.Users.Where(x => !x.IsDeleted).Include(x => x.Role).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }

            return new UserDto
            {
                id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                Email = user.Email,
                Role = user.Role.Name
            };
        }
    }
}
