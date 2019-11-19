using c__zuo_ye.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Dao
{
    class UserDao : BaseDao<User>
    {
        public UserDao()
        {
            this.tablename = "t_user";
            Console.WriteLine("userDao init finish");
        }

    }
}
