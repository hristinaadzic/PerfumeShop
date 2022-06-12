using PerfumeShop.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases
{
    public abstract class EfUseCase
    {
        protected EfUseCase(Context context)
        {
            Context = context;
        }
        protected Context Context { get; }
    }
}
