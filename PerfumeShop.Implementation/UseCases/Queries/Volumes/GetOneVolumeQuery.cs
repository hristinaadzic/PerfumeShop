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

namespace PerfumeShop.Implementation.UseCases.Queries.Volumes
{
    public class GetOneVolumeQuery : EfUseCase, IGetOneVolumeQuery
    {
        public GetOneVolumeQuery(Context context) : base(context)
        {
        }

        public int Id => 27;

        public string Name => "Get one volume";

        public string Description => "Get volume by id";

        public VolumeDto Execute(int request)
        {
            var volume = Context.Volumes.Where(x => !x.IsDeleted).AsQueryable().FirstOrDefault(x => x.Id == request);

            if (volume == null)
            {
                throw new EntityNotFoundException(nameof(Volume), request);
            }

            return new VolumeDto
            {
                id = volume.Id,
                Volume = volume.VolumeInMillilitres
            };
        }
    }
}
