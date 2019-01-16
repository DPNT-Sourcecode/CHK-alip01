using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [TestCase("", ExpectedResult = 0)]
        public int CheckoutEmpty(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("564", ExpectedResult = -1)]
        public int CheckoutWrong(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}