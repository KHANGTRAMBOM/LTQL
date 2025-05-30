using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DTO
{
    public class QLKSDb : DbContext
    {
        private ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);
            builder.AddConsole();
        });

        private string ConnectionString = @"Data Source=KHANG-TRAMBOM\SQL;Initial Catalog=data02;Integrated Security=True";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            base.OnConfiguring(optionsBuilder);
           // optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            
            /*SET UP CHO CHỨC VỤ VÀ TÀI KHOẢN*/
            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(a => a.MaCV);
                entity.Property(a => a.TenCV).IsRequired();

                entity.
                HasCheckConstraint("TenCV", "TenCV NOT LIKE '%[^A-Za-z0-9 ]%'");



            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.Property(b => b.Taikhoan).IsRequired();
                entity.HasIndex(b => b.Taikhoan).IsUnique();
                entity.Property(b => b.Matkhau).IsRequired();

                entity.HasCheckConstraint("Taikhoan", "(LEN(Taikhoan) >= 0)");
                entity.HasCheckConstraint("Matkhau", "(LEN(Matkhau) >= 0)");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.HasOne(tk => tk.FK_MaCV)
                .WithMany(p => p.List_TaiKhoan)
                .HasForeignKey(p => p.MaCV)
                .OnDelete(DeleteBehavior.SetNull);
            });
            /*SET UP CHO CHỨC VỤ VÀ TÀI KHOẢN*/


            /*Set Up cho KHACHHANG*/

            /*Set contraint cho khachhang*/

   

            /*Set contraint cho khachhang*/

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.HasCheckConstraint("TenKH", "(TenKH NOT LIKE '%[^A-Za-z ]%')");

                entity.HasCheckConstraint("CCCD", "(CCCD NOT LIKE '%[^0-9]%' AND LEN(CCCD) = 12)");

                entity.HasCheckConstraint("SDT", "(SDT NOT LIKE '%[^0-9]%' AND LEN(SDT) = 10)");

                entity.HasCheckConstraint("Diachi", "(Diachi NOT LIKE '%[^A-Za-z0-9, ]%')");

                entity.HasIndex(e => e.CCCD)
                   .IsUnique();

                entity.Property(e => e.Gioitinh)
               .HasColumnType("nvarchar(3)")
               .IsRequired()
               .HasDefaultValue("Nam");


            });

            /*Set Up cho KHACHHANG*/



            /*Set Up cho LoaiNV*/


            modelBuilder.Entity<LoaiNV>(entity =>
            {
                entity.HasCheckConstraint("TenLoai", "(TenLoai NOT LIKE '%[^A-Za-z0-9 ]%')");

            });

            /*Set Up cho LoaiNV*/



            /*SET UP CHO NHANVIEN*/

            modelBuilder.Entity<NhanVien>(entity =>
            {
                entity.Property(e => e.LoaiNV)
                     .IsRequired(false);

                entity.HasOne(loainv => loainv.FK_LoaiNV)
                     .WithMany(nv => nv.Nhanvien)
                     .HasForeignKey("LoaiNV")
                     .OnDelete(DeleteBehavior.SetNull);

                entity
                .HasIndex(p => p.SDT)
                .IsUnique();
            });


            /*SET UP CHO NHANVIEN*/


            /*SET UP CHO tinhtrangphong*/

            modelBuilder.Entity<TinhTrangPHG>(entity =>
            {
                entity.HasCheckConstraint("TenTinhTrg", "(TenTinhTrg LIKE '%[A-Za-z0-9 ]%')");
            });


            /*SET UP CHO tinhtrangphong*/


            /*SET UP CHO PHONG*/


            modelBuilder.Entity<Phong>(entity =>
            {
                entity
                .HasIndex(p => p.TenPHG)
                .IsUnique();

                entity
                .Property(p => p.TenPHG)
                .HasMaxLength(4)
                .IsRequired();

                entity
                .HasCheckConstraint("TenPHG", "TenPHG like 'A[0-9][0-9][0-9]'");

                entity.Property(e => e.LoaiPHG)
                     .IsRequired(false);

                entity.Property(e => e.TinhTrang)
                     .IsRequired(false);

                entity.HasOne(loaiphg => loaiphg.FK_LoaiPHG)
                     .WithMany(phg => phg.Phongs)
                     .HasForeignKey("LoaiPHG")
                     .OnDelete(DeleteBehavior.SetNull);


                entity.HasOne(tinhtrang => tinhtrang.FK_TinhtrangPHG)
                     .WithMany(phg => phg.Phongs)
                     .HasForeignKey("TinhTrang")
                     .OnDelete(DeleteBehavior.SetNull);
            });

            /*SET UP CHO PHONG*/



            /*SET UP CHO loaidichvu*/

            modelBuilder.Entity<LoaiDV>(entity =>
            {
                entity.HasCheckConstraint("TenLoaiDV", "(TenLoaiDV NOT LIKE '%[^A-Za-z0-9 ]%')");
            });


            /*SET UP CHO loaidichvu*/



            /*SET UP CHO Dichvu*/


            modelBuilder.Entity<DichVu>(entity =>
            {
                entity.HasIndex(e => e.TenDV)
                      .IsUnique();

                entity.Property(e => e.LoaiDV)
                      .IsRequired(false);

                entity.HasOne(loaidv => loaidv.FK_LoaiDV)
                      .WithMany(dichvu => dichvu.DichVus)
                      .HasForeignKey("LoaiDV")
                      .OnDelete(DeleteBehavior.SetNull);
            });


            /*SET UP CHO Dichvu*/





            /*Set cho phiếu đặt phòng*/


            modelBuilder.Entity<PhieuDatPhong>(entity =>
            {
                entity.HasOne(kh => kh.FK_MaKH)
                      .WithMany(pdt => pdt.List_phieuDatPhongs)
                      .HasForeignKey("MaKH")
                      .OnDelete(DeleteBehavior.SetNull);
            });

            /*Set cho phiếu đặt phòng*/



            /*Set constraint cho ChiTietPhieuDatPhong*/

            modelBuilder.Entity<ChiTietPhieuDatPhong>(entity =>
            {
                entity.HasKey(p => new { p.MaDatPHG, p.MaPHG });
            });

            modelBuilder.Entity<ChiTietPhieuDatPhong>(entity =>
            {
                entity.HasOne(ct => ct.Phong)
                .WithMany(phg => phg.List_chiTietPhieuDatPhongs)
                .HasForeignKey(ct => ct.MaPHG)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ChiTietPhieuDatPhong>(entity =>
            {
                entity.HasOne(ct => ct.PhieuDatPhong)
                               .WithMany(phg => phg.List_chiTietPhieuDatPhongs)
                               .HasForeignKey(ct => ct.MaDatPHG)
                               .OnDelete(DeleteBehavior.Cascade);
            });

            /*Set constraint cho ChiTietPhieuDatPhong*/




            /*Set contraint cho PhieuNhanPhong*/

            modelBuilder.Entity<PhieuNhanPhong>(entity =>
            {
                entity.HasKey(e => e.MaNhanPHG);
            });

  
            modelBuilder.Entity<PhieuNhanPhong>(entity =>
            {
                entity.HasOne(e => e.FK_Khachhang)
                .WithMany(KH => KH.List_phieuNhanPhongs)
                .HasForeignKey(e => e.MaKH).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<PhieuNhanPhong>(entity =>
            {
                entity.HasOne(e => e.FK_PhieuDatPHG)
                .WithMany(PHG => PHG.List_PhieuNhanPhong)
                .HasForeignKey(e => e.MaDatPHG).OnDelete(DeleteBehavior.Cascade);
            });


            /*Set contraint cho PhieuNhanPhong*/



            /*Set contraint cho ChiTietPhieuNhanPhong*/
            modelBuilder.Entity<ChiTietPhieuNhanPhong>(entity =>
            {
                entity.HasKey(p => new { p.MaDatPHG, p.MaNhanPHG,p.MaKH});
            });

            modelBuilder.Entity<ChiTietPhieuNhanPhong>(entity =>
            {
                entity.HasOne(ct => ct.FK_PhieuNhanPhong)
                .WithMany(phg => phg.List_ChiTietPhieuNhanPhong)
                .HasForeignKey(ct => ct.MaNhanPHG)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ChiTietPhieuNhanPhong>(entity =>
            {
                entity.HasOne(ct => ct.FK_KhachHang)
                .WithMany(phg => phg.List_ChiTietPhieuNhanPhong)
                .HasForeignKey(ct => ct.MaKH)
                .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<ChiTietPhieuNhanPhong>(entity =>
            {
                entity.HasOne(ct => ct.FK_PhieuDatPhong)
                .WithMany(phg => phg.List_ChiTietPhieuNhanPhong)
                .HasForeignKey(ct => ct.MaDatPHG)
                .OnDelete(DeleteBehavior.NoAction);
            });
            /*Set contraint cho ChiTietPhieuNhanPhong*/


            /*Set cho SuDungDichVu*/
            modelBuilder.Entity<SuDungDV>(entity =>
            {
                entity.HasOne(dv => dv.FK_DichVu)
                      .WithMany(sddv => sddv.SuDungDVs)
                      .HasForeignKey("MaDV")
                      .OnDelete(DeleteBehavior.SetNull);


                entity.HasOne(nhanphg => nhanphg.FK_NhanPhong)
                    .WithMany(sddv => sddv.List_SuDungDichVu)
                    .HasForeignKey("MaNhanPHG")
                    .OnDelete(DeleteBehavior.Cascade);

            });


            /*Set cho SuDungDichVu*/

            /*  Set Hoadon  */

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasOne(nv => nv.FK_NhanVien)
                      .WithMany(hd => hd.List_hoaDons)
                      .HasForeignKey("MaNV")
                      .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(kh => kh.FK_KhachHang)
                    .WithMany(hd => hd.List_hoaDons)
                    .HasForeignKey("MaKH")
                    .OnDelete(DeleteBehavior.SetNull);


                entity.HasOne(nhanphg => nhanphg.FK_PhieuNhanPhong)
                   .WithMany(hd => hd.List_hoaDons)
                   .HasForeignKey("MaNhanPHG")
                   .OnDelete(DeleteBehavior.Cascade);

            });

            /*  Set Hoadon  */



            /*Set contraint cho ChiTietHoaDon*/

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasKey(e => new { e.MaPHG, e.MaHD, e.MaSuDungDV });
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasOne(ct => ct.FK_HoaDon)
                .WithMany(phg => phg.List_chiTietHoaDons)
                .HasForeignKey(ct => ct.MaHD)
                .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.HasOne(ct => ct.FK_Phong)
                .WithMany(phg => phg.List_chiTietHoaDons)
                .HasForeignKey(ct => ct.MaPHG)
                .OnDelete(DeleteBehavior.NoAction);
            });



            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {

                entity.HasOne(ct => ct.FK_SuDungDichVu)
                .WithMany(phg => phg.List_chiTietHoaDons)
                .HasForeignKey(ct => ct.MaSuDungDV)
                .OnDelete(DeleteBehavior.NoAction);
            });

            /*Set contraint cho ChiTietHoaDon*/
        }


        public DbSet<ChucVu> Chucvus { get; set; }
        public DbSet<TaiKhoan> Taikhoans { get; set; }
        public DbSet<KhachHang> Khachangs { get; set; }
        public DbSet<LoaiNV> LoaiNVs { get; set; }
        public DbSet<NhanVien> Nhanviens { get; set; }
        public DbSet<TinhTrangPHG> TinhTrangPHGs { get; set; }
        public DbSet<LoaiPHG> LoaiPHGs { get; set; }
        public DbSet<Phong> Phongs { get; set; }
        public DbSet<LoaiDV> LoaiDVs { get; set; }
        public DbSet<DichVu> Dichvus { get; set; }
        public DbSet<PhieuDatPhong> Phieudatphongs { get; set; }
        public DbSet<ChiTietPhieuDatPhong> Chitietphieudatphongs { get; set; }
        public DbSet<PhieuNhanPhong> Phieunhanphongs { get; set; }
        public DbSet<ChiTietPhieuNhanPhong> Chitietphieunhanphongs { get; set; }
        public DbSet<SuDungDV> SudungDVs { get; set; }
        public DbSet<HoaDon> Hoadons { get; set; }
        public DbSet<ChiTietHoaDon> Chitiethoadons { get; set; }

    }
}
