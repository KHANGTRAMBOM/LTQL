using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("TinhTrangPhong")]
    public class TinhTrangPHG
    {
        [Key]
        public int MaTinhTrg { get; set; }

        [RegularExpression("^[A-Za-z\\s]*$")]
        [StringLength(30)]
        public string TenTinhTrg { get; set; }
        public List<Phong> Phongs { get; set; }
        public void Print() => Console.WriteLine($"MaTinhTrg: {MaTinhTrg,-10} TenTinhTrg: {TenTinhTrg,-30}");

    }
}
