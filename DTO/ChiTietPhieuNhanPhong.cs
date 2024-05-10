using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("CHITIETPHIEUNHANHPHONG")]
    public class ChiTietPhieuNhanPhong
    {
        public int MaNhanPHG { get; set; }
        public int MaDatPHG { get; set; }
        public int MaKH { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayNhan { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayTraDuKien { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayTraThucTe { get; set; }

        public PhieuNhanPhong FK_PhieuNhanPhong { get; set; }
        public PhieuDatPhong FK_PhieuDatPhong { get; set; }
        public KhachHang FK_KhachHang { get; set; }

        public void Print() => Console.WriteLine($"MaNhanPHG: {MaNhanPHG,-10} MaDatPHG: {MaDatPHG,-10} MaKH: {MaKH,-10} NgayNhan: {NgayNhan.ToString("dd-MM-yyyy"),-20} NgayTraDuKien: {NgayTraDuKien.ToString("dd-MM-yyyy"),-20} NgayTraThucTe: {NgayTraThucTe.ToString("dd-MM-yyyy"),-20}");


    }
}
