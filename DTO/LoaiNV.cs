using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("LoaiNhanVien")]
    public class LoaiNV
    {
        [Key]
        public int MaLoai { get; set; }

        [RegularExpression("^[a-zA-Z0-9\\s]*$")]
        [MaxLength(20)]
        public string TenLoai { get; set; }

        public  List<NhanVien> Nhanvien { get; set; }
        public void Print() => Console.WriteLine($"MaLoai: {MaLoai,-10} TenLoai: {TenLoai,-30}");

    }
}
