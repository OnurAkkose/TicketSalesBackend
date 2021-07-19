using System;
using System.Linq;

namespace TicketSales.Core.Utilites.Results
{
    public interface IDataResult<out T> : IResult
    {
        T Data { get; }
    }
}
