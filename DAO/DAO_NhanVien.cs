using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_NhanVien
    {
        private static Provider provider = new Provider();
        
        /* Select* */

        public static List<NhanVien> Select_All()
        {
            var data = from p in provider.dbcontext.Nhanviens
                       select p;

            return data.ToList();
        }

        /* Chọn những lễ tân trong ds nhân viên */
        public static List<NhanVien> Select_LeTan()
        {
            var maletan = (from p in provider.dbcontext.LoaiNVs
                           where p.TenLoai.Contains("Lễ tân")
                           select p.MaLoai).FirstOrDefault();

            var data = from p in provider.dbcontext.Nhanviens
                       where p.LoaiNV == maletan
                       select p;

            return data.ToList();
        }

        /* Xóa */
        public static bool Delete(int MaNV)
        {
            /* Lấy 1 NhanVien ra theo MaNV */
            var data = (from p in provider.dbcontext.Nhanviens
                        where p.Manv == MaNV
                        select p).FirstOrDefault();

            provider.dbcontext.Nhanviens.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }


        /*Thêm*/
        public static bool Insert(string TenNV,string SDT,string Diachi,string Gioitinh,int LoaiNV)
        {

            /*Kiễm tra tính hợp lệ của SDT */
            if (!KiemTraSDT(SDT)) return false;

            /*Kiễm tra tính hợp lệ của TenNV */
            if (!KiemTraTenNV(TenNV)) return false;

            NhanVien nhanvien = new NhanVien() { TenNV = TenNV , SDT = SDT ,Diachi = Diachi , Gioitinh = Gioitinh , LoaiNV = LoaiNV };
            provider.dbcontext.Nhanviens.Add(nhanvien);

            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Cập nhật dữ liệu */
        public static bool Update(int MaNV, string TenNV, string SDT, string Diachi, string Gioitinh, int LoaiNV)
        {

            /* Lấy 1 NhanVien ra theo MaNV */
            var data = (from p in provider.dbcontext.Nhanviens
                        where p.Manv == MaNV
                        select p).FirstOrDefault();
            
            /* Có sự thay đổi sdt */
            if(data == null)
            {
                /*Kiễm tra tính hợp lệ của SDT */
                if (!KiemTraSDT(SDT)) return false;
            }    
           
         
                /*Kiễm tra tính hợp lệ của TenNV */
             if (!KiemTraTenNV(TenNV)) return false;


            data.TenNV = TenNV;
            data.SDT = SDT;
            data.Diachi = Diachi;
            data.Gioitinh = Gioitinh;
            data.LoaiNV = LoaiNV;

            return provider.dbcontext.SaveChanges() != 0;
        }

        /* HÀM SELECT THEO MÃ NHÂN VIÊN */
        public static NhanVien Select_By_MaNV(int MaNV)
        {
            var result = (from p in provider.dbcontext.Nhanviens
                          where p.Manv == MaNV
                          select p).FirstOrDefault();

            return result;
        }


        /* HÀM TÌM NHÂN VIÊN THEO TÊN */
        public static List<NhanVien> TimNhanVien(string TenNV)
        {
            var data = from p in provider.dbcontext.Nhanviens
                       where p.TenNV.ToLower().Contains(TenNV.ToLower())
                       select p;

            return data.ToList();
        }


        /*HÀM KIỄM TRA SDT GIỐNG VỚI RÀNG BUỘC TRÊN CSDL [CHECK(SDT NOT LIKE '%[^0-9]%' AND LEN(SDT) = 10) UNIQUE] */
        private static bool KiemTraSDT(string SDT)
        {
            
            var data = (from p in provider.dbcontext.Nhanviens
                        where p.SDT == SDT
                        select p).FirstOrDefault();

            if(data != null || !Regex.IsMatch(SDT, @"^[0-9]+$") || SDT.Length <= 0 || SDT.Length > 10)
            {
                return false;
            }

            return true;
        }


        /*HÀM KIỄM TRA TÊN NHÂN VIÊN GIỐNG VỚI RÀNG BUỘC TRÊN CSDL [CHECK(TENNV NOT LIKE '%[^A-Za-z ]%')] */
        private static bool KiemTraTenNV(string TenNV)
        {
           
            if (!Regex.IsMatch(TenNV, "^[A-Za-zÁ-ỹ ]") || TenNV.Length <= 0)
            {
                
                return false;
            }
            return true;
        }
    }
}
