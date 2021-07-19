using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Core.Utilites.Results
{
    public class ErrorHandler : Exception
    {
        public ErrorHandler(string message) : base($"{message}") { }
    }
}
