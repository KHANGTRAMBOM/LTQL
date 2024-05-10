using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Table("DICHVU")]
    public class DichVu
    {
        [Key]
        public int MaDV { get; set; }

        [StringLength(30)]
        [RegularExpression("^[a-zA-z0-9\\s,'-]*$")]
        [Required]
        public string TenDV { get; set; }
    
        public int? LoaiDV { get; set; }

        [Column(TypeName = "money")]
        [Range(0.01, float.MaxValue)]
        public float Dongia { get; set; }

        [ForeignKey("LoaiDV")]
        public LoaiDV FK_LoaiDV { get; set; }
        public List<SuDungDV> SuDungDVs { get; set; }

        public void Print() => Console.WriteLine($"MaDV: {MaDV,-10} TenDV: {TenDV,-30} LoaiDV: {LoaiDV,-10} Dongia: {Dongia,-10:C0}");
    }
}
