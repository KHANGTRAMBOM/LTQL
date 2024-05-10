using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_LoaiNV
    {
        public static List<LoaiNV> Select_All()
        {
            return DAO.DAO_LoaiNV.Select_All();
        }
    }
}
