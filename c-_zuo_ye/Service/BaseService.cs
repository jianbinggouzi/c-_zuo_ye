using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace c__zuo_ye.Service
{
    class BaseService<T>
    {
        protected ThreadLocal<T> dao = new ThreadLocal<T>();
        
    }
}
