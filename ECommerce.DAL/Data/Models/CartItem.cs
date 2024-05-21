﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; } 
        public int Quantity { get; set; } 
        public required int CartId { get; set; } 
        public  Cart? Cart { get; set; }
        public int ProductId { get; set; } 
        public Product? Product { get; set; }
    }
}
