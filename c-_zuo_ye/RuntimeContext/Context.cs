using c__zuo_ye.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c__zuo_ye.RuntimeContext
{
    class Context
    {
        public static UserService userService = new UserService();

        public static PostService postService = new PostService();



        public Context()
        {
            //Task<object> task = new Task<object>();
            
        }
    }
}
