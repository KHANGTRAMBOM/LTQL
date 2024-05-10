using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("HOADON")]
    public class HoaDon
    {
        [Key]
        public int MaHD { get; set; }

        public int? MaNV { get; set; }

        public int? MaKH { get; set; }
        public int MaNhanPHG { get; set; }

        [Column(TypeName = "money")]
        [Range(0.1,float.MaxValue)]
        public float TongTien { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayLap { get; set; }
        public NhanVien FK_NhanVien { get; set; }

        public KhachHang FK_KhachHang { get; set; }
        public PhieuNhanPhong FK_PhieuNhanPhong { get; set; }

        public List<ChiTietHoaDon> List_chiTietHoaDons { get; set; }

        public void Print() => Console.WriteLine($"MaHD: {MaHD,-10} MaNV: {MaNV,-10} MaKH: {MaKH,1-0} MaNhanPHG: {MaNhanPHG,-10} TongTien: {TongTien,-10:C0}");

    }
}
