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

namespace PerfumeShop.Implementation.UseCases.Commands.Users
{
    public class SoftDeleteUserCommand : EfUseCase, ISoftDeleteUserCommand
    {
        public SoftDeleteUserCommand(Context context) : base(context)
        {
        }

        public int Id => 13;

        public string Name => "Soft delete user";

        public string Description => "Updating isDeleted column";

        public void Execute(UserDto request)
        {
            var id = request.id;

            var user = Context.Users.FirstOrDefault(x => x.Id == id);

            if(user == null)
            {
                throw new EntityNotFoundException(nameof(User), request);
            }

            user.IsDeleted = true;
            user.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
