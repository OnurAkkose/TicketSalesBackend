using Autofac;
using AutoMapper;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketSales.Business.Abstract;
using TicketSales.Business.Concrete;
using TicketSales.Business.Mapping.AutoMapper;
using TicketSales.Business.Mapping.AutoMapper.Companies;
using TicketSales.Business.Mapping.AutoMapper.Tickets;
using TicketSales.Business.Mapping.AutoMapper.Users;
using TicketSales.Core.Security.Jwt;
using TicketSales.Core.Utilites.Interceptors;
using TicketSales.DataAccess.Abstract;
using TicketSales.DataAccess.Concrete;
using TicketSales.DataAccess.Concrete.Contexts;
using TicketSales.MessageBroker.RabbitMQ.Abstract;
using TicketSales.MessageBroker.RabbitMQ.Concrete;

namespace TicketSales.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CompanyManager>().As<ICompanyService>();
            builder.RegisterType<TicketManager>().As<ITicketService>();

            builder.RegisterType<EfCompanyDal>().As<ICompanyDal>();
            builder.RegisterType<EfTicketDal>().As<ITicketDal>();


            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.Register(context => new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CompanyProfile>();
                cfg.AddProfile<TicketProfile>();
                cfg.AddProfile<UserProfile>();
            }
             )).AsSelf().SingleInstance();
            builder.RegisterType<RabbitMqMessageBroker>().As<IMessageBroker>();
            builder.Register(c =>
            {
                var context = c.Resolve<IComponentContext>();
                var config = context.Resolve<MapperConfiguration>();
                return config.CreateMapper(context.Resolve);
            })
            .As<IMapper>()
            .InstancePerLifetimeScope();


            /*var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();*/
        }
    }
}
