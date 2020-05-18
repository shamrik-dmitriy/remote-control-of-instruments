using System.Windows.Forms;

namespace Services.MessagesServices.MessageBoxServices
{
    /// <summary>
    ///     Класс обеспечивает работу с диалоговыми сообщениями типа MessageBox.
    ///     Содержит методы для различных вариаций сообщений
    /// </summary>
    public class MessageBoxService : IMessageBoxService
    {
        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowMessage(string message)
        {
            MessageBox.Show(message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowMessage(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowExclamation(string message)
        {
            MessageBox.Show(message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowExclamation(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowError(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowWarning(string message, string caption)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        ///     <inheritdoc/>
        /// </summary>
        public void ShowWarning(string message)
        {
            MessageBox.Show(message, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}