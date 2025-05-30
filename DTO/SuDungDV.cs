using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("SuDungDV")]
    public class SuDungDV
    {
        [Key]
        public int MaSuDungDV { get; set; }
        public int? MaDV { get; set; }
        public int MaNhanPHG { get; set; }

        [Range(1, int.MaxValue)]
        public int Soluong { get; set; }
        public DichVu FK_DichVu { get; set; }
        public PhieuNhanPhong FK_NhanPhong { get; set; }
        public List<ChiTietHoaDon> List_chiTietHoaDons { get; set; }
        public void Print() => Console.WriteLine($"MaSuDungDV: {MaSuDungDV,-10} MaDV: {MaDV,-10} MaNhanPHG: {MaNhanPHG,-10} Soluong: {Soluong,-10}");

    }
}
