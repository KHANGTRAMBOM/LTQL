using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_TaiKhoan
    {
        private static Provider provider = new Provider();
        public static List<DTO.TaiKhoan> Select_All()
        {
            return (from p in provider.dbcontext.Taikhoans
                    select p).ToList();
        }

        public static bool Insert(string TaiKhoan,string MatKhau,int ChucVu)
        {
            DTO.TaiKhoan taikhoan = new DTO.TaiKhoan() { Taikhoan = TaiKhoan, Matkhau = MatKhau, MaCV = ChucVu };
            provider.dbcontext.Taikhoans.Add(taikhoan);
            return provider.dbcontext.SaveChanges() != 0;
        }

        public static TaiKhoan Select_By_TaiKhoan(string tk)
        {
            var data = (from p in provider.dbcontext.Taikhoans
                       where p.Taikhoan.Equals(tk)
                       select p).FirstOrDefault();

            return data;
        }

        public static bool KiemTraTaiKhoan(string tk,string mk)
        {
            var data = (from p in provider.dbcontext.Taikhoans
                        where p.Taikhoan.Equals(tk) && p.Matkhau.Equals(mk)
                        select p).FirstOrDefault();

            return data != null;
        }
    }
}
