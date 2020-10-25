using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.Models.ViewModels.Interfaces.Main
{
    public interface IMainModel
    {
        void ConnectOfSignalGenerator();
        void ConnectOfPowerSupply();

        void DisconnectOfSignalGenerator();

        void DisconnectOfPowerSupply();

        bool GetStateConnectionOfSignalGenerator();

        bool GetStateConnectionOfPowerSupply();
    }
}