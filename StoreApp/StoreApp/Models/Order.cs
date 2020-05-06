using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public string TimeStamp { get; set; }
    }
}
