using System;
using System.Linq;

namespace TicketSales.Core.Utilites.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {

        public DataResult(T data, bool success, string message) : base(message)
        {
            Data = data;
        }

        

        public T Data { get; }
    }
}
