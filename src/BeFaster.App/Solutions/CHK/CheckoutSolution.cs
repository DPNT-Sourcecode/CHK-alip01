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
            public Good(char item, int amount)
            {
                Item = item;
                Amount = amount;
            }
        }
        public class PriceRule : Good
        {

            public int Price;
            public Good BonusItem;
            public PriceRule(char item, int amount, int price, Good bonusItem = null) : base(item, amount)
            {
                Price = price;
                BonusItem = bonusItem;
            }
        }
        public static List<PriceRule> priceRules = new List<PriceRule>()
        {
            new PriceRule('E', 2, 80, new Good('B', 1)),
            new PriceRule('F', 2, 20, new Good('F', 1)),
            new PriceRule('A', 5, 200),
            new PriceRule('A', 3, 130),
            new PriceRule('A', 1, 50),
            new PriceRule('B', 2, 45),
            new PriceRule('B', 1, 30),
            new PriceRule('C', 1, 20),
            new PriceRule('D', 1, 15),
            new PriceRule('E', 1, 40),
            new PriceRule('F', 1, 10),
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
                while (basket.ContainsKey(rule.Item) && basket[rule.Item] >= rule.Amount)
                {
                    basket[rule.Item] -= rule.Amount;
                    sum += rule.Price;
                    if (rule.BonusItem != null)
                    {
                        if (basket.ContainsKey(rule.BonusItem.Item) && basket[rule.BonusItem.Item] >= rule.BonusItem.Amount){
                            basket[rule.BonusItem.Item] -= rule.BonusItem.Amount;
                        }
                    }
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



