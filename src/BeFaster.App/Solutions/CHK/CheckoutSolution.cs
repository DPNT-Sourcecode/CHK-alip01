using BeFaster.Runner.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public class Good
        {
            public char Item { get;  }
            public int Amount { get; set; }
            public Good(char item, int amount)
            {
                Item = item;
                Amount = amount;
            }
        }
        public class PriceRule : Good
        {

            public int Price { get; }
            public Good BonusItem { get;  }
            public PriceRule(char item, int amount, int price, Good bonusItem = null) : base(item, amount)
            {
                Price = price;
                BonusItem = bonusItem;
            }
        }
        public static int GroupPrice = 45;
       public static List<char> GroupRule = new char[] { 'S', 'T', 'X', 'Y', 'Z' }.ToList();
        public static List<PriceRule> priceRules = new List<PriceRule>()
        {
            new PriceRule('E', 2, 80, new Good('B', 1)),
            new PriceRule('F', 2, 20, new Good('F', 1)),
            new PriceRule('N', 3, 120, new Good('M', 1)),
            new PriceRule('R', 3, 150, new Good('Q', 1)),
            new PriceRule('U', 3, 120, new Good('U', 1)),
            new PriceRule('A', 5, 200),
            new PriceRule('A', 3, 130),
            new PriceRule('A', 1, 50),
            new PriceRule('B', 2, 45),
            new PriceRule('B', 1, 30),
            new PriceRule('C', 1, 20),
            new PriceRule('D', 1, 15),
            new PriceRule('E', 1, 40),
            new PriceRule('F', 1, 10),
            new PriceRule('G', 1, 20),
            new PriceRule('H', 10, 80),
            new PriceRule('H', 5, 45),
            new PriceRule('H', 1, 10),
            new PriceRule('I', 1, 35),
            new PriceRule('J', 1, 60),
            new PriceRule('K', 2, 150),
            new PriceRule('K', 1, 80),
            new PriceRule('L', 1, 90),
            new PriceRule('M', 1, 15),
            new PriceRule('N', 1, 40),
            new PriceRule('O', 1, 10),
            new PriceRule('P', 5, 200),
            new PriceRule('P', 1, 50),
            new PriceRule('Q', 3, 80),
            new PriceRule('Q', 1, 30),
            new PriceRule('R', 1, 50),
            new PriceRule('S', 1, 20),
            new PriceRule('T', 1, 20),
            new PriceRule('U', 1, 40),
            new PriceRule('V', 3, 130),
            new PriceRule('V', 2, 90),
            new PriceRule('V', 1, 50),
            new PriceRule('W', 1, 20),
            new PriceRule('X', 1, 17),
            new PriceRule('Y', 1, 20),
            new PriceRule('Z', 1, 21),
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
            var sum = 0;

            List<PriceRule> groupGoods = new List<PriceRule>();
            foreach (var groupItem in GroupRule)
            {
                if (basket.ContainsKey(groupItem))
                {
                    var count = basket[groupItem];
                    basket.Remove(groupItem);//remove group items
                    var price = priceRules.First(a => a.Item == groupItem && a.Amount == 1).Price;
                    for (int i = 0; i < count; i++)
                    {
                        groupGoods.Add(new PriceRule(groupItem, 1, price));
                    }
                }

            };
            var groupsNumber = groupGoods.Count / 3;
            sum += GroupPrice * groupsNumber;

            var restItems = groupGoods.Count % 3;
            var ItemsToAddBack = groupGoods.OrderBy(g => g.Price).Take(restItems);
            foreach(var itemBack in ItemsToAddBack)//add odd back
            {
                if (basket.ContainsKey(itemBack.Item))
                {
                    basket[itemBack.Item]++;
                }
                basket.Add(itemBack.Item,1);
            }

            foreach (var priceRule in priceRules)
            {
                while (basket.ContainsKey(priceRule.Item) && basket[priceRule.Item] >= priceRule.Amount)
                {
                    basket[priceRule.Item] -= priceRule.Amount;
                    sum += priceRule.Price;
                    if (priceRule.BonusItem != null)
                    {
                        if (basket.ContainsKey(priceRule.BonusItem.Item) && basket[priceRule.BonusItem.Item] >= priceRule.BonusItem.Amount)
                        {
                            basket[priceRule.BonusItem.Item] -= priceRule.BonusItem.Amount;
                        }
                    }
                    if (basket[priceRule.Item] == 0)
                    {
                        basket.Remove(priceRule.Item);
                    }
                }
            }
            return sum;
        }
    }
}



