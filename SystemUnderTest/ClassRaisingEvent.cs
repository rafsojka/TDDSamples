using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemUnderTest
{
    interface IClassRaisingEvent
    {
        event EventHandler<PriceVerifiedEventArgs> PriceVerified;
    }

    public class ClassRaisingEvent : IClassRaisingEvent
    {
        private IPriceGenerator priceGenerator;

        public ClassRaisingEvent(IPriceGenerator priceGenerator)
        {
            this.priceGenerator = priceGenerator;
        }

        public void VerifyPrice()
        {
            var price = priceGenerator.GeneratePrice();
            if (price > 0 && price <= 100)
            {
                PriceVerifiedEventArgs args = new PriceVerifiedEventArgs();
                args.Price = price;
                OnPriceVerified(args);
            }
        }

        protected virtual void OnPriceVerified(PriceVerifiedEventArgs e)
        {
            EventHandler<PriceVerifiedEventArgs> handler = PriceVerified;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public event EventHandler<PriceVerifiedEventArgs> PriceVerified;
    }

    public class PriceVerifiedEventArgs : EventArgs
    {
        
        public int Price { get; set; }
    }
}
