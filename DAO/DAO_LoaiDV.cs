using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_LoaiDV
    {
        static Provider provider = new Provider();
        public static List<LoaiDV> Select_All()
        {
            var source = from p in provider.dbcontext.LoaiDVs
                         select p;

            return source.ToList();
        }
    }
}
