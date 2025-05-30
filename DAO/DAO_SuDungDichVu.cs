using DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_SuDungDichVu
    {
        static Provider provider = new Provider();
        public static List<SuDungDV> Select_All()
        {
            var data = from p in provider.dbcontext.SudungDVs
                       select p;

            return data.ToList();
        }

        /*Select danh sach theo mã*/

        public static List<SuDungDV> Select_By_MaSDDV(int MaSDDV)
        {
            var data = from p in provider.dbcontext.SudungDVs
                       where p.MaSuDungDV == MaSDDV
                       select p;

            return data.ToList();
        }


        /*Select hiển thị chuẩn */

        public static object Select_Display(int MaSDDV)
        {
            var data = from p in DAO_SuDungDichVu.Select_All()
                       where p.MaSuDungDV == MaSDDV
                       join q in DAO_dichvu.Select_All()
                       on p.MaDV equals q.MaDV
                       select new
                       {
                           Dienta = q.TenDV,
                           Dongia = q.Dongia,
                           Soluong = p.Soluong,
                           Thanhtien = q.Dongia * p.Soluong,
                       };

            return data.ToList();
        }

        /*Select hiển thị chuẩn */
        public static object Select_Display_MaNhanPHG(int MaNhanPHG)
        {
            var data = from p in DAO_SuDungDichVu.Select_All()
                       where p.MaNhanPHG == MaNhanPHG
                       join q in DAO_dichvu.Select_All()
                       on p.MaDV equals q.MaDV
                       select new
                       {
                           MaDV = q.MaDV,
                           Dienta = q.TenDV,
                           Dongia = q.Dongia,
                           Soluong = p.Soluong,
                           Thanhtien = q.Dongia * p.Soluong,
                       };

            return data.ToList();
        }

        /*Select danh sach theo Madv và manhanphg*/

        public static SuDungDV Select_By_MaDV_MaNhanPHG(int MaDV, int MaNhanPHG)
        {
            var data = (from p in provider.dbcontext.SudungDVs
                        where p.MaDV == MaDV && p.MaNhanPHG == MaNhanPHG
                        select p).FirstOrDefault();
            return data;
        }


        /* Them SDDV*/
        public static bool Insert(int Madv, int Manhanphg, int soluong)
        {
            SuDungDV sd = new SuDungDV() { MaDV = Madv, MaNhanPHG = Manhanphg, Soluong = soluong };
            provider.dbcontext.SudungDVs.Add(sd);
            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Cap nhat so luong */
        public static bool Update_SoLuong(int Masddv,int MaNhanPHG,int soluong)
        {
            SuDungDV sd = (from p in provider.dbcontext.SudungDVs
                                      where p.MaSuDungDV == Masddv
                                      select p).FirstOrDefault();
      



            var data = DAO_SuDungDichVu.Select_By_MaNhanPHG(MaNhanPHG);


            sd.Soluong += soluong;

  
            /* Nếu số lượng bằng 0 thì xóa nó luôn */

            if (sd.Soluong == 0)
            {


                /* Lấy hóa đơn mà chi tiết của nó có mã sddv này */
                HoaDon hd = DAO_HoaDon.Select_By_MaNhanPHG(MaNhanPHG);

   
                /* Giả sử chưa có khách chưa lấy phòng thì xóa trược tiếp*/
                if (hd == null) provider.dbcontext.SudungDVs.Remove(sd);

                /* Giả sử khách lấy phòng rồi thì phải xóa  chi tiết hóa đơn trước */
                else if (hd != null)
                {

                    /* Lấy chi tiết hóa đơn lấy và mã phòng của nó */
                    ChiTietHoaDon cthd = DAO_ChiTietHoaDon.Select_By_MaHD(hd.MaHD);
   
                    /* Lấy phòng */
                    Phong phong = DAO_Phong.Select_By_MaPHG((int)cthd.MaPHG);

                    /* Tiến hành xóa chi tiết hóa đơn*/

                    bool a = DAO_ChiTietHoaDon.Delete(hd.MaHD, Masddv);

                    /* Tiến hành xóa sử dụng dịch vụ */
                    bool b = DAO_SuDungDichVu.Delete(Masddv);

                    /* Cập nhật lại tổng tiền của hóa đơn đó */
                    float tiendv = DAO_SuDungDichVu.GetTongTien_By_MaNhanPHG_SauPhuThu(hd.MaNhanPHG);

                    DAO_HoaDon.Update_TongTien(hd.MaNhanPHG, phong.MaPHG, tiendv);
                              
                }             
            }
                
            return provider.dbcontext.SaveChanges() != 0;
        }

        /* Lấy DS SDDV THEO MÃ NHẬN PHÒNG */
        public static List<SuDungDV> Select_By_MaNhanPHG(int maNhanPHG)
        {
            var data = (from p in provider.dbcontext.SudungDVs
                        where p.MaNhanPHG == maNhanPHG
                        select p);

            return data.ToList();
        }

        /* Lấy tổng tiền dịch vụ của một phòng trước phụ thu */
        public static float GetTongTien_By_MaNhanPHG(int MaNhanPHG)
        {
            float tongtien = 0;

            var result1 = (from p in provider.dbcontext.SudungDVs
                            where p.MaNhanPHG == MaNhanPHG
                           join q in provider.dbcontext.Dichvus 
                           on p.MaDV equals q.MaDV
                           select new { Thanhtien = q.Dongia * p.Soluong }).ToList();


            result1.ForEach(x => tongtien += x.Thanhtien);


            return tongtien;
        }


        /* Lấy tổng tiền dịch vụ của một loại dịch vụ */
        public static float GetTongTien_By_MaSDDV(int MaSDDV)
        {
            float tongtien = 0;

            var result1 = (from p in provider.dbcontext.SudungDVs
                           where p.MaSuDungDV == MaSDDV
                           join q in provider.dbcontext.Dichvus 
                           on p.MaDV equals q.MaDV
                           select new { Thanhtien = q.Dongia * p.Soluong }).ToList();

            result1.ForEach(x => tongtien += x.Thanhtien);
        
            return tongtien;
        }


        /* Lấy tổng tiền dịch vụ của một phòng có cả phụ thu*/
        public static float GetTongTien_By_MaNhanPHG_SauPhuThu(int MaNhanPHG)
        {
       
            /* Lấy danh sách sử dụng dịch vụ của phòng này */
            var list_sddv = DAO_SuDungDichVu.Select_By_MaNhanPHG(MaNhanPHG);

            /* Lấy hóa đơn tương ứng với mã nhận phòng */
            var hoadon = DAO_HoaDon.Select_By_MaNhanPHG(MaNhanPHG);

            float tongtien = 0;

            var list_cthd = DAO_ChiTietHoaDon.Select_All_By_MaHD(MaNhanPHG);

            /* Duyệt từng CTHD */

            list_cthd.ForEach(x => tongtien += x.ThanhTien); 
/*
            list_sddv.ForEach(sd =>
            {
                ChiTietHoaDon cthd = DAO_ChiTietHoaDon.Select_By_MaHD_MaSDDV(hoadon.MaHD, sd.MaSuDungDV);
                tongtien += cthd.ThanhTien;   
            });*/

            return tongtien;
        }

        /* Lấy sử dụng dv mới nhất được thêm vô của phòng */
        public static SuDungDV Select_By_MaNhanPHG_Last_Element(int MaNhanPHG)
        {
            var data_list = DAO_SuDungDichVu.Select_By_MaNhanPHG(MaNhanPHG);

            return data_list[data_list.Count - 1];
        }

        /* Xóa sử dụng dịch vụ*/
        public static bool Delete(int MaSDDV)
        {
            var data = (from p in provider.dbcontext.SudungDVs
                       where p.MaSuDungDV == MaSDDV
                       select p).FirstOrDefault();

            provider.dbcontext.SudungDVs.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }
    }
}
