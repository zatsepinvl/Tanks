using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tanks
{
    public class PermissionException:Exception
    {
        public override string Message
        {
            get
            {
                return "Ошибка доступа. Нет разрешения на выполнение данного действия";
            }
        }
    }
}
