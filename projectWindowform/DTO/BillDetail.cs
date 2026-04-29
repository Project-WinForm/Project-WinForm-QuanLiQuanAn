using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectWindowform.DTO
{
    public class BillDetail
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int FoodId { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
