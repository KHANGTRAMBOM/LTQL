using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_PhieuDatPhong
    {
        public static List<PhieuDatPhong> Select_All()
        {
            return DAO.DAO_PhieuDatPhong.Select_All();
        }

        public static bool Insert(int MaKH)
        {
            return DAO_PhieuDatPhong.Insert(MaKH);  
        }


        public static PhieuDatPhong Select_By_MaKH_Last(int MaKH)
        {
            return DAO_PhieuDatPhong.Select_By_MaKH_Last(MaKH);
        }

        public static PhieuDatPhong Select_By_MaDatPHG(int MaDatPHG)
        {
            return DAO_PhieuDatPhong.Select_By_MaDatPHG(MaDatPHG);
        }

        public static bool Delete(int MaDatPHG)
        {
           return DAO_PhieuDatPhong.Delete(MaDatPHG);
        }

    }
}
