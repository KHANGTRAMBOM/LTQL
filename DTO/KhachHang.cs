using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("KHACHHANG")]
    public class KhachHang
    {
        [Key]
        public int MaKH { get; set; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-Z\\s]*$", ErrorMessage = "Tên không được chứa ký tự đặc biệt")]
        [Required]
        public string TenKH { get; set; }

        [StringLength(12)]
        [RegularExpression("^[0-9]{12}$", ErrorMessage = "CCCD không hợp lệ")]
        [Required]
        public string CCCD { get; set; }


        [StringLength(10)]
        [RegularExpression("^[0-9]{10}$", ErrorMessage = "SĐT không hợp lệ")]
        public string? SDT { get; set; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-Z0-9\\s,'-]*$", ErrorMessage = "Địa chỉ không được chứa ký tự đặc biệt")]

        public string? Diachi { get; set; }

        [StringLength(3)]
        [RegularExpression("Nam|Nữ", ErrorMessage = "Chỉ nhận giá trị 'Nam' hoặc 'Nữ'")]
        [Required]
        public string Gioitinh { get; set; }
     

        public List<PhieuDatPhong> List_phieuDatPhongs { get; set; }

        public List<PhieuNhanPhong> List_phieuNhanPhongs { get; set; }

        public List<ChiTietPhieuNhanPhong> List_ChiTietPhieuNhanPhong { get; set; }

        public List<HoaDon> List_hoaDons { get; set; }

        public void Print() => Console.WriteLine($"MaKH: {MaKH,-10} TenKH: {TenKH,-20} CCCD: {CCCD,-20} SDT: {SDT,-20} Diachi: {Diachi,-20} Gioitinh: {Gioitinh,-3}");

    }
}
