using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Presenter.Common.Interfaces;
using ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces;

namespace ServiceDesktop.Presenter.Common.AbstractClasses
{
    public abstract class BasePresenter<TView> : IPresenter where TView : IView
    {
        protected TView View { get; private set; }

        protected IApplicationController Controller { get; private set; }

        protected BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public void Run()
        {
            View.Show();
        }
    }

    public abstract class BasePresenter<TView, TArg> : IPresenter<TArg> where TView : IView
    {
        protected TView View { get; private set; }

        protected IApplicationController Controller { get; private set; }

        protected BasePresenter(IApplicationController controller, TView view)
        {
            Controller = controller;
            View = view;
        }

        public abstract void Run(TArg arg);
    }
}