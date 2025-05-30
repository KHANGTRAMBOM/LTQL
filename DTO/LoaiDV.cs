using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("LoaiDV")]
    public class LoaiDV
    {
        [Key]
        public int MaLoaiDV { get; set; }

        [RegularExpression("^[A-Za-z0-9\\s]*$")]
        [MaxLength(30)]
        public string TenLoaiDV { get; set; }

        public List<DichVu> DichVus { get; set; }

        public void Print() => Console.WriteLine($"MaLoaiDV: {MaLoaiDV,-10} TenLoaiDV: {TenLoaiDV,-30}");

    }
}
