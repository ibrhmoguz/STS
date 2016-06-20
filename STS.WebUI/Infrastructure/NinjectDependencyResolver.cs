﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Ninject;
using STS.WebUI.Infrastructure.Abstract;
using STS.WebUI.Infrastructure.Concrete;
using STS.Domain.Abstract;
using STS.Domain.Concrete;

namespace STS.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            /*
            var mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new List<Product>
            {
                new Product(){Name = "Football", Price = 25},
                new Product(){Name = "Surf board", Price = 179},
                new Product(){Name = "Running shoes", Price = 95}
            });

            //kernel.Bind<IProductRepository>().ToConstant(mock.Object);
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>();
            */
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
            kernel.Bind<IKullaniciRepo>().To<KullaniciRepo>();
            kernel.Bind<IPersonelRepo>().To<PersonelRepo>();
            kernel.Bind<ISilahRepo>().To<SilahRepo>();
            kernel.Bind<IGrupRepo>().To<GrupRepo>();
            kernel.Bind<IIzinRepo>().To<IzinRepo>();
            kernel.Bind<IGrupKullaniciRepo>().To<GrupKullaniciRepo>();
            kernel.Bind<IGrupIzinRepo>().To<GrupIzinRepo>();
        }
    }
}