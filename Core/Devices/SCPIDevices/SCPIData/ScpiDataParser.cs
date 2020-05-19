using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Devices.SCPIDevices.SCPIData
{
    internal static class ScpiDataParser
    {
        /// <summary>
        ///     Возвращает строку с добавленными обязательными параметрами запроса
        /// </summary>
        /// <param name="command">Команда</param>
        /// <returns>Команда и обязательные параметры запроса</returns>
        public static byte[] ParseSendData(string command)
        {
            try
            {
                return Encoding.ASCII.GetBytes(command + "*OPC?;:SYST:ERR?;\n");
            }
            catch (Exception exception)
            {
                throw new ASCPIParseDataException(exception.Message);
            }
        }

        /// <summary>
        ///     Возвращает обработанную строку в соответствии с запросом
        /// </summary>
        /// <param name="data">"Сырые" данные</param>
        /// <returns>Обработанная строка</returns>
        public static string ParseReceiveData(byte[] data)
        {
            try
            {
                var dataArray = Encoding.ASCII.GetString(data).Split(';').ToList();

                var error = dataArray.Count == 3 ? dataArray[2] : dataArray[1];

                var errCode = Regex.Match(error, @"[+-]\d+").Value;
                var errMessage = Regex.Match(error, @"(?<="").+?(?="")").Value;

                if (errCode != "+0")
                    throw new Exception(errCode + ":" + errMessage);

                return dataArray[0];
            }
            catch (Exception exception)
            {
                throw new ASCPIParseDataException(exception.Message);
            }
        }

        /// <summary>
        ///     Возвращает вещественное число, обрабатывая массив байт <see cref="data"/>
        /// </summary>
        /// <param name="data">Входной массив байт</param>
        /// <returns>Вещественное значение результата</returns>
        public static double ParseDouble(byte[] data)
        {
            try
            {
                return Math.Round(double.Parse(ParseReceiveData(data),
                    CultureInfo.InvariantCulture), 2);
            }
            catch (Exception exception)
            {
                throw new ASCPIParseDataException(exception.Message);
            }
        }

        /// <summary>
        ///     Возвращает булево значение, обрабатывая массив байт <see cref="data"/>
        /// </summary>
        /// <param name="data">Входной массив байт</param>
        /// <returns>Булево значение результата</returns>
        public static bool ParseBoolean(byte[] data)
        {
            try
            {
                return Convert.ToBoolean(ParseReceiveData(data)[0].ToString() == "1");
            }
            catch (Exception exception)
            {
                throw new ASCPIParseDataException(exception.Message);
            }
        }

        /// <summary>
        ///     Возвращает целочисленное значение, обрабатывая массив байт <see cref="data"/>
        /// </summary>
        /// <param name="data">Входной массив байт</param>
        /// <returns>Целочисленное значение результата</returns>
        public static int ParseInteger(byte[] data)
        {
            try
            {
                return Convert.ToInt32(ParseReceiveData(data)[0].ToString() == "1");
            }
            catch (Exception exception)
            {
                throw new ASCPIParseDataException(exception.Message);
            }
        }
    }
}
