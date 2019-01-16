using BeFaster.Runner.Exceptions;
using System.Collections.Generic;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public class PriceRule
        {
            public string Item;
            public int Amount;
            public int Price;
            public PriceRule(string item, int amount, int price)
            {
                Item = item;
                Amount = amount;
                Price = price;
            }
        }
        public static List<PriceRule> rules = new List<PriceRule>()
        {
            new PriceRule("A", 3, 130),
            new PriceRule("A", 1, 50),
            new PriceRule("B", 2, 45),
            new PriceRule("B", 1, 30),
            new PriceRule("C", 1, 20),
            new PriceRule("D", 1, 15),
        };
            
        public static int Checkout(string skus)
        {
            throw new SolutionNotImplementedException();
        }
    }
}

