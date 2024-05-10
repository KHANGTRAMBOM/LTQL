using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_PhieuNhanPhong
    {
        static Provider provider = new Provider();
        public static List<PhieuNhanPhong> Select_All()
        {
            var data = from p in provider.dbcontext.Phieunhanphongs
                       select p;

            return data.ToList();
        }

        public static PhieuNhanPhong Select_By_MaPhieuNhan(int MaPhieuNhan)
        {
            var result = (from p in provider.dbcontext.Phieunhanphongs
                         where p.MaNhanPHG ==MaPhieuNhan
                         select p).FirstOrDefault();
            return result;
        }

        public static PhieuNhanPhong Select_By_MaPhieuDat(int MaPhieuDat)
        {
            var result = (from p in provider.dbcontext.Phieunhanphongs
                          where p.MaDatPHG == MaPhieuDat
                          select p).FirstOrDefault();
            return result;
        }

        public static bool Insert(int maDatPHG, int maKH)
        {
            PhieuNhanPhong ph = new PhieuNhanPhong() { MaDatPHG = maDatPHG,MaKH = maKH };
            provider.dbcontext.Phieunhanphongs.Add(ph);
            return provider.dbcontext.SaveChanges() != 0;
        }

        public static bool Delete_By_MaDatPHG(int MaDatPHG)
        {
            var result = (from p in provider.dbcontext.Phieunhanphongs
                          where p.MaDatPHG == MaDatPHG
                          select p).FirstOrDefault();
            provider.dbcontext.Phieunhanphongs.Remove(result);
            return provider.dbcontext.SaveChanges() != 0;
        }
    }
}
