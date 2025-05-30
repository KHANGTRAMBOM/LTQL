using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static  class BUS_ChiTietHoaDon
    {
        public static List<ChiTietHoaDon> Select_All()
        {
            return DAO_ChiTietHoaDon.Select_All();
        }

        public static ChiTietHoaDon Select_By_MaHD(int MaHD)
        {
            return DAO_ChiTietHoaDon.Select_By_MaHD(MaHD);
        }

        public static List<ChiTietHoaDon> Select_All_By_MaHD(int MaHD)
        {
            return DAO_ChiTietHoaDon.Select_All_By_MaHD(MaHD);
        }

        public static object TimKiemTheoTen(string TenKH)
        {
            return DAO_ChiTietHoaDon.TimKiemTheoTen(TenKH);
        }

   
        public static NhanVien GetNhanVien(int MaHD)
        {
            return DAO_ChiTietHoaDon.GetNhanVien(MaHD);
        }

        public static ChiTietPhieuNhanPhong GetChiTietPhieuNhanPhong(int MaNhanPHG)
        {
            return DAO.DAO_ChiTietHoaDon.GetChiTietPhieuNhanPhong((int) MaNhanPHG);
        }


        public static ChiTietPhieuDatPhong GetChiTietPhieuDatPhong(int MaDatPHG)
        {
            return DAO.DAO_ChiTietHoaDon.GetChiTietPhieuDatPhong((int) MaDatPHG);
        }


        public static ChiTietHoaDon Select_By_MaHD_MaSDDV(int MaHD, int MaSDDV)
        {
          return DAO.DAO_ChiTietHoaDon.Select_By_MaHD_MaSDDV((int) MaHD, MaSDDV);
        }

        public static bool Insert(int MaHD, int MaPHG, int MaSDDV, float TienPHG, float TienDV, int SoNgay)
        {
            return DAO_ChiTietHoaDon.Insert(MaHD, MaPHG, MaSDDV, TienPHG, TienDV, SoNgay);
        }


        public static bool Update_TienDV(int MaHD, int MaSDDV)
        {
           return DAO_ChiTietHoaDon.Update_TienDV((int) MaHD, MaSDDV);
        }

        public static bool Delete(int MaHD, int MaSDDV)
        {
            return DAO_ChiTietHoaDon.Delete(MaHD, MaSDDV); 
        }

    }
}
