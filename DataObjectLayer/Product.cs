using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjectLayer
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string QTY { get; set; }
        public string Price { get; set; }
        public string UPC { get; set; }
    }
}
