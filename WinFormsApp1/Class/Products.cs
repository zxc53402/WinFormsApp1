using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Class
{
    internal class Products
    {
        public string? ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? UnitPrice { get; set; }
    }
    internal class Category
    {
        public string? CategoryID { get; set;}
        public string? CategoryName { get; set;}
        public string? Description { get; set;}
    }
    internal class OrderDetail
    {
        public string? ProductID { get; set; }
        public string? Uniprice { get; set; }
        public int? Quentity { get; set; }

    }
    
    
}
