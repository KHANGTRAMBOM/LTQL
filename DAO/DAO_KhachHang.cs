using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_KhachHang
    {
        private static Provider provider = new Provider();

        /* Select * */
        public static List<DTO.KhachHang> Select_All()
        {
            return (from p in provider.dbcontext.Khachangs
                    select p).ToList();
        }


        /* Select theo tên khách hàng */
        public static List<DTO.KhachHang> Select_By_Name(string HoTen)
        {
            return (from p in provider.dbcontext.Khachangs
                    where p.TenKH.Contains(HoTen)
                    select p).ToList();
        }


        /* Select theo mã khách hàng có thể sử dụng đê tìm kiếm  */
        public static DTO.KhachHang Select_By_ID(int ID)
        {
            return (from p in provider.dbcontext.Khachangs
                    where p.MaKH == ID
                    select p).FirstOrDefault();
        }

        /* thêm */  
        public static bool Insert(string TenKH,string CCCD,string SDT,string Diachi,string Gioitinh)
        {
             /*Kiễm tra CCCD có trùng không*/
            if (!KiemTraCCCD(CCCD)) return false;

            KhachHang kh;

            kh = new KhachHang() { TenKH = TenKH, CCCD = CCCD, SDT = SDT, Diachi = Diachi, Gioitinh = Gioitinh};

            provider.dbcontext.Khachangs.Add(kh);

            return provider.dbcontext.SaveChanges() != 0;
        }


        /*Hàm kiễm tra CCCD có trùng không [CHECK(CCCD NOT LIKE '%[^0-9]%' AND LEN(CCCD) = 12) UNIQUE NOT NULL]*/
        private static bool KiemTraCCCD(string CCCD)
        {
            return (from p in provider.dbcontext.Khachangs
                    where p.CCCD == CCCD
                    select p).FirstOrDefault() == null && CCCD.Length == 12;
        }



        /* xóa */
        public static bool Delete(int ID)
        {
            var data = Select_By_ID(ID);
            provider.dbcontext.Khachangs.Remove(data);
            return provider.dbcontext.SaveChanges() != 0;
        }

        /* xóa */
        public static bool Delete_By_CCCD(string CCCD)
        {
            var data = Select_By_CCCD(CCCD);
            provider.dbcontext.Khachangs.Remove(data);
            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Select theo CCCD có thể sử dụng đê tìm kiếm  */
        public static DTO.KhachHang Select_By_CCCD(string CCCD)
        {
            return (from p in provider.dbcontext.Khachangs
                    where p.CCCD == CCCD
                    select p).FirstOrDefault();
        }


        /* Tìm khách hàng nếu không có thì tạo ra luôn */
        public static DTO.KhachHang TimKhachHang_OrCreate(string TenKH, string CCCD, string SDT, string Diachi, string Gioitinh)
        {
            var data = Select_By_CCCD(CCCD);
            if (data == null)
            {
                Insert(TenKH, CCCD, SDT, Diachi, Gioitinh);
                return Select_By_CCCD(CCCD);
            }

            return data;
        }
    }
}
