using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bll
{
    /// <summary>
    /// Интерфейс сохранения сообщений
    /// </summary>
    interface ISavior
    {
        void SaveMessage (string text);
    }
}
