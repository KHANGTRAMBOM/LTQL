using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("CHITIETPHIEUDATPHONG")]
    public class ChiTietPhieuDatPhong
    {
        public int MaDatPHG { get; set; }
        public int MaPHG { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayDat { get; set; }

        [Column(TypeName = ("Date"))]
        public DateTime NgayNhan { get; set; }

        public PhieuDatPhong PhieuDatPhong { get; set; }
        public Phong Phong { get; set; }

        public void Print() => Console.WriteLine($"MaDatPHG: {MaDatPHG,-10} MaPHG: {MaPHG,-10} NgayDat: {NgayDat.Date.ToString("dd-MM-yyyy"),-20} NgayNhan: {NgayNhan.Date.ToString("dd-MM-yyyy"),-20}");



    }
}
