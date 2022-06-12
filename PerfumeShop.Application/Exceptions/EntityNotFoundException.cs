using PerfumeShop.Application.UseCases.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        private BrandDto request;

        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException(string v, Dto request)
        {
        }

        public EntityNotFoundException(string entityType, int id)
            : base($"Entity of type {entityType} with an id of {id} was not found.")
        {

        }

        public EntityNotFoundException(string message, BrandDto request) : base(message)
        {
            this.request = request;
        }
    }
}
