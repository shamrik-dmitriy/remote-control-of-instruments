using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using CDBA.A30.SoftwareSettings;

namespace CDBA.A30.Services.ExchangeServices.ELVDSExchangeServices
{
    /// <summary>
    ///     Предоставляет функциональность для работы с конвертером ELVDS
    /// </summary>
    public unsafe class ELvdsExchangeService : IELvdsExchangeService, IDisposable
    {
        #region Constructor

        /// <summary>
        ///     Иницииализирует подключение к конвертеру ELVDS по заданному IP-адресу <see cref="ipAddress" />
        /// </summary>
        /// <param name="ipAddress">Ip-адрес конвертера ELVDS</param>
        public ELvdsExchangeService(bool converter)
        {
        }

        #endregion

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #region DLL Import for ELVDS

        //TODO: Из ПО Конкс

        //Charset?
        [DllImport("eth_link.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint InitSockEnv(char* ip, int twoSockets);

        [DllImport("eth_link.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint ShutSockEnv();

        [DllImport("eth_link.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint UDP_Send(byte* szsend, uint dwsz);

        [DllImport("eth_link.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint UDP_Get(byte* recarr, uint bsize);

        #endregion

        #region Public Methods

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Connect()
        {
            try
            {
                var ipAddress = Settings.GetSettings.GetIpAddressELvdsFirst.ToCharArray();
                fixed (char* ip = &ipAddress[0])
                {
                    InitSockEnv(ip, 0);
                }

                Application.DoEvents();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Disconnect()
        {
            try
            {
                ShutSockEnv();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Send(byte[] data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public byte[] Receive()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}