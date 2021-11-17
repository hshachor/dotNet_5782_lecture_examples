using System;
using System.Collections.Generic;

namespace GenericObserver
{
    public interface IObserver<T>
    {
        void Notify(T parm);
    }
    public interface IObservable<T>
    {
        void AddObserver(IObserver<T> o);
        void RemoveObserver(IObserver<T> o);
    }
    public class MyObservable : IObservable<int>
    {
        private List<IObserver<int>> observers = new();

        public void AddObserver(IObserver<int> obs)
        { observers.Add(obs); }
        public void RemoveObserver(IObserver<int> obs)
        { observers.Remove(obs); }

        private void notifyAll(int parm)
        {
            foreach (var item in observers)
                item.Notify(parm);
        }
        public void change(int x)
        {
            notifyAll(x);
        }
    }
    public class MyObserver1 : IObserver<int>
    {
        private IObservable<int> myObservable;
        public MyObserver1(IObservable<int> obs)
        {
            myObservable = obs;
            myObservable.AddObserver(this);
        }
        ~MyObserver1() { myObservable.RemoveObserver(this); }
        public void Notify(int parm)
        {
            Console.WriteLine("Got update: { 0}", parm);
        }
    }

}
