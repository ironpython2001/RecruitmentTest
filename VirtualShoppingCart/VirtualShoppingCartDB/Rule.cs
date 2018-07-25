using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualShoppingCartDB
{
    //In Production System these rules should come from an external assembly
    //Or from database system Or from some rule engine.
    public class Rule
    {
        public static bool IsOfferApplicable(Product product, int quantity)
        {
            //for demo purpose for productid=1 has only offers
            if (product.ProductID == 1)
            {
                if (quantity > 2)
                { return true; }
                else
                { return false; }
            }
            return false;
        }

        public static (int quantity, double SubTotal) ApplyOffer(Product product, int quantity)
        {
            var returnValue = (quantity: default(int), SubTotal: default(double));
            //for demo purpose for productid=1 has only offers
            if (product.ProductID == 1)
            {
                if (quantity > 2)
                {
                    //buy 2 get 1
                    returnValue.quantity = quantity + 1;
                    returnValue.SubTotal = quantity * product.Price;
                    return returnValue;
                }
            }
            returnValue.quantity = quantity + 1;
            returnValue.SubTotal = quantity * product.Price;
            return returnValue;
        }
    }
}
