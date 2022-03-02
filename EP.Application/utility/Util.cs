using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.utility
{
    public static class Util
    {
        /// <summary>
        /// مقدار عددی بر گشت داده می شود 
        /// </summary>
        /// <param name="value"> مقدار دربافتی  </param>
        /// <param name="i">در صورتی که مقدار عددی نبود / مقدار پیش فرض</param>
        /// <returns></returns>
        public static int ToDigit(this object value,int i)
        {
            try
            {
                return Convert.ToInt32(value.ToString());
                
            }
            catch
            {
                return i;
            }
        }
    }
}
