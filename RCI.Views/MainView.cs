using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCI.Presenters.Interfaces.Views.Main;

namespace RCI.Views
{
    public partial class MainView : Form, IMainView
    {
        #region Constructor

        public MainView()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public new void Show()
        {
            try
            {
                Application.Run(this);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion
    }
}