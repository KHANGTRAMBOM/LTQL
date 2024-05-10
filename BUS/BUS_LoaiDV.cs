using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_LoaiDV
    {
        public static List<LoaiDV> Select_All()
        {
            return DAO.DAO_LoaiDV.Select_All();
        }
    }
}
