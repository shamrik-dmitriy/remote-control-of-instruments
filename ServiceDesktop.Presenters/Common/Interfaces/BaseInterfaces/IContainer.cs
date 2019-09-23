using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces
{
    public interface IContainer
    {
        void Register<TService, TImplementation>() where TImplementation : TService;

        void Register<TService>();

        void RegisterInstance<T>(T instance);

        TService Resolve<TService>();

        bool IsRegistered<TService>();
        void Register<TService, TArgument>(Expression<Func<TArgument, TService>> factory);
    }
}