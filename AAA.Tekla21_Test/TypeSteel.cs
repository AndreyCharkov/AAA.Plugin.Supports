using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AAA.Plugin.Supports
{
    public class TypeSteel
    {
        public string Steel(int steel)
        {
            if (steel != 3) //Проверка на сталь 
            {
                return "09Г2С";
            }
            else
            {
                return "08Х18Н10Т";
            }
        }
    }
}
