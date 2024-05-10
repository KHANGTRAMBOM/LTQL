using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_ChiTietDatPhong
    {
        public static List<ChiTietPhieuDatPhong> Select_All()
        {
            return DAO.DAO_ChiTietPhieuDatPhong.Select_All();
        }

        public static ChiTietPhieuDatPhong Select_By_MaDatPHG(int MaDatPHG)
        {
            return DAO_ChiTietPhieuDatPhong.Select_By_MaDatPHG(MaDatPHG); 
        }

        public static List<ChiTietPhieuDatPhong> Select_By_MaPHG(int MaPHG)
        {
            return DAO_ChiTietPhieuDatPhong.Select_By_MaPHG(MaPHG);
        }

        public static bool Insert(int MaPHG, int MaDatPHG, DateTime ngaydat, DateTime ngaynhan)
        {
            return DAO_ChiTietPhieuDatPhong.Insert(MaPHG, MaDatPHG,ngaydat,ngaynhan);
        }
    }
}
