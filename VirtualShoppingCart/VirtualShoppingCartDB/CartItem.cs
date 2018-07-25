using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace VirtualShoppingCartDB
{
    public class CartItem
    {
        public class Globals
        {
            public int param_quantity;
        }
        

        //assumption is that guid is unique
        private Guid _id;
        public Guid ID
        {
            get
            {
                return this._id;
            }
        }

        public Product Product { get; set; }
        public int Quantity { get; set; }

        private double _subTotal;
        public double SubTotal
        {
            get
            {
                this._subTotal = this.CalculateSubTotal(this.Quantity, this.Product.Price);
                return _subTotal;
            }
            set
            {
                this._subTotal = value;
            }
            
        }
       
        public CartItem(Product product, int quantity)
        {
            this._id = new Guid();
            this.Product = product;
            //check offer is applicable for this product and quantity
            if (Rule.IsOfferApplicable(product, quantity))
            {
                var offerRule = Rule.ApplyOffer(product, quantity);
                this.Quantity = offerRule.quantity;
                this._subTotal = offerRule.SubTotal;
            }
            else
            {
                this.Quantity = this.Quantity + quantity;
                this._subTotal = this.CalculateSubTotal(this.Quantity, product.Price);
            }
        }

        public (int quantity, double SubTotal) UpdateCartItem(Product product, int quantity)
        {
            var returnValue = (Quantity: default(int), SubTotal: default(double));
            if (Rule.IsOfferApplicable(product,quantity))
            {
                var offerRule = Rule.ApplyOffer(product, quantity);
                returnValue.Quantity = offerRule.quantity;
                returnValue.SubTotal = offerRule.SubTotal;
            }
            else
            {
                returnValue.Quantity = this.Quantity + quantity;
                returnValue.SubTotal= this.CalculateSubTotal(quantity, product.Price);
            }
            return returnValue;
        }

        private double CalculateSubTotal(int quantity,double price)
        {
            var subTotal = quantity * price;
            return subTotal;
        }


    }

}
