using DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_HoaDon
    {
        static Provider provider = new Provider();
        public static List<HoaDon> Select_All()
        {
            var data = from p in provider.dbcontext.Hoadons
                       select p;

            return data.ToList();
        }

        /* Lấy dữ liệu để hiện thị theo datagridview */
        public static object Select_Display()
        {
            var data = (from p in provider.dbcontext.Hoadons
                        join q in provider.dbcontext.Chitiethoadons on p.MaHD equals q.MaHD
                        join kh in provider.dbcontext.Khachangs on p.MaKH equals kh.MaKH
                        select new
                        {
                            MaHD = p.MaHD,
                            TenKH = kh.TenKH,
                            MaPHG = q.MaPHG,
                            TienPHG = q.TienPHG,
                            TienDV = q.TienDV,
                            Songay = q.SoNgay,
                            Thanhtien = p.TongTien
                        })
            .AsEnumerable().Distinct()
            .ToList()
            .Where(p => KiemTraHoaDonDaThanhToan(p.MaHD));
  

            return data.ToList();

        }

        /* HÀM SELECT THEO MÃ HÓA ĐƠN*/
        public static HoaDon Select_By_MaHD(int MaHD)
        {
            var data = (from p in provider.dbcontext.Hoadons
                        where p.MaHD == MaHD
                        select p).FirstOrDefault();

            return data;
        }

        /* HÀM THÊM MỘT HOADDON */
        public static bool Insert(int MaNV, int MaKH, int MaNhanPHG, DateTime NgayLap)
        {
            HoaDon hd = new HoaDon() { MaNV = MaNV, MaKH = MaKH, MaNhanPHG = MaNhanPHG, NgayLap = NgayLap};
            provider.dbcontext.Hoadons.Add(hd);
            return provider.dbcontext.SaveChanges() != 0;
        }

        /* TÌM HOADON THEO MÃ NHẬN PHÒNG */
        public static HoaDon Select_By_MaNhanPHG(int MaNhanPHG)
        {
            var data = (from p in provider.dbcontext.Hoadons
                        where p.MaNhanPHG == MaNhanPHG
                        select p).FirstOrDefault();
            return data;
        }


        /* Lấy số ngày ở của hóa đơn  */
        public static int GetSoNgay(int MaHD)
        {
            var songay = (from p in provider.dbcontext.Hoadons
                          where p.MaHD == MaHD
                          join q in provider.dbcontext.Chitietphieunhanphongs
                          on p.MaNhanPHG equals q.MaNhanPHG
                          select new { ngaynhan = q.NgayNhan, ngaytra = q.NgayTraThucTe }).FirstOrDefault();

            int ngay;
            
            if (songay.ngaytra == DateTime.MinValue)/* Khach hang chua thanh toan hoa don */
            {
                ngay = (int)(DateTime.Now - songay.ngaynhan).TotalDays;
            }
            else/* Khach hang chua đã thanh toán hoa don */
            {
                ngay = (int)(songay.ngaytra - songay.ngaynhan).TotalDays;
            }    
            
            return ngay == 0 ? 1 : ngay;
        }


        /* Cập nhật lại tổng tiền của hóa đơn */
        public static bool Update_TongTien(int maNhanPHG,int MaPHG ,float tiendv)
        {
           
            var hoadon = DAO_HoaDon.Select_By_MaNhanPHG(maNhanPHG);
            int songay = GetSoNgay(hoadon.MaHD);
            var phong = DAO_Phong.Select_By_MaPHG(MaPHG);

            /* tổng tiền = tiền dv + số ngày * giá phòng */
            hoadon.TongTien = tiendv + (songay * phong.Dongia);

            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Láy tổng tiền của hóa đơn [ chưa bao gồm phụ thu ] */
        public static float GetTongTienChuaPhuThu(int maNhanPHG, int MaPHG, float tiendv)
        {

            var hoadon = DAO_HoaDon.Select_By_MaNhanPHG(maNhanPHG);
            int songay = GetSoNgay(hoadon.MaHD);
            var phong = DAO_Phong.Select_By_MaPHG(MaPHG);

            /* tổng tiền = tiền dv + số ngày * giá phòng */
            
            return tiendv + (songay * phong.Dongia);
        }

        /* Kiễm tra hóa đơn đã thanh toán chưa [ ngày trả thực tế != null ]*/
        public static bool KiemTraHoaDonDaThanhToan(int MaHD)
        {
            /* Lấy đại diện từ danh sách chi tiết hóa đơn */
            var data = (from p in provider.dbcontext.Hoadons
                        where p.MaHD == MaHD
                        join q in provider.dbcontext.Chitietphieunhanphongs
                        on p.MaNhanPHG equals q.MaNhanPHG
                        select q.NgayTraThucTe).FirstOrDefault();

            return  data != DateTime.MinValue;
        }

        /*Danh sách hóa đơn đã thanh toán*/
        public static object DanhSachHoaDonDaThanhToan()
        {
            /* Lấy ma hoa don da thanh toan */
            var data = (from p in provider.dbcontext.Hoadons
                        join q in provider.dbcontext.Chitiethoadons on p.MaHD equals q.MaHD
                        group new { p, q } by new { p.MaHD, p.MaKH, q.MaPHG } into danhsachhoadon
                        select new
                        {
                            MaHD = danhsachhoadon.Key.MaHD,
                            MaKH = danhsachhoadon.Key.MaKH,
                            MaPHG = danhsachhoadon.Key.MaPHG,
                            TienPHG = danhsachhoadon.Max(x => x.q.TienPHG),
                            TienDV = danhsachhoadon.Sum(x => x.q.TienDV),
                            Songay = danhsachhoadon.Max(x => x.q.SoNgay),
                            Thanhtien = danhsachhoadon.Select(x => x.p.TongTien).FirstOrDefault()
                        }) ;

         
            var data2 = (from kh in provider.dbcontext.Khachangs
                         join q in data
                         on kh.MaKH equals q.MaKH
                         orderby q.MaHD ascending
                         select new
                         {
                             MaHD = q.MaHD,
                             TenKH = kh.TenKH,
                             MaPHG = q.MaPHG,
                             TienPHG = q.TienPHG,
                             TienDV = q.TienDV,
                             Songay = q.Songay,
                             Thanhtien = q.Thanhtien
                         })
                        .ToList()
                        .Where(p => KiemTraHoaDonDaThanhToan(p.MaHD));
             
            return data2.ToList();
        }

        public static float GetDoanhSo()
        {
            var data = (from p in provider.dbcontext.Hoadons
                        join q in provider.dbcontext.Chitiethoadons on p.MaHD equals q.MaHD
                        join kh in provider.dbcontext.Khachangs on p.MaKH equals kh.MaKH
                        select new
                        {
                            MaHD = p.MaHD,
                            Tongtien = p.TongTien
                        })
            .AsEnumerable().Distinct()
            .ToList()
            .Where(p => KiemTraHoaDonDaThanhToan(p.MaHD))
            .ToList(); 


            float doanhso = 0;

            data.ForEach(p => doanhso+= p.Tongtien);

            return doanhso;
        }

    }
}
