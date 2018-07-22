using System;
using System.Collections.Generic;
using System.Text;

namespace VirtualShoppingCartDB
{
    public class CartItem
    {
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
        }
        
        public CartItem(Product product, int quantity)
        {
            this._id = new Guid();
            this.Product = product;
            this.Quantity = this.Quantity + quantity;
            this._subTotal = this.CalculateSubTotal(this.Quantity, product.Price);
        }

        private double CalculateSubTotal(int quantity,double price)
        {
            var subTotal = quantity * price;
            return subTotal;
        }


    }

}
