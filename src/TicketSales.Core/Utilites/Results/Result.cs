using System;
using System.Linq;

namespace TicketSales.Core.Utilites.Results
{
    public class Result : IResult
    {
        public Result(string message)
        {
            Message = message;
        }
        public bool Success { get; }
        public string Message { get; }
    }
}
