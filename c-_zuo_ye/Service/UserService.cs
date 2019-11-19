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
        private ThreadLocal<UserDao> _userDao = new ThreadLocal<UserDao>();


        //注册
        public bool signup(User user)
        {
            UserDao userDao = _userDao.Value;
            return userDao.add(user) > 0 ? true : false;
        }

        //return: User实例 null则登录失败 
        public User login(string uuid,string password)
        {
            UserDao userDao = _userDao.Value;
            User user = userDao.get(uuid);
            return user.getPassword().Equals(password) ? user : null;
        }
        //return: 成功/失败 修改资料
        public bool changeInfo(string uuid,string key,string value)
        {
            UserDao userDao = _userDao.Value;
            
            return userDao.update(uuid,key,value) > 0 ? true : false;
        }


    }
}
