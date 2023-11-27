using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCart_CodeFirst.Models
{
    public class CartItem
    {
        public Book productOrder { get; set; }
        public int Quality { get; set; }
    }
}