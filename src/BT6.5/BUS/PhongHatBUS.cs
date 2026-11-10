using System.Collections.Generic;
using BT6._5.DAL;
using BT6._5.DTO;

namespace BT6._5.BUS
{
    public class PhongHatBUS
    {
        private readonly PhongHatDAL dal = new PhongHatDAL();

        public List<PhongHatDTO> LayDanhSach()
        {
            return dal.LayDanhSach();
        }
    }
}