using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{

    public class TaiKhoan
    {
        [Key]
        public string Taikhoan { get; set;}
        public string Matkhau { get; set;}

        public int? MaCV { get; set; }
        public ChucVu FK_MaCV { get; set; }
        public void Print() => Console.WriteLine($"Taikhoan: {Taikhoan,-20} Matkhau: {Matkhau,-20} MaCV: {MaCV}");

    }
}
