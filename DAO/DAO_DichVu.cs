using DTO;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_dichvu
    {
        static Provider provider = new Provider();

        /* Select* */
        public static List<DichVu> Select_All()
        {
            var source = from p in provider.dbcontext.Dichvus
                         select p;

            return source.ToList();
        }


        /* XÓA */
        public static bool Delete(int MaDV)
        {
            /* TÌM DỊCH VỤ CẦN Xóa */

            var data = (from p in provider.dbcontext.Dichvus
                       where p.MaDV == MaDV
                       select p).FirstOrDefault();

            provider.dbcontext.Dichvus.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }


        /* THÊM */
        public static bool Insert(string TenDV,int LoaiDV,float Dongia)
        {                      
            /* Kiễm tra tên dịch vụ có trùng không */
            if (!KiemTraTenDV(TenDV)) return false;

            DichVu dichvu = new DichVu() { TenDV = TenDV , LoaiDV = LoaiDV ,Dongia = Dongia};
            provider.dbcontext.Dichvus.Add(dichvu);
            return provider.dbcontext.SaveChanges() != 0;
        }


        /* SỬA */
        public static bool Update(int MaDV,string TenDV, int LoaiDV, float Dongia)
        {
            /* TÌM DỊCH VỤ CẦN THAY ĐỔI */
            var data = (from p in provider.dbcontext.Dichvus
                        where p.MaDV == MaDV
                        select p).FirstOrDefault();
            
             /* Kiễm tra xem có người dùng có thay đổi tên của dịch vụ không*/
            if (!KiemTraTenDV(TenDV)) return false;
  
            data.TenDV = TenDV;
            data.LoaiDV = LoaiDV;
            data.Dongia = Dongia;

            return provider.dbcontext.SaveChanges() != 0;
        }


        /*HÀM KIỄM TRA TÊN DỊCH VỤ GIỐNG VỚI RÀNG BUỘC TRÊN CSDL CHECK [(TENDV LIKE '%[A-Za-z0-9 ]%')UNIQUE] */
        private static bool KiemTraTenDV(string TenDV)
        {
            var data = (from p in provider.dbcontext.Dichvus
                        where p.TenDV.Contains(TenDV)
                        select p).FirstOrDefault();

            if (data != null || !Regex.IsMatch(TenDV, "^[A-Za-z0-9 ]") || TenDV.Length == 0)
            {
                return false;
            }

            return true;
        }

        /* Lay Dich Vu Theo Ma */
        public static DichVu GetDichVu_By_MaDV(int MaDV)
        {
            var result = (from p in provider.dbcontext.Dichvus
                         where p.MaDV == MaDV
                         select p).FirstOrDefault();

            return result;
        }

    }
}
