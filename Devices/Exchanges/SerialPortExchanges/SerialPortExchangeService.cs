using System;
using System.IO.Ports;

namespace Shamrik.Dmitriy.Devices.Exchanges.SerialPortExchanges
{
    /// <summary>
    ///     Низкоуровневый класс для взаимодействия по интерфейсу RS-232
    ///     Предназначен для использования в более высоких абстракциях
    /// </summary>
    public class SerialPortService : ISerialPortExchangeService, IDisposable
    {
        #region Private Member Variables

        /// <summary>
        ///     Флаг, показывающий, был ли ресурс уже освобожден
        ///     (вызывался ли уже метод Dispose())
        /// </summary>
        private bool _disposed;

        #endregion

        #region Private Properties

        /// <summary>
        ///     Экземпляр последовательного порта
        /// </summary>
        private SerialPort SerialPort { get; }

        #endregion

        #region Constructor / Destructor

        /// <summary>
        ///     Инициализиурет экземпляр последовательно порта согласно переданным параметрам
        /// </summary>
        /// <param name="serialPortName">Имя последовательного порта</param>
        /// <param name="baudRate">Скорость передачи в бодах, по умолчанию 9600 бод/сек</param>
        /// <param name="dataBits">Число битов данных в байте, по умолчанию 8 бит</param>
        /// <param name="parity">Протокол контроля четности <see cref="Parity" />, по умолчанию контроль четности не осуществляется</param>
        /// <param name="stopBits">Стоповые биты в байте <see cref="StopBits" />, по умолчанию один стоповый бит</param>
        /// <param name="readTimeout">Срок ожидания в миллисекундах для завершения операции чтения, по умолчанию 2000 мс</param>
        /// <param name="writeTimeout">Срок ожидания в миллисекундах для завершения операции записи, по умолчанию 2000 мс</param>
        /// <param name="handshake">
        ///     Протокол установления связи для передачи данных с использованием значения из
        ///     <see cref="Handshake" />
        /// </param>
        public SerialPortService(string serialPortName, int baudRate = 9600, int dataBits = 8,
            Parity parity = Parity.None,
            StopBits stopBits = StopBits.One,
            int readTimeout = 2000, int writeTimeout = 2000, Handshake handshake = Handshake.None)
        {
            SerialPort = new SerialPort
            {
                PortName = serialPortName,
                BaudRate = baudRate,
                DataBits = dataBits,
                Parity = parity,
                StopBits = stopBits,
                ReadTimeout = readTimeout,
                WriteTimeout = writeTimeout,
                Handshake = handshake
            };
        }

        ~SerialPortService()
        {
            Dispose(false);
        }

        #endregion

        #region Public Methods

        #region Connect / Disconnect

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Connect()
        {
            try
            {
                SerialPort.Open();
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Close();
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        #endregion

        #region Write Data

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Send(byte[] data)
        {
            try
            {
                Send(data, 0, data.Length);
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Send(byte[] data, int count)
        {
            try
            {
                Send(data, 0, count);
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Send(byte[] data, int offset, int count)
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Write(data, offset, count);
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public void Send(string data)
        {
            try
            {
                if (SerialPort.IsOpen) SerialPort.Write(data);
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        #endregion

        #region Read Data

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public string ReceiveString()
        {
            try
            {
                if (SerialPort.IsOpen)
                    return SerialPort.ReadExisting();
                throw new ExchangeServiceException(SerialPort.PortName + " был закрыт");
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public byte[] Receive()
        {
            try
            {
                if (SerialPort.IsOpen)
                {
                    var bufferSize = SerialPort.BytesToRead;
                    var buffer = new byte[bufferSize];

                    for (var i = 0; i < bufferSize; ++i)
                    {
                        var readByteValue = (byte) SerialPort.ReadByte();
                        buffer[i] = readByteValue;
                    }

                    return buffer;
                }

                throw new ExchangeServiceException(SerialPort.PortName + " был закрыт");
            }
            catch (Exception exception)
            {
                throw new ExchangeServiceException(exception.ToString());
            }
        }

        #endregion

        #region Dispose

        /// <summary>
        ///     Освобождает ресурсы последовательного порта по требованию пользователя
        ///     и подавляет финализацию
        /// </summary>
        public virtual void Dispose()
        {
            lock (this)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        /// <summary>
        ///     Освобождает ресурсы последовательного порта
        /// </summary
        /// <param name="isDisposing">True - очистка запущена пользователем объекта, False - очистка запущена сборщиком мусора</param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (!_disposed)
            {
                if (isDisposing)
                {
                    if (SerialPort == null) return;
                    if (SerialPort.IsOpen) SerialPort.Close();

                    SerialPort.Dispose();
                }

                _disposed = true;
            }
        }

        #endregion

        #endregion
    }
}