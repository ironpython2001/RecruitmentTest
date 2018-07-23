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

        public void Update(CartItem item)
        {
            var exists = this.Items.Exists(x => x.ID == item.ID);
            if (exists)
            {
                var ItemToUpdate = this.Items.Where(x => x.ID == item.ID).First();
                ItemToUpdate.Quantity = item.Quantity;
                this._lastUpdatedDate= DateTime.Now;
            }
        }

        //public void DeleteItem(int rowID)
        //{
        //    Items.RemoveAt(rowID);
        //    LastUpdate = DateTime.Now;
        //}

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
