using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Domain
{
    class Post
    {
        private string uuid;
        private string useruuid;
        private string time;
        private string text;
        private int read;
        private int digest;
        private string lastid;
        
        public string getUuid()
        {
            return uuid;
        }

        public string getUseruuid()
        {
            return useruuid;
        }

        public string getTime()
        {
            return time;
        }

        public string getText()
        {
            return text;
        }

        public int getRead()
        {
            return read;
        }

        public int getDigest()
        {
            return digest;
        }

        public string getLastid()
        {
            return lastid;
        }

        public void setUuid(string uuid)
        {
            this.uuid = uuid;
        }

        public void setUseuuid(string useruuid)
        {
            this.useruuid = useruuid;
        }

        public void setTime(String time)
        {
            this.time = time;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        public void setRead(int read)
        {
            this.read = read;
        }

        public void setDigest(int digest)
        {
            this.digest = digest;
        }

        public void setLastid(string lastid)
        {
            this.lastid = lastid;
        }

    }
}
