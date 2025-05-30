using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_NhanVien
    {
        public static List<NhanVien> Select_All()
        {
            return DAO.DAO_NhanVien.Select_All();
        }
        public static bool Insert(string TenNV, string SDT, string Diachi, string Gioitinh, int LoaiNV)
        {
            return DAO.DAO_NhanVien.Insert(TenNV, SDT,  Diachi, Gioitinh,LoaiNV);
        }
        public static bool Update(int Manv,string TenNV, string SDT, string Diachi, string Gioitinh, int LoaiNV)
        {
            return DAO.DAO_NhanVien.Update(Manv,TenNV, SDT, Diachi, Gioitinh, LoaiNV);
        }
        public static bool Delete(int MaNV)
        {
            return DAO.DAO_NhanVien.Delete(MaNV);
        }

        public static List<NhanVien> TimNhanVien(string TenNV)
        {
            return DAO.DAO_NhanVien.TimNhanVien(TenNV);
        }
        public static NhanVien Select_By_MaNV(int MaNV)
        {
            return DAO_NhanVien.Select_By_MaNV(MaNV);
        }

        public static List<NhanVien> Select_LeTan()
        {
           return DAO_NhanVien.Select_LeTan();

        }
    }
}
