using System;
using System.Collections.Generic;
using System.Text;

namespace RCVMobile3.Models
{
    public class Cart
    {
        public Guid Id { get; set; }
        public string cart_user { get; set; }
        public string cart_clotheid { get; set; }
        public int cart_price { get; set; }
    }
}
