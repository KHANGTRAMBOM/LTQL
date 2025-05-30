using DAO;
using DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_Taikhoan
    {
        public static List<DTO.TaiKhoan> Select_All()
        {
            return DAO.DAO_TaiKhoan.Select_All();
        }

        public static bool Insert(string TaiKhoan, string MatKhau, int ChucVu)
        {
            return DAO.DAO_TaiKhoan.Insert(TaiKhoan, MatKhau, ChucVu);
        }

        public static TaiKhoan Select_By_TaiKhoan(string tk)
        {
            return DAO_TaiKhoan.Select_By_TaiKhoan(tk);
        }

        public static bool KiemTraTaiKhoan(string tk, string mk)
        {
            return DAO_TaiKhoan.KiemTraTaiKhoan(tk, mk);
        }

    }
}
