using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class BUS_SuDungDichVu
    {
        public static List<SuDungDV> Select_All()
        {
            return DAO_SuDungDichVu.Select_All();
        }

        public static List<SuDungDV> Select_By_MaSDDV(int MaSDDV)
        {
            return DAO_SuDungDichVu.Select_By_MaSDDV(MaSDDV);
        }

        public static object Select_Display(int MaSDDV)
        {
            return DAO_SuDungDichVu.Select_Display(MaSDDV);
        }

        public static object Select_Display_MaNhanPHG(int MaNhanPHG)
        {
            return DAO_SuDungDichVu.Select_Display_MaNhanPHG(MaNhanPHG);
        }
        public static SuDungDV Select_By_MaDV_MaNhanPHG(int MaDV, int MaNhanPHG)
        {
           return DAO_SuDungDichVu.Select_By_MaDV_MaNhanPHG(MaDV, MaNhanPHG);
        }


        public static List<SuDungDV> Select_By_MaNhanPHG(int maNhanPHG)
        {
            return DAO_SuDungDichVu.Select_By_MaNhanPHG(maNhanPHG);
        }


        public static bool Insert(int Madv, int Manhanphg, int soluong)
        {
            return DAO_SuDungDichVu.Insert(Madv, Manhanphg, soluong);
        }



        public static bool Update_SoLuong(int Masddv,int MaNhanPHG,int soluong)
        {
            return DAO_SuDungDichVu.Update_SoLuong(Masddv,MaNhanPHG,soluong);
        }


        public static float GetTongTien_By_MaNhanPHG(int MaNhanPHG)
        {
            return DAO_SuDungDichVu.GetTongTien_By_MaNhanPHG(MaNhanPHG);
        }

        public static float GetTongTien_By_MaSDDV(int MaSDDV)
        {
            return DAO_SuDungDichVu.GetTongTien_By_MaSDDV(MaSDDV);
        }

        public static float GetTongTien_By_MaNhanPHG_SauPhuThu(int MaNhanPHG)
        {
            return DAO_SuDungDichVu.GetTongTien_By_MaNhanPHG_SauPhuThu(MaNhanPHG);
        }

        public static SuDungDV Select_By_MaNhanPHG_Last_Element(int MaNhanPHG)
        {
            return DAO_SuDungDichVu.Select_By_MaNhanPHG_Last_Element(MaNhanPHG);
        }
        public static bool Delete(int MaSDDV)
        {
            return DAO_SuDungDichVu.Delete(MaSDDV);
        }

    }
}
