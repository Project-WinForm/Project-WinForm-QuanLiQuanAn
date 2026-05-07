using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectWindowform.DTO
{
    public class Food
    {
        public int Id { get; set; }
        public string TenMon { get; set; } = "";
        public decimal Gia { get; set; }
        public int DanhMucId { get; set; }
        public string HinhAnh { get; set; } = "";
        public bool TrangThai { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImagePath { get; set; }
    }
}
