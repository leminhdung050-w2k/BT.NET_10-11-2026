using System.Collections.Generic;
using BT6._3.DAL;
using BT6._3.DTO;

namespace BT6._3.BUS
{
    public class ThanhVienBUS
    {
        private readonly ThanhVienDAL dal = new ThanhVienDAL();

        public List<ThanhVienDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }
    }
}