using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUnderTest
{
    public class ClassWithDependency
    {
        private IPriceGenerator priceGenerator;

        public ClassWithDependency(IPriceGenerator priceGenerator)
        {
            this.priceGenerator = priceGenerator;
        }

        public bool VerifyPrice()
        {
            var price = priceGenerator.GeneratePrice();
            return (price > 0 && price <= 100);
        }
    }
}
