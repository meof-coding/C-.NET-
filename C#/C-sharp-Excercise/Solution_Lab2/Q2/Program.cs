using System;

namespace Q2
{
    interface ITax
    {
        public float ComputeTax();
    }

    class Payment : ITax
    {
        public delegate void PaymentChangeHandler(float old_num, float new_num);
        //Even declaration
        public event PaymentChangeHandler AmountChanged;
        public float amount;

        public float Amount { get {return amount; } set {AmountChanged?.Invoke(amount,amount=value); } } 

        public Payment(float amount)
        {
            this.Amount = amount;
        }

        public Payment()
        {
        }

        public float ComputeTax()
        {
            return Amount * 10 / 100;
        }

       
    }
    class Program
    {
        private static void notifyAmountChanged(float old_num, float new_num)
        {
            Console.WriteLine($"Amount changed - old value: {old_num}, new value: {new_num}");
        }
        static void Main(string[] args)
        {
            Payment payment = new Payment() { amount = 1000 };
            payment.AmountChanged += notifyAmountChanged; // your handling function
            payment.Amount = 990;
            Console.WriteLine("Tax:" +payment.ComputeTax().ToString("0.0"));
        }
    }
}
