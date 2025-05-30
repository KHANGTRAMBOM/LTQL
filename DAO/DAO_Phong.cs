using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_Phong
    {
        private static Provider provider = new Provider();
       /* Select* */
        public static List<Phong> Select_All()
        {
            var result = (from p in provider.dbcontext.Phongs
                         select p).ToList();

            result.ForEach(p =>
            {
                var entry = provider.dbcontext.Entry(p);
                entry.Reference(i => i.FK_LoaiPHG).Load();
            });


            return result;
        }

        /*Thêm*/
        public static bool Insert(string TenPhong, string LoaiPhong, float DonGia)
        {
            /*Kiễm tra tính hợp lệ của tenphong */
            if (!KiemTraTenPhong(TenPhong)) return false;

            Phong phong = new Phong() { TenPHG = 'A'+TenPhong, LoaiPHG = LoaiPhong, Dongia = DonGia, TinhTrang = 1 };
            provider.dbcontext.Phongs.Add(phong);

            return provider.dbcontext.SaveChanges() != 0;
        }

        /* Cập nhật dữ liệu */
        public static bool Update(int MaPHG,string TenPHG,string LoaiPHG, float Dongia)
        {

            var data = (from p in provider.dbcontext.Phongs
                        where p.MaPHG == MaPHG
                        select p).FirstOrDefault();

            /*Co sự thay đổi tên phòng */
            if (data == null)
            {
                if (!KiemTraTenPhong(TenPHG)) return false;
                data.TenPHG = TenPHG;
                data.LoaiPHG = LoaiPHG;
                data.Dongia = Dongia;
            }    
            else
            {
                data.LoaiPHG = LoaiPHG;
                data.Dongia = Dongia;
            }    
           
            return provider.dbcontext.SaveChanges() != 0;
        }


        public static bool Update_With_tinhtrang(int MaPHG, string TenPHG, string LoaiPHG, float Dongia,int tinhtrang)
        {
            /**/
            var data = (from p in provider.dbcontext.Phongs
                        where p.MaPHG == MaPHG
                        select p).FirstOrDefault();


            /*Kiễm tra tính hợp lệ của tenphong */

            if(data.TenPHG != TenPHG)
            {
                 if (!KiemTraTenPhong(TenPHG)) return false;
            }    
            
            data.TenPHG = TenPHG;
            data.LoaiPHG = LoaiPHG;
            data.TinhTrang = tinhtrang;
            data.Dongia = Dongia;

            return provider.dbcontext.SaveChanges() != 0;

        }


        /* Xóa */
        public static bool Delete(int MaPHG)
        { 


            var data = (from p in provider.dbcontext.Phongs
                       where p.MaPHG == MaPHG
                       select p).FirstOrDefault();
            
            provider.dbcontext.Phongs.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }

        /* Truy vấn lấy phòng từ mã phòng */
        public static Phong Select_By_MaPHG(int MaPHG)
        {
            var result = (from p in provider.dbcontext.Phongs
                         where p.MaPHG == MaPHG
                         select p).FirstOrDefault();

            return result;
        }


        /*HÀM KIỄM TRA TÊN PHÒNG GIỐNG VỚI RÀNG BUỘC TRÊN CSDL (UNIQUE) */
        private static bool KiemTraTenPhong(string TenPHG)
        {
            var data = (from p in provider.dbcontext.Phongs
                        where p.TenPHG.Contains(TenPHG)
                        select p).FirstOrDefault();

            if (data != null || !Regex.IsMatch(TenPHG, "^[0-9]") || TenPHG.Length <= 0 || TenPHG.Length > 3)
            {
                return false;
            }

            return true;
        }
    }
}
