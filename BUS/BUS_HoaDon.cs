using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_HoaDon
    {
        public static List<HoaDon> Select_All()
        {
            return DAO_HoaDon.Select_All();
        }

        public static HoaDon Select_By_MaHD(int MaHD)
        {
           return DAO_HoaDon.Select_By_MaHD(MaHD);
        }

        public static bool Insert(int MaNV, int MaKH, int MaNhanPHG, DateTime NgayLap)
        {
          return DAO_HoaDon.Insert(MaNV, MaKH, MaNhanPHG,NgayLap);
        }

        public static HoaDon Select_By_MaNhanPHG(int MaNhanPHG)
        {
            return DAO_HoaDon.Select_By_MaNhanPHG(MaNhanPHG);
        }

        public static int GetSoNgay(int MaHD)
        {
           return DAO_HoaDon.GetSoNgay(MaHD);   
        }

        public static bool Update_TongTien(int MaNhanPHG,int MaPHG,float tiendv)
        {
            return DAO_HoaDon.Update_TongTien(MaNhanPHG,MaPHG,tiendv);
        }

        public static float GetTongTienChuaPhuThu(int maNhanPHG, int MaPHG, float tiendv)
        {
           return DAO_HoaDon.GetTongTienChuaPhuThu(maNhanPHG,MaPHG,tiendv); 
        }

        public static object Select_Display()
        {
           return DAO_HoaDon.Select_Display();
        }

        public static bool KiemTraHoaDonDaThanhToan(int MaHD)
        {
            return DAO_HoaDon.KiemTraHoaDonDaThanhToan(MaHD);
        }

        public static object DanhSachHoaDonDaThanhToan()
        {
           return DAO_HoaDon.DanhSachHoaDonDaThanhToan();
        }

        public static float GetDoanhSo()
        {
            return DAO_HoaDon.GetDoanhSo();
        }
    }
}
