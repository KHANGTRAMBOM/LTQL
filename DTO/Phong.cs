using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("PHONG")]
    public class Phong
    {
        [Key]
        public int MaPHG { get; set; }

        [StringLength(4)]
        public string TenPHG { get; set; }

        [StringLength(4)]
        public string LoaiPHG { get; set; }
        public LoaiPHG FK_LoaiPHG { get; set; }

        [Column(TypeName = "money")]
        [Required]
        [Range(0.01,float.MaxValue,ErrorMessage = "Giá trị phải lớn hơn 0")]
        public float Dongia { get; set; }

        public int? TinhTrang { get; set;}
       
        public TinhTrangPHG FK_TinhtrangPHG { get; set; }


        public List<ChiTietPhieuDatPhong> List_chiTietPhieuDatPhongs { get; set; }

        public List<ChiTietHoaDon> List_chiTietHoaDons { get; set; }

        public void Print() => Console.WriteLine($"MaPHG: {MaPHG,-10} TenPHG: {TenPHG,-4} LoaiPHG: {LoaiPHG,-20} Dongia: {Dongia,10:C0} TinhTrang: {TinhTrang,-10}");

    }
}
