using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Devices.SCPIDevices.SignalGenerator.SignalGenerators
{
    /// <summary>
    ///     Specific interface for R&D SMB100A
    /// </summary>
    public interface ISMB100A : ISignalGenerator
    {
        #region Amplitude Modulation

        void SetAmplitudeModulationState(bool state);

        bool GetAmplitudeModulationState();

        #endregion

        #region Phase Modulation

        void SetPhaseModulationState(bool state);

        bool GetPhaseModulationState();

        #endregion

        #region Frequency Modulations

        void SetFrequencyModulationState(bool state);

        bool GetFrequencyModulationState();

        #endregion
    }
}