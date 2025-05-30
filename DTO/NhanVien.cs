using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("NHANVIEN")]
    public class NhanVien
    {
        [Key]
        public int Manv { get; set; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-Z\\s]*$")]
        [Required]

        public string TenNV { get; set; }


        [StringLength(10)]
        [RegularExpression("^[0-9]{10}$")]
        public string? SDT { get; set; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-Z0-9\\s,'-]*$", ErrorMessage = "Địa chỉ không được chứa ký tự đặc biệt")]

        public string? Diachi { get; set; }

        [StringLength(3)]
        [RegularExpression("Nam|Nữ", ErrorMessage = "Chỉ nhận giá trị 'Nam' hoặc 'Nữ'")]

        public string Gioitinh { get; set; }

        public int? LoaiNV {get; set; }

        [ForeignKey("LoaiNV")]

        public LoaiNV FK_LoaiNV { get; set; }
        public List<HoaDon> List_hoaDons { get; set; }

        public void Print() => Console.WriteLine($"Manv: {Manv,-10} TenNV: {TenNV,-30} SDT: {SDT,-10} Diachi: {Diachi,-30} Gioitinh: {Gioitinh,-3} LoaiNV: {LoaiNV,-10}");


    }
}
