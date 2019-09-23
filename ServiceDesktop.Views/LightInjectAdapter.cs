using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using LightInject;
using ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces;

namespace ServiceDesktop.Views
{
    /// <summary>
    ///     
    /// </summary>
    public class LightInjectAdapter : IContainer
    {
        private readonly ServiceContainer _serviceContainer = new ServiceContainer();

        public void Register<TService, TImplementation>() where TImplementation : TService
        {
            _serviceContainer.Register<TService, TImplementation>();
        }

        public void Register<TService>()
        {
            _serviceContainer.Register<TService>();
        }

        public void RegisterInstance<T>(T instance)
        {
            _serviceContainer.RegisterInstance(instance);
        }

        public TService Resolve<TService>()
        {
            return _serviceContainer.GetInstance<TService>();
        }

        public void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory)
        {
            _serviceContainer.Register(serviceFactory => factory);
        }

        public bool IsRegistered<TService>()
        {
            return _serviceContainer.CanGetInstance(typeof(TService), string.Empty);
        }
    }
}