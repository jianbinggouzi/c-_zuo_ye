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
        private UserDao userDao = new UserDao();

        //修改用户名
        public int changeUserName(String uuid, String name)
        {
            return userDao.update(uuid, "name", name);

        }
        //修改密码
        public int changUserPassword(String uuid, String password)
        {
            return userDao.update(uuid, "password", password);
        }

        //注册
        public bool signup(string account,String password)
        {
            User user = new User(account, password);
            UserDao userDao = new UserDao();
            return userDao.add(user) > 0 ? true : false;
        }

        //return: User实例 null则登录失败 
        public User login(string username,string password)
        {
           
            List<User> list = userDao.executeReader("select * from t_user where name='{0}' and password='{1}'",new object[]{ username,password});
            User user = list[0];
            return user.getPassword().Equals(password) ? user : null;
        }
        //return: 成功/失败 修改资料
        public bool changeInfo(string uuid,string key,string value)
        {
            
            return userDao.update(uuid,key,value) > 0 ? true : false;
        }
        //根据uuid获取用户名
        public String getUserNameByUuid(string uuid)
        {
            Object result = userDao.executeScalar("select name from t_user where uuid='{0}'", new object[] { uuid });
            return (String)result;
        }

    }
}
