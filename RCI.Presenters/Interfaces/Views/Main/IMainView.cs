using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCI.Presenters.Interfaces.Views.Main
{
    /// <summary>
    ///     Интерфейс для главной формы
    /// </summary>
    public interface IMainView : IRichTextBoxView
    {
        #region Events

        /// <summary>
        ///     Событие показа формы
        /// </summary>
        event Action ShowForm;

        /// <summary>
        ///     Событие закрытия формы
        /// </summary>
        event Action CloseForm;

        #endregion

        #region Methods

        #region Forms

        /// <summary>
        ///     Перегрузка метода показа формы
        /// </summary>
        void Show();

        #endregion

        #endregion
    }
}