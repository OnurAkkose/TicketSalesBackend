using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketSales.Core.CrossCuttingConcerns.Caching.Redis
{
    public interface IRedisManager
    {
        Task<string> GetCacheValueAsync(string key);
        Task SetCacheValueAsync(string key, object data);
    }
}
