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

namespace PerfumeShop.Implementation.UseCases.Commands.Volumes
{
    public class SoftDeleteVolumeCommand : EfUseCase, ISoftDeleteVolumeCommand
    {
        public SoftDeleteVolumeCommand(Context context) : base(context)
        {
        }

        public int Id => 19;

        public string Name => "Soft delete volume";

        public string Description => "Updating isDeleted Column";

        public void Execute(VolumeDto request)
        {
            var id = request.id;

            var volume = Context.Products.FirstOrDefault(x => x.Id == id);

            if (volume == null)
            {
                throw new EntityNotFoundException(nameof(Volume), request);
            }

            volume.IsDeleted = true;
            volume.DeletedAt = DateTime.UtcNow;
            Context.SaveChanges();
        }
    }
}
