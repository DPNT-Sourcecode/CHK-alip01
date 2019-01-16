﻿using BeFaster.App.Solutions.CHK;
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
        [TestCase("A", ExpectedResult = 50)]
        public int CheckoutA(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("AA", ExpectedResult = 100)]
        public int CheckoutAA(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("AAA", ExpectedResult = 130)]
        public int CheckoutAAA(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("AAAA", ExpectedResult = 180)]
        public int CheckoutAAAA(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("EE", ExpectedResult = 80)]
        public int CheckoutEE(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
        [TestCase("EEBB", ExpectedResult = 110)]
        public int CheckoutEEBB(string skus)
        {
            return CheckoutSolution.Checkout(skus);
        }
    }
}