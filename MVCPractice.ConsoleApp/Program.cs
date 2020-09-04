using ConsoleApp.Algorithm.Custom;
using System;

namespace MVCPractice.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FibonacciSequence fibonacciSequence = new FibonacciSequence();
            Console.WriteLine(fibonacciSequence.GetIndexNumber(4)); 
        }
        
        static void RunAlgorithm(string AlgorithmName)
        {

        }

        static void iPhone_PriceChanged(object sender, PriceChangedEventArgs args)
        {
            Console.WriteLine($"{args._newPrice}元，原价{args._oldPrice}");
        }
    }



    //public delegate void PriceChangedHandler(decimal oldPrice, decimal newPrice);

    public class IPhone
    {
        decimal price;
        public event EventHandler<PriceChangedEventArgs> PriceChanged;
        protected virtual void OnPriceChanged(PriceChangedEventArgs e)
        {
            if (PriceChanged != null)
                PriceChanged(this, e);
        }

        public decimal Price
        {
            get { return price; }
            set
            {
                if (price == value)
                {
                    return;
                }
                decimal oldPrice = price;
                price = value;
                if (PriceChanged!=null)
                {
                    OnPriceChanged(new PriceChangedEventArgs(oldPrice,Price));
                }
            }

        }
    }

    public class PriceChangedEventArgs : EventArgs
    {
        public readonly decimal _oldPrice;
        public readonly decimal _newPrice;
        public PriceChangedEventArgs(decimal oldPrice,decimal newPrice)
        {
            _oldPrice = oldPrice;
            _newPrice = newPrice;
        }
    }

    
}
