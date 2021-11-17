using System;

namespace ObservableValueChanged
{
    public class ValueChangedArgs : EventArgs
    {
        public readonly int OldV; public readonly int NewV;
        public ValueChangedArgs(int oldV, int newV)
        { OldV = oldV; NewV = newV; }
    }
    public class MyValue
    {
        private int value = 0;
        public event EventHandler<ValueChangedArgs> OnValueChanged = null;
        private void valueChangedHandler(int oldV, int newV)
        {
            if (OnValueChanged != null)
                OnValueChanged(this, new ValueChangedArgs(oldV, newV));
        }
        public int Value
        {
            get { return value; }
            set
            {
                if (value != this.value)
                {
                    int temp = this.value;
                    this.value = value;
                    valueChangedHandler(temp, value);
                }
            }
        }
    }
    public class ValueChangeObserver
    {
        public ValueChangeObserver(MyValue v)
        {
            v.OnValueChanged += myOnValueChanged;
        }
        private void myOnValueChanged(object sender, ValueChangedArgs args)
        {
            Console.WriteLine("Value changed by {0}",
                              args.NewV - args.OldV);
        }
    }

    public class ValueAverageChangeObserver
    {
        private int sum = 0, count = 0;
        public ValueAverageChangeObserver(MyValue v)
        {
            v.OnValueChanged += myOnValueChanged;
        }
        private void myOnValueChanged(object sender, ValueChangedArgs args)
        {
            count++; sum += (args.NewV - args.OldV);
            Console.WriteLine("Value average change is {0:F}",
                              (double)sum / (double)count);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            MyValue v = new MyValue();

            new ValueChangeObserver(v);
            new ValueAverageChangeObserver(v);

            v.Value = 100;
            v.Value = 100;
            v.Value = 210;
            v.Value = 150;
            v.Value = 180;
        }
    }

}
