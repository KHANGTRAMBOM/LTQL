using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_LoaiPHG
    {
        public static List<LoaiPHG> Select_All()
        {
            return DAO.DAO_LoaiPHG.Select_All();
        }

        public static LoaiPHG Select_By_MaLoai(string MaLoai)
        {
            return DAO_LoaiPHG.Select_By_MaLoai(MaLoai);
        }
    }
}
