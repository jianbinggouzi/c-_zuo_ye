using c__zuo_ye.Dao;
using c__zuo_ye.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c__zuo_ye.Service
{
    class UserService
    {
        private ThreadLocal<UserDao> userDao = new ThreadLocal<UserDao>();

        //return: User实例 null则登录失败 
        public User login(string uuid,string password)
        {
            UserDao u = userDao.Value;
            string sql = "select * from t_user where uuid = '{0}' and password = '{1}'";
            object[] args = new object[] { uuid, password };
            List<User> list =u.executeReader(sql,args);
            return list[0];
        }
        //return: 成功/失败
        public bool changeInfo(string uuid,string key,string value)
        {
            UserDao u = userDao.Value;
            if (key.Equals("uuid"))
                return false;
            string sql = "update t_user set '{0}' = '{1}' where uuid = '{2}'";
            object[] args = new object[] { key, value, uuid };
            return u.executeNonQuery(sql, args) > 0 ? true : false;
        }


    }
}
