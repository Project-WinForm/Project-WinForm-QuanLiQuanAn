using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projectWindowform.DAL;

namespace projectWindowform.BLL
{
    public class StaffBLL
    {
        private StaffDAL dal = new StaffDAL();
        public bool Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            return dal.CheckLogin(username, password);
        }
    }
}
