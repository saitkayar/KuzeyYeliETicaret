using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependecyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
          builder.RegisterType<UrunManager>().As<IUrunService>();
          builder.RegisterType<UrunDal>().As<IUrunDal>();
          builder.RegisterType<KategoriManager>().As<IKategoriService>();
          builder.RegisterType<KategoriDal>().As<IKategoriDal>();
          builder.RegisterType<MusteriManager>().As<IMusteriService>();
          builder.RegisterType<MusteriDal>().As<IMusteriDal>();
          builder.RegisterType<SatisManager>().As<ISatisService>();
          builder.RegisterType<SatisDal>().As<ISatisDal>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
