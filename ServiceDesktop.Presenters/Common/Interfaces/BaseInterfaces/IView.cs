using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces
{
    /// <summary>
    ///     General methods for all Views
    /// </summary>
    public interface IView
    {
        void Show();

        void Close();
    }
}