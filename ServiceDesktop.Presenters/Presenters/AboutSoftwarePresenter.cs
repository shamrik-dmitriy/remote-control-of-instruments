using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceDesktop.Presenter.Common.AbstractClasses;
using ServiceDesktop.Presenter.Common.Interfaces;
using ServiceDesktop.Presenter.Views;

namespace ServiceDesktop.Presenter.Presenters
{
    public class AboutSoftwarePresenter : BasePresenter<IAboutSoftwareView>
    {
        public AboutSoftwarePresenter(IApplicationController controller, IAboutSoftwareView view) : base(controller,
            view)
        {
        }
    }
}