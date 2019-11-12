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
    class PostService 
    {

        private ThreadLocal<PostDao> _postDao = new ThreadLocal<PostDao>();

        private ThreadLocal<UserDao> _userDao = new ThreadLocal<UserDao>();

        //发帖子
        public bool addPost(Post post)
        {
            UserDao userDao = _userDao.Value;
            PostDao postDao = _postDao.Value;

            userDao.updateField(post.getUseruuid(), "send", (userDao.get(post.getUseruuid()).getSend()+1).ToString());

            return postDao.add("t_post", post)>0?true:false;


        }
    }
}
