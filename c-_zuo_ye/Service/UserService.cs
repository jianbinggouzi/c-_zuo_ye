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
    class UserService : BaseService<UserDao>
    {
        private ThreadLocal<UserDao> _userDao = new ThreadLocal<UserDao>();

        private string tablename = "t_user";

        //注册
        public bool signup(User user)
        {
            UserDao userDao = _userDao.Value;
            return userDao.add(tablename,user) > 0 ? true : false;
        }

        //return: User实例 null则登录失败 
        public User login(string uuid,string password)
        {
            UserDao userDao = _userDao.Value;
            string sql = "select * from t_user where uuid = '{0}' and password = '{1}'";
            object[] args = new object[] { uuid, password };
            List<User> list =userDao.executeReader(sql,args);
            return list[0];
        }
        //return: 成功/失败
        public bool changeInfo(string uuid,string key,string value)
        {
            UserDao userDao = _userDao.Value;
            
            return userDao.updateField(uuid,key,value) > 0 ? true : false;
        }


    }
}
