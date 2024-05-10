using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_KhachHangcs
    {
        public static List<DTO.KhachHang> Select_All()
        {
           return DAO.DAO_KhachHang.Select_All();
        }

        public static List<DTO.KhachHang> Select_By_Name(string HoTen)
        {
            return DAO.DAO_KhachHang.Select_By_Name(HoTen);
        }

        public static DTO.KhachHang Select_By_ID(int ID)
        {
            return DAO.DAO_KhachHang.Select_By_ID(ID);
        }
        public static bool Delete(int ID)
        {
           return DAO.DAO_KhachHang.Delete(ID);
        }

        public static bool Delete_By_CCCD(string CCCD)
        {
            return DAO.DAO_KhachHang.Delete_By_CCCD(CCCD);
        }
        public static bool Insert(string TenKH, string CCCD, string SDT, string Diachi, string Gioitinh)
        {
            return DAO_KhachHang.Insert(TenKH, CCCD, SDT, Diachi, Gioitinh);
        }

        public static DTO.KhachHang TimKhachHang_OrCreate(string TenKH, string CCCD, string SDT, string Diachi, string Gioitinh)
        {
            return DAO_KhachHang.TimKhachHang_OrCreate(TenKH, CCCD, SDT, Diachi, Gioitinh);
        }

        public static DTO.KhachHang Select_By_CCCD(string CCCD)
        {
            return DAO_KhachHang.Select_By_CCCD(CCCD);
        }

    }
}
