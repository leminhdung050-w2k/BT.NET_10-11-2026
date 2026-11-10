using System.Collections.Generic;
using BT6._3.DAL;
using BT6._3.DTO;

namespace BT6._3.BUS
{
    public class BaoCaoBUS
    {
        private readonly BaoCaoDAL dal = new BaoCaoDAL();

        public List<CongViecDTO> TaskTreHan(int maDuAn)
        {
            return dal.TaskTreHan(maDuAn);
        }

        public int DemTreHan()
        {
            return dal.DemTreHan();
        }

        public double TyLeHoanThanhDuAn(int maDuAn)
        {
            return dal.TyLeHoanThanhDuAn(maDuAn);
        }

        public List<ThongKeDTO> ThongKeThanhVien(int maDuAn)
        {
            return dal.ThongKeThanhVien(maDuAn);
        }
    }
}