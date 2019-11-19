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

            userDao.update(post.getUseruuid(), "send", (userDao.get(post.getUseruuid()).getSend() + 1).ToString());

            return postDao.add(post) > 0 ? true : false;


        }
        //删除帖子
        public bool deletePost(Post post)
        {
            UserDao userDao = _userDao.Value;
            PostDao postDao = _postDao.Value;
            userDao.update(post.getUseruuid(), "send", (userDao.get(post.getUseruuid()).getSend() - 1).ToString());
            return postDao.delete(post.getUuid()) > 0 ? true : false;
        }
        //赞同帖子
        public bool digestPost(Post post)
        {
            PostDao postDao = _postDao.Value;
            return postDao.update(post.getUuid(), "digest", (postDao.get(post.getUuid()).getDigest()+1).ToString())>0?true:false;
        }
    }
}
