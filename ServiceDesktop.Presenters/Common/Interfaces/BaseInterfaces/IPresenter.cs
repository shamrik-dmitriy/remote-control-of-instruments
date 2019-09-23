using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceDesktop.Presenter.Common.Interfaces.BaseInterfaces
{
    /// <summary>
    ///     General methods for all Presenters
    /// </summary>
    public interface IPresenter
    {
        void Run();
    }

    /// <summary>
    ///     General methods for all Presenters with argument
    /// </summary>
    public interface IPresenter<in TArg>
    {
        void Run(TArg arg);
    }
}