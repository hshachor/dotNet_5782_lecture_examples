using System;

namespace Threads
{
    /// <summary>
    /// EventArgs with old value and new value.
    /// </summary>
    public class ValueChangedArgs: EventArgs
    {
        public readonly float OldV; public readonly float NewV;
        public ValueChangedArgs(float oldV, float newV)
        { OldV = oldV; NewV = newV; }
    }

    /// <summary>
    /// Bank account
    /// </summary>
    public class BankAccount
    {
        /// <summary>
        /// Create new object with empty balance and given rate
        /// </summary>
        /// <param name="rate"> periodically rate </param>
        public BankAccount(float rate = 0.01f)
        {
            Balance = 0;
            this.rate = rate;
        }
        /// <summary>
        /// Applied whenever the balance is changed.
        /// </summary>
        public event EventHandler<ValueChangedArgs> BalanceChanged;
        
        /// <summary>
        /// Current balance
        /// </summary>
        public float Balance { get => balance; private set
            {
                float newVal = (float) Math.Round(value * 100) / 100;

                if (value != balance) {
                    float oldV = balance;
                    balance = value;
                    if (BalanceChanged != null)
                    {
                        BalanceChanged(this, new(oldV, balance));
                    }
                }
            }
        }
        
        /// <summary>
        /// Add money to account
        /// </summary>
        /// <param name="amount">amount to add</param>
        public void Deposit(float amount)
        {
            Balance += amount;
        }
        
        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="amount">amount to remove</param>
        public void Withdraw(float amount)
        {
            if (amount < Balance)
            {
                Balance -= amount;
            }
        }
        
        /// <summary>
        /// Apply interest (called from outside)
        /// Should be internal and called from "Bank" class.
        /// </summary>
        public void ApplyInterest()
        {
            Balance += rate * Balance;
        }
                
        private float balance;
        private float rate;
    }
}
