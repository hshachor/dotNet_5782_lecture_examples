using System;

namespace DL
{
    public sealed class DalObject : DLAPI.IDAL
    {
        static DalObject instance = null;// new DalObject();
        DalObject() { }
        public static DalObject Instnace
        {
            get
            {
                if (instance == null)
                {
                    instance = new DalObject();
                }
                return instance;
            }
        }
        public string GetData() { return "Hello"; }
    }
}
