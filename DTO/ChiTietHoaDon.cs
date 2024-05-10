using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("CHITIETHOADON")]
    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }

        public int? MaPHG { get; set; }

        public int? MaSuDungDV { get; set; }

        [Range(0, float.MaxValue)]
        [Column(TypeName = "Money")]
        public float PhuThu { get; set; }

        [Range(0, float.MaxValue)]
        [Column(TypeName = "Money")]
        public float TienPHG { get; set; }

        [Column(TypeName = "Money")]
        public float TienDV { get; set; }

        [Range(1, float.MaxValue)]
        public int SoNgay { get; set; }

        [Column(TypeName = "Money")]
        public float ThanhTien { get; set; } 

        public HoaDon FK_HoaDon { get; set; }
        public Phong FK_Phong { get; set; }
        public SuDungDV FK_SuDungDichVu { get; set; }

        public void Print() => Console.WriteLine($"MaHD: {MaHD,-10} MaPHG: {MaPHG,-10} MaSuDungDV: {MaSuDungDV,-10} PhuThu: {PhuThu,-20:C0} TienPHG: {TienPHG,-20:C0} TienDV: {TienDV,-20:C0} SoNgay: {SoNgay,-20} ThanhTien: {ThanhTien,-20:C0}");

        public void TinhThanhTien()
        {
            ThanhTien = PhuThu + TienDV;
        }

        public void TinhPhuThu()
        {
            /* Phu thu 10% */
            PhuThu = (int) (ThanhTien / 10);

            TinhThanhTien();
        }
    }
}
