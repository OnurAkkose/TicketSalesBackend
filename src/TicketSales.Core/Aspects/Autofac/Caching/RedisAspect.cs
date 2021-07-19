using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Core.CrossCuttingConcerns.Caching.Redis;
using TicketSales.Core.Utilites.Interceptors;
using Microsoft.Extensions.DependencyInjection;
using TicketSales.Core.Utilites.IoC;
using Castle.DynamicProxy;

namespace TicketSales.Core.Aspects.Autofac.Caching
{
    public class RedisAspect : MethodInterception
    {
        private IRedisManager _redisManager;

        public RedisAspect()
        {
            _redisManager = ServiceTool.ServiceProvider.GetService<IRedisManager>();
        }
        public override void Intercept(IInvocation invocation)
        {
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            var keyy = "redisKeyExample";
            invocation.Proceed();
            _redisManager.SetCacheValueAsync(keyy, invocation.ReturnValue);
        }
    }
}
