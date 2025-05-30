using DTO;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class DAO_ChucVu
    {
        private static Provider provider = new Provider();
        public static List<DTO.ChucVu> Select_All()
        {
            return (from p in provider.dbcontext.Chucvus
                    select p).ToList();

        }
        public static List<DTO.ChucVu> Select_By_ID(int MaCV)
        {
            return (from p in provider.dbcontext.Chucvus
                    where p.MaCV == MaCV
                    select p).ToList();
        }

        public static List<DTO.ChucVu> Select_By_Name(string TenCV)
        {
            return (from p in provider.dbcontext.Chucvus
                    where p.TenCV.Contains(TenCV)
                    select p).ToList();
        }

        public static bool Insert(string TenCV)
        {
            DTO.ChucVu chucVu = new DTO.ChucVu() {TenCV = TenCV};
            provider.dbcontext.Chucvus.Add(chucVu);
            return provider.dbcontext.SaveChanges() != 0;
        }

    }
}
