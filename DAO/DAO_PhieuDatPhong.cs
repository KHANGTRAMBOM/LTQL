using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_PhieuDatPhong
    {
        static Provider provider = new Provider();
        public static List<PhieuDatPhong> Select_All()
        {
            var data = from p in provider.dbcontext.Phieudatphongs
                       select p;

            return data.ToList();
        }

        /* Thêm */
        public static bool Insert(int MaKH)
        {
            PhieuDatPhong phieudatphong = new PhieuDatPhong() { MaKH = MaKH };
            provider.dbcontext.Phieudatphongs.Add(phieudatphong);
            return provider.dbcontext.SaveChanges() != 0;
        }


        /* Lấy mã đặt phòng gần đây nhất theo mã kh */
        public static PhieuDatPhong Select_By_MaKH_Last(int MaKH)
        { 
            return (from p in provider.dbcontext.Phieudatphongs
                   where p.MaKH == MaKH
                   orderby p.MaDatPHG descending
                   select p).FirstOrDefault();    
        }

        /* Lấy mã đặt phòng gần đây nhất theo mã đặt phòng */
        public static PhieuDatPhong Select_By_MaDatPHG(int MaDatPHG)
        {
            return (from p in provider.dbcontext.Phieudatphongs
                    where p.MaDatPHG == MaDatPHG
                    select p).FirstOrDefault();
        }


        public static bool Delete(int MaDatPHG)
        {
            var data = (from p in provider.dbcontext.Phieudatphongs
                       where p.MaDatPHG == MaDatPHG
                       select p).FirstOrDefault();

            provider.dbcontext.Phieudatphongs.Remove(data);

            return provider.dbcontext.SaveChanges() != 0;
        }

    }
}
