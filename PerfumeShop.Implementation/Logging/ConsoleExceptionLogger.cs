using PerfumeShop.Application.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void LogException(Exception exception)
        {
            Console.WriteLine("Occured at: " + DateTime.UtcNow);
            Console.WriteLine(exception.Message);
        }
    }
}
