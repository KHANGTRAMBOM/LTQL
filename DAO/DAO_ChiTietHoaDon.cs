using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_ChiTietHoaDon
    {
        static Provider provider = new Provider();

        /* SELECT * */
        public static List<ChiTietHoaDon> Select_All()
        {
            var data = from p in provider.dbcontext.Chitiethoadons
                       select p;

            return data.ToList();

        }


        /* Truy vấn lấy nhân viên lập hóa đơn */
        public static NhanVien GetNhanVien(int MaHD)
        {
            var reuslt = DAO_HoaDon.Select_By_MaHD(MaHD);

            return DAO_NhanVien.Select_By_MaNV((int)reuslt.MaNV);

        }


        /* Truy vấn lấy  ChiTietPhieuNhanPhong */
        public static ChiTietPhieuNhanPhong GetChiTietPhieuNhanPhong(int MaNhanPHG)
        {
            var result = DAO_ChiTietPhieuNhanPhong.Select_By_MaNhanPhong(MaNhanPHG);
            return result;
        }



        /* Truy vấn lấy  ChiTietPhieuDatPhong  */
        public static ChiTietPhieuDatPhong GetChiTietPhieuDatPhong(int MaDatPHG)
        {
           var result = DAO_ChiTietPhieuDatPhong.Select_By_MaDatPHG(MaDatPHG);
           return result;
        }


        /* Truy vấn lấy  DanhSachSuDungDichVu */
        public static List<SuDungDV> GetDanhSachSuDungDichVu(int MaSDDV)
        {
            var result = DAO_SuDungDichVu.Select_By_MaSDDV(MaSDDV);

            return result;
        }

        /* Truy vấn lấy ra Chitiethoadon theo mã hóa đơn*/
        public static ChiTietHoaDon Select_By_MaHD(int MaHD)
        {
            var result = (from p in provider.dbcontext.Chitiethoadons
                         where p.MaHD == MaHD
                         select p).FirstOrDefault();

            return result;
        }


        /* Truy vấn lấy ra Chitiethoadon theo mã hóa đơn và mã sddv*/
        public static ChiTietHoaDon Select_By_MaHD_MaSDDV(int MaHD,int MaSDDV)
        {
            var result = (from p in provider.dbcontext.Chitiethoadons
                          where p.MaHD == MaHD && p.MaSuDungDV == MaSDDV
                          select p).FirstOrDefault();

            return result;
        }

        /* Tìm kiếm theo tên*/
        public static object TimKiemTheoTen(string TenKH)
        {
            var source = from p in DAO_ChiTietHoaDon.Select_All()
                         join q in DAO_SuDungDichVu.Select_All()
                         on p.MaSuDungDV equals q.MaSuDungDV
                         join e in DAO_PhieuNhanPhong.Select_All()
                         on q.MaNhanPHG equals e.MaNhanPHG
                         join v in DAO_KhachHang.Select_All()
                         on e.MaKH equals v.MaKH
                         where v.TenKH.ToLower().Contains(TenKH.ToLower())
                         select new
                         {
                             MaHD = p.MaHD,
                             TenKH = v.TenKH,
                             MaPHG = p.MaPHG,
                             PhuThu = p.PhuThu,
                             TienPHG = p.TienPHG,
                             TienDV = p.TienDV,
                             SoNgay = p.SoNgay,
                             ThanhTien = p.TienPHG * p.SoNgay + p.TienDV + p.PhuThu
                         };

            return source.ToList();
        }

        /* Thêm dữ liệu vào chi tiết hóa đơn */

        public static bool Insert(int MaHD,int MaPHG,int MaSDDV,float TienPHG,float TienDV,int SoNgay)
        {

            ChiTietHoaDon cthd = new ChiTietHoaDon() { MaHD = MaHD, MaPHG = MaPHG,MaSuDungDV = MaSDDV,TienPHG = TienPHG, TienDV = TienDV, SoNgay = SoNgay};
            cthd.TinhThanhTien();
            cthd.TinhPhuThu();

            provider.dbcontext.Chitiethoadons.Add(cthd);

            return provider.dbcontext.SaveChanges() != 0;
        }

        /* Cập nhật lại dữ liệu khi có người dùng sử dụng dịch vụ */

        public static bool Update_TienDV(int MaHD, int MaSDDV)
        {
            ChiTietHoaDon cthd = Select_By_MaHD_MaSDDV(MaHD,MaSDDV);

            float tiendv = DAO_SuDungDichVu.GetTongTien_By_MaSDDV(MaSDDV);

            cthd.TienDV = tiendv;

            cthd.TinhThanhTien();

            cthd.TinhPhuThu();

            return provider.dbcontext.SaveChanges() != 0;
        }

        /* Xóa */

        public static bool Delete(int MaHD, int MaSDDV)
        {
             var data = (from p in provider.dbcontext.Chitiethoadons
                        where p.MaHD == MaHD && p.MaSuDungDV == MaSDDV
                        select p).FirstOrDefault();

            provider.dbcontext.Chitiethoadons.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }

        /*Lấy danh sách chi tiết hóa đơn của hóa đơn này*/
        public static List<ChiTietHoaDon> Select_All_By_MaHD(int maHD)
        {
            var result = (from p in provider.dbcontext.Chitiethoadons
                          where p.MaHD == maHD
                          select p).ToList();
            return result;
        }
    }
}
