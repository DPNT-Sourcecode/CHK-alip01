using BeFaster.Runner.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public class Good
        {
            public char Item;
            public int Amount;
        }
        public class PriceRule : Good
        {

            public int Price;
            public PriceRule(char item, int amount, int price)
            {
                Item = item;
                Amount = amount;
                Price = price;
            }
        }
        public static List<PriceRule> priceRules = new List<PriceRule>()
        {
            new PriceRule('A', 3, 130),
            new PriceRule('A', 1, 50),
            new PriceRule('B', 2, 45),
            new PriceRule('B', 1, 30),
            new PriceRule('C', 1, 20),
            new PriceRule('D', 1, 15),
        };

        public static int Checkout(string skus)
        {
            var validGoods = priceRules.Select(r => r.Item).Distinct();
            if (!skus.All(c => validGoods.Contains(c)))
            {
                return -1;
            }

            var goods = skus.Distinct();
            Dictionary<char, int> basket = new Dictionary<char, int>();
            foreach (var good in goods)
            {
                basket.Add(good, skus.Where(c => c == good).Count());
            }
            return CalculateSum(basket);
        }
        public static int CalculateSum(Dictionary<char, int> basket)
        {
            //if (basket.Count() == 0)
            //{
            //    return sum;
            //}
            var sum = 0;
            foreach (var rule in priceRules)
            {
                while (basket.ContainsKey(rule.Item)&&basket[rule.Item] >= rule.Amount)
                {
                    basket[rule.Item] -= rule.Amount;
                    sum += rule.Price;
                    if (basket[rule.Item] == 0)
                    {
                        basket.Remove(rule.Item);
                    }
                }
            }
            return sum;
        }
    }
}
