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

        private PostDao postDao = new PostDao();

        private UserDao userDao = new UserDao();

        //分页查询
        public List<Post> getPosts(int pageNo,int pageSize){
            int index = (pageNo-1)*pageSize;
            List<Post> list = null;
            if (pageNo == -1)
            {
                list = postDao.executeReader("select * from t_post where lastid='' order by time desc", new object[] { });
            }else
                list = postDao.executeReader("select * from t_post where lastid='' order by time desc limit {0},{1}",new object[]{index,pageSize});
            return list;
        }

        //获取评论
        public List<Post> getComment(String uuid)
        {
            List<Post> list = postDao.executeReader("select * from t_post where lastid='{0}' order by time desc", new object[] { uuid });
            return list;
        }

        //发帖子
        public bool addPost(Post post)
        {

            userDao.update(post.getUseruuid(), "send", (userDao.get(post.getUseruuid()).getSend() + 1).ToString());

            return postDao.add(post) > 0 ? true : false;


        }

        //删除帖子
        public bool deletePost(Post post)
        {
      
            userDao.update(post.getUseruuid(), "send", (userDao.get(post.getUseruuid()).getSend() - 1).ToString());
            return postDao.delete(post.getUuid()) > 0 ? true : false;
        }
        //赞同帖子
        public bool digestPost(Post post)
        {
           
            return postDao.update(post.getUuid(), "digestnum", (postDao.get(post.getUuid()).getDigestnum()+1).ToString())>0?true:false;
        }
    }
}
