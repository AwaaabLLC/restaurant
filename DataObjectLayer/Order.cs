﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public int TableNumber { get; set; }
    }
}