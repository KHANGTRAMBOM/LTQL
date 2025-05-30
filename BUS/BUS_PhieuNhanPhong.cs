using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_PhieuNhanPhong
    {
        public static List<PhieuNhanPhong> Select_All()
        {
            return DAO.DAO_PhieuNhanPhong.Select_All();
        }

        public static PhieuNhanPhong Select_By_MaPhieuNhan(int MaPhieuNhan)
        {
            return DAO_PhieuNhanPhong.Select_By_MaPhieuNhan(MaPhieuNhan);
        }

        public static bool Insert(int MaDatPHG,int MaKH)
        {
            return DAO_PhieuNhanPhong.Insert( MaDatPHG, MaKH);
        }


        public static PhieuNhanPhong Select_By_MaPhieuDat(int MaPhieuDat)
        {
           return DAO_PhieuNhanPhong.Select_By_MaPhieuDat((int) MaPhieuDat);
        }

        public static bool Delete_By_MaDatPHG(int MaDatPHG)
        {
            return DAO_PhieuNhanPhong.Delete_By_MaDatPHG((int) MaDatPHG);
        }
    }
}
