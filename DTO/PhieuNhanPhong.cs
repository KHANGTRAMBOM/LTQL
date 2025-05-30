using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("PHIEUNHANPHONG")]
    public class PhieuNhanPhong
    {
        public int MaNhanPHG { get; set; }

        public int MaDatPHG { get; set; }
        public int? MaKH { get; set; }

        public KhachHang FK_Khachhang { get; set; }

        public PhieuDatPhong FK_PhieuDatPHG { get; set; }

        public List<ChiTietPhieuNhanPhong> List_ChiTietPhieuNhanPhong { get; set; }

        public List<SuDungDV> List_SuDungDichVu{ get; set; }

        public List<HoaDon> List_hoaDons { get; set; }

        public void Print() => Console.WriteLine($"MaNhanPHG: {MaNhanPHG,-10} MaDatPHG: {MaDatPHG,-10} MaKH: {MaKH,-10}");

    }
}
