using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Domain
{
    class User
    {
        private string name;
        private string uuid;
        private string password;
        private int send;
        
        public User()
        {

        }

       public User(string name,string password)
        {
            this.name = name;
            this.password = password;
            this.send = 0;
            this.uuid = Guid.NewGuid().ToString().Replace("-", String.Empty);
        }

        public string getName()
        {
            return name;
        }

        public string getUuid()
        {
            return uuid;
        }

        public string getPassword()
        {
            return password;
        }

        public int getSend()
        {
            return send;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setUuid(string uuid)
        {
            this.uuid = uuid;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public void setSend(int send)
        {
            this.send = send;
        }
    }
}
