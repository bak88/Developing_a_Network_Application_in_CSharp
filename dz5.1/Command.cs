using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz5._1
{
    internal enum Command
    {
        Register,  // регистрация пользователя
        Message,    // сообщение
        Confirmation, //подтверждение
        GetUnreadMessages
    }
}
