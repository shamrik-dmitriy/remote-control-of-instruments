using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RCI.Presenters.Interfaces.Views.Main;

namespace RCI.Views
{
    public partial class MainView : Form, IMainView
    {
        #region Private Properties

        private RichTextBox OutputInformationArea => richTextBoxLogInformation;

        #endregion

        #region Public Events

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public event Action ShowForm;

        /// <summary>
        ///     <inheritdoc />
        /// </summary>
        public event Action CloseForm;

        #endregion

        #region Constructor

        public MainView()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        public new void Show()
        {
            try
            {
                Application.Run(this);
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        #endregion

        private void MainView_Shown(object sender, EventArgs e)
        {
            Update();
            ShowForm?.Invoke();
        }

        #region RichTextBox

        /// <summary>
        ///     Set View to RichTextBox
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="color">Text color</param>
        /// <param name="fontStyle">Text style</param>
        /// <param name="horizontalAlignment">Text alignment</param>
        /// <param name="size">Text size</param>
        private void SetViewRichTextBox(string message, Color color, FontStyle fontStyle,
            HorizontalAlignment horizontalAlignment, int size)
        {
            OutputInformationArea.BeginInvoke((Action) (() =>
            {
                var lastIndex = OutputInformationArea.TextLength;
                var finishIndex = lastIndex + message.Length;
                OutputInformationArea.AppendText(message + Environment.NewLine);
                OutputInformationArea.Select(lastIndex, finishIndex);
                OutputInformationArea.SelectionColor = color;
                OutputInformationArea.SelectionAlignment = horizontalAlignment;
                OutputInformationArea.SelectionFont = new Font("Tahoma", size, fontStyle);
                OutputInformationArea.ScrollToCaret();
                OutputInformationArea.SelectionStart = finishIndex;
                OutputInformationArea.Update();
            }));
        }

        #endregion

        public void ClearInfoBlock()
        {
            OutputInformationArea.BeginInvoke((Action) (() => { OutputInformationArea.Clear(); }));
        }

        public void SetContextRegularMessage(string message)
        {
            SetViewRichTextBox(message, Color.Black, FontStyle.Regular, HorizontalAlignment.Left, 10);
        }

        public void SetContextFailMessage(string message)
        {
            SetViewRichTextBox(message, Color.DarkRed, FontStyle.Regular, HorizontalAlignment.Left, 10);
        }

        public void SetContextAttentionMessage(string message)
        {
            SetViewRichTextBox(message, Color.DarkOrange, FontStyle.Regular, HorizontalAlignment.Left, 10);
        }

        public void SetContextPassedMessage(string message)
        {
            SetViewRichTextBox(message, Color.DarkGreen, FontStyle.Regular, HorizontalAlignment.Left, 10);
        }
    }
}