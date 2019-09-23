using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces;

namespace ServiceDesktop.Presenter.Views
{
    public interface IAboutSoftwareView : IView
    {
        /// <summary>
        ///     Running software and Show form
        /// </summary>
        void Show();
    }
}