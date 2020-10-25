using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCI.Models.ViewModels.Interfaces.Main;

namespace RCI.Models.ViewModels.MainViewModel
{
    /// <summary>
    ///     Модель главной формы
    /// </summary>
    public class MainModel : IMainModel
    {
        public void ConnectOfSignalGenerator()
        {
            //throw new NotImplementedException();
        }

        public void ConnectOfPowerSupply()
        {
            //throw new NotImplementedException();
        }

        public void DisconnectOfSignalGenerator()
        {
            // throw new NotImplementedException();
        }

        public void DisconnectOfPowerSupply()
        {
            // throw new NotImplementedException();
        }

        public bool GetStateConnectionOfSignalGenerator()
        {
            return true;
        }

        public bool GetStateConnectionOfPowerSupply()
        {
            return true;
        }
    }
}