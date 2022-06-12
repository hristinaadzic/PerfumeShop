using FluentValidation;
using PerfumeShop.Application.Emails;
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

namespace PerfumeShop.Implementation.UseCases.Queries.Users
{
    public class RegisterUserCommand : EfUseCase, IRegisterUserCommand
    {
        private RegisterUserValidator _validator;
        private IEmailSender _sender;
        public RegisterUserCommand(Context context, RegisterUserValidator validator, IEmailSender sender) : base(context)
        {
            _validator = validator;
            _sender = sender;
        }

        public int Id => 21;

        public string Name => "User registration";

        public string Description => "Register new user";

        public void Execute(RegisterDto request)
        {
            _validator.ValidateAndThrow(request);

            var hash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            var user = new User
            {
                Email = request.Email,
                Password = request.Password,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                RoleId = 2
            };

            Context.Users.Add(user);
            Context.SaveChanges();

            _sender.Send(new MessageDto
            {
                To = request.Email,
                Title = "Successfull registration!",
                Body = "Dear " + request.FirstName + "\n Please activate your account...."
            });
        }
    }
}
