using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace VirtualShoppingCartDB
{
    public class Cart
    {
        private DateTime _dateCreated;
        public DateTime DateCreated
        {
            get => _dateCreated;
        }

        private DateTime _lastUpdatedDate;
        public DateTime LastUpdatedDate
        {
            get => _lastUpdatedDate;
        }

        public List<CartItem> Items { get; set; }


        public Cart()
        {
            if (this.Items == null)
            {
                this.Items = new List<CartItem>();
                this._dateCreated = DateTime.Now;
            }
        }
        

        public void AddItem(CartItem item)
        {
            this.Items.Add(item);
            this._lastUpdatedDate= DateTime.Now;
        }

        public void Update(CartItem item,int quantity)
        {
            var exists = this.Items.Exists(x => x.ID == item.ID);
            if (exists)
            {
                var itemToUpdate = this.Items.Where(x => x.ID == item.ID).First();
                var result = itemToUpdate.UpdateCartItem(itemToUpdate.Product, quantity);
                itemToUpdate.Quantity = result.quantity;
                itemToUpdate.SubTotal = result.SubTotal;
                this._lastUpdatedDate= DateTime.Now;
            }
        }

        public void Delete(CartItem item)
        {
            var exists = this.Items.Exists(x => x.ID == item.ID);
            if (exists)
            {
                this.Items.Remove(item);
                    
            }
            this._lastUpdatedDate = DateTime.Now;
        }

        //private int ItemIndexOfID(int ProductID)
        //{
        //    int index = 0;
        //    foreach (CartItem item in Items)
        //    {
        //        if (item.ProductID == ProductID)
        //        {
        //            return index;
        //        }
        //        index += 1;
        //    }
        //    return -1;
        //}

        //public double Total
        //{
        //    get
        //    {
        //        double t = 0;
        //        if (Items == null)
        //        {
        //            return 0;
        //        }
        //        foreach (CartItem Item in Items)
        //        {
        //            t += Item.SubTotal;
        //        }
        //        return t;
        //    }
        //}


    }

}
