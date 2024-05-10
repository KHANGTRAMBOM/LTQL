using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   
    public class ChucVu
    {    
        public int MaCV { get; set; }
        public string TenCV { get; set; }

        public List<TaiKhoan> List_TaiKhoan { get; set; }
        public void Print() => Console.WriteLine($"MaCV: {MaCV,-10} TenCV: {TenCV,-30}");

    }
}
