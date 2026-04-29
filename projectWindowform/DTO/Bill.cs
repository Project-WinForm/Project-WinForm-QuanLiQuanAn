using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectWindowform.DTO
{
    public class Bill
    {
        public int Id { get; set; }
        public int TableId { get; set; }
        public DateTime ThoiGianMo { get; set; }
        public DateTime? ThoiGianDong { get; set; }
        public decimal TongTien { get; set; }
        public bool TrangThai { get; set; }
    }
}
