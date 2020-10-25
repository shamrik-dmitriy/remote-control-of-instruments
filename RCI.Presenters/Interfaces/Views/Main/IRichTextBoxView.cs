using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.Presenters.Interfaces.Views.Main
{
    /// <summary>
    ///     Интерфейс для вывода информации в RichTextBox
    /// </summary>
    public interface IRichTextBoxView
    {
        /// <summary>
        ///     Clear RichTextBox info block
        /// </summary>
        void ClearInfoBlock();

        #region Context Message | Left, Regular

        /// <summary>
        ///     Set message with regular black color font
        /// </summary>
        /// <param name="message">Message</param>
        void SetContextRegularMessage(string message);

        /// <summary>
        ///     Set message with regular red color font
        /// </summary>
        /// <param name="message">Message</param>
        void SetContextFailMessage(string message);

        /// <summary>
        ///     Set message with regular orange color font
        /// </summary>
        /// <param name="message">Message</param>
        void SetContextAttentionMessage(string message);

        /// <summary>
        ///     Set message with regular green color font
        /// </summary>
        /// <param name="message">Message</param>
        void SetContextPassedMessage(string message);

        #endregion
    }
}