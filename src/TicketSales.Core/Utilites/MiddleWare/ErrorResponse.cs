using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Core.Utilites.MiddleWare
{
    public class ErrorResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
