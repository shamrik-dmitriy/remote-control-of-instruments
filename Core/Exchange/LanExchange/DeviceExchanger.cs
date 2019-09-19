using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exchange.LanExchange
{
    /// <summary>
    ///     Class for work remote devices with Ethernet channel.
    ///     Send/Recieve data
    /// </summary>
    public sealed class DeviceExchanger
    {
        #region Private Properties

        /// <summary>
        ///     Instance of Socket
        /// </summary>
        private Socket Socket { get; set; }

        /// <summary>
        ///     Instance of EndPoint
        /// </summary>
        private EndPoint EndPoint { get; set; }

        /// <summary>
        ///     Instance of IpAddress
        /// </summary>
        private IPAddress IpAddress { get; set; }

        /// <summary>
        ///     Instance of IpPort
        /// </summary>
        private int IpPort { get; set; }

        #endregion

        #region Private Member Variable

        /// <summary>
        ///     Size of buffer
        /// </summary>
        private const int BufferSize = 256;

        /// <summary>
        ///     Instance of object for lock sync
        /// </summary>
        private readonly object _lockObject = new object();

        #endregion

        #region Constructor

        /// <summary>
        ///     Constructor of Device Exchanger
        /// </summary>
        /// <param name="ipAddress">Ip address</param>
        /// <param name="ipPort">Ip port</param>
        public DeviceExchanger(string ipAddress, int ipPort)
        {
            try
            {
                IpAddress = IPAddress.Parse(ipAddress);
                IpPort = ipPort;
                Connect();
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        ///     Initialization of connect
        /// </summary>
        private void Connect()
        {
            try
            {
                if (Socket == null)
                {
                    Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (EndPoint == null)
                        EndPoint = new IPEndPoint(IpAddress, IpPort);
                    var ping = new Ping();
                    var pingReply = ping.Send(IpAddress, 1000);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                        throw new Exception("Device " + IpAddress + ":" + IpPort + " not responding!");
                    Socket.Connect(EndPoint);
                }
            }
            catch (PingException exception)
            {
                throw new Exception(exception.Message);
            }
            catch (Exception exception)
            {
                throw new Exception("Connection failed due to: " + exception.Message);
            }
        }

        /// <summary>
        ///     Close connect
        /// </summary>
        private void Disconnect()
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
        ///     Sending data query
        /// </summary>
        /// <param name="command">Command for send</param>
        /// <returns>Tuple, first element - request execution status, second element - response value</returns>
        private Tuple<bool, string> SendData(string command)
        {
            lock (_lockObject)
            {
                var buffer = new byte[BufferSize];
                buffer = new byte[buffer.Length];
                try
                {
                    var strBuilder = new StringBuilder();
                    var readBytes = 0;
                    var sendData = Encoding.ASCII.GetBytes(command + "\n");
                    var ping = new Ping();
                    var pingReply = ping.Send(IpAddress, 5000);
                    if (pingReply != null && pingReply.Status != IPStatus.Success)
                        throw new Exception("Устройство не отвечает!");
                    Socket.Send(sendData);
                    if (command.IndexOf("?", StringComparison.Ordinal) >= 0)
                    {
                        do
                        {
                            readBytes = Socket.Receive(buffer);
                        } while (Socket.Available < 0);
                    }

                    return new Tuple<bool, string>(true, Encoding.ASCII.GetString(buffer, 0, readBytes));
                }
                catch (Exception exception)
                {
                    Disconnect();
                    throw new Exception("Failed to send command \"" + command + "\" to " + IpAddress + ":" + IpPort +
                                        ", due to: " + exception.Message);
                }
                finally
                {
                    Array.Clear(buffer, 0, buffer.Length);
                }
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        ///     Sending a command to a device and receiving a response in string format
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns>Request response string</returns>
        public string SendRequestDataString(string command)
        {
            try
            {
                lock (this)
                {
                    var request = SendData(command);

                    if (request.Item1)
                    {
                        return request.Item2;
                    }

                    throw new Exception(request.Item2);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///    Data request and pending response in double precision format
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns></returns>
        public double SendRequestDataDouble(string command)
        {
            try
            {
                lock (this)
                {
                    var request = SendData(command);
                    if (request.Item1)
                    {
                        return Convert.ToDouble(request.Item2, new NumberFormatInfo());
                    }
                    else
                        throw new Exception(request.Item2);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     Request data and wait for a response in integer format
        /// </summary>
        /// <param name="command">Command</param>
        /// <returns></returns>
        public int SendRequestDataInt(string command)
        {
            try
            {
                lock (this)
                {
                    var request = SendData(command);
                    if (request.Item1)
                    {
                        return Convert.ToInt32(request.Item2);
                    }
                    else
                        throw new Exception(request.Item2);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        /// <summary>
        ///     Sending a command without returning a response from the device
        /// </summary>
        /// <param name="command">Commands</param>
        public void SendDataWithOutReturn(string command)
        {
            try
            {
                lock (this)
                {
                    var request = SendData(command);

                    if (!request.Item1)
                        throw new Exception(request.Item2);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion
    }
}