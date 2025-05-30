using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_ChiTietNhanPhong
    {
        public static List<ChiTietPhieuNhanPhong> Select_All()
        {
            return DAO.DAO_ChiTietPhieuNhanPhong.Select_All();
        }

        public static ChiTietPhieuNhanPhong Select_By_MaNhanPhong(int MaNhanPhong)
        {
            return DAO_ChiTietPhieuNhanPhong.Select_By_MaNhanPhong(MaNhanPhong);
        }

        public static bool Insert(int MaNhanPHG, int MaDatPhong, int MaKH, DateTime Ngaynhan, DateTime NgayTraDuKien, DateTime NgayTraThucTe)
        {
            return DAO_ChiTietPhieuNhanPhong.Insert(MaNhanPHG, MaDatPhong, MaKH, Ngaynhan, NgayTraDuKien, NgayTraThucTe);
        }

        public static ChiTietPhieuNhanPhong TimKiem(int MaNhanPHG, int MaDatPhong, int MaKH)
        {
           return DAO_ChiTietPhieuNhanPhong.TimKiem(MaNhanPHG, MaDatPhong, MaKH);
        }


        /* Update */

        public static bool Update_NgayTraThucTe(int MaNhanPHG, int MaDatPhong, int MaKH, DateTime NgayTraThucTe)
        {
           return DAO_ChiTietPhieuNhanPhong.Update_NgayTraThucTe(MaNhanPHG,MaDatPhong,MaKH, NgayTraThucTe);
        }

        public static bool Update_NgayTraDuKien(int MaNhanPHG, int MaDatPhong, int MaKH, DateTime NgayTraDuKien)
        {
            return DAO_ChiTietPhieuNhanPhong.Update_NgayTraDuKien(MaNhanPHG, MaDatPhong, MaKH, NgayTraDuKien);
        }


    }
}
