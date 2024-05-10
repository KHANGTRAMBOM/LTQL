using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("PHIEUDATPHONG")]
    public class PhieuDatPhong
    {
        [Key]
        public int MaDatPHG { get; set; }   
        public int? MaKH { get; set; }
        public KhachHang FK_MaKH { get; set; }
        public List<ChiTietPhieuDatPhong> List_chiTietPhieuDatPhongs { get; set; }
        public List<PhieuNhanPhong> List_PhieuNhanPhong { get; set; }
        public List<ChiTietPhieuNhanPhong> List_ChiTietPhieuNhanPhong { get; set; }

        public void Print() => Console.WriteLine($"MaDatPHG: {MaDatPHG,-10} MaKH: {MaKH,-10}");

    }
}
