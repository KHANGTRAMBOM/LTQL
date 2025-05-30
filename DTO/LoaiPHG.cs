using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("LOAIPHG")]
    public class LoaiPHG
    {
        [Key]
        [StringLength(4)]
        public string MaloaiPHG { get; set; }

        [StringLength(20)]
        public string TenloaiPHG { get; set; }

        [Range(1,int.MaxValue)]
        public int SoNguoiToiDa { get; set; }
        public List<Phong> Phongs { get; set; }

        public void Print() => Console.WriteLine($"MaloaiPHG: {MaloaiPHG,-20} TenloaiPHG: {TenloaiPHG,-30}  SoNguoiToiDa: {SoNguoiToiDa,-10}");


    }
}
