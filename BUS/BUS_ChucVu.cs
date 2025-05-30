using DTO;
using DAO;
using System.Threading.Tasks.Dataflow;

namespace BUS
{
    public static class ChucVu
    {
        public static List<DTO.ChucVu> Select_All()
        {
            return DAO.DAO_ChucVu.Select_All();
        }

        public static List<DTO.ChucVu> Select_By_ID(int MaCV)
        {
            return DAO.DAO_ChucVu.Select_By_ID(MaCV);
        }

        public static List<DTO.ChucVu> Select_By_Name(string TenCV)
        {
            return DAO.DAO_ChucVu.Select_By_Name(TenCV);
        }

        public static bool Insert(string TenCV)
        {
            return DAO.DAO_ChucVu.Insert(TenCV);
        }
    }
}