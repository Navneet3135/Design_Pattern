using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Learning_Design_Pattern.BehavioralDesignPattern
{
    /*The Strategy Pattern is a behavioral design pattern that allows us to define a family of
     algorithms, encapsulate each one, and select the appropriate algorithm at runtime.
     Decouples algorithms from the main code – Allows changing behavior dynamically.
     Improves maintainability – New strategies (algorithms) can be added without modifying existing code.
     Encourages open-closed principle – Code is open for extension but closed for modification.
    
     Where is the Strategy Pattern Used?
     Sorting Algorithms

     QuickSort, MergeSort, BubbleSort can be selected at runtime.
     Authentication Mechanisms

     Different login methods: Google Login, Facebook Login, Email Login.
     Compression Algorithms

     ZIP, RAR, GZIP formats can be selected dynamically.
     Discount Calculation in E-Commerce

     Flat Discount, Percentage Discount, Buy-One-Get-One-Free.
    */
    public class StrategyPattern
    {
        public static void InitializeStrategy()
        {
            PaymentContext paymentContext = new PaymentContext();
            Console.WriteLine("Choose Payment Method: 1 - Credit Card, 2 - PayPal, 3 - Bitcoin");
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    paymentContext.SetPaymentStrategy(new CreditCardPayment());
                    break;
                case "2":
                    paymentContext.SetPaymentStrategy(new PayPalPayment());
                    break;
                case "3":
                    paymentContext.SetPaymentStrategy(new BitcoinPayment());
                    break;
                default:
                    Console.WriteLine("Invalid choice. Exiting...");
                    return;
            }
            Console.WriteLine("Enter Amount to Pay:");
            double amount = Convert.ToDouble(Console.ReadLine());

            paymentContext.ProcessPayment(amount);

        }


    }

    public interface IPaymentStrategy
    {
        void Pay(double amount);    
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount:C} using Credit Card.");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount:C} using PayPal.");

        }
    }

    public class BitcoinPayment : IPaymentStrategy
    {
        public void Pay(double amount)
        {
            Console.WriteLine($"Paid {amount:C} using Bitcoin.");

        }
    }


    public class PaymentContext
    {
        IPaymentStrategy? _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy? paymentStrategy)
        {
            _paymentStrategy = paymentStrategy; 
        }

        public void ProcessPayment(double amount)
        {
            if(_paymentStrategy == null)
            {
                Console.WriteLine("No payment method selected.");
            }
            else
            {
                _paymentStrategy?.Pay(amount);
            }
        }
    }

    
}
