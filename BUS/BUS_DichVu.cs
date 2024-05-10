using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_DichVu
    {
        public static List<DichVu> Select_All()
        {
           return DAO.DAO_dichvu.Select_All();
        }

        /* XÓA */

        public static bool Delete(int MaDV)
        {
            return DAO.DAO_dichvu.Delete(MaDV);
        }


        /* THÊM */
        public static bool Insert(string TenDV, int LoaiDV, float Dongia)
        {
            return DAO.DAO_dichvu.Insert(TenDV,LoaiDV,Dongia);
        }


        /* SỬA */
        public static bool Update(int MaDV, string TenDV, int LoaiDV, float Dongia)
        {
            return DAO.DAO_dichvu.Update(MaDV,TenDV,LoaiDV,Dongia);
        }

        public static DichVu GetDichVu_By_MaDV(int MaDV)
        {
           return DAO_dichvu.GetDichVu_By_MaDV(MaDV);
        }
    }
}
