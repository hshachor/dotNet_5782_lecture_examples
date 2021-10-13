using System;

namespace Properties
{
    class Rational
    {
        public int Nominator;
        int denominator;
        public int Denominator
        {
            get
            {
                return denominator;
            }
            set
            {
                if (value != 0)
                {
                    denominator = value;
                }
            }
        }
    }

    class MoreProperties
    {
        public int HiddenField { get; set; }
        
        int field;
        public int ShortNotation { get => field; set => field = value; }
        
        public int DifferentPermission { get; protected set; }
        
        int cnt;
        public int ValueOfCounter { get => cnt; }

        // no field:
        public DateTime NoField { get => DateTime.Today.AddDays(7); }

        public int InitValue { get; set; } = 5;

        public int ChangeOnInitOnly { get; init; }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
