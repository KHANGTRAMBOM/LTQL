using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_TinhTrangPHG
    {

        public static List<TinhTrangPHG> Select_All()
        {
            return DAO_TinhTrangPHG.Select_All();
        }

        public static TinhTrangPHG Select_By_MaTinhTrang(int MaTinhTrang)
        {
            return DAO_TinhTrangPHG.Select_By_MaTinhTrang(MaTinhTrang);

        }
    }
}
