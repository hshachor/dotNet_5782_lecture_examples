using System;

namespace BL
{
    public class BL
    {
        DLAPI.IDAL dl = DL.DLFactory.GetDAL(0);
        //DL.DalXML dl = DL.DalXML.Instance;
        public string GetMessage() => dl.GetData();
    }
}
