using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static  class DAO_ChiTietPhieuNhanPhong
    {
        static Provider provider = new Provider();
        public static List<ChiTietPhieuNhanPhong> Select_All()
        {
            var data = from p in provider.dbcontext.Chitietphieunhanphongs
                       select p;

            return data.ToList();
        }
        /* Select chitietphieunhanphong tu manhanphong */
        public static ChiTietPhieuNhanPhong Select_By_MaNhanPhong(int MaNhanPhong)
        {
            var data = DAO_PhieuNhanPhong.Select_By_MaPhieuNhan(MaNhanPhong);

            var result = (from p in provider.dbcontext.Chitietphieunhanphongs
                          where p.MaNhanPHG == data.MaNhanPHG
                          select p).FirstOrDefault();

            return result;
        }

        /* Insert */

        public static bool Insert(int MaNhanPHG,int MaDatPhong,int MaKH, DateTime Ngaynhan,DateTime NgayTraDuKien,DateTime NgayTraThucTe)
        { 
            ChiTietPhieuNhanPhong ct = new ChiTietPhieuNhanPhong() { MaNhanPHG = MaNhanPHG, MaDatPHG = MaDatPhong, MaKH = MaKH,NgayNhan = Ngaynhan,NgayTraDuKien = NgayTraDuKien, NgayTraThucTe = NgayTraThucTe };
            provider.dbcontext.Chitietphieunhanphongs.Add(ct);
            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Tim kiem*/

        public static ChiTietPhieuNhanPhong TimKiem(int MaNhanPHG, int MaDatPhong, int MaKH)
        {
            var data = (from p in provider.dbcontext.Chitietphieunhanphongs
                       where p.MaNhanPHG == MaNhanPHG && p.MaDatPHG == MaDatPhong && p.MaKH == MaKH
                       select p).FirstOrDefault();

            return data;
        }


        /* Update */

        public static bool Update_NgayTraThucTe(int MaNhanPHG, int MaDatPhong, int MaKH , DateTime NgayTraThucTe)
        {
            var data = (from p in provider.dbcontext.Chitietphieunhanphongs
                        where p.MaNhanPHG == MaNhanPHG && p.MaDatPHG == MaDatPhong && p.MaKH == MaKH
                        select p).FirstOrDefault();
            data.NgayTraThucTe = NgayTraThucTe;
            return provider.dbcontext.SaveChanges() != 0;
        }

        public static bool Update_NgayTraDuKien(int MaNhanPHG, int MaDatPhong, int MaKH, DateTime NgayTraDuKien)
        {
            var data = (from p in provider.dbcontext.Chitietphieunhanphongs
                        where p.MaNhanPHG == MaNhanPHG && p.MaDatPHG == MaDatPhong && p.MaKH == MaKH
                        select p).FirstOrDefault();
            data.NgayTraDuKien = NgayTraDuKien;
            return provider.dbcontext.SaveChanges() != 0;
        }
    }
}
