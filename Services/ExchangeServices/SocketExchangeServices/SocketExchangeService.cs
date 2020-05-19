using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Services.ExchangeServices.SocketExchangeServices
{
    /// <summary>
    ///     Класс предоставляет возможность для работы с сокетами
    ///     Низкий уровень абстракции. Предназначен для использования в более высоких уровнях абстракции
    /// </summary>
    public sealed class SocketExchangeServiceService : IExchangeService, IDisposable
    {
        #region Private Properties

        /// <summary>
        ///     Instance of IpAddress device
        /// </summary>
        private IPAddress IpAddress { get; }

        /// <summary>
        ///     Instance of IpPort device
        /// </summary>
        private int IpPort { get; }

        /// <summary>
        ///     Instance of Endpoint
        /// </summary>
        private EndPoint EndPoint { get; set; }

        /// <summary>
        ///     Instance of Socket
        /// </summary>
        private Socket Socket { get; set; }

        /// <summary>
        ///     Type of Socket protocol
        /// </summary>
        private ProtocolType TypeOfProtocol { get; }

        /// <summary>
        ///     Type of Socket
        /// </summary>
        private SocketType TypeOfSocket { get; }

        /// <summary>
        ///     Address family of socket
        /// </summary>
        private AddressFamily AddressFamily { get; }

        #endregion

        #region Private member variables

        /// <summary>
        ///     Lock object for socket
        /// </summary>
        private readonly object _lockObject = new object();

        /// <summary>
        ///     Size of buffer
        /// </summary>
        private const int BufferSize = 256;

        #endregion

        #region Constructor

        /// <summary>
        ///     Create of instance Lan Exchanger
        /// </summary>
        /// <param name="ipAddress">Device ip address</param>
        /// <param name="ipPort">Device ip port</param>
        /// <param name="typeOfProtocolType">Socket protocol type</param>
        /// <param name="socketType">Socket type</param>
        /// <param name="addressFamily">Address family</param>
        public SocketExchangeServiceService(string ipAddress, int ipPort,
            ProtocolType typeOfProtocolType = ProtocolType.Tcp,
            SocketType socketType = SocketType.Stream, AddressFamily addressFamily = AddressFamily.InterNetwork)
        {
            try
            {
                IpAddress = IPAddress.Parse(ipAddress);
                IpPort = ipPort;
                TypeOfProtocol = typeOfProtocolType;
                TypeOfSocket = socketType;
                AddressFamily = addressFamily;
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.Message);
            }
        }

        #endregion

        #region Private methods

        /// <summary>
        ///     Реализует операцию пингования удалённого сервера
        /// </summary>
        /// <param name="timeout">Время ожидания ответа, в мс</param>
        private void PingExecute(int timeout = 1000)
        {
            try
            {
                using (var ping = new Ping())
                {
                    var pingReply = ping.Send(IpAddress, timeout);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                        throw new Exception("Устройство " + IpAddress + ":" + IpPort + " не отвечает");
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Connect()
        {
            try
            {
                lock (_lockObject)
                {
                    if (Socket == null)
                    {
                        Socket = new Socket(AddressFamily, TypeOfSocket, TypeOfProtocol);
                        if (EndPoint == null) EndPoint = new IPEndPoint(IpAddress, IpPort);

                        PingExecute();

                        Socket.ReceiveTimeout = 5000;
                        Socket.SendTimeout = 5000;

                        Socket.Connect(EndPoint);
                    }
                }
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException("Подключение не удалось:" + exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Disconnect()
        {
            lock (_lockObject)
            {
                if (Socket == null) return;
                Socket.Shutdown(SocketShutdown.Both);
                Socket.Close(1);
                Socket = null;
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void Send(byte[] data)
        {
            try
            {
                lock (_lockObject)
                {
                    //PingExecute();
                    Socket.Send(data);
                }
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException("Не удалось отправить данные на " + IpAddress + ":" + IpPort +
                                                   " по причине: " + exception.Message);
            }
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public byte[] Receive()
        {
            var buffer = new byte[BufferSize];
            buffer = new byte[buffer.Length];

            try
            {
                lock (_lockObject)
                {
                    //PingExecute();
                    do
                    {
                        Socket.Receive(buffer);
                    } while (Socket.Available < 0);

                    return buffer;
                }
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException("Не удалось прочитать данные от " + IpAddress + ":" + IpPort +
                                                   " по причине: " + exception.Message);
            }
        }

        public void Dispose()
        {
            Socket?.Dispose();
        }

        #endregion
    }
}