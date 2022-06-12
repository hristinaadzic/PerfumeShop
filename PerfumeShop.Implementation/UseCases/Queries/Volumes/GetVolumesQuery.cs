using PerfumeShop.Application.UseCases.DTO;
using PerfumeShop.Application.UseCases.DTO.Searches;
using PerfumeShop.Application.UseCases.Queries;
using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Queries.Volumes
{
    public class GetVolumesQuery : EfUseCase, IGetVolumesQuery
    {
        public GetVolumesQuery(Context context) : base(context)
        {
        }

        public int Id => 20;

        public string Name => "Get volumes";

        public string Description => "Get all volumes";

        public IEnumerable<VolumeDto> Execute(BaseSearch request)
        {
            var query = Context.Volumes.Where(x => !x.IsDeleted).AsQueryable();

            return query.Select(x => new VolumeDto
            {
                Volume = x.VolumeInMillilitres
            }).ToList();
        }
    }
}
