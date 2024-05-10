using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_LoaiPHG
    {

        private static Provider provider = new Provider();
        public static List<LoaiPHG> Select_All()
        {
            var result = from p in provider.dbcontext.LoaiPHGs
                         select p;

            return result.ToList();
        }
        /* Select LoaiPHG theo mã loại phòng */
        public static LoaiPHG Select_By_MaLoai(string MaLoai)
        {
            var result = (from p in provider.dbcontext.LoaiPHGs
                         where p.MaloaiPHG == MaLoai
                         select p).FirstOrDefault();

            return result;
        }
    }
}
