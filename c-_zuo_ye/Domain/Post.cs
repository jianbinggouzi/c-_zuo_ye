using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c__zuo_ye.Domain
{
    public class Post
    {
        private string uuid;
        private string useruuid;
        private string time;
        private string text;
        private int readnum;
        private int digestnum;
        private string lastid;
        
        public Post()
        {

        }

        public Post(String text,String useruuid,String lastid)
        {
            this.uuid = Guid.NewGuid().ToString().Replace("-", String.Empty);
            this.useruuid = useruuid;
            this.time = DateTime.Now.ToString("g");
            this.text = text;
            this.readnum = 0;
            this.digestnum = 0;
            this.lastid = lastid;
        }

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

        public int getReadnum()
        {
            return readnum;
        }

        public int getDigestnum()
        {
            return digestnum;
        }

        public string getLastid()
        {
            return lastid;
        }

        public void setUuid(string uuid)
        {
            this.uuid = uuid;
        }

        public void setUseruuid(string useruuid)
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

        public void setReadnum(int read)
        {
            this.readnum = read;
        }

        public void setDigestnum(int digest)
        {
            this.digestnum = digest;
        }

        public void setLastid(string lastid)
        {
            this.lastid = lastid;
        }

    }
}
