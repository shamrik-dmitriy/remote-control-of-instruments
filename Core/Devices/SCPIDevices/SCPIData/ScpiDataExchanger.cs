using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.ExchangeServices;

namespace Core.Devices.SCPIDevices.SCPIData
{
    /// <summary>
    ///     Вспомогательный класс для обмена данными
    /// </summary>
    internal class ScpiDataExchanger
    {
        /// <summary>
        ///     Экземпляр для обмена данными
        /// </summary>
        private IExchangeService Exchange { get; set; }

        /// <summary>
        ///     Конструктор, принимает коннектор <see cref="exchange"/>
        /// </summary>
        /// <param name="exchange">Коннектор</param>
        public ScpiDataExchanger(IExchangeService exchange)
        {
            Exchange = exchange;
        }

        /// <summary>
        ///     Отправляет команду и возвращает результата заданного типа <see cref="T"/>
        ///     Для отправки без возврата данных используйте <see cref="Request"/> 
        /// </summary>
        /// <typeparam name="T">Требуемый тип данных</typeparam>
        /// <param name="command">Команда для устройства</param>
        /// <returns>Значение типа <see cref="T"/></returns>
        public T Request<T>(string command)
        {
            try
            {
                var type = typeof(T);

                var byteCommand = ScpiDataParser.ParseSendData(command);

                Exchange.Connect();
                Exchange.Send(byteCommand);

                switch (type.Name)
                {
                    case nameof(Double):
                        {
                            return (T)Convert.ChangeType(ScpiDataParser.ParseDouble(Exchange.Receive()), typeof(T));
                        }

                    case nameof(Int32):
                        {
                            return (T)Convert.ChangeType(ScpiDataParser.ParseInteger(Exchange.Receive()), typeof(T));
                        }

                    case nameof(Boolean):
                        {
                            return (T)Convert.ChangeType(ScpiDataParser.ParseBoolean(Exchange.Receive()), typeof(T));
                        }

                    case nameof(String):
                        {
                            return (T)Convert.ChangeType(ScpiDataParser.ParseReceiveData(Exchange.Receive()), typeof(T));
                        }

                    default: throw new Exception("Не верный тип возврата: " + type.Name);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                Exchange.Disconnect();
            }
        }

        /// <summary>
        ///     Отправляет команду на устройство без возврата данных.
        ///     Для возврата данных используйте <see cref="Request{T}"/>
        /// </summary>
        /// <param name="command">Команда для устройства</param>
        public void Request(string command)
        {
            try
            {
                var byteCommand = ScpiDataParser.ParseSendData(command);

                Exchange.Connect();
                Exchange.Send(byteCommand);

                var buffer = Exchange.Receive();

                ScpiDataParser.ParseReceiveData(buffer);
            }
            catch (ASCPIParseDataException ascpiParseDataException)
            {
                throw new ASCPIParseDataException(ascpiParseDataException.Message);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
            finally
            {
                Exchange.Disconnect();
            }
        }
    }
}
