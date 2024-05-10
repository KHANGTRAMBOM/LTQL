using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_ChiTietPhieuDatPhong
    {
        static Provider provider = new Provider();

        public static List<ChiTietPhieuDatPhong> Select_All()
        {
            var data = from p in provider.dbcontext.Chitietphieudatphongs
                       select p;

            return data.ToList();
        }

        /* Select theo MaDatPHG */ 
        public static ChiTietPhieuDatPhong Select_By_MaDatPHG(int MaDatPHG)
        {
            var result = (from p in provider.dbcontext.Chitietphieudatphongs
                         where p.MaDatPHG == MaDatPHG
                         select p).FirstOrDefault();

            return result;
        }

        /* Select theo MaPHG */
        public static List<ChiTietPhieuDatPhong> Select_By_MaPHG(int MaPHG)
        {
            var result = (from p in provider.dbcontext.Chitietphieudatphongs
                          where p.MaPHG == MaPHG
                          select p);

            return result.ToList();
        }

        public static bool Insert(int MaPHG,int MaDatPHG,DateTime ngaydat , DateTime ngaynhan)
        {
            ChiTietPhieuDatPhong phieunhanphg = new ChiTietPhieuDatPhong() { MaPHG = MaPHG, MaDatPHG = MaDatPHG, NgayDat = ngaydat, NgayNhan = ngaynhan };
            provider.dbcontext.Chitietphieudatphongs.Add(phieunhanphg);
            return provider.dbcontext.SaveChanges() != 0;
        }
        
    }
}
