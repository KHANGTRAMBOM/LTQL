using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_Phong
    {
        public static List<Phong> Select_All()
        {
          return DAO.DAO_Phong.Select_All();
        }

        public static bool Insert(string TenPhong, string LoaiPhong, float DonGia)
        {
            return DAO.DAO_Phong.Insert(TenPhong, LoaiPhong, DonGia);
        }

        public static bool Update_With_tinhtrang(int MaPHG, string TenPHG, string LoaiPHG, float Dongia, int tinhtrang)
        {
            return DAO.DAO_Phong.Update_With_tinhtrang(MaPHG,TenPHG,LoaiPHG,Dongia,tinhtrang);
        }

        public static bool Update(int MaPHG, string TenPHG, string LoaiPHG, float Dongia)
        {
            return DAO.DAO_Phong.Update(MaPHG, TenPHG, LoaiPHG, Dongia);
        }
        public static bool Delete(int MaPHG) 
        {
            return DAO.DAO_Phong.Delete(MaPHG);
        }
        public static Phong Select_By_MaPHG(int MaPHG)
        {
            return DAO_Phong.Select_By_MaPHG(MaPHG);
        }
    }
}
