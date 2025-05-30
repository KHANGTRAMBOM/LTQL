using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_TinhTrangPHG
    {
        static Provider provider = new Provider(); 
        public static List<TinhTrangPHG> Select_All()
        {
            return (from p in  provider.dbcontext.TinhTrangPHGs
                   select p).ToList();
        }

        public static TinhTrangPHG Select_By_MaTinhTrang(int MaTinhTrang)
        {
            return (from p in provider.dbcontext.TinhTrangPHGs
                    where p.MaTinhTrg == MaTinhTrang
                    select p).FirstOrDefault();
        }
    }
}
