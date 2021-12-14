using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public static class DLFactory
    {
        public static DLAPI.IDAL GetDAL(int flag)
        {
            switch (flag)
            {
                case 0:
                default:
                    return DalObject.Instnace;
            }
        }
    }
}
