using DTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DAO
{
    public class Provider
    {
        public QLKSDb dbcontext;
        public Provider()
        {
            //Console.OutputEncoding = Encoding.UTF8;
            dbcontext = new QLKSDb();
            CreateDB();
        }

        /* Tao database */
        public void CreateDB()
        {
            bool dbExists = dbcontext.Database.CanConnect();
            if (!dbExists)
            {
                dbcontext.Database.EnsureCreated();
                CreateBaseData();
                Console.WriteLine("Tạo Dữ Liệu Thành Công");
            }   
           
        }
        /* Xoa database */
        public void DropDB()
        {
            dbcontext.Database.EnsureDeleted();
        }

        /* Insert du lieu mau cho database */
        private void CreateBaseData()
        {
            Data_ChucVu();
            Data_TaiKhoan();
            Data_KhachHang();
            Data_LoaiNV();
            Data_NhanVien();
            Data_Tinhtrangphong();
            Data_Loaiphong();
            Data_phong();
            Data_LoaiDV();
            Data_DichVu();
            //Data_Have_FK();
        }
        /* Insert du lieu chucvu */
        public void Data_ChucVu()
        {
            List<ChucVu> chucvu = new List<ChucVu>()
            {
                new ChucVu() {TenCV = "Quản lý"},
                new ChucVu() {TenCV = "Nhân viên"}
            };

            dbcontext.Chucvus.AddRange(chucvu);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu taikhoan */
        public void Data_TaiKhoan()
        {
            List<TaiKhoan> taikhoan = new List<TaiKhoan>()
            {
                new TaiKhoan() {Taikhoan = "admin2k3", Matkhau = "123" , MaCV = 1},
                new TaiKhoan() {Taikhoan = "nv2k3", Matkhau = "123" , MaCV = 2},
            };

            dbcontext.Taikhoans.AddRange(taikhoan);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu khachhang */
        public void Data_KhachHang()
        {
            List<KhachHang> khachhang = new List<KhachHang>()
            {
                new KhachHang(){ TenKH = "Trọng Khang" , CCCD = "012345678911" , SDT = "0123456789" , Diachi = "Chau Thanh" , Gioitinh = "Nam" },
                new KhachHang(){ TenKH = "Bunbo" , CCCD = "012345678922" , SDT = "0123456789" , Diachi = "Chau Thanh" , Gioitinh = "Nam" },
            };

            dbcontext.Khachangs.AddRange(khachhang);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu loainv */
        public void Data_LoaiNV()
        {
            List<LoaiNV> loainv = new List<LoaiNV>()
            {
                new LoaiNV(){TenLoai = "Lễ tân"},
                new LoaiNV(){TenLoai = "Lao công"},
                new LoaiNV(){TenLoai = "CSKH"},
                new LoaiNV(){TenLoai = "Kế toán"},

            };

            dbcontext.LoaiNVs.AddRange(loainv);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu nhanvien */
        public void Data_NhanVien()
        {
            List<NhanVien> nhanvien = new List<NhanVien>()
            {
              new NhanVien(){TenNV = "Nhân viên A" , SDT = "0123456789" , Diachi = "Thành phố Z" , Gioitinh = "Nam" , LoaiNV = 1},
               new NhanVien(){TenNV = "Nhân viên B" , SDT = "0123456788" , Diachi = "Thành phố Z" , Gioitinh = "Nữ" , LoaiNV = 2},
                new NhanVien(){TenNV = "Nhân viên C" , SDT = "0123456777" , Diachi = "Thành phố Z" , Gioitinh = "Nam" , LoaiNV = 3},
                 new NhanVien(){TenNV = "Nhân viên D" , SDT = "0123456666" , Diachi = "Thành phố Z" , Gioitinh = "Nam" , LoaiNV = 4},
            };

            dbcontext.Nhanviens.AddRange(nhanvien);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu tinhtrangphong */
        public void Data_Tinhtrangphong()
        {
            List<TinhTrangPHG> tinhtrangphong = new List<TinhTrangPHG>()
            {
                new TinhTrangPHG(){TenTinhTrg = "Phòng trống"},
                new TinhTrangPHG(){TenTinhTrg = "Có khách"},
                new TinhTrangPHG(){TenTinhTrg = "Được đặt"},
            };

            dbcontext.TinhTrangPHGs.AddRange(tinhtrangphong);

            dbcontext.SaveChanges();

        }
        /* Insert du lieu loaiphong */
        public void Data_Loaiphong()
        {
            List<LoaiPHG> loaiphong = new List<LoaiPHG>()
            {
                new LoaiPHG(){MaloaiPHG = "PT",TenloaiPHG = "Phòng thường" , SoNguoiToiDa = 5},
                new LoaiPHG(){MaloaiPHG = "PĐ",TenloaiPHG = "Phòng đôi" , SoNguoiToiDa = 2},
                new LoaiPHG(){MaloaiPHG = "PV",TenloaiPHG = "Phòng VIP" , SoNguoiToiDa = 3},
                new LoaiPHG(){MaloaiPHG = "PTT",TenloaiPHG = "Phòng tổng thống" , SoNguoiToiDa = 1},
            };

            dbcontext.LoaiPHGs.AddRange(loaiphong);

            dbcontext.SaveChanges();

        }
        /* Insert du lieu phong */
        public void Data_phong()
        {
            List<Phong> phong = new List<Phong>()
            {
                new Phong(){TenPHG = "A201", LoaiPHG = "PT" , Dongia = 400000, TinhTrang = 1 },
                new Phong(){TenPHG = "A202", LoaiPHG = "PT" , Dongia = 400000, TinhTrang = 1 },
                new Phong(){TenPHG = "A203", LoaiPHG = "PĐ" , Dongia = 800000, TinhTrang = 1 },
                new Phong(){TenPHG = "A204", LoaiPHG = "PV" , Dongia = 1200000, TinhTrang = 1 },

                new Phong(){TenPHG = "A301", LoaiPHG = "PT" , Dongia = 400000, TinhTrang = 1 },
                new Phong(){TenPHG = "A302", LoaiPHG = "PT" , Dongia = 400000, TinhTrang = 1 },
                new Phong(){TenPHG = "A303", LoaiPHG = "PĐ" , Dongia = 800000, TinhTrang = 1 },
                new Phong(){TenPHG = "A304", LoaiPHG = "PV" , Dongia = 1200000, TinhTrang = 1 },

                new Phong(){TenPHG = "A401", LoaiPHG = "PV" , Dongia = 1200000, TinhTrang = 1 },
                new Phong(){TenPHG = "A402", LoaiPHG = "PV" , Dongia = 1200000, TinhTrang = 1 },
                new Phong(){TenPHG = "A403", LoaiPHG = "PV" , Dongia = 1200000, TinhTrang = 1 },
                new Phong(){TenPHG = "A404", LoaiPHG = "PTT" , Dongia = 10000000, TinhTrang = 1 },

            };

            dbcontext.Phongs.AddRange(phong);

            dbcontext.SaveChanges();

        }
        /* Insert du lieu loaidv */
        public void Data_LoaiDV()
        {
            List<LoaiDV> loaidv = new List<LoaiDV>()
            {
              new LoaiDV(){TenLoaiDV = "Đồ ăn"},
              new LoaiDV(){TenLoaiDV = "Đồ uống"},
              new LoaiDV(){TenLoaiDV = "Khác"},
            };

            dbcontext.LoaiDVs.AddRange(loaidv);

            dbcontext.SaveChanges();
        }

        /* Insert du lieu dichvu */
        public void Data_DichVu()
        {
            List<DichVu> dichvu = new List<DichVu>()
            {
              new DichVu(){TenDV = "Bia Tiger bạc" , LoaiDV = 2 , Dongia = 30000},
              new DichVu(){TenDV = "Bia He-ni-ken" , LoaiDV = 2 , Dongia = 30000},
              new DichVu(){TenDV = "Bia 'Hơi'" , LoaiDV = 3 , Dongia = 1200000},
              new DichVu(){TenDV = "Bò húc" , LoaiDV = 2 , Dongia = 30000},
              new DichVu(){TenDV = "Cola - Pepsi" , LoaiDV = 2 , Dongia = 30000},
              new DichVu(){TenDV = "Snack" , LoaiDV = 1 , Dongia = 30000},
              new DichVu(){TenDV = "Bim bim" , LoaiDV = 1 , Dongia = 30000},
              new DichVu(){TenDV = "Dịch vụ đặc biệt #Thường" , LoaiDV = 3 , Dongia = 2000000},
              new DichVu(){TenDV = "Dịch vụ đặc biệt #Vua" , LoaiDV = 3 , Dongia = 5000000},
              new DichVu(){TenDV = "Dịch vụ đặc biệt #VIP" , LoaiDV = 3 , Dongia = 10000000},
            };

            dbcontext.Dichvus.AddRange(dichvu);

            dbcontext.SaveChanges();
        }
        /* Insert du lieu cho cac bang con lai */
        public void Data_Have_FK()
        {
            /* Insert du lieu phieudatphong */

            List<PhieuDatPhong> phieudatphong = new List<PhieuDatPhong>()
            {
                new PhieuDatPhong(){MaKH = 1}
            };

            dbcontext.Phieudatphongs.AddRange(phieudatphong);

            dbcontext.SaveChanges();

            /* Insert du lieu chitietphieudatphong */

            List<ChiTietPhieuDatPhong> chitietphieudatphong = new List<ChiTietPhieuDatPhong>()
            {
                new ChiTietPhieuDatPhong(){MaDatPHG = 1, MaPHG = 1 , NgayDat = DateTime.Now , NgayNhan = DateTime.Now }
            };

            dbcontext.Chitietphieudatphongs.AddRange(chitietphieudatphong);

            dbcontext.SaveChanges();

            /* Insert du lieu phieunhanphong*/

            List<PhieuNhanPhong> phieunhanphong = new List<PhieuNhanPhong>()
            {
               new PhieuNhanPhong(){MaDatPHG = 1,MaKH = 1}
            };

            dbcontext.Phieunhanphongs.AddRange(phieunhanphong);

            dbcontext.SaveChanges();

            /*      var result = from p in dbcontext.Phieunhanphongs
                               select p;

                  result.ToList().ForEach(x => { x.Print();});*/

            /* Insert du lieu chitietphieunhanphong */

            List<ChiTietPhieuNhanPhong> chitietphieunhanphong = new List<ChiTietPhieuNhanPhong>()
            {
               new ChiTietPhieuNhanPhong() {MaNhanPHG = 1 , MaDatPHG = 1, MaKH = 1 , NgayNhan = DateTime.Now, NgayTraDuKien = DateTime.Now , NgayTraThucTe = DateTime.Now},
            };

            dbcontext.Chitietphieunhanphongs.AddRange(chitietphieunhanphong);

            dbcontext.SaveChanges();

            /*      var result = from p in dbcontext.Chitietphieunhanphongs
                               select p;

                  result.ToList().ForEach(x => { x.Print(); });*/


            /* Insert du lieu sudungdichvu */

            List<SuDungDV> sudungdichvu = new List<SuDungDV>(){
                new SuDungDV() {MaDV = 1 , MaNhanPHG = 1, Soluong = 10 } ,
                new SuDungDV() {MaDV = 2 , MaNhanPHG = 1, Soluong = 10 } ,
                new SuDungDV() {MaDV = 3 , MaNhanPHG = 1, Soluong = 10 } ,
            };

            dbcontext.SudungDVs.AddRange(sudungdichvu);

            dbcontext.SaveChanges();

            /*  var result = from p in dbcontext.SudungDVs
                           select p;

              result.ToList().ForEach(x => { x.Print(); });*/


            /* Insert du lieu cho hoadon */

            float tongtien = DAO_SuDungDichVu.GetTongTien_By_MaNhanPHG(1);

            List<HoaDon> hoadon = new List<HoaDon>(){
               new HoaDon(){MaNV = 1,MaKH = 1,MaNhanPHG = 1 ,TongTien = tongtien , NgayLap = DateTime.Now}
            };

            dbcontext.Hoadons.AddRange(hoadon);

            dbcontext.SaveChanges();

 /*           var result = from p in dbcontext.Hoadons
                         select p;

            result.ToList().ForEach(x => { x.Print(); });*/


            /* Insert du lieu cho chitiethoadon */

            //lay tien phong
            var phong = DAO_Phong.Select_By_MaPHG(1);

            //lay tiền dich vụ của loại dịch vụ đó
            var hoadonn = (from p in dbcontext.Hoadons
                           where p.MaHD == 1
                           select p).FirstOrDefault();

            //lay so ngay
            var songay = (from p in dbcontext.Hoadons
                          where p.MaNhanPHG == 1
                          join q in dbcontext.Chitietphieunhanphongs
                          on p.MaNhanPHG equals q.MaNhanPHG
                          select new { ngaynhan = q.NgayNhan, ngaytra = q.NgayTraThucTe }).FirstOrDefault();

            int ngay = (int)(songay.ngaytra - songay.ngaynhan).TotalDays;

            List<ChiTietHoaDon> chitiethoadon = new List<ChiTietHoaDon>(){
               new ChiTietHoaDon(){MaHD = 1, MaPHG = 1, MaSuDungDV = 1,PhuThu = 0 , TienPHG = phong.Dongia,TienDV = hoadonn.TongTien , SoNgay = ngay,ThanhTien = 0},
               new ChiTietHoaDon(){MaHD = 1, MaPHG = 1, MaSuDungDV = 2,PhuThu = 0 , TienPHG = phong.Dongia,TienDV = hoadonn.TongTien , SoNgay = ngay,ThanhTien = 0},
               new ChiTietHoaDon(){MaHD = 1, MaPHG = 1, MaSuDungDV = 3,PhuThu = 0 , TienPHG = phong.Dongia,TienDV = hoadonn.TongTien , SoNgay = ngay,ThanhTien = 0},            
            };

            dbcontext.Chitiethoadons.AddRange(chitiethoadon);

            dbcontext.SaveChanges();



          /*  var result2 = from p in dbcontext.Chitiethoadons
                         select p;
            
                        var result = (from p in dbcontext.Chitiethoadons
                                      select p).FirstOrDefault();

                        result.TinhThanhTien();

                        result.Print();*/


        }

    }
}