using PerfumeShop.Application.UseCases;
using PerfumeShop.DataAccess;
using PerfumeShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.UseCases.Commands
{
    public class EfUseCaseLogger
    {
        private Context _context;

        public EfUseCaseLogger(Context context)
        {
            _context = context;
        }

        public void Log(UseCaseLog log)
        {
            var useCaseLog = new UseCaseLog
            {
                UseCaseName = log.UseCaseName,
                UserId = log.UserId,
                ExecutionDateTime = log.ExecutionDateTime,
                Data = log.Data

            };

            _context.UseCaseLogs.Add(useCaseLog);
        }
    }
}
