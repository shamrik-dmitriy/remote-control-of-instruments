using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCI.Models.ViewModels.Interfaces.Main;
using RCI.Presenters.Interfaces.Views.Main;

namespace RCI.Presenters.Presenters.Main
{
    public class MainPresenter
    {
        #region Private Properties

        private IMainView MainView { get; set; }

        #endregion

        #region Constructor

        public MainPresenter(IMainView mainView, IMainModel mainModel)
        {
            MainView = mainView;
        }

        #endregion

        #region Public Methods

        public void Run()
        {
            MainView.Show();
        }

        #endregion
    }
}