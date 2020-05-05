using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class Stock
    {
        public int StockID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
    }
}
