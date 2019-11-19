using c__zuo_ye.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Dao
{
    class PostDao : BaseDao<Post>
    {
        public PostDao()
        {
            this.tablename = "t_post";
            Console.WriteLine("postDao init finish");
        }
    }
}
