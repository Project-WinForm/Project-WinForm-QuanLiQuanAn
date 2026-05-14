using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tieuluan.DTO
{
    public class OrderItem
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public int Total => Price * Quantity;
    }
}