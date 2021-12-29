using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Entities.Helpers
{
    public class TotalPrice
    {
        protected ApplicationDbContext _context { get; set; }
        public TotalPrice()
        {
        }
        public TotalPrice(ApplicationDbContext context)
        {
            this._context = context;
        }

        public double OrderAmount(int id,int quantity)
        {

            var price = from i in _context.Products
                           where i.ProductId == id
                           select i.ProductPrice;
            double totalPrice = Convert.ToDouble(price) * quantity;
            return totalPrice;
        }
    }
}
