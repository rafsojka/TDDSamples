using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUnderTest
{
    public interface IPriceGenerator
    {
        int GeneratePrice();
    }

    public class PriceGenerator : IPriceGenerator
    {
        public int GeneratePrice()
        {
            var rnd = new Random();
            return rnd.Next(-100, 150);
        }
    }

    public class ClassWithDependency
    {
        private IPriceGenerator priceGenerator;

        public ClassWithDependency(IPriceGenerator priceGenerator)
        {
            this.priceGenerator = priceGenerator;
        }

        public bool VerifyPrice()
        {
            return (priceGenerator.GeneratePrice() > 0 && priceGenerator.GeneratePrice() <= 100);
        }
    }
}
