using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_LoaiNV
    {
        private static Provider provider = new Provider();
        public static List<LoaiNV> Select_All()
        {
            var result = from p in provider.dbcontext.LoaiNVs
                         select p;

            return result.ToList();
        }
    }
}
